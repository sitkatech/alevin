using System;
using System.IO;
using System.IO.Compression;
using System.Web;
using LtInfo.Common;
using Toad.WebInstaller.Database.DatabaseUtil;
using Toad.WebInstaller.DatabaseMigration;

namespace Toad.WebInstaller
{
    /// <summary>
    /// Utility class as starting point for making a web site be able to deploy to itself, started as part of Toad project
    /// </summary>
    public class WebAppInstallerUtility
    {
         private readonly HttpPostedFileBase _httpPostedFileBase;
         private readonly Action<string> _loggingFunction;

         private readonly WebAppInstallerConfig _webAppInstallerConfig;

         public WebAppInstallerUtility(DirectoryInfo webSiteDir, HttpPostedFileBase httpPostedFileBase, string dbName, string dbServerName, Action<string> loggingFunction)
         {
             _webAppInstallerConfig = new WebAppInstallerConfig {CurrentWebRootDirectory = webSiteDir, DbName = dbName, DbServerName = dbServerName};
             _httpPostedFileBase = httpPostedFileBase;
             _loggingFunction = loggingFunction;

         }

         /// <summary>
         /// Does the entire installation process to a new version:
         ///  -- Update website code
         ///  -- Update database
         /// </summary>
         /// <returns></returns>
         public void DoInstallation()
         {
             // Unzip everything and get ready to do real work
             UnzipPackageAndPrepareForInstallation();

             // Copy the website files into place
             CopyNewWebsiteFiles();

             // Run the database change scripts
             ProcessDatabaseChangeScripts();

             // Process the lookup tables
             ProcessLookupTables();

             // Database Objects
             ProcessDatabaseObjects();

             // Post release script
             ProcessPostReleaseScripts();

             CompareTablesWithSchema();

             // Copy the website files into place
             //CopyNewWebsiteFiles();
         }

         /// <summary>
        /// Does unzipping tasks, but does not actually make any changes to the website
        /// </summary>
        /// <returns></returns>
        public WebAppInstallerConfig UnzipPackageAndPrepareForInstallation()
        {
            const string installer = "TempInstaller";
            var appRootDir = _webAppInstallerConfig.CurrentWebRootDirectory.Parent;

            if (appRootDir == null)
            {
                throw new NullReferenceException(String.Format("No parent directory for {0}", _webAppInstallerConfig.CurrentWebRootDirectory.FullName));
            }

            // Set up a staging directory where we will do our unzipping
            //var unzipDir = new DirectoryInfo(Path.Combine(appRootDir.FullName, installer));
            _webAppInstallerConfig.UnzipDirectory = new DirectoryInfo(Path.Combine(appRootDir.FullName, installer));
            if (_webAppInstallerConfig.UnzipDirectory.Exists)
            {
                _webAppInstallerConfig.UnzipDirectory.Delete(true);
            }

            // Save uploaded file to this staging directory
            var zipFilePath = new FileInfo(_webAppInstallerConfig.UnzipDirectory.FullName + ".zip");
            if (zipFilePath.Exists)
            {
                zipFilePath.Delete();
            }
            _httpPostedFileBase.SaveAs(zipFilePath.FullName);

            // Unzip into a "_New" directory
            ZipFile.ExtractToDirectory(zipFilePath.FullName, _webAppInstallerConfig.UnzipDirectory.FullName);
            var zipFileWebRootDir = new DirectoryInfo(Path.Combine(_webAppInstallerConfig.UnzipDirectory.FullName, WebAppInstallerConfig.WebBasePathExpectedInToadPackage));
            _webAppInstallerConfig.DatabaseRootDirectory = new DirectoryInfo(Path.Combine(_webAppInstallerConfig.UnzipDirectory.FullName, WebAppInstallerConfig.DatabaseBasePathExpectedInToadPackage));
            _webAppInstallerConfig.DatabaseReleaseScriptDirectory = new DirectoryInfo(Path.Combine(_webAppInstallerConfig.DatabaseRootDirectory.FullName, WebAppInstallerConfig.ReleaseScriptDirectoryName));
            _webAppInstallerConfig.LookupTablesDirectory = new DirectoryInfo(Path.Combine(_webAppInstallerConfig.DatabaseRootDirectory.FullName, WebAppInstallerConfig.LookupTablesDirectoryName));
            _webAppInstallerConfig.DatabaseObjectsDirectory = new DirectoryInfo(Path.Combine(_webAppInstallerConfig.DatabaseRootDirectory.FullName, WebAppInstallerConfig.DatabaseObjectsDirectoryName));
            _webAppInstallerConfig.PostReleaseScriptsDirectory = new DirectoryInfo(Path.Combine(_webAppInstallerConfig.DatabaseRootDirectory.FullName, WebAppInstallerConfig.PostReleaseScriptsDirectoryName));
            _webAppInstallerConfig.NewWebRootDirectory = new DirectoryInfo(_webAppInstallerConfig.CurrentWebRootDirectory.FullName + "_New");
            _loggingFunction(FileUtility.RoboCopyDirectory(zipFileWebRootDir, _webAppInstallerConfig.NewWebRootDirectory));

            // Copy original web site files into an "_old" directory
            _webAppInstallerConfig.OldWebRootDirectory = new DirectoryInfo(_webAppInstallerConfig.CurrentWebRootDirectory.FullName + "_Old");
            _loggingFunction(FileUtility.RoboCopyDirectory(_webAppInstallerConfig.CurrentWebRootDirectory, _webAppInstallerConfig.OldWebRootDirectory));

            // At this point we should be set up, and ready to do real work with everything we've unzipped.
            return _webAppInstallerConfig;
        }

