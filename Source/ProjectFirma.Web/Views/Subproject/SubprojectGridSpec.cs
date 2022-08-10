/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateBatchGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Subproject
{
    public class SubprojectAdminGridSpec : GridSpec<ProjectFirmaModels.Models.Subproject>
    {
        public SubprojectAdminGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Delete(x.PrimaryKey)), true), 30, DhtmlxGridColumnFilterType.None);
            //Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Edit(x.PrimaryKey)), ModalDialogFormHelper.DefaultDialogWidth, "Edit Subproject")), 30, DhtmlxGridColumnFilterType.None);
            Add("Implementation Start Year", x => x.ImplementationStartYear.DisplayValue(), 120);
            Add("Completion Year", x => x.CompletionYear.DisplayValue(), 120);
            Add("Project Stage", x => x.ProjectStage.ProjectStageDisplayName, 120);
            Add("Notes", x => x.Notes, 120);
        }
    }

    public class SubprojectUserGridSpec : GridSpec<ProjectFirmaModels.Models.Subproject>
    {
        public SubprojectUserGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Delete(x.PrimaryKey)), true), 30, DhtmlxGridColumnFilterType.None);
            //Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Edit(x.PrimaryKey)), ModalDialogFormHelper.DefaultDialogWidth, "Edit Subproject")), 30, DhtmlxGridColumnFilterType.None);
            Add("Implementation Start Year", x => x.ImplementationStartYear.DisplayValue(), 120);
            Add("Completion Year", x => x.CompletionYear.DisplayValue(), 120);
            Add("Project Stage", x => x.ProjectStage.ProjectStageDisplayName, 120);
            Add("Notes", x => x.Notes, 120);
        }
    }

    public class SubprojectGridSpec : GridSpec<ProjectFirmaModels.Models.Subproject>
    {
        public SubprojectGridSpec(ProjectPrimaryKey projectPrimaryKey)
        {
            ObjectNameSingular = "Subproject";
            ObjectNamePlural = "Subprojects";

            var contentUrl = SitkaRoute<SubprojectController>.BuildUrlFromExpression(x => x.New(projectPrimaryKey));
            CreateEntityModalDialogForm = new ModalDialogForm(contentUrl, 950, $"Create a new Subproject");


            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Delete(x.PrimaryKey)), true), 30, DhtmlxGridColumnFilterType.None);
            //Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<SubprojectController>.BuildUrlFromExpression(c => c.Edit(x.PrimaryKey)), ModalDialogFormHelper.DefaultDialogWidth, "Edit Subproject")), 30, DhtmlxGridColumnFilterType.None);
            Add("Implementation Start Year", x => x.ImplementationStartYear.DisplayValue(), 120);
            Add("Completion Year", x => x.CompletionYear.DisplayValue(), 120);
            Add("Project Stage", x => x.ProjectStage.ProjectStageDisplayName, 120);
            Add("Notes", x => x.Notes, 120);
        }
    }

}
