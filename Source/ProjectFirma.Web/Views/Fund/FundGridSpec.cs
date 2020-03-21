/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.Fund
{
    public class FundGridSpec : GridSpec<ProjectFirmaModels.Models.Fund>
    {
        public FundGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "Fund";
            ObjectNamePlural = "Funds";
            SaveFiltersInCookie = true;

            // FundNumber as link
            Add("Fund Number", f => UrlTemplate.MakeHrefString(f.GetDetailUrl(), f.ReclamationFundNumber), 100, DhtmlxGridColumnFilterType.Html);
            // Agreement
            Add("Fund Description", f => f.Description, 300, DhtmlxGridColumnFilterType.Text);
        }
    }
}