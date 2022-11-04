﻿/*-----------------------------------------------------------------------
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

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int EvaluationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationName)]
        [Required]
        [StringLength(ProjectFirmaModels.Models.Evaluation.FieldLengths.EvaluationName)]
        public string EvaluationName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationDefinition)]
        [StringLength(ProjectFirmaModels.Models.Evaluation.FieldLengths.EvaluationDefinition)]
        public string EvaluationDefinition { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationStartDate)]
        public DateTime? EvaluationStartDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationEndDate)]
        public DateTime? EvaluationEndDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationStatus)]
        [Required]
        public int EvaluationStatusID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.EvaluationVisibility)]
        [Required]
        public int EvaluationVisibilityID { get; set; }




        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.Evaluation evaluation)
        {
            EvaluationID = evaluation.EvaluationID;
            EvaluationName = evaluation.EvaluationName;
            EvaluationDefinition = evaluation.EvaluationDefinition;
            EvaluationStartDate = evaluation.EvaluationStartDate;
            EvaluationEndDate = evaluation.EvaluationEndDate;
            EvaluationStatusID = evaluation.EvaluationStatusID;
            EvaluationVisibilityID = evaluation.EvaluationVisibilityID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Evaluation evaluation, FirmaSession currentFirmaSession)
        {
            evaluation.EvaluationName = EvaluationName;
            evaluation.EvaluationDefinition = EvaluationDefinition;
            evaluation.EvaluationStartDate = EvaluationStartDate;
            evaluation.EvaluationEndDate = EvaluationEndDate;
            evaluation.EvaluationStatusID = EvaluationStatusID;
            evaluation.EvaluationVisibilityID = EvaluationVisibilityID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (EvaluationStartDate.HasValue && EvaluationEndDate.HasValue)
            {
                if (EvaluationStartDate.Value.CompareTo(EvaluationEndDate.Value) > 0)
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, DateTime?>(
                        $"{FieldDefinitionEnum.EvaluationStartDate.ToType().GetFieldDefinitionLabel()} must come before {FieldDefinitionEnum.EvaluationEndDate.ToType().GetFieldDefinitionLabel()}.",
                        m => m.EvaluationStartDate));
                }
            }

            if (EvaluationStatusID != EvaluationStatus.Draft.EvaluationStatusID)
            {
                if (!EvaluationStartDate.HasValue)
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, DateTime?>($"{FieldDefinitionEnum.EvaluationStartDate.ToType().GetFieldDefinitionLabel()} is required when {FieldDefinitionEnum.EvaluationStatus.ToType().GetFieldDefinitionLabel()} is not in the {EvaluationStatus.Draft.EvaluationStatusDisplayName} state.", x => x.EvaluationStartDate));
                }

                if (!EvaluationEndDate.HasValue)
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, DateTime?>($"{FieldDefinitionEnum.EvaluationEndDate.ToType().GetFieldDefinitionLabel()} is required when {FieldDefinitionEnum.EvaluationStatus.ToType().GetFieldDefinitionLabel()} is not in the {EvaluationStatus.Draft.EvaluationStatusDisplayName} state.", x => x.EvaluationEndDate));
                }
            }


            return validationResults;
        }

    }
}
