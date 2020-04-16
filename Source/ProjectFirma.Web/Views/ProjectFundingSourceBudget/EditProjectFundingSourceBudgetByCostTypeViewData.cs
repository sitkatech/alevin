﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceBudgetByCostTypeViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public enum ProjectFundingSourceBudgetViewEnum
    {
        Edit,
        Create
    }
    public class EditProjectFundingSourceBudgetByCostTypeViewData : FirmaUserControlViewData
    {
        public ProjectFundingSourceBudgetViewEnum ViewEnum { get; }
        public EditProjectFundingSourceBudgetByCostTypeViewDataForAngular ViewDataForAngular { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForFundingSource { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostType { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForNoFundingSourceIdentified { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForSecuredFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForTargetedFunding { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPlanningDesignStartYear { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCompletionYear { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForEstimatedTotalCost { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForEstimatedAnnualOperatingCost { get; }

        public EditProjectFundingSourceBudgetByCostTypeViewData(EditProjectFundingSourceBudgetByCostTypeViewDataForAngular editProjectFundingSourceBudgetByCostTypeViewDataForAngular, ProjectFundingSourceBudgetViewEnum viewEnum)
        {
            ViewEnum = viewEnum;
            ViewDataForAngular = editProjectFundingSourceBudgetByCostTypeViewDataForAngular;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForFundingSource = FieldDefinitionEnum.FundingSource.ToType();
            FieldDefinitionForCostType = FieldDefinitionEnum.CostType.ToType();
            FieldDefinitionForNoFundingSourceIdentified = FieldDefinitionEnum.NoFundingSourceIdentified.ToType();
            FieldDefinitionForSecuredFunding = FieldDefinitionEnum.SecuredFunding.ToType();
            FieldDefinitionForTargetedFunding = FieldDefinitionEnum.TargetedFunding.ToType();
            FieldDefinitionForPlanningDesignStartYear = FieldDefinitionEnum.PlanningDesignStartYear.ToType();
            FieldDefinitionForCompletionYear = FieldDefinitionEnum.CompletionYear.ToType();
            FieldDefinitionForEstimatedTotalCost = FieldDefinitionEnum.EstimatedTotalCost.ToType();
            FieldDefinitionForEstimatedAnnualOperatingCost = FieldDefinitionEnum.EstimatedAnnualOperatingCost.ToType();
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
                ObligationItemBudgetRollUps = project.GetObligationItemBudgetRollUpByYearAndCostTypeAndFundingSourceSimples();
                ObligationItemInvoiceRollUps = project.GetObligationItemInvoiceRollUpByYearAndCostTypeAndFundingSourceSimples();
            }
        }

        
    }
}
