/*-----------------------------------------------------------------------
<copyright file="ExpectedFundingViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Views.ProjectFundingSourceBudget;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class EditProjectFundingSourceBudgetByCostTypeCreateWorkflowContainerViewData : ProjectCreateViewData
    {
        public string RequestFundingSourceUrl { get; }
        public EditProjectFundingSourceBudgetByCostTypeViewData ViewDataForPartial { get; }
        public EditProjectFundingSourceBudgetByCostTypeViewModel ViewModelForPartial { get; }


        public EditProjectFundingSourceBudgetByCostTypeCreateWorkflowContainerViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            EditProjectFundingSourceBudgetByCostTypeViewData.EditProjectFundingSourceBudgetByCostTypeViewDataForAngular viewDataForAngularClass,
            EditProjectFundingSourceBudgetByCostTypeViewModel viewModelForPartial
        ) : base(currentFirmaSession, project, ProjectCreateSection.Budget.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            ViewDataForPartial = new EditProjectFundingSourceBudgetByCostTypeViewData(viewDataForAngularClass, ProjectFundingSourceBudgetViewEnum.Create);
            ViewModelForPartial = viewModelForPartial;
        }

        
    }
}