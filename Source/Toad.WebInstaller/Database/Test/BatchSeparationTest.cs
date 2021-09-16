using System;
using NUnit.Framework;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.Database.Test
{
    [TestFixture]
    public class BatchSeparationTest
    {
        [Test]
        public void TestBatchSeparatingSimple()
        {
            const string sqlBatch0 = "-- Comment";
            const string sqlBatch1 = "select * from information_schema.tables";
            const string sqlBatch2 = "select 5 + 5 as Answer\r\nselect 10 + 4 as Answer2";

            var sql = String.Format("{0}\r\nGO\r\n{1}\r\ngo  \r\n{2}\r\nGo\r\nGO\r\n", sqlBatch0, sqlBatch1, sqlBatch2);
            var batches = SqlExecuteSafe.GetSqlBatches(sql);
            Assert.That(batches.Length, Is.EqualTo(3), "Should have gotten rtight number of batches");
            Assert.That(batches[0], Is.EqualTo(sqlBatch0), "First batch should match");
            Assert.That(batches[1], Is.EqualTo(sqlBatch1), "First batch should match");
            Assert.That(batches[2], Is.EqualTo(sqlBatch2), "First batch should match");
        }

        [Test]
        public void TestBatchSeparatingRealWorldExample()
        {
            const string sql = @"
if exists ( select * from sys.procedures where object_id = object_id('dbo.spTest1') )
    drop procedure dbo.spTest1
go

create procedure dbo.spTest1
as
begin
    select 1
end
go

grant execute on dbo.spTest1 to MySpecialUserThatIMade
go";
            var batches = SqlExecuteSafe.GetSqlBatches(sql);
            Assert.That(batches.Length, Is.EqualTo(3), "Should have gotten rtight number of batches");
            Assert.That(batches[0], Is.EqualTo(@"if exists ( select * from sys.procedures where object_id = object_id('dbo.spTest1') )
    drop procedure dbo.spTest1"));
            Assert.That(batches[1], Is.EqualTo(@"create procedure dbo.spTest1
as
begin
    select 1
end"));
            Assert.That(batches[2], Is.EqualTo("grant execute on dbo.spTest1 to MySpecialUserThatIMade"));
        }

        [Test]
        public void HandlesMultilineComments()
        {
            const string sql = @"
-- BatchID1
/*
This is inside a multiline comment
GO
*/
-- BatchID2
/* Another multiline
   GO
*/ -- BatchID3
";
            var batches = SqlExecuteSafe.GetSqlBatches(sql);
            Assert.That(batches, Is.EqualTo(new[] { "-- BatchID1\r\n\r\n-- BatchID2\r\n -- BatchID3" }), "Multiline comment should be ignored so should see only 1 batch here");
        }

        [Test]
        public void WhitespaceBeforeBatchSeparatorIsOk()
        {
            const string sql = @"
-- BatchID1
    GO            
-- BatchID2
";
            var batches = SqlExecuteSafe.GetSqlBatches(sql);
            Assert.That(batches, Is.EqualTo(new[] { "-- BatchID1", "-- BatchID2" }), "Should be able to parse with inline comment after the GO");
        }

    }

    [TestFixture]
    public class SqlExecuteSafeTest
    {
        [Test]
        public void AnyFailureInAnyBatchShouldFailAll()
        {
            var db = new SqlServer("(local)", "tempdb");
            var testSubject = new SqlExecuteSafe();

            Exception ex;
            string strSql = @"
-- Batch that works BatchID1
select 1
go
-- Batch that fails BatchID2
BLAH
go
-- Batch that works BatchID3
select 1
go";
            var success = testSubject.TryExecuteNonQuery(db, strSql, out ex);
            Assert.That(success, Is.False, "Should have failed to run because of middle batch that was bad");
            Assert.That(ex, Is.Not.Null, "Should have gotten exception back in failure situation");
            Assert.That(ex.Message, Is.StringContaining("BatchID2").And.Not.StringContaining("BatchID1").And.Not.StringContaining("BatchID3"), "Should only mention the failed batch within the script");

        }
    }
}