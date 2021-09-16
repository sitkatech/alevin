using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.Database.Test
{
    [TestFixture, Ignore("Not working")]
    public class SchemaRecompilerTest
    {
        private string databaseServer = @"(local)";
        private string databaseName = "UnitTest_SchemaRecompiler";
        private SqlServer destinationDatabaseServer;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            destinationDatabaseServer = new SqlServer(databaseServer, databaseName);
        }

        private void Recompile(string directory)
        {
            var testMessages = new List<string>();
            Action<string> testLogAction = (string x) => testMessages.Add(x);

            var sourceDirectoryInfo = new DirectoryInfo(directory);
            var compiler = new SchemaRecompiler(sourceDirectoryInfo, destinationDatabaseServer, testLogAction);

            compiler.RecompileExecutableObjects(false, true, false);
        }

        private DateTime GetObjectCreatedOnDate(string objectName)
        {
            var dataTable = destinationDatabaseServer.ExecuteDataTable(string.Format("select CREATED from information_schema.routines where specific_name = '{0}'", objectName));
            return (DateTime) dataTable.Rows[0][0];
        }

        [Test]
        [ExpectedException(typeof (Exception))]
        public void SchemaRecompile_Fail()
        {
            Recompile(@"..\..\Database\Test\Source\Bad");
        }

        [Test]
        public void SchemaRecompile_Succeed()
        {
            Recompile(@"..\..\Database\Test\Source\Good");
            var lastCreatedOnDate = GetObjectCreatedOnDate("procAbcSelect");
            Recompile(@"..\..\Database\Test\Source\Good");
            Assert.IsTrue(lastCreatedOnDate < GetObjectCreatedOnDate("procAbcSelect"), "procAbcSelect created on date should be greater than previous value");
        }

    }
}