using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NUnit.Framework;

namespace ProjectFirmaModels.UnitTestCommon
{
    [TestFixture]
    public class DatabaseHasOnlyResolvedObjectReferences : DatabaseDirectAccessTestFixtureBase
    {
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            BaseFixtureSetup();
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            BaseFixtureTeardown();
        }

        private const string CheckForUnresolvedObjectReferences = @"
-- Finds references from executable database objects that did not resolve at compile time
select x.ObjectSchemaName, x.ObjectName, x.ReferenceDatabaseName, x.ReferencedSchemaName, x.ReferencedObjectName
from
(
SELECT s.name as ObjectSchemaName, p.name as ObjectName, ReferenceDatabaseName = COALESCE(d.referenced_database_name, DB_NAME()),
  ReferencedSchemaName = d.referenced_schema_name, ReferencedObjectName = d.referenced_entity_name
  FROM sys.schemas AS s
  INNER JOIN sys.all_objects AS p ON s.[schema_id] = p.[schema_id]
  INNER JOIN sys.sql_expression_dependencies AS d ON p.[object_id] = d.referencing_id
  WHERE d.referenced_id IS NULL
    AND d.referenced_server_name IS NULL
    AND d.referenced_class = 1
    AND OBJECT_ID(QUOTENAME(COALESCE(d.referenced_database_name, DB_NAME()))
          + '.' + QUOTENAME(d.referenced_schema_name)
          + '.' + QUOTENAME(d.referenced_entity_name)) IS NULL
) x
where
	 x.ReferencedObjectName not in ('deleted','inserted','updated') -- these are T-Sql Trigger Views for finding records affected by the statement, built in and need to be ignored
     and x.ReferencedObjectName not in ('STArea','STContains','STIntersection','STIntersects','STLength') -- these are geospatial functions ignore, may need to add to this list
     and x.ObjectName not in ('sp_upgraddiagrams') 
order by x.ObjectSchemaName, x.ObjectName, x.ReferenceDatabaseName, x.ReferencedSchemaName, x.ReferencedObjectName
";

        private class SqlUnresolvedReferences : IComparable<SqlUnresolvedReferences>
        {
            private readonly string _objectSchemaName;
            private readonly string _objectName;
            private readonly string _referenceDatabaseName;
            private readonly string _referencedSchemaName;
            private readonly string _referencedObjectName;

            public SqlUnresolvedReferences(DataRow dataRow)
            {
                _objectSchemaName = (string)dataRow["ObjectSchemaName"];
                _objectName = (string)dataRow["ObjectName"];
                _referenceDatabaseName = dataRow.IsNull("ReferenceDatabaseName") ? null : (string)dataRow["ReferenceDatabaseName"];
                _referencedSchemaName = dataRow.IsNull("ReferencedSchemaName") ? null : (string)dataRow["ReferencedSchemaName"];
                _referencedObjectName = dataRow.IsNull("ReferencedObjectName") ? null : (string)dataRow["ReferencedObjectName"];
            }

            public string ToDisplayString()
            {
                return String.Format("{0}.{1} has unresolved reference to {2}.{3}.{4}", _objectSchemaName, _objectName, _referenceDatabaseName, _referencedSchemaName, _referencedObjectName);
            }

            public int CompareTo(SqlUnresolvedReferences other)
            {
                if (_objectSchemaName != other._objectSchemaName)
                {
                    return String.Compare(_objectSchemaName, other._objectSchemaName, StringComparison.InvariantCultureIgnoreCase);
                }
                if (_objectName != other._objectName)
                {
                    return String.Compare(_objectName, other._objectName, StringComparison.InvariantCultureIgnoreCase);
                }
                if (_referenceDatabaseName != other._referenceDatabaseName)
                {
                    return String.Compare(_referenceDatabaseName, other._referenceDatabaseName, StringComparison.InvariantCultureIgnoreCase);
                }
                if (_referencedSchemaName != other._referencedSchemaName)
                {
                    return String.Compare(_referencedSchemaName, other._referencedSchemaName, StringComparison.InvariantCultureIgnoreCase);
                }
                return String.Compare(_referencedObjectName, other._referencedObjectName, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        private List<SqlUnresolvedReferences> FindUnresolvedDatabaseObjectReferences()
        {
            return ExecAdHocSql(CheckForUnresolvedObjectReferences).Rows.Cast<DataRow>().Select(x => new SqlUnresolvedReferences(x)).ToList();
        }

        [Test, Description("Searches the database for any objects that have references to other database objects that don't resolve, i.e. a stored procedure references a table that doesn't exist.")]
        public void EnsureDatabaseObjectsReferencesToOtherObjectsAreAllFullyResolved()
        {
            var problems = FindUnresolvedDatabaseObjectReferences().Select(x => x.ToDisplayString());
            var result = String.Join("\r\n", problems);
            Assert.That(String.IsNullOrWhiteSpace(result), string.Format("Found some database objects that have unresolved object references.\r\nIf it's on an update/delete via alias, use fully qualified table instead the alias to work around the false alarm.  Also it is an advantage for searachability to have the fully qualified table name next to update/delete statements.\r\nSee:\r\n{0}", result));
        }

    }
}