using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Management.Smo;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    public class DatabaseBackupViaSqlFileCreator
    {
        private readonly string _databaseServer;
        private readonly string _databaseName;

        public DatabaseBackupViaSqlFileCreator(string databaseServer, string databaseName)
        {
            _databaseServer = databaseServer;
            _databaseName = databaseName;
        }

        public string CreateSqlBackup()
        {
            var server = new Server(_databaseServer);
            var dependencyWalker = new DependencyWalker(server);
            var database = server.Databases[_databaseName];

            var tables = (database.Tables.Cast<Table>().Where(table => table.IsSystemObject == false || table.Name == "sysdiagrams").Select(table => table.Urn)).ToArray();
            var dependencyTree = dependencyWalker.DiscoverDependencies(tables, true);
            var dependencyCollection = dependencyWalker.WalkDependencies(dependencyTree);

            var strings = new List<string>();

            var schemaScripter = new Scripter(server)
            {
                Options =
                    new ScriptingOptions
                    {
                        ClusteredIndexes = true,
                        Default = true,
                        DriAll = true,
                        ExtendedProperties = true,
                        IncludeHeaders = false,
                        Indexes = true,
                    }
            };
            var schemaScripts = dependencyCollection.SelectMany(x => schemaScripter.Script(new[] { x.Urn }).Cast<string>()).ToList();
            strings.AddRange(schemaScripts);

            strings.Add("GO");

            var dataScripter = new Scripter(server) {Options = new ScriptingOptions {ScriptData = true, ScriptSchema = false}};
            var dataScripts = dataScripter.EnumScriptWithList(dependencyCollection);
            strings.AddRange(dataScripts);

            return String.Join("\r\n", strings);
        }
    }
}