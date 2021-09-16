using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Management.Smo;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    public class DatabaseTableScripter
    {
        private static readonly string[] _tablesToIgnore = new[] {"dtproperties", "sysdiagrams"};
        private readonly Microsoft.SqlServer.Management.Smo.Database _databaseSmo;
        private readonly Server _serverSmo;
        private readonly DirectoryInfo _sourceDirectory;
        private readonly Action<string> _loggerFunction;

        public DatabaseTableScripter(DirectoryInfo sourceDirectory, string serverName, string databaseName, Action<string> loggerFunc)
        {
            _sourceDirectory = sourceDirectory;
            _serverSmo = new Server(serverName);
            _serverSmo.ConnectionContext.MultipleActiveResultSets = true;
            _serverSmo.SetDefaultInitFields(typeof(Table), new StringCollection {"Schema", "Name", "IsSystemObject"});
            _databaseSmo = _serverSmo.Databases[databaseName];
            _loggerFunction = loggerFunc;
        }

        private static Scripter MakeSmoDatabaseScripter(Server serverSmo)
        {
            var scr = new Scripter(serverSmo);
            var options = new ScriptingOptions
                          {
                              DriAll = true,
                              ClusteredIndexes = true,
                              Default = true,
                              Indexes = true,
                              IncludeHeaders = false,
                              ExtendedProperties = true,
                          };
            scr.Options = options;
            return scr;
        }

        public DatabaseTableScripterResult ScriptToDisk()
        {
            _loggerFunction(string.Format("Connecting to server {0} database {1} to get Table information", _serverSmo.Name, _databaseSmo.Name));
            var userTables = _databaseSmo.Tables.AsParallel().Cast<Table>().Where(t => !_tablesToIgnore.Contains(t.Name, StringComparer.InvariantCultureIgnoreCase) && !t.IsSystemObject).OrderBy(t => t.Schema).ThenBy(t => t.Name).ToList();

            // This can't be paralellized effectively but the other bits are left parallel
            _loggerFunction("Generating SQL scripts for tables");
            var scripterSmo = MakeSmoDatabaseScripter(_serverSmo);
            var userTableScripts = userTables.Select(t =>
                                                     {
                                                         Console.Write(".");
                                                         return new TableScript(_sourceDirectory, new FullTableName(t.Schema, t.Name), scripterSmo.Script(new[] {t}));
                                                     }).ToList();
            Console.WriteLine();

            userTableScripts.AsParallel().ForAll(uts => uts.MakeScriptFileMatchDatabase());

            var tablesInDatabase = userTableScripts.Select(x => x.TableName);
            var existingTablesOnDisk = _sourceDirectory.GetFiles().Select(FileNameToFullTableName);

            var extraTables = existingTablesOnDisk.Except(tablesInDatabase).ToList();
            extraTables.AsParallel().ForAll(x => CalculateTableFileInfo(x, _sourceDirectory).Delete());

            return new DatabaseTableScripterResult(
                userTableScripts.Where(x => x.ChangeStatus == TableScript.ChangedStatus.Added).Select(x => x.TableName).ToList(),
                userTableScripts.Where(x => x.ChangeStatus == TableScript.ChangedStatus.Changed).Select(x => x.TableName).ToList(),
                userTableScripts.Where(x => x.ChangeStatus == TableScript.ChangedStatus.Unchanged).Select(x => x.TableName).ToList(),
                extraTables);
        }

        private static FileInfo CalculateTableFileInfo(FullTableName currentTable, DirectoryInfo sourceDirectory)
        {
            return new FileInfo(Path.Combine(sourceDirectory.FullName, string.Format("{0}.{1}.sql", currentTable.Schema, currentTable.TableName)));
        }

        private static FullTableName FileNameToFullTableName(FileInfo file)
        {
            var tableFromFileName = new Regex(@"(?<schema>[^\.]+)\.(?<tablename>[^\.]+)\.sql");

            var match = tableFromFileName.Match(file.Name);
            if (match == null)
            {
                throw new ApplicationException(string.Format("Couldn't figure out the table name from the file {0}, file does not match naming convention.", file.FullName));
            }

            var schema = match.Groups["schema"].Value;
            var tableName = match.Groups["tablename"].Value;

            return new FullTableName(schema, tableName);
        }

        public class DatabaseTableScripterResult
        {
            public ReadOnlyCollection<FullTableName> Added;
            public ReadOnlyCollection<FullTableName> Changed;
            public ReadOnlyCollection<FullTableName> Deleted;
            public ReadOnlyCollection<FullTableName> Unchanged;

            public int TotalTables { get { return Added.Count + Changed.Count + Unchanged.Count; } }

            public DatabaseTableScripterResult(IEnumerable<FullTableName> added, IEnumerable<FullTableName> changed, IEnumerable<FullTableName> unchanged, IEnumerable<FullTableName> deleted)
            {
                Added = new ReadOnlyCollection<FullTableName>(added.ToList());
                Changed = new ReadOnlyCollection<FullTableName>(changed.ToList());
                Deleted = new ReadOnlyCollection<FullTableName>(deleted.ToList());
                Unchanged = new ReadOnlyCollection<FullTableName>(unchanged.ToList());
            }
        }

        public struct FullTableName : IEquatable<FullTableName>
        {
            public readonly string Schema;
            public readonly string TableName;

            public string FullName
            {
                get { return String.Format("{0}.{1}", Schema, TableName); }
            }

            private string FullNameInvariant
            {
                get { return FullName.ToLowerInvariant(); }
            }

            public FullTableName(string schema, string tableName)
            {
                Schema = schema;
                TableName = tableName;
            }

            #region IEquatable<FullTableName> Members

            public bool Equals(FullTableName other)
            {
                return other.FullNameInvariant.Equals(FullNameInvariant);
            }

            #endregion

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (obj.GetType() != typeof(FullTableName))
                {
                    return false;
                }
                return Equals((FullTableName) obj);
            }

            public override int GetHashCode()
            {
                return FullNameInvariant.GetHashCode();
            }

            public static bool operator ==(FullTableName left, FullTableName right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(FullTableName left, FullTableName right)
            {
                return !left.Equals(right);
            }
        }

        private class TableScript
        {
            #region ChangedStatus enum

            public enum ChangedStatus
            {
                Unchanged,
                Added,
                Changed,
                Unknown
            }

            #endregion

            private readonly string _singleSqlScript;
            private readonly FullTableName _tableName;
            private readonly FileInfo _tableScriptFile;
            private ChangedStatus _changeStatus = ChangedStatus.Unknown;

            public TableScript(DirectoryInfo sourceDirectory, FullTableName tableName, StringCollection sqlScripts)
            {
                _tableName = tableName;
                var allScripts = sqlScripts.Cast<string>().ToList();
                _singleSqlScript = String.Join(string.Format("\r\n{0}\r\n", SqlExecuteSafe.SqlBatchSeparator), allScripts);
                _tableScriptFile = CalculateTableFileInfo(tableName, sourceDirectory);
            }

            public ChangedStatus ChangeStatus
            {
                get { return _changeStatus; }
            }

            public FullTableName TableName
            {
                get { return _tableName; }
            }

            public void MakeScriptFileMatchDatabase()
            {
                if (!_tableScriptFile.Exists)
                {
                    _changeStatus = ChangedStatus.Added;
                    File.WriteAllText(_tableScriptFile.FullName, _singleSqlScript);
                }
                else
                {
                    var didUpdate = FileHelper.UpdateFileOnlyOnChange(_tableScriptFile, _singleSqlScript);
                    _changeStatus = (didUpdate) ? ChangedStatus.Changed : ChangedStatus.Unchanged;
                }
            }
        }
    }
}