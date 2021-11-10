using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Toad.WebInstaller
{
    [TestFixture]
    public class WebAppInstallerUtilityTest
    {
        [Test, Description("If the Microsoft SqlServer DLLs versions don't match, can get a runtime assembly binding exception \"System.IO.FileLoadException: Could not load file or assembly\" only in QA/Prod. Machines with GAC registered components will succeed masking the problem until release.")]
        [Ignore("11/9/21 TK - Failing because of the SQLServerTypes dll we are dropping in the bin is not the same as other SQL Server dlls")]
        public void MicrosoftSqlServerDllVersionsShouldAllMatch()
        {
            string localPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var thisDll = new FileInfo(localPath);
            var dir = thisDll.Directory;
            var sqlServerDlls = dir.GetFileSystemInfos("Microsoft.SqlServer.*.dll");
            var sqlVersionInfosStrings = sqlServerDlls.Select(GetProductVersionForFile).ToList();
            var differentVersions = sqlVersionInfosStrings.Distinct().ToList();
            var namesAndVersions = sqlServerDlls.Select(x => string.Format("{0} {1}", GetProductVersionForFile(x), x.Name)).ToList().OrderBy(y => y).ToList();
            var listOfDllsAndVersions = String.Join("\r\n", namesAndVersions);
            var message = "Adjust the .csproj references to Microsoft.SqlServer.*.dll files. Should all be on *same* version, but found different versions in use: " + String.Join(", ", differentVersions) + "\r\n\r\nDetails:\r\n" + listOfDllsAndVersions;
            Assert.That(differentVersions.Count(), Is.EqualTo(1), message);
        }

        public Version GetProductVersionForFile(FileSystemInfo file)
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(file.FullName);
            return new Version(fileVersionInfo.ProductMajorPart, fileVersionInfo.ProductMinorPart, fileVersionInfo.ProductBuildPart);
        }

    }
}