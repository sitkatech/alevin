﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.DocumentLibrary
{
    public class IndexViewData : FirmaViewData
    {
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public bool HasDocumentLibraryManagePermissions { get; }
        public string NewUrl { get; }

        public IndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Document Libraries";

            HasDocumentLibraryManagePermissions = new DocumentLibraryManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            GridSpec = new IndexGridSpec(HasDocumentLibraryManagePermissions)
            {
                ObjectNameSingular = "Document Library",
                ObjectNamePlural = "Document Libraries",
                SaveFiltersInCookie = true,
            };

            GridName = "documentLibrariesGrid";
            GridDataUrl = SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            NewUrl = SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(tc => tc.New());
        }
    }
}
