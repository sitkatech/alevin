/*-----------------------------------------------------------------------
<copyright file="ImportGdbFile.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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

using System.IO;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class FbmsBudgetStageImportsHelper
    {
        public static FbmsBudgetStageImports LoadFromXlsFile(Stream stream, int headerRowOffset)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(stream, FbmsBudgetStageImports.SheetName, FbmsBudgetStageImports.UseExistingSheetNameIfSingleSheetFound, headerRowOffset);
            return FbmsBudgetStageImports.LoadFromXlsFile(dataTable);
        }

        public static FbmsBudgetStageImports LoadFromXlsFile(FileInfo file, int headerRowOffset)
        {
            var dataTable = OpenXmlSpreadSheetDocument.ExcelWorksheetToDataTable(file.FullName, FbmsBudgetStageImports.SheetName, FbmsBudgetStageImports.UseExistingSheetNameIfSingleSheetFound, headerRowOffset);
            return FbmsBudgetStageImports.LoadFromXlsFile(dataTable);
        }
    }
}