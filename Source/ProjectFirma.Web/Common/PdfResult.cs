﻿/*-----------------------------------------------------------------------
<copyright file="PdfResult.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.IO;
using System.Web;
using System.Web.Mvc;
using ProjectFirmaModels.Models;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    public class PdfResult : FileResourceResult
    {
        public PdfResult(FileResourceInfo fileResourceInfo) : base(fileResourceInfo.GetOriginalCompleteFileName(), fileResourceInfo.FileResourceData.Data, FileResourceMimeType.PDF)
        {
            Check.Require(fileResourceInfo.FileResourceMimeType == FileResourceMimeType.PDF, "Only a real PDF file can be saved off as PDF");
            ConstructorImpl(fileResourceInfo.GetOriginalCompleteFileName());
        }

        private void ConstructorImpl(string fileName)
        {
            Check.Require(fileName.ToLower().EndsWith(".pdf"), "PDF files should end with the file extension .pdf or downloaded file will be tricky to open");
        }

        /// <summary> 
        /// Execute the Result. 
        /// </summary> 
        /// <param name="context">Controller context.</param> 
        public override void ExecuteResult(ControllerContext context)
        {
            WriteStream(MemoryStream, Filename, FileResourceMimeType);
        }

        /// <summary> 
        /// Writes the memory stream to the browser. 
        /// </summary>
        /// <param name="memoryStream">Memory stream.</param>
        /// <param name="fileName"></param>
        /// <param name="fileResourceMimeType"></param>
        private static void WriteStream(MemoryStream memoryStream, string fileName, FileResourceMimeType fileResourceMimeType)
        {
            var context = HttpContext.Current;
            context.Response.Clear();

            context.Response.AddHeader("Content-Type", fileResourceMimeType.FileResourceMimeTypeContentTypeName);

            context.Response.AddHeader("Content-Disposition", $"inline;filename=\"{fileName}\"");
            context.Response.AddHeader("Content-Length", memoryStream.Length.ToString());
            memoryStream.WriteTo(context.Response.OutputStream);
            memoryStream.Close();
            context.Response.End();
        }
    }
}
