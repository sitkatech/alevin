﻿/*-----------------------------------------------------------------------
<copyright file="EditSubGoalViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Assessment
{
    public class EditSubGoalViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Title")]
        [StringLength(AssessmentSubGoal.FieldLengths.AssessmentSubGoalTitle)]
        
        public string AssessmentSubGoalTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(AssessmentSubGoal.FieldLengths.AssessmentSubGoalDescription)]
        public string AssessmentSubGoalDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditSubGoalViewModel()
        {
        }

        public EditSubGoalViewModel(AssessmentSubGoal assessmentSubGoal)
        {
            AssessmentSubGoalDescription = assessmentSubGoal.AssessmentSubGoalDescription;
            AssessmentSubGoalTitle = assessmentSubGoal.AssessmentSubGoalTitle;
        }

        public void UpdateModel(AssessmentSubGoal assessmentSubGoal, FirmaSession currentFirmaSession)
        {
            assessmentSubGoal.AssessmentSubGoalDescription = AssessmentSubGoalDescription;
            assessmentSubGoal.AssessmentSubGoalTitle = AssessmentSubGoalTitle;
        }
    }
}
