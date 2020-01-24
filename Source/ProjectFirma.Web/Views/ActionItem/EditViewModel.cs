/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ActionItem
{

    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int ActionItemID { get; set; }


        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemText)]
        [Required]
        [StringLength(ProjectFirmaModels.Models.ActionItem.FieldLengths.ActionItemText)]
        public string ActionItemText { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemState)]
        public ActionItemStateEnum ActionItemStateEnum { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemAssignedToPerson)]
        public int AssignedToPersonID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemAssignedOnDate)]
        public DateTime AssignedOnDate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemDueByDate)]
        public DateTime DueByDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemCompletedOnDate)]
        public DateTime? CompletedOnDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemProjectStatus)]
        public int? ProjectProjectStatusID { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.ActionItem actionItem)
        {
            ActionItemID = actionItem.ActionItemID;
            ProjectID = actionItem.ProjectID;
            ActionItemText = actionItem.ActionItemText;
            ActionItemStateEnum = actionItem.ActionItemState.ToEnum;
            AssignedToPersonID = actionItem.AssignedToPersonID;
            AssignedOnDate = actionItem.AssignedOnDate;
            DueByDate = actionItem.DueByDate;
            CompletedOnDate = actionItem.CompletedOnDate;
            ProjectProjectStatusID = actionItem.ProjectProjectStatusID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ActionItem actionItem, FirmaSession currentFirmaSession)
        {
            actionItem.ProjectID = ProjectID;
            actionItem.ActionItemText = ActionItemText;
            actionItem.ActionItemStateID = (int) ActionItemStateEnum;
            actionItem.AssignedToPersonID = AssignedToPersonID;
            actionItem.AssignedOnDate = AssignedOnDate;
            actionItem.DueByDate = DueByDate;
            actionItem.CompletedOnDate = CompletedOnDate;
            actionItem.ProjectProjectStatusID = ProjectProjectStatusID;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            // todo: Due by date cant be before the assigned date

            // todo: Completed date can't be before the assigned date

            return validationResults;
        }

    }
}
