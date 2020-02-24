/*-----------------------------------------------------------------------
<copyright file="ExcelColumnSpec.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using ClosedXML.Excel;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    using System;
    using System.IO;
    using System.Reflection;

    namespace DocumentFormat.OpenXml.Extensions
    {
        public abstract class AbstractReader
        {
            /// <summary>
            /// Returns a memory stream with a copy of a file's contents.
            /// </summary>
            public static MemoryStream StreamFromFile(string path)
            {
                byte[] buffer;

                using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[file.Length];
                    file.Read(buffer, 0, (int)file.Length);
                    file.Close();
                }

                var memory = new MemoryStream();
                memory.Write(buffer, 0, buffer.Length);

                return memory;
            }

            /// <summary>
            /// Returns a copy of an embedded resource from the project as a memory stream. 
            /// </summary>
            /// <remarks>
            /// Include any folder paths in the filename parameter.
            /// </remarks>
            public static MemoryStream GetEmbeddedResourceStream(string filename)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string[] resNames = assembly.GetManifestResourceNames();

                //foreach (string abc in resNames)
                //    Console.WriteLine(abc);

                string name = assembly.GetName().Name;

                //Oddly enough the vb.net compiler ignores the folder name, 
                //so you can only have one eg blank.xlsx in the whole project
                //This is different to the c# behaviour
                filename = filename.Replace("/", ".");
                filename = filename.Replace("\\", "."); //If this looks incorrect make sure the input is escaped correctly
                name += "." + filename;

                Stream stream = assembly.GetManifestResourceStream(name);
                if (stream == null) throw new ArgumentException(string.Format("Embedded resource with path {0} was not found.", filename));

                var buffer = new byte[(int)stream.Length];
                var memStream = new MemoryStream(buffer.Length);

                stream.Position = 0;
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();

                memStream.Write(buffer, 0, buffer.Length);

                return memStream;
            }

            /// <summary>
            /// Returns a copy of a file provided as a memory stream.
            ///</summary>
            public static MemoryStream Copy(string path)
            {
                var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                if (stream == null) throw new ApplicationException(string.Format("File with path {0} was not found.", path));

                var buffer = new byte[(int)stream.Length];
                var memStream = new MemoryStream(buffer.Length);

                stream.Position = 0;
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();

                memStream.Write(buffer, 0, buffer.Length);

                return memStream;
            }
        }
    }
}