        public void CopyNewWebsiteFiles()
        {
            // Robocopy "_New" into Current directory
            _loggingFunction(FileUtility.RoboCopyDirectory(_webAppInstallerConfig.NewWebRootDirectory, _webAppInstallerConfig.CurrentWebRootDirectory));
        }

        /// <summary>
        /// Process all the database change scripts
        /// </summary>
        public void ProcessDatabaseChangeScripts()
        {
            var databaseMigrator = new DatabaseMigrator(_webAppInstallerConfig.DatabaseReleaseScriptDirectory, _webAppInstallerConfig.DbServerName, _webAppInstallerConfig.DbName, _loggingFunction);
            databaseMigrator.PerformMigration();
        }


        public void DoSqlRecompilerAction(DirectoryInfo scriptDirectory, bool dropDbExecutableObjects, bool retryCompiles, bool dropConstraints)
        {
            // Must have SourceDirectory, the directory must exist
            ErrorHelper.AssertPreCondition(Directory.Exists(scriptDirectory.FullName), string.Format("source-directory \"{0}\" was not found.", scriptDirectory.FullName));

            using (var destServer = (new SqlServer(_webAppInstallerConfig.DbServerName, _webAppInstallerConfig.DbName)))
            {
                var sqlRecompiler = new SchemaRecompiler(scriptDirectory, destServer, _loggingFunction);
                sqlRecompiler.RecompileExecutableObjects(dropDbExecutableObjects, retryCompiles, dropConstraints);
            }
        }

        public void ProcessLookupTables()
        {
            DoSqlRecompilerAction(_webAppInstallerConfig.LookupTablesDirectory, false, false, true);
        }

        public void ProcessDatabaseObjects()
        {
            DoSqlRecompilerAction(_webAppInstallerConfig.DatabaseObjectsDirectory, true, true, false);
        }

        public void ProcessPostReleaseScripts()
        {
            DoSqlRecompilerAction(_webAppInstallerConfig.PostReleaseScriptsDirectory, false, false, false);
        }

        public void CompareTablesWithSchema()
        {
            // Must have SourceDirectory, the directory must exist
            ErrorHelper.AssertPreCondition(Directory.Exists(_webAppInstallerConfig.DatabaseTablesDirectory.FullName), string.Format("source-directory \"{0}\" was not found.", _webAppInstallerConfig.DatabaseTablesDirectory.FullName));
            var comparer = new DatabaseScriptTablesAndCompareTask(_webAppInstallerConfig.DatabaseTablesDirectory, _webAppInstallerConfig.DbServerName, _webAppInstallerConfig.DbName, _loggingFunction);
            comparer.AssertTablesMatch();
        }
    }
}
