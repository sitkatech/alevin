/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using ProjectFirma.Web.Views.Shared.SubprojectTimeline;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;


namespace ProjectFirma.Web.Views.Subproject
{
    public class DetailViewData : SubprojectViewData
    {
        public bool UserHasManageSubprojectPermissions { get; }

        public bool PerformanceMeasureActualFromSubprojectManageFeature { get; }

        public string EditSubprojectUrl { get; }

        public List<GeospatialAreaType> GeospatialAreaTypes { get; }

        public SubprojectBasicsViewData SubprojectBasicsViewData { get; }

        public string EditSubprojectPerformanceMeasureExpectedsUrl { get; }

        public PerformanceMeasureExpectedSummaryViewData PerformanceMeasureExpectedSummaryViewData { get; }

        public PerformanceMeasureReportedValuesGroupedViewData PerformanceMeasureReportedValuesGroupedViewData { get; }
        public string EditPerformanceMeasureActualsUrl { get; }

        public EntityNotesViewData SubprojectNotesViewData { get; }
        public EntityNotesViewData InternalNotesViewData { get; }

        public List<ProjectStage> SubprojectStages { get; }

        public string SubprojectListUrl { get; }

        public SubprojectTimelineDisplayViewData SubprojectTimelineDisplayViewData { get; }


        public string UpdateStatusUrl { get; set; }

        public DetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Subproject subproject,
            List<ProjectStage> subprojectStages,
            SubprojectBasicsViewData subprojectBasicsViewData,
            bool userHasManageSubprojectPermissions,
            string editPerformanceMeasureExpectedsUrl,
            string editPerformanceMeasureActualsUrl,
            PerformanceMeasureExpectedSummaryViewData performanceMeasureExpectedSummaryViewData,
            PerformanceMeasureReportedValuesGroupedViewData performanceMeasureReportedValuesGroupedViewData,
            EntityNotesViewData subprojectNotesViewData,
            EntityNotesViewData internalNotesViewData,
            bool performanceMeasureActualFromSubprojectManageFeature)
            : base(currentFirmaSession, subproject)
        {
            EditSubprojectUrl =
                SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Edit(subproject.PrimaryKey));

            SubprojectStages = subprojectStages;
            UserHasManageSubprojectPermissions = userHasManageSubprojectPermissions;
            var proposedSubprojectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Detail(Subproject.Project.PrimaryKey)) + "#subprojects";
            SubprojectListUrl = proposedSubprojectListUrl;
            SubprojectBasicsViewData = subprojectBasicsViewData;
            EditSubprojectPerformanceMeasureExpectedsUrl = editPerformanceMeasureExpectedsUrl;
            PerformanceMeasureExpectedSummaryViewData = performanceMeasureExpectedSummaryViewData;
            EditPerformanceMeasureActualsUrl = editPerformanceMeasureActualsUrl;
            PerformanceMeasureReportedValuesGroupedViewData = performanceMeasureReportedValuesGroupedViewData;
            SubprojectNotesViewData = subprojectNotesViewData;
            InternalNotesViewData = internalNotesViewData;
            PerformanceMeasureActualFromSubprojectManageFeature = performanceMeasureActualFromSubprojectManageFeature;
            var projectStatusesForLegend = HttpRequestStorage.DatabaseEntities.ProjectStatuses.OrderBy(ps => ps.ProjectStatusSortOrder).ToList();
            var projectStatusLegendDisplayViewData = new ProjectStatusLegendDisplayViewData(projectStatusesForLegend);
            SubprojectTimelineDisplayViewData = new SubprojectTimelineDisplayViewData(subproject,
                new SubprojectTimeline(subproject, userHasManageSubprojectPermissions,
                    userHasManageSubprojectPermissions), userHasManageSubprojectPermissions,
                projectStatusLegendDisplayViewData);

        }
    }
}
