/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Subproject
{

    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ProjectID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectName)]
        public string SubprojectName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectDescription)]
        public string SubprojectDescription { get; set; }

        [Required]
        public int SubprojectID { get; set; }

        [Required(ErrorMessage = "Subproject Stage field is required.")]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectStage)]
        public int SubprojectStageID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        public int? ImplementationStartYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CompletionYear)]
        public int? CompletionYear { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectNote)]
        public string Notes { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.Subproject subproject)
        {
            ProjectID = subproject.ProjectID;
            SubprojectName = subproject.SubprojectName;
            SubprojectDescription = subproject.SubprojectDescription;
            SubprojectID = subproject.SubprojectID;
            SubprojectStageID = subproject.SubprojectStageID;
            ImplementationStartYear = subproject.ImplementationStartYear;
            CompletionYear = subproject.CompletionYear;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Subproject subproject, FirmaSession currentFirmaSession)
        {
            subproject.SubprojectName = SubprojectName;
            subproject.SubprojectDescription = SubprojectDescription;
            subproject.SubprojectStageID = SubprojectStageID;
            subproject.ImplementationStartYear = ImplementationStartYear;
            subproject.CompletionYear = CompletionYear;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CompletionYear < ImplementationStartYear)
            {
                yield return new SitkaValidationResult<EditViewModel, int?>(
                    FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear,
                    m => m.CompletionYear);
            }

            if (SubprojectStageID == ProjectStage.Completed.ProjectStageID && !CompletionYear.HasValue)
            {
                yield return new SitkaValidationResult<EditViewModel, int?>($"Since the Subproject is in the Completed stage, the Completion year is required", m => m.CompletionYear);
            }

            if (SubprojectStageID == ProjectStage.PostImplementation.ProjectStageID && !CompletionYear.HasValue)
            {
                yield return new SitkaValidationResult<EditViewModel, int?>($"Since the Subproject is in the Post-Implementation stage, the Completion year is required", m => m.CompletionYear);
            }

            var isCompletedOrPostImplementation = SubprojectStageID == ProjectStage.Completed.ProjectStageID || SubprojectStageID == ProjectStage.PostImplementation.ProjectStageID;
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
            if (isCompletedOrPostImplementation && CompletionYear > currentYear)
            {
                yield return new SitkaValidationResult<EditViewModel, int?>(
                    $"The Subproject is in Completed or Post-Implementation stage; the Completion Year must be less than or equal to the current year",
                    m => m.CompletionYear);
            }

        }
        
    }

}