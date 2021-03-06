﻿/*-----------------------------------------------------------------------
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

using ProjectFirma.Web.Views.ProjectFundingSourceBudget;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class EditProjectFundingSourceBudgetByCostTypeUpdateWorkflowContainerViewData : ProjectUpdateViewData
    {


        public ProjectBudgetSummaryViewData ProjectBudgetSummaryViewData { get; }
        public ProjectBudgetsAnnualByCostTypeViewData ProjectBudgetsAnnualByCostTypeViewData { get; }
        


        public EditProjectFundingSourceBudgetByCostTypeViewData ViewDataForPartial { get; }
        public EditProjectFundingSourceBudgetByCostTypeViewModel ViewModelForPartial { get; }

        public EditProjectFundingSourceBudgetByCostTypeUpdateWorkflowContainerViewData(FirmaSession currentFirmaSession,
            ProjectUpdateBatch projectUpdateBatch,
            EditProjectFundingSourceBudgetByCostTypeViewData.EditProjectFundingSourceBudgetByCostTypeViewDataForAngular viewDataForAngularClass,
            ProjectBudgetSummaryViewData projectBudgetSummaryViewData,
            ProjectBudgetsAnnualByCostTypeViewData projectBudgetsAnnualByCostTypeViewData,
            ProjectUpdateStatus projectUpdateStatus,
            EditProjectFundingSourceBudgetByCostTypeValidationResult editProjectFundingSourceBudgetByCostTypeValidationResult,
            EditProjectFundingSourceBudgetByCostTypeViewModel viewModelForPartial
        ) : base(currentFirmaSession, projectUpdateBatch, projectUpdateStatus, editProjectFundingSourceBudgetByCostTypeValidationResult.GetWarningMessages(), ProjectUpdateSection.Budget.ProjectUpdateSectionDisplayName)
        {
            

            ProjectBudgetSummaryViewData = projectBudgetSummaryViewData;
            ProjectBudgetsAnnualByCostTypeViewData = projectBudgetsAnnualByCostTypeViewData;


            bool showApproveAndReturnButton =
                ProjectFundingSourceByCostTypeViewDataHelper.ShowApproveAndReturnButtonForUpdateWorkflow(projectUpdateBatch,
                    currentFirmaSession);
            ViewDataForPartial = new EditProjectFundingSourceBudgetByCostTypeViewData(viewDataForAngularClass, ProjectFundingSourceBudgetViewEnum.Update, projectUpdateBatch, projectUpdateStatus.IsBudgetsUpdated, showApproveAndReturnButton);
            ViewModelForPartial = viewModelForPartial;

        }


    }
}