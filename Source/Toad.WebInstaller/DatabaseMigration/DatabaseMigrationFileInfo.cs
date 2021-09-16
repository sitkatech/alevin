using System;
using System.IO;
using System.Text.RegularExpressions;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    /// <summary>
    /// Represents a migration file on disk with it's migration number and the pattern for reading the file in
    /// </summary>
    public class DatabaseMigrationFileInfo
    {
        public readonly int DatabaseMigrationNumber;
        public readonly FileInfo DatabaseMigrationFile;
        private readonly Lazy<string> _lazyLoadedFileContents;
        public string FileContents
        {
            get { return _lazyLoadedFileContents.Value; }
        }
        private static readonly Regex _migrationFileRegex = new Regex(@"^(?<migrationNumber>[0-9]+).*\.sql$", RegexOptions.Singleline | RegexOptions.Compiled);

        public static bool IsFileMatch(FileInfo file)
        {
            return _migrationFileRegex.IsMatch(file.Name);
        }

        public static int ParseMigrationNumber(FileInfo databaseMigrationFile)
        {
            ErrorHelper.AssertPreCondition(_migrationFileRegex.IsMatch(databaseMigrationFile.Name), string.Format("File name {0} doesn't match required pattern {1}", databaseMigrationFile.FullName, _migrationFileRegex));
            int migrationNumber;
            ErrorHelper.AssertPostCondition(
                Int32.TryParse(_migrationFileRegex.Match(databaseMigrationFile.Name).Groups["migrationNumber"].Value,
                               out migrationNumber),
                string.Format("File name {0} doesn't match required pattern {1}", databaseMigrationFile.FullName,
                              _migrationFileRegex));
            return migrationNumber;
        }

        public DatabaseMigrationFileInfo(FileInfo databaseMigrationFile)
        {
            DatabaseMigrationNumber = ParseMigrationNumber(databaseMigrationFile);
            DatabaseMigrationFile = databaseMigrationFile;
           _lazyLoadedFileContents = new Lazy<string>(() => FileHelper.ReadAllTextCheckingForProperEncoding(databaseMigrationFile.FullName));
        }
    }
}