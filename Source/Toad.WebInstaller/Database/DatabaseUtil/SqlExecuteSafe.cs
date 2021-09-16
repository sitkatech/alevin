using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    public class SqlExecuteSafe
    {
        public const string SqlBatchSeparator = "GO";

        /// <summary>
        /// Match the T-SQL batch separator GO
        /// </summary>
        private static readonly Regex _sqlBatchSeparator = new Regex(string.Format(@"^\s*{0}\s*$", SqlBatchSeparator), RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

        /// <summary>
        /// Match multiline SQL comment /*  */
        /// </summary>
        private static readonly Regex _sqlMultilineCommentFinder = new Regex(@"\/\*.*?\*\/", RegexOptions.Singleline);

        public bool TryExecuteNonQuery(SqlServer objDatabase, string strSql, out Exception exceptionOut)
        {
            var inTransaction = FileShouldBeRunInTransaction(strSql);
            if (inTransaction)
            {
                objDatabase.TranBegin();
            }
            try
            {
                exceptionOut = null;
                foreach (var batch in GetSqlBatches(strSql))
                {
                    try
                    {
                        objDatabase.ExecuteNonQuery(batch);
                    }
                    catch (Exception ex)
                    {
                        var message = string.Format("{0}\r\n\r\n-- ===== Sql Batch:\r\n{1}", ex.Message, batch);
                        if (ex is SqlException)
                        {
                            var sqlEx = (SqlException) ex;
                            if (sqlEx.Number == 574)
                            {
                                message += "\r\n\r\nREMEMBER - you can use the --NO_TRANSACTION in your change script!\r\n\r\n";
                            }
                        }
                        exceptionOut = new ApplicationException(message, ex);
                        if (inTransaction)
                        {
                            objDatabase.TranRollback();
                        }
                        return false;
                    }
                }
                if (inTransaction)
                {
                    objDatabase.TranCommit();
                }
                return true;
            }
            catch
            {
                if (inTransaction)
                {
                    objDatabase.TranRollback();
                }
                throw;
            }
        }

        private static bool FileShouldBeRunInTransaction(string sql)
        {
            return !sql.StartsWith("--NO_TRANSACTION");
        }

        public void ExecuteNonQuery(SqlServer objDatabase, string strSql)
        {
            Exception ex;
            var succeeded = TryExecuteNonQuery(objDatabase, strSql, out ex);
            if (!succeeded)
            {
                throw ex;
            }
        }

        public static string[] GetSqlBatches(string strSql)
        {
            var strSqlMinusMultilineComments = RemoveMultilineSqlComments(strSql);
            return _sqlBatchSeparator.Split(strSqlMinusMultilineComments).Select(batch => batch.Trim()).Where(trimmedBatch => !String.IsNullOrEmpty(trimmedBatch)).ToArray();
        }

        public static string RemoveMultilineSqlComments(string sql)
        {
            return _sqlMultilineCommentFinder.Replace(sql, String.Empty);
        }
    }
}