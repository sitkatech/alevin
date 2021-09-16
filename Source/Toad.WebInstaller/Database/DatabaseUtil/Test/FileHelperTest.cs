using System.IO;
using System.Text;
using NUnit.Framework;

namespace Toad.WebInstaller.Database.DatabaseUtil.Test
{
    [TestFixture]
    public class FileHelperTest
    {
        private const string SqlScriptDirectory = @"..\Database\DatabaseUtil\Test\SqlScripts";

        [Test]
        public void OnlyProperEncodingAllowed()
        {
            var tempFile = Path.GetTempFileName();
            const int windowsDefaultCodePageNumber = 1252;
            var windowsDefaultEncoding = Encoding.GetEncoding(windowsDefaultCodePageNumber);
            const string fileContents = "Smart Apostrophe: ‘’, Smart Quotes: “”, others • – — ™ ›œžŸ  ¡¢£¤¥¦§¨©ª«»­®¯";
            File.WriteAllText(tempFile, fileContents, windowsDefaultEncoding);

            var readWithProperEncoding = File.ReadAllText(tempFile, windowsDefaultEncoding);
            Assert.That(readWithProperEncoding, Is.EqualTo(fileContents), "Test precondition: the high order chars made it to disk with default encoding");

            // Act & Assert
            Assert.That(() => FileHelper.ReadAllTextCheckingForProperEncoding(tempFile), Throws.Exception.With.Message.Contains("encoding").And.With.Message.Contains(tempFile), "Given Windows 1252 with high order chars, should throw an exception about encoding problems and include the file name");

            // Arrange - safe as UTF
            File.WriteAllText(tempFile, fileContents, Encoding.UTF8);
            Assert.That(FileHelper.ReadAllTextCheckingForProperEncoding(tempFile), Is.EqualTo(fileContents), "Saving in UTF-8 should make things work");
        }

        [Test]
        public void TestLoadSqlObjectsFromDisk()
        {
            var sqlDirectory = new DirectoryInfo(SqlScriptDirectory);

            var dict = FileHelper.LoadSqlObjectsFromDisk(sqlDirectory);

            Assert.AreEqual(4, dict.Count);
            Assert.IsTrue(dict.ContainsKey("SqlScript1"));
            Assert.IsTrue(dict.ContainsKey("okprefix.SqlScript2"));
            Assert.IsTrue(dict.ContainsKey("SqlScript3"));
            Assert.IsTrue(dict.ContainsKey("SqlScript4.firstextension"));

            var strFilename = Path.Combine(SqlScriptDirectory, "dbo.SqlScript1.sql");
            var expectedString = FileHelper.ReadAllTextCheckingForProperEncoding(strFilename);
            Assert.AreEqual(expectedString, dict["SqlScript1"].FileContents);
        }

        [Test]
        public void TestReadStringFromResource()
        {
            var resource = SqlServer.LookupSqlForAllObjects();
            Assert.That(resource, Is.StringStarting("--Note: This is embedded in the solution as a resource file"), "Resource did not look like expected value");
        }


    }
}