/*-----------------------------------------------------------------------
<copyright file="EditSubprojectProjectStatusViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.SubprojectProjectStatus
{
    public class EditSubprojectProjectStatusViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.Status)]
        public int ProjectStatusID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusUpdateDate)]
        public DateTime? ProjectStatusUpdateDate { get; set; }

        public DateTime? ProjectStatusUpdateTime { get; set; }

        [StringLength(ProjectFirmaModels.Models.SubprojectProjectStatus.FieldLengths.SubprojectProjectStatusRecentActivities)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusRecentActivities)]
        public string SubprojectProjectStatusRecentActivities { get; set; }

        [StringLength(ProjectFirmaModels.Models.SubprojectProjectStatus.FieldLengths.SubprojectProjectStatusUpcomingActivities)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusUpcomingActivities)]
        public string SubprojectProjectStatusUpcomingActivities { get; set; }

        [StringLength(ProjectFirmaModels.Models.SubprojectProjectStatus.FieldLengths.SubprojectProjectStatusRisksOrIssues)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusRisksOrIssues)]
        public string SubprojectProjectStatusRisksOrIssues { get; set; }

        [StringLength(ProjectFirmaModels.Models.SubprojectProjectStatus.FieldLengths.SubprojectProjectStatusComment)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusComments)]
        public string SubprojectProjectStatusComment { get; set; }


        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IsFinalStatusUpdate)]
        public bool IsFinalStatusUpdate { get; set; }

        [StringLength(ProjectFirmaModels.Models.SubprojectProjectStatus.FieldLengths.LessonsLearned)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StatusLessonsLearned)]
        public string LessonsLearned { get; set; }



        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditSubprojectProjectStatusViewModel()
        {
            IsFinalStatusUpdate = false;
        }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditSubprojectProjectStatusViewModel(DateTime projectStatusUpdateDate)
        {
            ProjectStatusUpdateDate = projectStatusUpdateDate;
            IsFinalStatusUpdate = false;
        }


        public EditSubprojectProjectStatusViewModel(ProjectFirmaModels.Models.SubprojectProjectStatus projectProjectStatus)
        {
            SubprojectProjectStatusRecentActivities = projectProjectStatus.SubprojectProjectStatusRecentActivities;
            SubprojectProjectStatusUpcomingActivities = projectProjectStatus.SubprojectProjectStatusUpcomingActivities;
            SubprojectProjectStatusRisksOrIssues = projectProjectStatus.SubprojectProjectStatusRisksOrIssues;
            SubprojectProjectStatusComment = projectProjectStatus.SubprojectProjectStatusComment;
            LessonsLearned = projectProjectStatus.LessonsLearned;
            ProjectStatusID = projectProjectStatus.ProjectStatusID;
            ProjectStatusUpdateDate = projectProjectStatus.SubprojectProjectStatusUpdateDate;
            IsFinalStatusUpdate = projectProjectStatus.IsFinalStatusUpdate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.SubprojectProjectStatus projectProjectStatus, FirmaSession currentFirmaSession)
        {
            projectProjectStatus.SubprojectProjectStatusRecentActivities = SubprojectProjectStatusRecentActivities;
            projectProjectStatus.SubprojectProjectStatusUpcomingActivities = SubprojectProjectStatusUpcomingActivities;
            projectProjectStatus.SubprojectProjectStatusRisksOrIssues = SubprojectProjectStatusRisksOrIssues;
            projectProjectStatus.SubprojectProjectStatusComment = SubprojectProjectStatusComment;
            if (IsFinalStatusUpdate)
            {
                projectProjectStatus.LessonsLearned = LessonsLearned;
            }
            else
            {
                projectProjectStatus.LessonsLearned = null;
            }
            projectProjectStatus.ProjectStatusID = ProjectStatusID;

            if (ProjectStatusUpdateTime.HasValue && ProjectStatusUpdateDate.HasValue)
            {
                var year = ProjectStatusUpdateDate.Value.Year;
                var month = ProjectStatusUpdateDate.Value.Month;
                var day = ProjectStatusUpdateDate.Value.Day;
                var hours = ProjectStatusUpdateTime.Value.Hour;
                var minutes = ProjectStatusUpdateTime.Value.Minute;
                var seconds = 0;
                projectProjectStatus.SubprojectProjectStatusUpdateDate = new DateTime(year, month, day, hours, minutes, seconds);
            }
            else
            {
                projectProjectStatus.SubprojectProjectStatusUpdateDate = ProjectStatusUpdateDate.Value;
            }

            projectProjectStatus.IsFinalStatusUpdate = IsFinalStatusUpdate;
            if (!ModelObjectHelpers.IsRealPrimaryKeyValue(projectProjectStatus.PrimaryKey))
            {
                projectProjectStatus.SubprojectProjectStatusCreateDate = DateTime.Now;
                projectProjectStatus.SubprojectProjectStatusCreatePerson = currentFirmaSession.Person;
            }
            else
            {
                projectProjectStatus.SubprojectProjectStatusLastEditedDate = DateTime.Now;
                projectProjectStatus.SubprojectProjectStatusLastEditedPerson = currentFirmaSession.Person;
            }
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            

            // lessons learned is required if there is not Final Status Update
            if (string.IsNullOrEmpty(LessonsLearned) && IsFinalStatusUpdate)
            {
                errors.Add(new ValidationResult($"Lessons Learned must be entered for Final Status Updates."));
            }

            return errors;
        }
    }
}
