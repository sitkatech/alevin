using System;
using System.IO;
using NUnit.Framework;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    [TestFixture]
    public class DatabaseTableScripterTest
    {
        [Test]
        public void CanScriptToDiskWithoutExceptions()
        {
            Action<string> loggerFunc = x => {};
            var tempDir = new DirectoryInfo(Path.Combine(Path.GetTempPath(), string.Format("DatabaseTableScripterTest-{0}", Guid.NewGuid())));
            tempDir.Create();
            try
            {
                var tableScripter = new DatabaseTableScripter(tempDir, "(local)", "tempdb", loggerFunc);
                Assert.DoesNotThrow(()=>tableScripter.ScriptToDisk());
            }
            finally
            {
                tempDir.Delete(true);
            }
        }
    }
}