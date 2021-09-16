using System;
using System.Collections.Generic;
using System.Linq;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    /// <summary>
    /// Represents a set of migrations that can be applied
    /// </summary>
    public class DatabaseMigrationFileInfoSet
    {
        private readonly Dictionary<int, DatabaseMigrationFileInfo> _fileSet = new Dictionary<int, DatabaseMigrationFileInfo>();
        public DatabaseMigrationFileInfoSet(IEnumerable<DatabaseMigrationFileInfo> databaseMigrationFiles)
        {
            var duplicateGroups = databaseMigrationFiles.AsParallel().GroupBy(migration => migration.DatabaseMigrationNumber).Where(group => group.Count() > 1);

            if (duplicateGroups.Any())
            {
                var duplicateNumberList = String.Join(", ", duplicateGroups.Select(x => x.Key));
                var duplicateDetailStrings = duplicateGroups.Select(x => String.Format("   {0}: {1}", x.Key, String.Join(", ", x.Select(y => y.DatabaseMigrationFile.Name))));
                var duplicateDetails = String.Join("\r\n", duplicateDetailStrings);
                ErrorHelper.AssertPreCondition(false, String.Format("Found duplicate database migration files for migration number(s) {0}.\r\n{1}", duplicateNumberList, duplicateDetails));
            }

            foreach (var migration in databaseMigrationFiles)
            {
                _fileSet.Add(migration.DatabaseMigrationNumber, migration);
            }
        }

        public List<DatabaseMigrationFileInfo> GetOrderedMigrations()
        {
            return _fileSet.Values.OrderBy(x => x.DatabaseMigrationNumber).ToList();
        }
    }
}