/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceBudgetByCostTypeViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public enum ProjectFundingSourceBudgetViewEnum
    {
        Edit,
        Create,
        Update
    }
    public class EditProjectFundingSourceBudgetByCostTypeViewData : FirmaUserControlViewData
    {
        public ProjectFundingSourceBudgetViewEnum ViewEnum { get; }
        public EditProjectFundingSourceBudgetByCostTypeViewDataForAngular ViewDataForAngular { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForNoFundingSourceIdentified { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPlanningDesignStartYear { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCompletionYear { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForEstimatedTotalCost { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForEstimatedAnnualOperatingCost { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProjectedFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForObligatedFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForExpendedFunding { get; }

        //The following fields are only for the Update workflow
        public string RefreshUrl { get; }
        public string DiffUrl { get; }
        public string RequestFundingSourceUrl { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public bool ProjectUpdateStatusIsBudgetsUpdated { get; }
        public bool UpdateShowApproveAndReturnButton { get; }

        public EditProjectFundingSourceBudgetByCostTypeViewData(EditProjectFundingSourceBudgetByCostTypeViewDataForAngular editProjectFundingSourceBudgetByCostTypeViewDataForAngular, ProjectFundingSourceBudgetViewEnum viewEnum)
        {
            ViewEnum = viewEnum;
            ViewDataForAngular = editProjectFundingSourceBudgetByCostTypeViewDataForAngular;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
            FieldDefinitionForNoFundingSourceIdentified = FieldDefinitionEnum.NoFundingSourceIdentified.ToType();
            FieldDefinitionForPlanningDesignStartYear = FieldDefinitionEnum.PlanningDesignStartYear.ToType();
            FieldDefinitionForCompletionYear = FieldDefinitionEnum.CompletionYear.ToType();
            FieldDefinitionForEstimatedTotalCost = FieldDefinitionEnum.EstimatedTotalCost.ToType();
            FieldDefinitionForEstimatedAnnualOperatingCost = FieldDefinitionEnum.EstimatedAnnualOperatingCost.ToType();
            FieldDefinitionForProjectedFunding = FieldDefinitionEnum.ProjectedFunding.ToType();
            FieldDefinitionForObligatedFunding = FieldDefinitionEnum.ObligatedFunding.ToType();
            FieldDefinitionForExpendedFunding = FieldDefinitionEnum.ExpendedFunding.ToType();

        }

        public EditProjectFundingSourceBudgetByCostTypeViewData(EditProjectFundingSourceBudgetByCostTypeViewDataForAngular editProjectFundingSourceBudgetByCostTypeViewDataForAngular, ProjectFundingSourceBudgetViewEnum viewEnum, ProjectUpdateBatch projectUpdateBatch, bool projectUpdateStatusIsBudgetsUpdated, bool updateShowApproveAndReturnButton) : this(editProjectFundingSourceBudgetByCostTypeViewDataForAngular, viewEnum)
        {
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ExpectedFundingComment, projectUpdateBatch.IsReturned());
            ProjectUpdateStatusIsBudgetsUpdated = projectUpdateStatusIsBudgetsUpdated;
            UpdateShowApproveAndReturnButton = updateShowApproveAndReturnButton;

            RequestFundingSourceUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.MissingFundingSource());
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshExpectedFundingByCostType(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffExpectedFundingByCostType(projectUpdateBatch.Project));
        }

        public class EditProjectFundingSourceBudgetByCostTypeViewDataForAngular
        {
            public List<int> RequiredCalendarYearRange { get; }
            public List<FundingSourceSimple> AllFundingSources { get; }
            public List<CostTypeSimple> AllCostTypes { get; }
            public List<ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple> ObligationItemBudgetRollUps { get; }
            public List<ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple> ObligationItemInvoiceRollUps { get; }
            // Actually a ProjectID
            public int ProjectID { get; }
            public int MaxYear { get; }
            public bool UseFiscalYears { get; }
            public IEnumerable<SelectListItem> FundingTypes { get; }

            public EditProjectFundingSourceBudgetByCostTypeViewDataForAngular(ProjectFirmaModels.Models.Project project,
                List<FundingSourceSimple> allFundingSources,
                List<CostTypeSimple> allCostTypes,
                List<int> requiredCalendarYearRange,
                IEnumerable<SelectListItem> fundingTypes)
            {
                RequiredCalendarYearRange = requiredCalendarYearRange;
                AllFundingSources = allFundingSources;
                AllCostTypes = allCostTypes;
                ProjectID = project.ProjectID;
                FundingTypes = fundingTypes;
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
                UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
                ObligationItemBudgetRollUps = project.GetObligationItemBudgetRollUpByYearAndCostTypeAndFundingSourceSimples();
                ObligationItemInvoiceRollUps = project.GetObligationItemInvoiceRollUpByYearAndCostTypeAndFundingSourceSimples();
            }

            public EditProjectFundingSourceBudgetByCostTypeViewDataForAngular(ProjectFirmaModels.Models.ProjectUpdateBatch projectUpdateBatch,
                List<FundingSourceSimple> allFundingSources,
                List<CostTypeSimple> allCostTypes,
                List<int> requiredCalendarYearRange,
                IEnumerable<SelectListItem> fundingTypes)
            {
                RequiredCalendarYearRange = requiredCalendarYearRange;
                AllFundingSources = allFundingSources;
                AllCostTypes = allCostTypes;
                ProjectID = projectUpdateBatch.ProjectID;
                FundingTypes = fundingTypes;
                MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
				UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
                ObligationItemBudgetRollUps = projectUpdateBatch.Project.GetObligationItemBudgetRollUpByYearAndCostTypeAndFundingSourceSimples();
                ObligationItemInvoiceRollUps = projectUpdateBatch.Project.GetObligationItemInvoiceRollUpByYearAndCostTypeAndFundingSourceSimples();
            }
        }

        
    }
}
