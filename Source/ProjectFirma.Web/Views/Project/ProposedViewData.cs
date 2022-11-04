﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class ProposedViewData : FirmaViewData
    {
        public ProposalsGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public bool HasProposeProjectPermissions { get; }
        public string ProposeNewProjectUrl { get; }

        public ProposedViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized();

            HasProposeProjectPermissions = new ProjectCreateFeature().HasPermissionByFirmaSession(currentFirmaSession);
            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.InstructionsProposal(null));

            GridSpec = new ProposalsGridSpec(currentFirmaSession) {ObjectNameSingular = $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true};

            if (new ProjectCreateNewFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                GridSpec.CustomExcelDownloadUrl =
                    SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ProposalsExcelDownload());
            }
            if (new ProjectCreateFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                GridSpec.CreateEntityActionPhrase = "Propose a New Project";
                GridSpec.CreateEntityModalDialogForm = null;
            }
            GridName = "proposalsGrid";
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ProposedGridJsonData());
        }
    }
}
