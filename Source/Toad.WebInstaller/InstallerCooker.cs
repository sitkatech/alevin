using System.IO;
using System.IO.Compression;
using LtInfo.Common;

namespace Toad.WebInstaller
{
    public class InstallerCooker
    {
        private readonly DirectoryInfo _websiteRootSource;
        private readonly DirectoryInfo _databaseRootSource;

        public InstallerCooker(DirectoryInfo websiteRootSource, DirectoryInfo databaseRootSource)
        {
            _websiteRootSource = websiteRootSource;
            _databaseRootSource = databaseRootSource;
        }

        public void CreateZipPackage(FileInfo outputFile)
        {
            var stagingDirectory = new DirectoryInfo(FileUtility.CreateTempDirectory());
            var websiteRootStaging = new DirectoryInfo(Path.Combine(stagingDirectory.FullName, WebAppInstallerConfig.WebBasePathExpectedInToadPackage));
            var databaseStaging = new DirectoryInfo(Path.Combine(stagingDirectory.FullName, WebAppInstallerConfig.DatabaseBasePathExpectedInToadPackage));

            // Copy files into "WebSiteRoot" directory in the staging area
            FileUtility.RoboCopyDirectory(_websiteRootSource, websiteRootStaging);

            // Copy files into "Database" directory in the staging area
            FileUtility.RoboCopyDirectory(_databaseRootSource, databaseStaging);

            // TODO: Clean filtered files from staging area

            // Add the "WebSiteRoot" directory to the zip file
            ZipFile.CreateFromDirectory(stagingDirectory.FullName, outputFile.FullName);

            // Clean up staging directory
            Directory.Delete(stagingDirectory.FullName, true);
        }
    }
}
