﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceBudgetByCostTypeViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public class EditProjectFundingSourceBudgetByCostTypeViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingType)]
        public int? FundingTypeID { get; set; }

        public List<ProjectFundingSourceBudgetsByCostTypeBulk> ProjectFundingSourceBudgets { get; set; }

        public List<ProjectRelevantCostTypeSimple> ProjectRelevantCostTypes { get; set; }

        public List<ProjectNoFundingSourceIdentifiedSimple> NoFundingSourceAmounts { get; set; }

        public bool ShouldSaveChanges { get; set; }


        //The following fields are for the Update workflow
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpectedFundingUpdateNote)]
        [DisplayName("Comment")]
        public string ExpectedFundingUpdateNote { get; set; }

        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpectedFundingComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectFundingSourceBudgetByCostTypeViewModel()
        {
        }

        public EditProjectFundingSourceBudgetByCostTypeViewModel(ProjectFirmaModels.Models.Project project, List<int> calendarYearsToPopulate, List<ProjectRelevantCostTypeSimple> projectRelevantCostTypes)
        {
            FundingTypeID = project.FundingTypeID;
            ProjectRelevantCostTypes = projectRelevantCostTypes;
            var noFundingSourceAmountSimples = new List<ProjectNoFundingSourceIdentifiedSimple>();
            var projectNoFundingSourceIdentifieds = project.ProjectNoFundingSourceIdentifieds.ToList();
            if (project.FundingTypeID.HasValue)
            {
                switch (project.FundingType.ToEnum)
                {
                    case FundingTypeEnum.BudgetVariesByYear:
                        {
                            ProjectFundingSourceBudgets = ProjectFundingSourceBudgetsByCostTypeBulk.MakeFromListByCostType(project, calendarYearsToPopulate);
                            noFundingSourceAmountSimples.AddRange(ProjectNoFundingSourceIdentifiedSimple.CreateFromProjectNoFundingSourceIdentifieds(projectNoFundingSourceIdentifieds));
                            break;
                        }

                    case FundingTypeEnum.BudgetSameEachYear:
                        ProjectFundingSourceBudgets = ProjectFundingSourceBudgetsByCostTypeBulk.MakeFromListByCostType(project, new List<int>());
                        noFundingSourceAmountSimples.AddRange(ProjectNoFundingSourceIdentifiedSimple.CreateFromProjectNoFundingSourceIdentifieds(projectNoFundingSourceIdentifieds));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            NoFundingSourceAmounts = noFundingSourceAmountSimples;
        }

        public EditProjectFundingSourceBudgetByCostTypeViewModel(ProjectUpdateBatch projectUpdateBatch, List<int> calendarYearsToPopulate, List<ProjectRelevantCostTypeSimple> projectRelevantCostTypes)
        {
            FundingTypeID = projectUpdateBatch.ProjectUpdate.FundingTypeID;
            ProjectRelevantCostTypes = projectRelevantCostTypes;
            var noFundingSourceAmountSimples = new List<ProjectNoFundingSourceIdentifiedSimple>();
            var projectNoFundingSourceIdentifieds = projectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates.ToList();
            if (projectUpdateBatch.ProjectUpdate.FundingTypeID.HasValue)
            {
                switch (projectUpdateBatch.ProjectUpdate.FundingType.ToEnum)
                {
                    case FundingTypeEnum.BudgetVariesByYear:
                        {
                            ProjectFundingSourceBudgets = ProjectFundingSourceBudgetsByCostTypeBulk.MakeFromListByCostType(projectUpdateBatch, calendarYearsToPopulate);
                            noFundingSourceAmountSimples.AddRange(ProjectNoFundingSourceIdentifiedSimple.CreateFromProjectNoFundingSourceIdentifieds(projectNoFundingSourceIdentifieds));
                            break;
                        }

                    case FundingTypeEnum.BudgetSameEachYear:
                        ProjectFundingSourceBudgets = ProjectFundingSourceBudgetsByCostTypeBulk.MakeFromListByCostType(projectUpdateBatch, new List<int>());
                        noFundingSourceAmountSimples.AddRange(ProjectNoFundingSourceIdentifiedSimple.CreateFromProjectNoFundingSourceIdentifieds(projectNoFundingSourceIdentifieds));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            NoFundingSourceAmounts = noFundingSourceAmountSimples;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, DatabaseEntities databaseEntities)
        {
            var currentProjectFundingSourceBudgets = project.ProjectFundingSourceBudgets.ToList();
            databaseEntities.ProjectFundingSourceBudgets.Load();
            var allProjectFundingSourceBudgets = databaseEntities.AllProjectFundingSourceBudgets.Local;
            var currentProjectNoFundingSourceIdentifieds = project.ProjectNoFundingSourceIdentifieds.ToList();
            databaseEntities.ProjectNoFundingSourceIdentifieds.Load();
            var allProjectNoFundingSourceIdentifieds = HttpRequestStorage.DatabaseEntities.AllProjectNoFundingSourceIdentifieds.Local;

            project.FundingTypeID = FundingTypeID;

            var projectFundingSourceBudgetsUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceBudget>();
            if (ProjectFundingSourceBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceBudgetsUpdated = ProjectFundingSourceBudgets.Where(x => x.IsRelevant ?? false).SelectMany(x => x.ToProjectFundingSourceBudgets()).ToList();
            }
            currentProjectFundingSourceBudgets.Merge(projectFundingSourceBudgetsUpdated,
                allProjectFundingSourceBudgets,
                (x, y) => x.ProjectID == y.ProjectID &&
                                                                           x.FundingSourceID == y.FundingSourceID &&
                                                                           x.CostTypeID == y.CostTypeID &&
                                                                           x.CalendarYear == y.CalendarYear,
                (x, y) => x.SetProjectedAmount(y.ProjectedAmount), databaseEntities);

            var projectNoFundingSourceAmountsUpdated = new List<ProjectNoFundingSourceIdentified>();
            if (FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID && NoFundingSourceAmounts != null)
            {
                // Completely rebuild the list
                projectNoFundingSourceAmountsUpdated = NoFundingSourceAmounts.Select(x =>
                        new ProjectNoFundingSourceIdentified(project.ProjectID, x.CostTypeID) { NoFundingSourceIdentifiedYet = x.Amount })
                    .ToList();
            }
            else if (FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID && NoFundingSourceAmounts != null)
            {
                // Completely rebuild the list
                projectNoFundingSourceAmountsUpdated = NoFundingSourceAmounts.Select(x =>
                        new ProjectNoFundingSourceIdentified(project.ProjectID, x.CostTypeID) { CalendarYear = x.CalendarYear, NoFundingSourceIdentifiedYet = x.Amount})
                    .ToList();
            }
            // set if funding type is "Varies By Year", delete rows otherwise
            currentProjectNoFundingSourceIdentifieds.Merge(projectNoFundingSourceAmountsUpdated,
                allProjectNoFundingSourceIdentifieds,
                (x, y) => x.ProjectID == y.ProjectID &&
                                                                                    x.CalendarYear == y.CalendarYear &&
                                                                                    x.CostTypeID == y.CostTypeID,
                (x, y) => x.NoFundingSourceIdentifiedYet = y.NoFundingSourceIdentifiedYet, databaseEntities);

            var currentProjectRelevantCostTypes = project.GetBudgetsRelevantCostTypes();
            var allProjectRelevantCostTypes = databaseEntities.AllProjectRelevantCostTypes.Local;
            var projectRelevantCostTypes = new List<ProjectRelevantCostType>();
            if (ProjectRelevantCostTypes != null)
            {
                // Completely rebuild the list
                projectRelevantCostTypes =
                    ProjectRelevantCostTypes.Where(x => x.IsRelevant)
                        .Select(x => new ProjectRelevantCostType(x.ProjectRelevantCostTypeID, x.ProjectID, x.CostTypeID, ProjectRelevantCostTypeGroup.Budgets.ProjectRelevantCostTypeGroupID))
                        .ToList();
            }
            currentProjectRelevantCostTypes.Merge(projectRelevantCostTypes,
                allProjectRelevantCostTypes,
                (x, y) => x.ProjectID == y.ProjectID && x.CostTypeID == y.CostTypeID && x.ProjectRelevantCostTypeGroupID == y.ProjectRelevantCostTypeGroupID, databaseEntities);
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var currentProjectFundingSourceBudgetUpdates = projectUpdateBatch.ProjectFundingSourceBudgetUpdates.ToList();
            databaseEntities.ProjectFundingSourceBudgetUpdates.Load();
            var allProjectFundingSourceBudgetUpdates = databaseEntities.AllProjectFundingSourceBudgetUpdates.Local;
            var currentProjectNoFundingSourceIdentifiedUpdates = projectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates.ToList();
            databaseEntities.ProjectNoFundingSourceIdentifiedUpdates.Load();
            var allProjectNoFundingSourceIdentifiedUpdates = HttpRequestStorage.DatabaseEntities.AllProjectNoFundingSourceIdentifiedUpdates.Local;

            projectUpdateBatch.ProjectUpdate.FundingTypeID = FundingTypeID;
            projectUpdateBatch.ExpectedFundingUpdateNote = ExpectedFundingUpdateNote;

            var projectFundingSourceBudgetUpdatesUpdated = new List<ProjectFirmaModels.Models.ProjectFundingSourceBudgetUpdate>();
            if (ProjectFundingSourceBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceBudgetUpdatesUpdated = ProjectFundingSourceBudgets.Where(x => x.IsRelevant ?? false).SelectMany(x => x.ToProjectFundingSourceBudgetUpdates(projectUpdateBatch)).ToList();
            }
            currentProjectFundingSourceBudgetUpdates.Merge(projectFundingSourceBudgetUpdatesUpdated,
                allProjectFundingSourceBudgetUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.SetProjectedAmount(y.ProjectedAmount), databaseEntities);

            var projectNoFundingSourceIdentifiedUpdatesUpdated = new List<ProjectNoFundingSourceIdentifiedUpdate>();
            if (FundingTypeID == FundingType.BudgetSameEachYear.FundingTypeID && NoFundingSourceAmounts != null)
            {
                // Completely rebuild the list
                projectNoFundingSourceIdentifiedUpdatesUpdated = NoFundingSourceAmounts.Select(x =>
                        new ProjectNoFundingSourceIdentifiedUpdate(projectUpdateBatch.ProjectUpdateBatchID, x.CostTypeID) { NoFundingSourceIdentifiedYet = x.Amount })
                    .ToList();
            }
            else if (FundingTypeID == FundingType.BudgetVariesByYear.FundingTypeID && NoFundingSourceAmounts != null)
            {
                // Completely rebuild the list
                projectNoFundingSourceIdentifiedUpdatesUpdated = NoFundingSourceAmounts.Select(x =>
                        new ProjectNoFundingSourceIdentifiedUpdate(projectUpdateBatch.ProjectUpdateBatchID, x.CostTypeID) { CalendarYear = x.CalendarYear, NoFundingSourceIdentifiedYet = x.Amount})
                    .ToList();
            }

            // ReSharper disable once IdentifierTypo
            foreach (var pnfsi in projectNoFundingSourceIdentifiedUpdatesUpdated)
            {
                // ReSharper disable thrice StringLiteralTypo
                Debug.WriteLine($"pnfsi: pnfsi.ProjectUpdateBatchID: {pnfsi.ProjectUpdateBatchID} - pnfsi.CalendarYear: {pnfsi.CalendarYear} pnfsi.CostTypeID: {pnfsi.CostTypeID} pnfsi.NoFundingSourceIdentifiedYet (amount): {pnfsi.NoFundingSourceIdentifiedYet}");
            }

            currentProjectNoFundingSourceIdentifiedUpdates.Merge(projectNoFundingSourceIdentifiedUpdatesUpdated,
                allProjectNoFundingSourceIdentifiedUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && 
                                                                                            x.CalendarYear == y.CalendarYear &&
                                                                                            x.CostTypeID == y.CostTypeID,
                (x, y) => x.NoFundingSourceIdentifiedYet = y.NoFundingSourceIdentifiedYet, databaseEntities);

            var currentProjectUpdateRelevantCostTypes = projectUpdateBatch.GetBudgetsRelevantCostTypes();
            var allProjectRelevantCostTypeUpdates = databaseEntities.AllProjectRelevantCostTypeUpdates.Local;
            var projectRelevantCostTypeUpdates = new List<ProjectRelevantCostTypeUpdate>();
            if (ProjectRelevantCostTypes != null)
            {
                // Completely rebuild the list
                projectRelevantCostTypeUpdates =
                    ProjectRelevantCostTypes.Where(x => x.IsRelevant)
                        .Select(x => new ProjectRelevantCostTypeUpdate(x.ProjectRelevantCostTypeID, projectUpdateBatch.ProjectUpdateBatchID, x.CostTypeID, ProjectRelevantCostTypeGroup.Budgets.ProjectRelevantCostTypeGroupID))
                        .ToList();
            }
            currentProjectUpdateRelevantCostTypes.Merge(projectRelevantCostTypeUpdates,
                allProjectRelevantCostTypeUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.CostTypeID == y.CostTypeID && x.ProjectRelevantCostTypeGroupID == y.ProjectRelevantCostTypeGroupID, databaseEntities);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();
            if (ProjectFundingSourceBudgets == null)
            {
                ProjectFundingSourceBudgets = new List<ProjectFundingSourceBudgetsByCostTypeBulk>();
            }
            if (FundingTypeID.HasValue && ProjectFundingSourceBudgets.Any())
            {
                // need to make sure there is at least one relevant cost type selected
                var projectFundingSourceBudgetBulks = ProjectFundingSourceBudgets.Where(x => x.IsRelevant ?? false).ToList();
                if (!projectFundingSourceBudgetBulks.Any())
                {
                    errors.Add(new ValidationResult($"Select a {FieldDefinitionEnum.CostType.ToType().GetFieldDefinitionLabel()} or remove the {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}"));
                }
            }
            return errors;
        }
    }
}