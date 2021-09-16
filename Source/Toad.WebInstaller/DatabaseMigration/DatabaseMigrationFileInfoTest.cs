using System.IO;
using LtInfo.Common;
using NUnit.Framework;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    [TestFixture]
    public class DatabaseMigrationFileInfoTest
    {
        [Test]
        public void CanParseFile()
        {
            var file = FileUtility.FirstMatchingFileUpDirectoryTree(@"DatabaseMigration\Test\DatabaseMigrationFiles\11.sql");
            var testSubject = new DatabaseMigrationFileInfo(file);
            Assert.That(testSubject.DatabaseMigrationNumber, Is.EqualTo(11), "Should have gotten number right");
            Assert.That(testSubject.FileContents, Is.EqualTo(FileHelper.ReadAllTextCheckingForProperEncoding(file.FullName)), "Should have read in file correctly");
        }

        [Test]
        public void DoesntAllowBadFile()
        {
            var file = new FileInfo(@"..\..\DatabaseMigration\Test\DatabaseMigrationFiles\IgnoreMe.txt");
            Assert.Catch(() => new DatabaseMigrationFileInfo(file), "Should throw an exception on bad file");
        }

        [Test]
        public void CanTellGoodAndBadFiles()
        {
            AssertFileTestCase("1.sql", true);
            AssertFileTestCase("5544.sql", true);
            AssertFileTestCase("1.good.sql", true);

            AssertFileTestCase("bad.sql", false);
            AssertFileTestCase("bad.txt", false);
            AssertFileTestCase("b123123ad.txt", false);
        }

        [Test]
        public void CanParseNumberFromFilename()
        {
            AssertGotRightNumber("1.sql", 1);
            AssertGotRightNumber("0001.sql", 1);
            AssertGotRightNumber("0001 Plus other text.sql", 1);
            AssertGotRightNumber("1AndMore.sql", 1);

        }

        private static void AssertGotRightNumber(string filename, int expectedNumber)
        {
            var migration = new DatabaseMigrationFileInfo(new FileInfo(filename));
            Assert.That(migration.DatabaseMigrationNumber, Is.EqualTo(expectedNumber), string.Format("Expected to get number {0} when parsing filename {1}", expectedNumber, filename));
        }

        private static void AssertFileTestCase(string fileName, bool expected)
        {
            Assert.That(DatabaseMigrationFileInfo.IsFileMatch(new FileInfo(fileName)), Is.EqualTo(expected), string.Format("Expected to be {0} for file {1}", expected, fileName));
        }
    }
}