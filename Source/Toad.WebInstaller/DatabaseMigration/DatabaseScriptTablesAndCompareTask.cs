using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Toad.WebInstaller.Database.DatabaseUtil;

namespace Toad.WebInstaller.DatabaseMigration
{
    /// <summary>
    /// Compares that database tables match a set of files on disk by scripting out tables via Sql Server SMO and comparing
    /// </summary>
    public class DatabaseScriptTablesAndCompareTask
    {
        private readonly DirectoryInfo _sourceDirectory;
        private readonly string _databaseServer;
        private readonly string _databaseName;
        private readonly Action<string> _loggerFunc;

        public DatabaseScriptTablesAndCompareTask(DirectoryInfo sourceDirectory, string databaseServer, string databaseName, Action<string> loggerFunc)
        {
            _sourceDirectory = sourceDirectory;
            _databaseServer = databaseServer;
            _databaseName = databaseName;
            _loggerFunc = loggerFunc;
        }

        public void AssertTablesMatch()
        {
            try
            {
                // Must have SourceDirectory, the directory must exist
                ErrorHelper.AssertPreCondition(Directory.Exists(_sourceDirectory.FullName), string.Format("source-directory \"{0}\" was not found.", _sourceDirectory.FullName));

                var tempDirectory = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
                Directory.CreateDirectory(tempDirectory.FullName);

                var tableScripter = new DatabaseTableScripter(tempDirectory, _databaseServer, _databaseName, _loggerFunc);
                tableScripter.ScriptToDisk();

                // compare all files in tempDirectory and sourceDirectory
                CompareOriginalToScriptedFiles(tempDirectory);
            }
            catch (Exception e)
            {
                const string errorTemplate = "Exception occurred while executing sourceDirectory=\"{0}\" databaseServer=\"{1}\" databaseName=\"{2}\" {3}";
                var message = String.Format(errorTemplate, _sourceDirectory, _databaseServer, _databaseName, e);
                throw new Exception(message);
            }
        }

        private void CompareOriginalToScriptedFiles(DirectoryInfo tempDirectory)
        {
            var scriptedFileInfos = tempDirectory.GetFiles();
            var originalFileInfos = _sourceDirectory.GetFiles();

            var scriptedFileNames = scriptedFileInfos.Select(x => x.Name).ToList();
            var originalFileNames = originalFileInfos.Select(x => x.Name).ToList();

            var extraFileNames = scriptedFileNames.Except(originalFileNames).ToList();
            var missingFileNames = originalFileNames.Except(scriptedFileNames).ToList();
            var differentFileNames = new List<string>();

            foreach (var scriptedFile in scriptedFileInfos)
            {
                var originalFiles = _sourceDirectory.GetFiles(scriptedFile.Name);
                if (originalFiles.Length > 0)
                {
                    var strFilename = scriptedFile.FullName;
                    var scriptedFileContents = FileHelper.ReadAllTextCheckingForProperEncoding(strFilename);
                    var strFilename1 = originalFiles[0].FullName;
                    var originalFileContents = FileHelper.ReadAllTextCheckingForProperEncoding(strFilename1);

                    if (scriptedFileContents != originalFileContents)
                    {
                        differentFileNames.Add(scriptedFile.Name);
                    }
                }
            }

            if (extraFileNames.Any() || missingFileNames.Any() || differentFileNames.Any())
            {
                var extraMessage = extraFileNames.Any() ? "New Tables: " + String.Join(", ", extraFileNames) : String.Empty;
                var missingMessage = missingFileNames.Any() ? "Missing Tables: " + String.Join(", ", missingFileNames) : String.Empty;
                var differentMessage = differentFileNames.Any() ? "Differing Tables: " + String.Join(", ", differentFileNames) : String.Empty;
                var message = string.Format("Build failed with differing scripted tables to expected tables:\r\n{0}\r\n{1}\r\n{2}", extraMessage, missingMessage, differentMessage);
                throw new Exception(message);
            }
        }
    }
}
