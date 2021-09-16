namespace Toad.WebInstaller.Database.DatabaseUtil
{
	/// <summary>
	/// Summary description for DatabaseServer.
	/// </summary>
	public class DatabaseServer
	{
		private string m_strServer;
		private string m_strDatabase;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strServer"></param>
		/// <param name="strDatabase"></param>
		public DatabaseServer(string strServer, string strDatabase)
		{
			m_strServer = strServer;
			m_strDatabase = strDatabase;
		}

		/// <summary>
		/// 
		/// </summary>
		public string Server 
		{
			get
			{
				return m_strServer;
			}
			set
			{
				m_strServer = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Database
		{
			get
			{
				return m_strDatabase;
			}
			set
			{
				m_strDatabase = value;
			}
		}
	}
}
