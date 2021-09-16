using System.Collections;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
	/// <summary>
	/// Summary description for DatabaseServerCollection.
	/// </summary>
	public class DatabaseServerDict : DictionaryBase
	{
		public void Add(string key, DatabaseServer value)
		{
			Dictionary.Add(key, value);
		}

		public void Remove(string key)
		{
			Dictionary.Remove(key);
		}

		public bool Contains(string key)
		{
			return Dictionary.Contains(key);
		}

		public DatabaseServer this[string strIndex]
		{
			get
			{
				return (DatabaseServer)base.Dictionary[strIndex];
			}
			set
			{
				base.Dictionary[strIndex] = value;
			}
		}

		public new DatabaseServerDictEnumerator GetEnumerator()
		{
			return new DatabaseServerDictEnumerator(base.GetEnumerator());
		}
	}

	public class DatabaseServerDictEnumerator
	{
		private IDictionaryEnumerator m_objBaseEnum;
		public DatabaseServerDictEnumerator(IDictionaryEnumerator objEnum)
		{
			m_objBaseEnum = objEnum;
		}

		public DatabaseServer Current
		{
			get
			{
				return (DatabaseServer)m_objBaseEnum.Value;
			}
		}

		public string Key
		{
			get
			{
				return (string)m_objBaseEnum.Key;
			}
		}

		public bool MoveNext()
		{
			return m_objBaseEnum.MoveNext();
		}

		public void Reset()
		{
			m_objBaseEnum.Reset();
		}
	}
}
