﻿/*-----------------------------------------------------------------------
<copyright file="CostAuthorityIndexViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.CostAuthority
{
    public class CostAuthorityIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData AgrementIndexViewPageContentViewData { get; }
        public CostAuthorityGridSpec CostAuthorityGridSpec { get; }
        public string CostAuthorityGridName { get; }
        public string CostAuthorityGridDataUrl { get; }
        public bool HasCostAuthorityManagePermissions { get; }
        public string NewUrl { get; }

        public CostAuthorityIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetCostAuthorityNamePluralized();

            HasCostAuthorityManagePermissions = new CostAuthorityManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            CostAuthorityGridSpec = new CostAuthorityGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = MultiTenantHelpers.GetCostAuthorityName(),
                ObjectNamePlural = MultiTenantHelpers.GetCostAuthorityNamePluralized(),
                SaveFiltersInCookie = true
            };

            NewUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(c => c.NewCostAuthority());

            CostAuthorityGridName = "CostAuthoritiesGrid";
            CostAuthorityGridDataUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(c => c.CostAuthorityGridJsonData());

            AgrementIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}
