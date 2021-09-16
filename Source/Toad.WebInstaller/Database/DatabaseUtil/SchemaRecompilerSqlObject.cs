using System;
using System.IO;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
	public class SchemaRecompilerSqlObject
	{
		public readonly string SqlObjectName;
	    public readonly FileInfo OriginalFile;
	    public readonly string SqlScriptText;
		public bool HasScriptExecutedSuccessfully;
		public Exception LastException;

	    public bool HasException
	    {
            get { return LastException != null; }
	    }

	    public SchemaRecompilerSqlObject(string sqlObjectName, FileInfo originalFile, string sqlScriptText)
		{
			SqlObjectName = sqlObjectName;
	        OriginalFile = originalFile;
	        SqlScriptText = sqlScriptText;
			HasScriptExecutedSuccessfully = false;
			LastException = null;
		}

	    public string GetErrorMessage()
		{
            if(!HasException)
            {
			    return String.Empty;
			}

	        return String.Format("Object: [{0}]\r\nError Description:\r\n{1}", SqlObjectName, LastException);
		}
	}
}