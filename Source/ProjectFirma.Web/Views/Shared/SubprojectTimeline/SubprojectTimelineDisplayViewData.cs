﻿/*-----------------------------------------------------------------------
<copyright file="SubprojectTimelineDisplayViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Web;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;

namespace ProjectFirma.Web.Views.Shared.SubprojectTimeline
{
    public class SubprojectTimelineDisplayViewData : FirmaUserControlViewData
    {
        public Models.SubprojectTimeline SubprojectTimeline { get; }

        public HtmlString AddSubprojectProjectStatusButton { get; }
        public bool UserHasProjectStatusUpdatePermissions { get; }

        public ProjectStatusLegendDisplayViewData ProjectStatusLegendDisplayViewData { get; }
        public ProjectFirmaModels.Models.ProjectStatus CurrentProjectStatus { get; }

        public SubprojectTimelineDisplayViewData(ProjectFirmaModels.Models.Subproject subproject,
            Models.SubprojectTimeline subprojectTimeline, bool userHasProjectStatusUpdatePermissions,
            ProjectStatusLegendDisplayViewData projectStatusLegendDisplayViewData)
        {
            SubprojectTimeline = subprojectTimeline;
            UserHasProjectStatusUpdatePermissions = userHasProjectStatusUpdatePermissions && MultiTenantHelpers.GetTenantAttributeFromCache().EnableStatusUpdates;
            var updateStatusUrl = SitkaRoute<SubprojectProjectStatusController>.BuildUrlFromExpression(tc => tc.New(subproject));
            AddSubprojectProjectStatusButton =
                ModalDialogFormHelper.MakeNewIconButton(updateStatusUrl, "Update Status", true);
            ProjectStatusLegendDisplayViewData = projectStatusLegendDisplayViewData;
            CurrentProjectStatus = subproject.GetCurrentSubprojectStatus();
        }
    }
}