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

using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.ProjectCustomGrid;

namespace ProjectFirma.Web.Views.Project
{
    public class IndexViewData : FirmaViewData
    {
        public ProjectCustomGridSpec ProjectCustomFullGridSpec { get; }
        public string ProjectCustomFullGridName { get; }
        public string ProjectCustomFullGridDataUrl { get; }

        public string ProposeNewProjectUrl { get; }
        public string ProjectUpdatesUrl { get; }
        public bool DisplayActionButtons { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, List<ProjectCustomGridConfiguration> projectCustomFullGridConfigurations) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Full {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} List";
            var projectDetails = HttpRequestStorage.DatabaseEntities.vProjectDetails.ToDictionary(x => x.ProjectID);
            ProjectCustomFullGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomFullGridConfigurations, ProjectCustomGridType.Full.ToEnum, projectDetails, currentFirmaSession.Tenant) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            if (new ProjectCreateFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                ProjectCustomFullGridSpec.CustomExcelDownloadUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload()); // TODO:
            }
            else if (currentFirmaSession.Role.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID)
            {
                ProjectCustomFullGridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.DenyCreateProject()), $"New {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
            }
            ProjectCustomFullGridName = "projectsGrid";
            ProjectCustomFullGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.AllActiveProjectsCustomGridFullJsonData());

            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));
            ProjectUpdatesUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.MyProjectsRequiringAnUpdate());
            DisplayActionButtons = !currentFirmaSession.IsAnonymousOrUnassigned();
        }
    }
}
