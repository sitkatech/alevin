/*-----------------------------------------------------------------------
<copyright file="InvestmentByFundingOrganizationTypeViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Results
{
    public class BiOpAnnualReportViewData : FirmaViewData
    {
       
        public BiOpAnnualReportGridSpec BiOpAnnualReportGridSpec { get; set; }
        public string BiOpAnnualReportGridName { get; set; }
        public string BiOpAnnualReportGridDataUrl { get; set; }
        public string BiOpAnnualReportFullGridDownloadUrl { get; set; }

        public BiOpAnnualReportViewData(FirmaSession currentFirmaSession, 
            ProjectFirmaModels.Models.FirmaPage firmaPage, 
            TenantAttribute tenantAttribute,
            List<GeospatialAreaType> geoSpatialAreasToInclude, 
            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasuresToInclude) 
            : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "BiOp Annual Report";

            BiOpAnnualReportGridSpec = new BiOpAnnualReportGridSpec(geoSpatialAreasToInclude, performanceMeasuresToInclude, GridOutputFormat.Html)
            {
                ObjectNameSingular = "Report Row",
                ObjectNamePlural = "Report Rows",
                SaveFiltersInCookie = true
            };

            BiOpAnnualReportGridName = "BiOpAnnualReportGrid";
            BiOpAnnualReportGridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(c => c.BiOpAnnualReportGridJsonData());
            BiOpAnnualReportFullGridDownloadUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(c => c.BiOpAnnualReportGridCsvDownload());
        }
    }
}
