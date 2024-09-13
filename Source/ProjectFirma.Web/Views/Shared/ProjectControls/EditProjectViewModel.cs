/*-----------------------------------------------------------------------
<copyright file="EditProjectViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    public class EditProjectViewModel : FormViewModel, IValidatableObject
    {
        public int ProjectID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectName)]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ProjectName)]
        [Required]
        public string ProjectName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectDescription)]
        [StringLength(ProjectModelExtensions.MaxLengthForProjectDescription)]
        [Required]
        public string ProjectDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectStage)]
        [Required]
        public int ProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        [Required]
        public int? ImplementationStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PlanningDesignStartYear)]
        [Required]
        public int? PlanningDesignStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CompletionYear)]
        public int? CompletionYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.BpaProjectNumber)]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.BpaProjectNumber)]
        [MaxLength(ProjectFirmaModels.Models.Project.FieldLengths.BpaProjectNumber)]
        public string BpaProjectNumber { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TaxonomyLeaf)]
        [Required(ErrorMessage = "This field is required.")]
        public int? TaxonomyLeafID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf)]
        public IEnumerable<int> SecondaryProjectTaxonomyLeafIDs { get; set; } = new List<int>();

        public bool HasExistingProjectUpdate { get; set; }

        public int? OldProjectStageID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.Solicitation)]
        public int? SolicitationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectExternalID)]
        public int? ExternalID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectViewModel()
        {
        }

        public EditProjectViewModel(ProjectFirmaModels.Models.Project project, bool hasExistingProjectUpdate)
        {
            TaxonomyLeafID = project.GetTaxonomyLeaf().TaxonomyLeafID;
            SecondaryProjectTaxonomyLeafIDs = project.SecondaryProjectTaxonomyLeafs.Select(x => x.TaxonomyLeafID);
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            ProjectStageID = project.ProjectStageID;
            OldProjectStageID = project.ProjectStageID;
            ImplementationStartYear = project.ImplementationStartYear;
            PlanningDesignStartYear = project.PlanningDesignStartYear;
            CompletionYear = project.CompletionYear;
            HasExistingProjectUpdate = hasExistingProjectUpdate;
            SolicitationID = project.SolicitationID;
            BpaProjectNumber = project.BpaProjectNumber;
            if (MultiTenantHelpers.GetTenantAttributeFromCache().ProjectExternalDataSourceEnabled)
            {
                ExternalID = project.ExternalID;

        }
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            project.ProjectName = ProjectName;
            project.ProjectDescription = ProjectDescription;
            // TaxonomyLeaf gets special handling
            SetTaxonomyLeaf(project, currentFirmaSession);
            project.ProjectStageID = ProjectStageID;
            project.ImplementationStartYear = ImplementationStartYear;
            project.PlanningDesignStartYear = PlanningDesignStartYear;
            project.CompletionYear = CompletionYear;
            project.SolicitationID = SolicitationID;
            project.BpaProjectNumber = BpaProjectNumber;
            if (MultiTenantHelpers.GetTenantAttributeFromCache().ProjectExternalDataSourceEnabled)
            {
                project.ExternalID = ExternalID;
            }

            var secondaryProjectTaxonomyLeavesToUpdate = (SecondaryProjectTaxonomyLeafIDs?.ToList() ?? new List<int>())
                .Select(x => new SecondaryProjectTaxonomyLeaf(project.ProjectID, x) {TenantID = HttpRequestStorage.Tenant.TenantID})
                .ToList();
            project.SecondaryProjectTaxonomyLeafs.Merge(
                secondaryProjectTaxonomyLeavesToUpdate,
                HttpRequestStorage.DatabaseEntities.AllSecondaryProjectTaxonomyLeafs.Local,
                (a, b) => a.TaxonomyLeafID == b.TaxonomyLeafID && a.ProjectID == b.ProjectID,
                HttpRequestStorage.DatabaseEntities);
        }

        private void SetTaxonomyLeaf(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            var currentTaxonomyLeaf = project.GetTaxonomyLeaf();
            // Are we attempting to change the TaxonomyLeaf away from what it is either already overridden to, 
            // or away from what it currently calculates to? 
            if (currentTaxonomyLeaf?.TaxonomyLeafID != this.TaxonomyLeafID)
            {
                // If so, we need a deliberate override.
                project.OverrideTaxonomyLeafID = this.TaxonomyLeafID;

            }
            // Immediate check for problems
            project.GetTaxonomyLeaf();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();
            if (!ProjectModelExtensions.IsProjectNameUnique(projects, ProjectName, ProjectID))
            {
                yield return new SitkaValidationResult<EditProjectViewModel, string>(
                    FirmaValidationMessages.ProjectNameUnique, m => m.ProjectName);
            }

            if (ImplementationStartYear < PlanningDesignStartYear)
            {
                yield return new SitkaValidationResult<EditProjectViewModel, int?>(
                    FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear,
                    m => m.ImplementationStartYear);
            }

            if (CompletionYear < ImplementationStartYear)
            {
                yield return new SitkaValidationResult<EditProjectViewModel, int?>(
                    FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear,
                    m => m.CompletionYear);
            }
            
            var isCompletedOrPostImplementation = ProjectStageID == ProjectStage.Completed.ProjectStageID || ProjectStageID == ProjectStage.PostImplementation.ProjectStageID;
            if (isCompletedOrPostImplementation && !CompletionYear.HasValue)
            {
                yield return new SitkaValidationResult<EditProjectViewModel, int?>($"Since the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the {ProjectStage.ToType(ProjectStageID).GetProjectStageDisplayName()} stage, the {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} is required", m => m.CompletionYear);
            }

            if (isCompletedOrPostImplementation && CompletionYear > DateTime.Now.Year)
            {
                var errorMessage = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} is in the {ProjectStage.ToType(ProjectStageID).GetProjectStageDisplayName()} stage: " +
                                   $"the {FieldDefinitionEnum.CompletionYear.ToType().GetFieldDefinitionLabel()} must be less than or equal to the current year";
                yield return new SitkaValidationResult<EditProjectViewModel, int?>(errorMessage, m => m.CompletionYear);
            }

            if (HasExistingProjectUpdate && OldProjectStageID != ProjectStageID)
            {
                var errorMessage = $"There are updates to this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} that have not been submitted. Please delete the update if you want to change this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}'s stage.";
                yield return new SitkaValidationResult<EditProjectViewModel, int>(errorMessage, m => m.ProjectStageID);
            }

            if (TaxonomyLeafID != null && (SecondaryProjectTaxonomyLeafIDs?.ToList() ?? new List<int>()).Contains(TaxonomyLeafID.Value))
            {
                yield return new SitkaValidationResult<EditProjectViewModel, IEnumerable<int>>(
                    $"Cannot have a {FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf.ToType().GetFieldDefinitionLabel()} " +
                    $"that is the same as the Primary {FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel()}.",
                    m => m.SecondaryProjectTaxonomyLeafIDs);
            }

            if (!string.IsNullOrEmpty(BpaProjectNumber))
            {
                var regexMatch = Regex.Match(BpaProjectNumber, "^" + ProjectModelExtensions.BpaProjectNumberRegexString);
                if (!regexMatch.Success)
                {
                    yield return new SitkaValidationResult<EditProjectViewModel, string>(
                        $"You must enter a valid {FieldDefinitionEnum.BpaProjectNumber.ToType().GetFieldDefinitionLabel()} (e.g. XXXX-XXX-XX).",
                        m => m.BpaProjectNumber);
                }
            }
        }
    }
}