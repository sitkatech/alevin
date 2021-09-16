using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using LtInfo.Common;
using NUnit.Framework;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    [TestFixture]
    public class DatabaseMigratorTest
    {
        private const string _databaseServer = "(local)";
        private const string _database = "tempdb";
        readonly DirectoryInfo _directory = FileUtility.FirstMatchingDirectoryUpDirectoryTree(@"DatabaseMigration\Test\DatabaseMigrationFiles");
        private DatabaseMigrator _testSubject;
        private List<string> _messageLog;

        [SetUp]
        public void TheSetup()
        {
            _messageLog = new List<string>();
            _testSubject = new DatabaseMigrator(_directory, _databaseServer, _database, (message) => _messageLog.Add(message));

            RemoveAnyTablesInTestDb();
            using (var sqlServer = new SqlServer(_databaseServer, _database))
            {
                sqlServer.ExecuteNonQuery(DatabaseMigrator.SqlToCreateMigrationsTable);
            }
        }

        [TearDown]
        public void TheTearDown()
        {
            _testSubject.Dispose();
            RemoveAnyTablesInTestDb();
        }

        private static void RemoveAnyTablesInTestDb()
        {
            using (var sqlServer = new SqlServer(_databaseServer, _database))
            {
                var tablesToClean = sqlServer.ExecuteDataTable(
                    "select TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME  from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'BASE TABLE' and TABLE_NAME not like '#%'");

                foreach (DataRow cleanupRow in tablesToClean.Rows)
                {
                    var cleanupSql = string.Format("DROP TABLE {0}.{1}.{2}", (string)cleanupRow["TABLE_CATALOG"],
                                                   (string)cleanupRow["TABLE_SCHEMA"], (string)cleanupRow["TABLE_NAME"]);
                    sqlServer.ExecuteNonQuery(cleanupSql);
                }
            }
        }

        [Test]
        public void CanFindMigrationFiles()
        {
            var files = _testSubject.FindMigrationFiles();
            var expected = new List<int> { 8, 9, 10, 11 };
            Assert.That(files.Count, Is.EqualTo(expected.Count), "Should have found the files");
            Assert.That(files.Select(x => x.DatabaseMigrationNumber).ToList(), Is.EqualTo(expected), "Should have gotten right version numbers");
            Assert.That(files.Select(x => x.DatabaseMigrationNumber).ToList(), Is.Ordered, "Migrations should be in order");
        }

        [Test]
        public void CanFindOtherSqlFiles()
        {
            // Act
            // ---
            var otherFiles = _testSubject.FindOtherSqlFiles();

            // Assert
            // ------
            var expected = new List<string> { "_otherA.sql", "_otherB.sql" };
            var actualFileNamesFound = otherFiles.Select(x => x.SqlFile.Name).ToList();
            Assert.That(actualFileNamesFound, Is.EqualTo(expected), "Should find all the SQL files");
            Assert.That(actualFileNamesFound, Is.Ordered, "Should find all the SQL files in order");
        }
        
        [Test]
        public void CanFindAppliedMigrations()
        {
            // Arrange
            // ------=

            var expectedAppliedVersions = new List<int> {1, 2, 3, 4};
            MarkDatabaseAsApplied(expectedAppliedVersions);

            // Act
            // ---

            var appliedVersions = _testSubject.LookupAppliedMigrationNumbers();

            // Assert
            // ------

            Assert.That(appliedVersions, Is.EqualTo(expectedAppliedVersions), "Should be able to find the versions");
        }

        private void MarkDatabaseAsApplied(IEnumerable<int> expectedAppliedVersions)
        {
            foreach (var i in expectedAppliedVersions)
            {
                _testSubject.MarkDatabaseMigrationAsApplied(i);
            }
        }

        [Test]
        public void CanMigrate()
        {
            // Arrange
            // -------
            Assert.That(GetTablesInTestDb(), Is.EquivalentTo(new List<string> {DatabaseMigrator.MigrationTableName}), "Test precondition: shouldn't have any tables to start");
            MarkDatabaseAsApplied(new[]{1,2,3,4,5,6,7,8});

            // Act
            // ---
            string allMessages;
            try
            {
                _testSubject.PerformMigration();
            }
            finally
            {
                Trace.WriteLine("** First Pass **");
                allMessages = String.Join("\r\n", _messageLog);
                Trace.WriteLine(allMessages);
            }

            // Assert
            // ------
            var tablesPresent = GetTablesInTestDb();
            var expected = new List<string>{ "tblUnitTest_OtherA", "tblUnitTest_OtherB", "tblUnitTest9", "tblUnitTest10", "tblUnitTest11", DatabaseMigrator.MigrationTableName };
            Assert.That(tablesPresent, Is.EquivalentTo(expected), "Should have created these tables");
            Assert.That(allMessages, Is.StringContaining("Applying migration #9"), "Should have logged about applying Migration #9");
            Assert.That(allMessages, Is.StringContaining("Applying migration #10"), "Should have logged about applying Migration #10");
            Assert.That(allMessages, Is.StringContaining("Applying migration #11"), "Should have logged about applying Migration #11");

            // Act
            // ---
            _messageLog.Clear();
            Assert.DoesNotThrow(() => _testSubject.PerformMigration(), "Should be able to re-run the migrator because it will *skip* files that have already been run");
            
            allMessages = String.Join("\r\n", _messageLog);
            Trace.WriteLine("** Second Pass **");
            Trace.WriteLine(allMessages);

            Assert.That(tablesPresent, Is.EquivalentTo(expected), "Tables should still be there 2nd time around");

            Assert.That(allMessages, Is.Not.StringContaining("Applying migration #9"), "Shouldn't have logged about applying Migration #9 because it was skipped");
            Assert.That(allMessages, Is.Not.StringContaining("Applying migration #10"), "Shouldn't have logged about applying Migration #10 because it was skipped");
            Assert.That(allMessages, Is.Not.StringContaining("Applying migration #11"), "Shouldn't have logged about applying Migration #11 because it was skipped");
        }

        [Test]
        public void CanDetectMissingScript()
        {
            // Arrange
            // -------
            Assert.That(GetTablesInTestDb(), Is.EquivalentTo(new List<string> { DatabaseMigrator.MigrationTableName }), "Test precondition: shouldn't have any tables to start");
            MarkDatabaseAsApplied(new[] { 1, 2, 3, 4, 5, 6 });

            // Act
            // ---
            var exception = Assert.Catch(() => _testSubject.PerformMigration(), "Should fail since DB has 1-6 applied and next script is 8 not 7");
            Assert.That(exception.Message, Is.StringContaining("7"), "Should mention that 7 is the next expected migration");
            Assert.That(exception.Message, Is.StringContaining("8"), "Should mention how the *next* one to apply is 8 ");
        }


        private static List<string> GetTablesInTestDb()
        {
            List<string> tablesPresent;
            using (var sqlServer = new SqlServer(_databaseServer, _database))
            {
                var tablesInTestDb = sqlServer.ExecuteDataTable("select TABLE_NAME  from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'BASE TABLE' and TABLE_NAME not like '#%'");
                tablesPresent = tablesInTestDb.Rows.Cast<DataRow>().Select(dataRow => (string) dataRow["TABLE_NAME"]).ToList();
            }
            return tablesPresent;
        }
    }
}