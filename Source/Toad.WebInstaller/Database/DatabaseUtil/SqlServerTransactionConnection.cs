using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Toad.WebInstaller.Database.DatabaseUtil
{

	public class SqlServer : IDisposable
	{
	    private readonly string _mStrDatabase;
		private readonly string _mStrServer;
		private SqlConnection _mObjConnection;
	    private SqlTransaction _mPossibleTransaction;

        public SqlServer(string strServer, string strDatabase) : this(strServer, strDatabase, null, null)
        {
        }

        public SqlServer(string strServer, string strDatabase, string dbUserName, string dbPassword)
		{
			_mStrServer = strServer;
			_mStrDatabase = strDatabase;
            _mObjConnection = GetSqlConnection(strServer, strDatabase, dbUserName, dbPassword);
		}

        public void TranBegin()
        {
            ErrorHelper.AssertPreCondition(_mPossibleTransaction == null, "Already have a transaction started!");
            _mPossibleTransaction = _mObjConnection.BeginTransaction();
        }

        public void TranCommit()
        {
            ErrorHelper.AssertPreCondition(_mPossibleTransaction != null, "Transaction not yet started.");
// ReSharper disable PossibleNullReferenceException
            _mPossibleTransaction.Commit();
// ReSharper restore PossibleNullReferenceException
            _mPossibleTransaction.Dispose();
            _mPossibleTransaction = null;
        }

        public void TranRollback()
        {
            ErrorHelper.AssertPreCondition(_mPossibleTransaction != null, "Transaction not yet started.");
// ReSharper disable PossibleNullReferenceException
            _mPossibleTransaction.Rollback();
// ReSharper restore PossibleNullReferenceException
            _mPossibleTransaction.Dispose();
            _mPossibleTransaction = null;
        }

        private static SqlConnection GetSqlConnection(string strServer, string strDatabase, string dbUserName, string dbPassword)
        {
            string strConnection;
            if (String.IsNullOrEmpty(dbUserName))
            {
                const string netConnectionStringTemplateTrusted = "Server={0};Database={1};Trusted_Connection=true";
                strConnection = String.Format(netConnectionStringTemplateTrusted, strServer, strDatabase);
            }
            else
            {
                const string netConnectionStringTemplateWithUsernameAndPassword = "Server={0};Database={1};User ID={2};Password={3}";
                strConnection = String.Format(netConnectionStringTemplateWithUsernameAndPassword, strServer, strDatabase, dbUserName, dbPassword);
            }
            var returnObject = new SqlConnection(strConnection);
            returnObject.Open();
            // for allowing spatial interesects in the Aries etl
            using(var command = new SqlCommand("SET QUOTED_IDENTIFIER ON", returnObject))
            {
                command.ExecuteNonQuery();
            }
            return returnObject;
        }

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
            if (_mObjConnection != null)
            {
                if (_mObjConnection.State == ConnectionState.Open)
                {
                    _mObjConnection.Close();
                }
                _mObjConnection.Dispose();
                _mObjConnection = null;
            }
            if (_mPossibleTransaction != null)
            {
                _mPossibleTransaction.Dispose(); // rollback if needed
                _mPossibleTransaction = null;
            }
		}

	    /// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private bool CheckInvariants()
		{
			bool retVal = (_mObjConnection.State == ConnectionState.Open);
    
			retVal = retVal && (_mStrServer != "");
			retVal = retVal && (_mStrDatabase != "");

			return retVal;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strCommandText"></param>
		public void ExecuteNonQuery(string strCommandText)
		{
            using (var sqlCommand = (_mPossibleTransaction == null) ? new SqlCommand(strCommandText, _mObjConnection) : new SqlCommand(strCommandText, _mObjConnection, _mPossibleTransaction))
            {
                sqlCommand.CommandTimeout = (int)TimeSpan.FromHours(1).TotalSeconds;
                sqlCommand.ExecuteNonQuery();
            }
		}

	    /// <summary>
		/// 
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
        public DataTable ExecuteDataTable(string strSQL)
		{
			var dataTable = new DataTable();
            using (var objAdapt = new SqlDataAdapter(strSQL, _mObjConnection))
            {
                objAdapt.Fill(dataTable);
            }
		    return dataTable;
		}

		/// <summary>
		/// 
		/// </summary>
		public void DropExecutableObjects()
		{
		    ErrorHelper.Assert(CheckInvariants());

		    var results = ExecuteDataTable(LookupSqlForAllObjects());

		    var dropSqlScript = new StringBuilder();
		    foreach (DataRow row in results.Rows)
		    {
		        var objectType = (string) row["ObjectType"];
		        var objectSchema = (string) row["ObjectSchema"];
		        var objectName = (string) row["ObjectName"];
		        dropSqlScript.AppendLine(string.Format("DROP {0} [{1}].[{2}]", objectType, objectSchema, objectName));
		    }
		    var dropAllObjects = dropSqlScript.ToString();
		    if(!string.IsNullOrEmpty(dropAllObjects))
                ExecuteNonQuery(dropAllObjects);
		}

	    public static string LookupSqlForAllObjects()
        {
            const string resource = "Toad.WebInstaller.Database.DatabaseUtil.ListAllUserExecutableObjectsSpTrUdfVw.sql";
            return FileHelper.ReadStringFromResource(resource);
        }
	}
}
