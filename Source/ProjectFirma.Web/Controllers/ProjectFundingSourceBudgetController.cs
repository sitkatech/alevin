/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceBudgetController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectFundingSourceBudget;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFundingSourceBudgetController : FirmaBaseController
    {
        
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public ViewResult EditProjectFundingSourceBudgetByCostTypeForProject(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var calendarYearRange = project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
            var projectRelevantCostTypes =
                project.GetAllProjectRelevantCostTypesAsSimples(ProjectRelevantCostTypeGroup.Budgets);
            var viewModel = new EditProjectFundingSourceBudgetByCostTypeViewModel(project, calendarYearRange, projectRelevantCostTypes);
            return ViewEditProjectFundingSourceBudgetByCostType(project, calendarYearRange, viewModel);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectFundingSourceBudgetByCostTypeForProject(ProjectPrimaryKey projectPrimaryKey, EditProjectFundingSourceBudgetByCostTypeViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var calendarYearRange = project.CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears();
                return ViewEditProjectFundingSourceBudgetByCostType(project, calendarYearRange, viewModel);
            }
            // if user pressed save button, save their changes before returning them to the project detail page
            if (viewModel.ShouldSaveChanges)
            {
                viewModel.UpdateModel(project, HttpRequestStorage.DatabaseEntities);
                SetMessageForDisplay($"Projected Funding updated for {project.ProjectName}.");
            }

            return Redirect(project.GetDetailUrl() + "#financials-1");
        }

        private ViewResult ViewEditProjectFundingSourceBudgetByCostType(Project project, List<int> calendarYearRange, EditProjectFundingSourceBudgetByCostTypeViewModel viewModel)
        {
            var allFundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList().Select(x => new FundingSourceSimple(x)).OrderBy(p => p.DisplayName).ToList();
            var allCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.ToList().Select(x => new CostTypeSimple(x)).OrderBy(p => p.CostTypeName).ToList();
            var fundingTypes = FundingType.All.ToList().ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            var viewDataForAngularEditor = new EditProjectFundingSourceBudgetByCostTypeViewData.EditProjectFundingSourceBudgetByCostTypeViewDataForAngular(project, allFundingSources, allCostTypes, calendarYearRange, fundingTypes);

            var containerViewData = new EditProjectFundingSourceBudgetByCostTypeContainerViewData(CurrentFirmaSession, project, viewDataForAngularEditor, viewModel);
            return RazorView<EditProjectFundingSourceBudgetByCostTypeContainer, EditProjectFundingSourceBudgetByCostTypeContainerViewData>(containerViewData);
        }

    }
}