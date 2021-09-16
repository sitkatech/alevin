using System;
using System.IO;

namespace Toad.WebInstaller
{
    public class WebAppInstallerConfig
    {
        public const string WebBasePathExpectedInToadPackage = "WebSiteRoot";
        public const string DatabaseBasePathExpectedInToadPackage = "Database";
        public const string ReleaseScriptDirectoryName = "ReleaseScript";
        public const string LookupTablesDirectoryName = "LookupTables";
        public const string DatabaseObjectsDirectoryName = "Objects";
        public const string PostReleaseScriptsDirectoryName = "PostReleaseScript";

        /// <summary>
        /// Name of the DB server
        /// </summary>
        public string DbServerName;

        /// <summary>
        /// Database name
        /// </summary>
        public string DbName;

        /// <summary>
        /// The base location the zip file has been expanded into
        /// </summary>
        public DirectoryInfo UnzipDirectory;

        /// <summary>
        /// The current directory where the Web site is actually runnning
        /// </summary>
        public DirectoryInfo CurrentWebRootDirectory;

        /// <summary>
        /// A directory where a backup copy of the original Web site has been placed
        /// </summary>
        public DirectoryInfo OldWebRootDirectory;

        /// <summary>
        /// A directory where copy of the new Web site files has been placed
        /// </summary>
        public DirectoryInfo NewWebRootDirectory;

        /// <summary>
        /// Directory for Database 
        /// </summary>
        public DirectoryInfo DatabaseRootDirectory;

        /// <summary>
        /// Database Release Script Directory 
        /// </summary>
        public DirectoryInfo DatabaseReleaseScriptDirectory;

        /// <summary>
        /// Directory for Lookup Tables
        /// </summary>
        public DirectoryInfo LookupTablesDirectory;

        /// <summary>
        /// Directory for Lookup Tables
        /// </summary>
        public DirectoryInfo DatabaseObjectsDirectory;

        /// <summary>
        /// Post-Release scripts
        /// </summary>
        public DirectoryInfo PostReleaseScriptsDirectory;

        private readonly Lazy<DirectoryInfo> _databaseTablesDirectory;
        public DirectoryInfo DatabaseTablesDirectory
        {
            get { return _databaseTablesDirectory.Value; }
        }

        public WebAppInstallerConfig()
        {
            _databaseTablesDirectory = new Lazy<DirectoryInfo>(() => new DirectoryInfo(Path.Combine(DatabaseRootDirectory.FullName, "Tables")));
        }

    }
}