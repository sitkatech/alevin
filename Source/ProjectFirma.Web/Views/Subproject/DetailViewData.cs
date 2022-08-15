/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirma.Web.Views.TechnicalAssistanceRequest;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Views.ActionItem;
using ProjectFirma.Web.Views.Obligation;


namespace ProjectFirma.Web.Views.Subproject
{
    public class DetailViewData : SubprojectViewData
    {
        public bool UserHasSubprojectAdminPermissions { get; }
        public bool UserHasEditSubprojectPermissions { get; }

        public string EditSubprojectUrl { get; }

        public List<GeospatialAreaType> GeospatialAreaTypes { get; }

        public SubprojectBasicsViewData SubprojectBasicsViewData { get; }


        public List<ProjectStage> SubprojectStages { get; }

        public string SubprojectListUrl { get; }


        public string UpdateStatusUrl { get; set; }
        public DetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Subproject subproject,
            List<ProjectStage> subprojectStages,
            SubprojectBasicsViewData subprojectBasicsViewData,
            bool userHasEditSubprojectPermissions)
            : base(currentFirmaSession, subproject)
        {
            EditSubprojectUrl =
                SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Edit(subproject.PrimaryKey));

            SubprojectStages = subprojectStages;
            UserHasEditSubprojectPermissions = userHasEditSubprojectPermissions;
            var proposedSubprojectListUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(c => c.Detail(Subproject.Project.PrimaryKey)) + "#subprojects";
            SubprojectListUrl = proposedSubprojectListUrl;
            SubprojectBasicsViewData = subprojectBasicsViewData;

        }
    }
}
