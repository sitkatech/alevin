using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    public class DatabaseMigrator : IDisposable
    {
        private const string MigrationTableSchema = "dbo";
        public const string MigrationTableName = "DatabaseMigration";
        private const string MigrationNumberColumn = "DatabaseMigrationNumber";
        public static readonly string SqlToCreateMigrationsTable = string.Format(@"
create table {0}.{1}
(
    {2} int not null,
    constraint PK_{1} primary key ({2})
)", MigrationTableSchema, MigrationTableName, MigrationNumberColumn);

        private readonly Action<string> _logFunction;
        private readonly string _migrationDatabaseName;
        private readonly string _migrationDatabaseServer;
        private readonly DirectoryInfo _migrationDirectory;

        public DatabaseMigrator(DirectoryInfo migrationDirectory, 
                                string migrationDatabaseServer,
                                string migrationDatabaseName, 
                                Action<string> logFunction)
        {
            _migrationDirectory = migrationDirectory;
            _migrationDatabaseServer = migrationDatabaseServer;
            _migrationDatabaseName = migrationDatabaseName;
            _logFunction = logFunction;
        }

        #region IDisposable Members

        public void Dispose() {}

        #endregion

        private void Log(string message)
        {
            if (_logFunction != null)
            {
                _logFunction(message);
            }
        }

        public void PerformMigration()
        {
            Log(String.Format("{0} code executing on machine {1} at {2}", GetType().Name, Environment.MachineName, DateTime.Now));
            Log(String.Format("Code in file {0}", Assembly.GetAssembly(GetType()).Location));
            Log(string.Format("Targeting database {0}.{1}", _migrationDatabaseServer, _migrationDatabaseName));

            if (!DoesMigrationsTableExists())
            {
                Log(string.Format("Migration table {0}.{1} not present, adding it...", MigrationTableSchema, MigrationTableName));
                AddMigrationTable();
            }

            Log(string.Format("Reading change scripts from directory {0}", _migrationDirectory.FullName));

            var sqlFiles = FindOtherSqlFiles();
            Log(string.Format("Extra SQL Files which will always be applied:\r\n   {0}", String.Join(", ", sqlFiles.Select(x => x.SqlFile.Name))));

            List<int> appliedMigrations = LookupAppliedMigrationNumbers();
            Log(string.Format("Changes currently applied to database:\r\n   {0}", IntRange.ToDisplayString(appliedMigrations)));
            ErrorHelper.AssertPreCondition(IsSequenceContiguous(appliedMigrations), string.Format("Expect Applied migrations contiguous but are not, could be a problem. Aborting.\r\n   {0}", String.Join(",", appliedMigrations.Select(x => x.ToString()))));
            ErrorHelper.AssertPreCondition(DoesSequenceStartAt(appliedMigrations, 1), string.Format("Expected applied migrations starting at 1 but was not.\r\n   {0}", String.Join(",", appliedMigrations.Select(x => x.ToString()))));

            var migrationFiles = FindMigrationFiles();
            Log(string.Format("Scripts available:\r\n   {0}", IntRange.ToDisplayString(migrationFiles.Select(x => x.DatabaseMigrationNumber))));

            ApplyExtraFiles(sqlFiles);

            if (migrationFiles.Any())
            {
                new DatabaseMigrationFileInfoSet(migrationFiles); // Does the duplicate filename checks

                var toBeApplied = FilterByApplied(migrationFiles, appliedMigrations);
                Log(string.Format("To be applied:\r\n   {0}", IntRange.ToDisplayString(toBeApplied.Select(x => x.DatabaseMigrationNumber))));

                if (toBeApplied.Any())
                {
                    var expectedNextMigrationNumber = (appliedMigrations.Any() ? appliedMigrations.Max() : 0 ) + 1;
                    var nextMigrationToBeApplied = toBeApplied.First().DatabaseMigrationNumber;
                    ErrorHelper.AssertPreCondition(expectedNextMigrationNumber == nextMigrationToBeApplied, string.Format("Expected migrations starting at {0} but next migration starts at {1}", expectedNextMigrationNumber, nextMigrationToBeApplied));

                    ErrorHelper.AssertPreCondition(IsSequenceContiguous(migrationFiles.Select(x => x.DatabaseMigrationNumber)),
                                                   string.Format("Available scripts are not contiguous could be a problem. Aborting.\r\n   Applied: {0}\r\n   Scripts: {1}",
                                                                 IntRange.ToDisplayString(appliedMigrations),
                                                                 IntRange.ToDisplayString(migrationFiles.Select(x => x.DatabaseMigrationNumber))));
                    ApplyMigrationFiles(toBeApplied);
                }
            }
            Log(string.Format("Migrations successfully completed at {0}", DateTime.Now));
        }

        private void AddMigrationTable()
        {
            ErrorHelper.AssertPreCondition(!DoesMigrationsTableExists());
            using (var sqlServer = new SqlServer(_migrationDatabaseServer, _migrationDatabaseName))
            {
                sqlServer.ExecuteNonQuery(SqlToCreateMigrationsTable);
            }
        }

        private void ApplyMigrationFiles(IEnumerable<DatabaseMigrationFileInfo> migrationFiles)
        {
            using (var sqlServer = new SqlServer(_migrationDatabaseServer, _migrationDatabaseName))
            {
                var sqlRunner = new SqlExecuteSafe();
                foreach (var migrationFile in migrationFiles)
                {
                    Log(string.Format("Applying migration #{0}: {1}...", migrationFile.DatabaseMigrationNumber, migrationFile.DatabaseMigrationFile.Name));
                    sqlRunner.ExecuteNonQuery(sqlServer, migrationFile.FileContents);
                    MarkDatabaseMigrationAsApplied(migrationFile.DatabaseMigrationNumber);
                }
            }
        }

        public void MarkDatabaseMigrationAsApplied(int databaseMigrationNumber)
        {
            using (var sqlServer = new SqlServer(_migrationDatabaseServer, _migrationDatabaseName))
            {
                var sql = string.Format("INSERT INTO {0}.{1}({2}) VALUES({3})", MigrationTableSchema, MigrationTableName, MigrationNumberColumn, databaseMigrationNumber);
                sqlServer.ExecuteNonQuery(sql);
            }
        }

        private void ApplyExtraFiles(IEnumerable<SqlFileInfo> sqlFiles)
        {
            using (var sqlServer = new SqlServer(_migrationDatabaseServer, _migrationDatabaseName))
            {
                var sqlRunner = new SqlExecuteSafe();
                var i = 0;
                foreach (var sqlFileInfo in sqlFiles)
                {
                    ++i;
                    Log(string.Format("Applying extra SQL file #{0}: {1}...", i, sqlFileInfo.SqlFile.Name));
                    sqlRunner.ExecuteNonQuery(sqlServer, sqlFileInfo.FileContents);
                }
            }
        }

        internal static List<DatabaseMigrationFileInfo> FilterByApplied(List<DatabaseMigrationFileInfo> migrations, List<int> appliedMigrations)
        {
            if (!appliedMigrations.Any())
            {
                return migrations;
            }
            var maxApplied = appliedMigrations.Max();
            var toBeApplied = migrations.Where(x => x.DatabaseMigrationNumber > maxApplied);
            var toBeAppliedAsOrderedList = toBeApplied.OrderBy(x => x.DatabaseMigrationNumber).ToList();
            return toBeAppliedAsOrderedList;
        }

        /// <summary>
        /// Returns the migrations in order, skipping files that are not part of the migrations sequence
        /// </summary>
        internal List<DatabaseMigrationFileInfo> FindMigrationFiles()
        {
            var allFilesInDirectory = _migrationDirectory.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).Where(DatabaseMigrationFileInfo.IsFileMatch).ToList();
            return allFilesInDirectory.Select(x => new DatabaseMigrationFileInfo(x)).OrderBy(x => x.DatabaseMigrationNumber).ToList();
        }

        /// <summary>
        /// Returns other SQL files in alphabetically order
        /// </summary>
        internal List<SqlFileInfo> FindOtherSqlFiles()
        {
            var allFilesInDirectory = _migrationDirectory.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).Where(x => SqlFileInfo.IsFileMatch(x) && !DatabaseMigrationFileInfo.IsFileMatch(x)).ToList();
            return allFilesInDirectory.Select(x => new SqlFileInfo(x)).OrderBy(x => x.SqlFile.Name).ToList();
        }

        internal bool DoesSequenceStartAt(IEnumerable<int> sequence, int startingAt)
        {
            if (!sequence.Any())
            {
                return true;
            }
            return sequence.Min() == startingAt;
        }

        internal bool IsSequenceContiguous(IEnumerable<int> sequence)
        {
            if (!sequence.Any())
            {
                return true;
            }
            var ranges = IntRange.MakeIntRanges(sequence);
            return (ranges.Count == 1);
        }

        internal List<int> LookupAppliedMigrationNumbers()
        {
            DemandMigrationTableExists();
            DataTable dt;
            using (var sqlServer = new SqlServer(_migrationDatabaseServer, _migrationDatabaseName))
            {
                dt = sqlServer.ExecuteDataTable(string.Format("SELECT {2} FROM {0}.{1} ORDER BY {2}", MigrationTableSchema, MigrationTableName, MigrationNumberColumn));
            }
            var migrationsApplied = dt.Rows.Cast<DataRow>().Select(row => (int) row[MigrationNumberColumn]).ToList();

            ErrorHelper.AssertPreCondition(migrationsApplied.Distinct().Count() == migrationsApplied.Count(), string.Format("Somehow the applied migrations table {0} has duplicate rows, cannot proceed!", MigrationTableName));
            return migrationsApplied;
        }

        private bool DoesMigrationsTableExists()
        {
            DataTable dt;
            using (var sqlServer = new SqlServer(_migrationDatabaseServer, _migrationDatabaseName))
            {
                dt = sqlServer.ExecuteDataTable(string.Format("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{0}' AND TABLE_NAME='{1}'", MigrationTableSchema, MigrationTableName));
            }
            return (dt.Rows.Count == 1);
        }

        private void DemandMigrationTableExists()
        {
            ErrorHelper.AssertPreCondition(DoesMigrationsTableExists(), string.Format("Is the {0}.{1} table missing from the database? Should already be in place.To use migrations, the database {2}.{3} would need a table like this:\r\n{4}\r\n", MigrationTableSchema, MigrationTableName, _migrationDatabaseServer, _migrationDatabaseName, SqlToCreateMigrationsTable));
        }
    }
}