using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace Toad.WebInstaller.DatabaseMigration
{
    [TestFixture]
    public class DatabaseMigrationFileInfoSetTest
    {
        [Test]
        public void CanFindDuplicates()
        {
            var m1 = new DatabaseMigrationFileInfo(new FileInfo("001.sql"));
            var m2 = new DatabaseMigrationFileInfo(new FileInfo("1.sql"));
            var m3 = new DatabaseMigrationFileInfo(new FileInfo("2.sql"));
            var m4 = new DatabaseMigrationFileInfo(new FileInfo("0002.sql"));
            var m5 = new DatabaseMigrationFileInfo(new FileInfo("2 Another File.sql"));
            var m6 = new DatabaseMigrationFileInfo(new FileInfo("2 Another File2.sql"));

            var ex = Assert.Catch(() => new DatabaseMigrationFileInfoSet(new List<DatabaseMigrationFileInfo> {m1, m2, m3, m4, m5, m6}), "Should throw exception because they are duplicates");
            Assert.That(ex.Message, Is.StringContaining("duplicate"), "Should be message about duplicates");
            Trace.WriteLine(ex.Message);
        }
    }
}