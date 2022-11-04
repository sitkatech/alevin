﻿/*-----------------------------------------------------------------------
<copyright file="ManageViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.PerformanceMeasureGroup;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class ManageViewData : FirmaViewData
    {        
        public PerformanceMeasureGridSpec PerformanceMeasureGridSpec{ get; }
        public string PerformanceMeasureGridName{ get; }
        public string PerformanceMeasureGridDataUrl{ get; }
        public string EditSortOrderUrl { get; }
        public bool HasPerformanceMeasureManagePermissions { get; }
        public string NewPerformanceMeasureUrl { get; }
        public PerformanceMeasureGroupGridSpec PerformanceMeasureGroupGridSpec { get; }
        public string PerformanceMeasureGroupGridName { get; }
        public string PerformanceMeasureGroupGridDataUrl { get; }
        public string NewPerformanceMeasureGroupUrl { get; }

        public ManageViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Manage {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}";

            HasPerformanceMeasureManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            PerformanceMeasureGridSpec = new PerformanceMeasureGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = MultiTenantHelpers.GetPerformanceMeasureName(),
                ObjectNamePlural = MultiTenantHelpers.GetPerformanceMeasureNamePluralized(),
                SaveFiltersInCookie = true
            };

            NewPerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.New());
            NewPerformanceMeasureGroupUrl = SitkaRoute<PerformanceMeasureGroupController>.BuildUrlFromExpression(c => c.New());

            PerformanceMeasureGridSpec.CustomExcelDownloadLinkText = $"Download with {FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabelPluralized()}";
            PerformanceMeasureGridSpec.CustomExcelDownloadUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());

            PerformanceMeasureGridName = "performanceMeasuresGrid";
            PerformanceMeasureGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.PerformanceMeasureGridJsonData());
            EditSortOrderUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.EditSortOrder());

            PerformanceMeasureGroupGridSpec = new PerformanceMeasureGroupGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.PerformanceMeasureGroup.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.PerformanceMeasureGroup.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureGroupGridName = "performanceMeasureGroupsGrid";
            PerformanceMeasureGroupGridDataUrl = SitkaRoute<PerformanceMeasureGroupController>.BuildUrlFromExpression(c => c.PerformanceMeasureGroupGridJsonData());
        }
    }
}
