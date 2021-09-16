using System.IO;
using System.Text.RegularExpressions;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    public class SqlFileInfo
    {
        public readonly FileInfo SqlFile;
        public readonly string FileContents;
        private static readonly Regex _sqlFileRegex = new Regex(@"^.*\.sql$", RegexOptions.Singleline | RegexOptions.Compiled);

        public static bool IsFileMatch(FileInfo file)
        {
            return _sqlFileRegex.IsMatch(file.Name);
        }

        public SqlFileInfo(FileInfo sqlFile)
        {
            SqlFile = sqlFile;
            FileContents = FileHelper.ReadAllTextCheckingForProperEncoding(sqlFile.FullName);
        }
    }
}