using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    /// <summary>
    /// Summary description for FileHelper.
    /// </summary>
    public abstract class FileHelper
    {
        private const int RobocopyExitThreshold = 3;

        /// <summary>
        /// Reads a string out of a text stream resource embedded in this assembly
        /// </summary>
        /// <param name="resourceName">full name of the resource including assembly name and paths and filename
        /// defaultNamespace.folderName.fileName.extension
        /// </param>
        /// <returns>value of the full string of the resource</returns>
        public static string ReadStringFromResource(string resourceName)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            var scriptStream = thisAssembly.GetManifestResourceStream(resourceName);
            
            ErrorHelper.AssertPreCondition(scriptStream != null, String.Format("Resource name {0} was not found in assembly manifest.  Check resource name and compile options", resourceName));

            var script = String.Empty;
            using(var txtStream = new StreamReader(scriptStream))
            {
                script = txtStream.ReadToEnd();
            }

            return script;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFolder"></param>
        /// <param name="strFilenamePattern"></param>
        /// <returns></returns>
        public static StringCollection FindFiles(string strFolder, string strFilenamePattern)
        {
            var arrFiles = Directory.GetFiles(strFolder);
            var objRegExp = new Regex(strFilenamePattern, RegexOptions.IgnoreCase);
            var colFiles = new StringCollection();

            foreach (string strFile in arrFiles)
            {
                if (objRegExp.Match(strFile).Success)
                    colFiles.Add(strFile);
            }		    
            
            var arrDirectories = Directory.GetDirectories(strFolder);
            foreach (string strSubFolder in arrDirectories)
            {
                StringCollection colFilesSubfolder = new StringCollection();
                colFilesSubfolder = FindFiles(strSubFolder, strFilenamePattern);
                                
                foreach (string strFile in colFilesSubfolder)
                    colFiles.Add(strFile);
            }		    
            
            return colFiles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static StringCollection GetFilesRecursive(string strPath)
        {
            return GetFilesRecursive(strPath, "*.*");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="strPattern"></param>
        /// <returns></returns>
        public static StringCollection GetFilesRecursive(string strPath, string strPattern)
        {
            var myFiles = new StringCollection();
            var objInfo = new DirectoryInfo(strPath);
            var objDirectories = objInfo.GetDirectories();

            foreach (var objChild in objDirectories)
            {
                var colFiles = GetFilesRecursive(objChild.FullName, strPattern);
                foreach (var strTemp in colFiles)
                    myFiles.Add(strTemp);
            }

            FileInfo[] objFiles = objInfo.GetFiles(strPattern);
            foreach (FileInfo objFile in objFiles)
                myFiles.Add(objFile.FullName);

            return myFiles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDirectory"></param>
        /// <param name="objAttribs"></param>
        public static void RemoveAttributesRecursive(string strDirectory, FileAttributes objAttribsToRemove)
        {
            DirectoryInfo objInfo = new DirectoryInfo(strDirectory);
            
            DirectoryInfo[] objChildren = objInfo.GetDirectories();
            foreach (DirectoryInfo objChild in objChildren)
                RemoveAttributesRecursive(objChild.FullName, objAttribsToRemove);

            FileInfo[] objFiles = objInfo.GetFiles();
            foreach (FileInfo objFile in objFiles)
                objFile.Attributes = (objFile.Attributes & (~objAttribsToRemove));

            objInfo.Attributes = (objInfo.Attributes & (~objAttribsToRemove));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="strDest"></param>
        /// <param name="blnRecurse"></param>
        public static void CopyDirectoryContents(string strSource, string strDest, bool blnRecurse)
        {
            if (blnRecurse)
            {
                // TODO: Implement the recursive copy...
                throw (new Exception("Not implemented!"));
            }
            
            string[] arrFiles = Directory.GetFiles(strSource);
            foreach (string strFile in arrFiles)
            {
                string strCopyTo = String.Format(@"{0}\{1}", strDest, Path.GetFileName(strFile));
                File.Copy(strFile, strCopyTo, true);
            }
        }
        public static void CopyDirectoryContents(string strSource, string strDest)
        {
            CopyDirectoryContents(strSource, strDest, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        public static string PathCombine(string path1, string path2)
        {
            string fixedPath2;

            if (path2.Substring(0, 1) == @"\")
                fixedPath2 = path2.Substring(1);
            else
                fixedPath2 = path2;

            return Path.Combine(path1, fixedPath2);
        }

        public class FileAndFileContents
        {
            public FileAndFileContents(FileInfo file, string fileContents)
            {
                File = file;
                FileContents = fileContents;
            }

            public readonly FileInfo File;
            public readonly string FileContents;
        }

        public static Dictionary<string, FileAndFileContents> LoadSqlObjectsFromDisk(DirectoryInfo directoryInfo)
        {
            var dict = new Dictionary<string, FileAndFileContents>(StringComparer.InvariantCultureIgnoreCase);
            LoadSqlObjectsFromDiskRecursively(directoryInfo, dict);
            return dict;
        }

        private static void LoadSqlObjectsFromDiskRecursively(DirectoryInfo directoryInfo, Dictionary<string, FileAndFileContents> dict)
        {
            foreach(var fileInfo in directoryInfo.GetFiles())
            {
                if (!IsValidSqlFile(fileInfo.Name))
                {
                    continue;
                }
                var cleanObjectName = GetCleanObjectName(fileInfo);
                if (dict.ContainsKey(cleanObjectName))
                {
                    throw new Exception(String.Format("Found two sql objects with the same name \"{0}\". Second file: \"{1}\"", cleanObjectName, fileInfo.FullName));
                }
                dict.Add(cleanObjectName, new FileAndFileContents(fileInfo, ReadAllTextCheckingForProperEncoding(fileInfo.FullName)));
            }
            foreach(var childDirectoryInfo in directoryInfo.GetDirectories())
            {
                LoadSqlObjectsFromDiskRecursively(childDirectoryInfo, dict);
            }
        }


        private static bool IsValidSqlFile(string fileName)
        {
            //Only run files with the following extension: sql,prc,viw,udf,trg	
            string ext = Path.GetExtension(fileName);
            if (!(ext == null) || !(ext == ""))
            {
                ext = ext.ToLower();
            }
            switch(ext) 
            { 
                case ".sql": 
                    return true; 
                case ".prc": 
                    return true; 
                case ".viw": 
                    return true; 
                case ".udf": 
                    return true; 
                case ".trg":
                    return true;
                default: 
                    return false;
            } 
        }

        private static string GetCleanObjectName(FileInfo fileInfo)
        {
            string name = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            var prefix = "dbo.";
            if(name.StartsWith(prefix))
            {
                name = name.Remove(0, prefix.Length);
            }
            return name;
        }

        public static bool UpdateFileOnlyOnChange(FileInfo originalFile, string newFileContents)
        {
            var updated = false;
            if (!File.Exists(originalFile.FullName) || newFileContents != ReadAllTextCheckingForProperEncoding(originalFile.FullName))
            {
                File.WriteAllText(originalFile.FullName, newFileContents);
                updated = true;
            }

            return updated;
        }

        public static string ReadAllTextCheckingForProperEncoding(string fileName)
        {
            // Assume UTF-8/UTF-32 encoding
            var fileContents = File.ReadAllText(fileName);

            const char replacementChar = '\xFFFD';

            if (fileContents.Contains(replacementChar.ToString()))
            {
                throw new ApplicationException(String.Format("File encoding read failure on file \"{0}\" - found unicode replacement character U+FFFD � in file contents.​\r\nThis can happen if file is encoded in Windows Code Page 1252 and contains high order characters.\r\nTry saving the file with an explicit UTF encoding (such as UTF-8 with signature - BOM) or replacing high order characters in the file (such as ‘ ’ — “ ” – … ) with lower order equivalents.", fileName));
            }

            return fileContents;
        }
    }

}
