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

    public class BioAnnualReportRow
    {
        public ProjectFirmaModels.Models.PerformanceMeasureActual PerformanceMeasureActual { get; set; }
        public ProjectFirmaModels.Models.Project Project { get; set; }
        public GeospatialAreaType GeospatialAreaType { get; set; }

    }

    public class BiOpAnnualReportGridSpec : GridSpec<BioAnnualReportRow>
    {
        private List<double> AllProjectedFundingValues;


        public BiOpAnnualReportGridSpec(List<GeospatialAreaType> geoSpatialAreaTypesToInclude,
            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasuresToInclude)
        {
            AllProjectedFundingValues = HttpRequestStorage.DatabaseEntities.Projects.ToList().Select(p => (double)p.GetProjectedFunding() + (double)p.GetNoFundingSourceIdentifiedAmountOrZero()).ToList();

            Add("Population", barr => barr.GeospatialAreaType.GeospatialAreaTypeName, 100);
            Add(FieldDefinitionEnum.Project.ToType().FieldDefinitionDisplayName, barr => barr.Project.GetDisplayNameAsUrl(), 250, DhtmlxGridColumnFilterType.Html);
            Add("Year", barr => barr.PerformanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel, 100);
            Add("WBS Number", barr => barr.Project.CostAuthorityProjects.FirstOrDefault(cap => cap.IsPrimaryProjectCawbs)?.CostAuthority.CostAuthorityWorkBreakdownStructure, 150, DhtmlxGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.ProjectStage.ToType().FieldDefinitionDisplayName} ", barr => barr.Project.ProjectStage.ProjectStageDisplayName, 150, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Basin Liason", barr => String.Join(",", barr.Project.ProjectGeospatialAreas.Select(pga => pga.GeospatialArea).ToList().GetSubbasinLiasonList().Select(pr => pr.GetFullNameFirstLast())), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            // from the project location simple point. Maybe we could find a center from detailed locations if the project doesn't have a simple location? -- SMG 8/11/2020
            Add("Lat", barr => $"{barr.Project.ProjectLocationPoint?.YCoordinate.ToString()}", 75, DhtmlxGridColumnFilterType.Numeric);
            Add("Lng", barr => $"{barr.Project.ProjectLocationPoint?.XCoordinate.ToString()}", 75, DhtmlxGridColumnFilterType.Numeric);

            foreach (var geospatialAreaType in geoSpatialAreaTypesToInclude)
            {
                Add(geospatialAreaType.GeospatialAreaTypeName,
                    barr => String.Join(",", barr.Project.ProjectGeospatialAreas.Where(x =>
                        x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).Select(x => x.GeospatialArea.GetDisplayNameAsUrl())).ToHTMLFormattedString(), 100, DhtmlxGridColumnFilterType.Html);
            }

            Add("Project Cost", barr => (double)barr.Project.GetProjectedFunding() + (double)barr.Project.GetNoFundingSourceIdentifiedAmountOrZero(), 100, DhtmlxGridColumnFormatType.Decimal);
            Add("Project Cost Category", barr => barr.Project.GetProjectedFundingCategory(AllProjectedFundingValues), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Is BPA Funded", barr => barr.Project.IsBPAFunded() ? "Yes" : "No", 50, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Sponsor Organization", barr => barr.Project.GetPrimaryContactOrganization().OrganizationName, 150, DhtmlxGridColumnFilterType.SelectFilterStrict);

            foreach (var performanceMeasure in performanceMeasuresToInclude)
            {
                Add(performanceMeasure.PerformanceMeasureDisplayName,
                    barr => performanceMeasure.PerformanceMeasureActuals.Where(pma =>
                            pma.ProjectID == barr.Project.ProjectID && pma.PerformanceMeasureReportingPeriod == barr.PerformanceMeasureActual.PerformanceMeasureReportingPeriod)
                        .Sum(pma => pma.ActualValue), 50, DhtmlxGridColumnFormatType.Decimal);
            }
        }
    }
}
