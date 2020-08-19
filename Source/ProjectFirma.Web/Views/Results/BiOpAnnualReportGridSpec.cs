/*-----------------------------------------------------------------------
<copyright file="InvestmentByFundingOrganizationType.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class BiOpAnnualReportGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        private List<double> AllProjectedFundingValues;
        

        public BiOpAnnualReportGridSpec(List<GeospatialAreaType> geoSpatialAreaTypesToInclude,
            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasuresToInclude, 
            List<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriodsToInclude)
        {
            SaveFiltersInCookie = true;
            AllProjectedFundingValues = HttpRequestStorage.DatabaseEntities.Projects.ToList().Select(p => (double) p.GetProjectedFunding()).ToList();


            Add(FieldDefinitionEnum.Project.ToType().FieldDefinitionDisplayName, p => p.GetDisplayNameAsUrl(), 250);
            Add("WBS Number", p => p.CostAuthorityProjects.FirstOrDefault(cap => cap.IsPrimaryProjectCawbs)?.CostAuthority.CostAuthorityWorkBreakdownStructure, 150);
            Add("Years Included",  p => string.Join(", ", performanceMeasureReportingPeriodsToInclude.Select(x => x.PerformanceMeasureReportingPeriodCalendarYear.ToString())), 100);
            Add("Basin Liason", p => String.Join(",", p.ProjectGeospatialAreas.Select(pga => pga.GeospatialArea).ToList().GetSubbasinLiasonList().Select(pr => pr.GetFullNameFirstLast())), 100);
            // from the project location simple point. Maybe we could find a center from detailed locations if the project doesn't have a simple location? -- SMG 8/11/2020
            Add("Lat/Lng", p => $"{p.ProjectLocationPoint?.YCoordinate.ToString()} {p.ProjectLocationPoint?.XCoordinate.ToString()}", 150);

            foreach (var geospatialAreaType in geoSpatialAreaTypesToInclude)
            {
                Add(geospatialAreaType.GeospatialAreaTypeName,
                    p => String.Join(",", p.ProjectGeospatialAreas.Where(x =>
                        x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).Select(x => x.GeospatialArea.GetDisplayNameAsUrl())).ToHTMLFormattedString(), 100, DhtmlxGridColumnFilterType.Html);
            }

            // todo: verify this
            Add("Project Cost", p => p.GetProjectedFunding(), 100, DhtmlxGridColumnFormatType.Decimal);
            Add("Project Cost Category", p => p.GetProjectedFundingCategory(AllProjectedFundingValues), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);

            Add("Is BPA Funded", p => p.IsBPAFunded() ? "Yes" : "No", 50, DhtmlxGridColumnFilterType.SelectFilterStrict);

            // calendar year(s) of metric

            // sponsor organization
            //Add("Sponsor Organization", p => p.GetAssociatedOrganizationRelationships())

            // metric name/value * 6

            foreach (var performanceMeasure in performanceMeasuresToInclude)
            {
                Add(performanceMeasure.PerformanceMeasureDisplayName,
                    p => performanceMeasure.PerformanceMeasureActuals.Where(pma =>
                            pma.ProjectID == p.ProjectID &&
                            performanceMeasureReportingPeriodsToInclude.Contains(pma.PerformanceMeasureReportingPeriod))
                        .Sum(pma => pma.ActualValue), 100);
            }


        }
    }
}
