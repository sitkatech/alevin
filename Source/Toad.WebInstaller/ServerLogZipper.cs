using System.IO;
using System.IO.Compression;

namespace Toad.WebInstaller
{
    /// <summary>
    /// Zips up all files in given directory, returns in-memory zip file for output
    /// </summary>
    public class DirectoryZipper
    {
        public static MemoryStream CreateZipPackage(DirectoryInfo directoryToZip)
        {
            // Make temp file to zip into (we need a real file just for the zipping)
            var tempZipFilenamePath = Path.GetTempFileName() + ".zip";

            // Zip up the given directory
            ZipFile.CreateFromDirectory(directoryToZip.FullName, tempZipFilenamePath);

            // Turn zipfile into an in-memory file
            var inMemoryZipFile = new MemoryStream();
            using (FileStream zipFileStream = File.OpenRead(tempZipFilenamePath))
            {
                zipFileStream.CopyTo(inMemoryZipFile);
            }

            // Clean up temp file
            File.Delete(tempZipFilenamePath);
            
            // Rewind the stream to the start for the convenience of users who will want the file data
            inMemoryZipFile.Seek(0, SeekOrigin.Begin);

            // Return the in-memory file
            return inMemoryZipFile;
        }
    }
}
