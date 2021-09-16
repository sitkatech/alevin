using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
	public class SchemaRecompiler
	{
		private readonly SqlServer _destServer;
        private readonly List<SchemaRecompilerSqlObject> _sqlScripts;
        private readonly Action<string> _logFunction;

		public SchemaRecompiler(DirectoryInfo sourceDirectoryInfo, SqlServer objDestServer, Action<string> logFunction)
		{
			_destServer = objDestServer;
            Log(String.Format("{0} Loading executable Objects from {1} executing on machine {2} at {3}", GetType().Name, sourceDirectoryInfo.FullName, Environment.MachineName,  DateTime.Now));
			_sqlScripts = LoadExecutableObjects(sourceDirectoryInfo);
		    _logFunction = logFunction;
            CheckInvariants();
		}

        private void Log(string message)
        {
            if (_logFunction != null)
            {
                _logFunction(message);
            }
        }

        private static List<SchemaRecompilerSqlObject> LoadExecutableObjects(DirectoryInfo sourceDirectoryInfo)
		{
			var objectNameFileContents = FileHelper.LoadSqlObjectsFromDisk(sourceDirectoryInfo);
            var sqlScriptsInFilenameOrder = objectNameFileContents.Select(x => new SchemaRecompilerSqlObject(x.Key, x.Value.File, x.Value.FileContents)).OrderBy(x => x.OriginalFile.FullName, StringComparer.InvariantCultureIgnoreCase).ToList();
            return sqlScriptsInFilenameOrder;
		}

		private void CheckInvariants()
		{
            ErrorHelper.Assert(_destServer != null, "The destination SQL Server is set to null.");
		}

		public void RecompileExecutableObjects(bool dropDbExecutableObjects, bool retryCompiles, bool dropConstraints)
		{
            CheckInvariants();
    
			// Clear out all executable objects in the target server
			if(dropDbExecutableObjects)
			{
                Log(String.Format("{0} Dropping executable Objects on machine {1} at {2}", GetType().Name, Environment.MachineName, DateTime.Now));
				_destServer.DropExecutableObjects();
			}

			var countRemaining = _sqlScripts.Count;
			var hasAtLeastOneScriptRunSuccessfully = true;
			var iterationCount = 0;

            if (dropConstraints)
            {
                Log(String.Format("{0} Disabling Database Constraints on machine {1} at {2}", GetType().Name, Environment.MachineName, DateTime.Now));
                DisableDatabaseConstraints();
            }

		    try
            {
                // Keep trying to script stuff while there are objects to be scripted
                // and while with each iteration something is getting scripted
                while (countRemaining > 0 && hasAtLeastOneScriptRunSuccessfully)
                {
                    _sqlScripts.Where(x => !x.HasScriptExecutedSuccessfully).ToList().ForEach(ExecuteSqlSafe);
                    var countAfterThisRun = _sqlScripts.Count(x => !x.HasScriptExecutedSuccessfully);
                    hasAtLeastOneScriptRunSuccessfully = countAfterThisRun < countRemaining;

                    countRemaining = countAfterThisRun;
                    iterationCount++;
                    if (!retryCompiles) break;
                }
            }
            finally
            {
                if (dropConstraints)
                {
                    Log(String.Format("{0} Re-enabling Database Constraints on machine {1} at {2}", GetType().Name, Environment.MachineName, DateTime.Now));
                    EnableDatabaseConstraints();
                }
            }

		    // If everything worked well...
		    if (countRemaining == 0)
		    {
		        return;
		    }

		    // Else some scripts didn't work out, raise an error
		    var erroredObjects = _sqlScripts.Where(x => x.HasException).ToList();
		    var iterationMessage = (retryCompiles) ? string.Format("Iterated for {0} times and got stuck. ", iterationCount) : string.Empty;
		    var strErrorMessage = string.Format("{0}Could not run {1} out of {2} database scripts.", iterationMessage, erroredObjects.Count, _sqlScripts.Count); 

		    var erroredObjectNamesAsStringList = String.Join(", ", erroredObjects.Select(x => x.SqlObjectName));
		    var allObjectErrorDetails = String.Join("\r\n\r\n", erroredObjects.Select(x => x.GetErrorMessage()));
		    strErrorMessage += string.Format("\r\nFailed Scripts: {0}\r\n\r\nDetails:\r\n\r\n{1}", erroredObjectNamesAsStringList, allObjectErrorDetails);
            Log(String.Format("{0} Error messages from exception: {1} at {2}", GetType().Name, strErrorMessage, DateTime.Now));

		    throw new Exception(strErrorMessage);
		}

	    private void EnableDatabaseConstraints()
	    {
            _destServer.ExecuteNonQuery(@"exec sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'");
            _destServer.ExecuteNonQuery("exec sp_msforeachtable 'ALTER TABLE ? ENABLE TRIGGER ALL'");
            _destServer.ExecuteNonQuery("DBCC CHECKCONSTRAINTS WITH ALL_CONSTRAINTS");
        }

	    private void DisableDatabaseConstraints()
	    {
            _destServer.ExecuteNonQuery(@"exec sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            _destServer.ExecuteNonQuery("exec sp_msforeachtable 'ALTER TABLE ? DISABLE TRIGGER ALL'");
	    }

	    private void ExecuteSqlSafe(SchemaRecompilerSqlObject objSqlRecompilerObject)
		{
            Log(String.Format("{0} Executing {1} at {2}", GetType().Name, objSqlRecompilerObject.OriginalFile.FullName, DateTime.Now));
			Exception myException;
            var objSqlExecuteSafe = new SqlExecuteSafe();
			objSqlRecompilerObject.HasScriptExecutedSuccessfully = objSqlExecuteSafe.TryExecuteNonQuery(_destServer, objSqlRecompilerObject.SqlScriptText, out myException);
			objSqlRecompilerObject.LastException = myException;
		}
	}
}