﻿/*-----------------------------------------------------------------------
<copyright file="ImportGdbFileViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class ImportEtlExcelFileViewData
    {
        public readonly string SupportedFileExtensionsCommaSeparated;
        public readonly List<string> SupportedFileExtensions;
        public string UploadFormID { get; set; }
        public readonly string NewEtlExcelUploadUrl;
        
        public readonly ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForArcGISFileGeodatabase;
        public readonly ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForKMLFile;

        public ImportEtlExcelFileViewData(string uploadFormId, string newEtlExcelUploadUrl)
        {
            UploadFormID = uploadFormId;
            NewEtlExcelUploadUrl = newEtlExcelUploadUrl;

            SupportedFileExtensions = new List<string> { "xlsx"};
            SupportedFileExtensionsCommaSeparated = string.Join(", ", SupportedFileExtensions.OrderBy(x => x));
            FieldDefinitionForArcGISFileGeodatabase = FieldDefinitionEnum.ArcGISFileGeodatabase.ToType();
            FieldDefinitionForKMLFile = FieldDefinitionEnum.KMLFile.ToType();
        }
    }
}