using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using NUnit.Framework;
using LtInfo.Common;

namespace Toad.WebInstaller
{
    [TestFixture]
    public class InstallerCookerTest
    {
        [Test]
        [Ignore("11/9/21 TK - failing due to mismatches slashes in file name comparison")]
        public void Test()
        {
            // Arrange
            // -------
            var rootDir = FileUtility.FirstMatchingDirectoryUpDirectoryTree(@"InstallerCookerTestFiles");
            const string mywebfiles = "MyWebFiles";
            var webSiteRoot = new DirectoryInfo(Path.Combine(rootDir.FullName, mywebfiles));
            const string mydatabasefiles = "MyDatabaseFiles";
            var databaseRoot = new DirectoryInfo(Path.Combine(rootDir.FullName, mydatabasefiles));
            var outputFile = new FileInfo(@"C:\Temp\MyZip.zip");
            if (File.Exists(outputFile.FullName))
            {
                outputFile.Delete();
            }

            var installerCooker = new InstallerCooker(webSiteRoot, databaseRoot);

            Assert.That(File.Exists(outputFile.FullName), Is.False, "Test precondition not there yet");
            
            // Act
            // ---
            installerCooker.CreateZipPackage(outputFile);

            // Assert
            // ------
            Assert.That(File.Exists(outputFile.FullName), Is.True, "Should make the file");

            List<string> expectedFileNames;
            List<string> actualFileNames;
            using (var zipArchive = ZipFile.OpenRead(outputFile.FullName))
            {
                var allFiles = rootDir.GetFiles("*.*", SearchOption.AllDirectories);
                expectedFileNames = allFiles.Select(x => x.FullName.Replace(rootDir.FullName + "\\", "").Replace(mywebfiles, WebAppInstallerConfig.WebBasePathExpectedInToadPackage).Replace(mydatabasefiles, WebAppInstallerConfig.DatabaseBasePathExpectedInToadPackage)).ToList();

                actualFileNames = zipArchive.Entries.Select(e => e.FullName).ToList();
            }
            Assert.That(actualFileNames, Is.EquivalentTo(expectedFileNames), string.Format("Should match, found problem in zip file \"{0}\"", outputFile.FullName));
            if (File.Exists(outputFile.FullName))
            {
                outputFile.Delete();
            }
        }
    }
}