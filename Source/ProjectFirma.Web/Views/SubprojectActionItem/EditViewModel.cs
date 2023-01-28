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
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.SubprojectActionItem
{

    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int SubprojectID { get; set; }

        [Required]
        public int ActionItemID { get; set; }


        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectActionItemText)]
        [Required]
        [StringLength(ProjectFirmaModels.Models.SubprojectActionItem.FieldLengths.SubprojectActionItemText)]
        public string ActionItemText { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectActionItemState)]
        public ActionItemStateEnum ActionItemStateEnum { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectActionItemAssignedToPerson)]
        public int AssignedToPersonID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectActionItemAssignedOnDate)]
        public DateTime AssignedOnDate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectActionItemDueByDate)]
        public DateTime DueByDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.SubprojectActionItemCompletedOnDate)]
        public DateTime? CompletedOnDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ActionItemProjectStatus)]
        public int? SubprojectProjectStatusID { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.SubprojectActionItem actionItem)
        {
            ActionItemID = actionItem.SubprojectActionItemID;
            SubprojectID = actionItem.SubprojectID;
            ActionItemText = actionItem.SubprojectActionItemText;
            ActionItemStateEnum = actionItem.ActionItemState.ToEnum;
            AssignedToPersonID = actionItem.AssignedToPersonID;
            AssignedOnDate = actionItem.AssignedOnDate;
            DueByDate = actionItem.DueByDate;
            CompletedOnDate = actionItem.CompletedOnDate;
            SubprojectProjectStatusID = actionItem.SubprojectProjectStatusID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.SubprojectActionItem actionItem, FirmaSession currentFirmaSession)
        {
            actionItem.SubprojectID = SubprojectID;
            actionItem.SubprojectActionItemText = ActionItemText;
            actionItem.ActionItemStateID = (int) ActionItemStateEnum;
            actionItem.AssignedToPersonID = AssignedToPersonID;
            actionItem.AssignedOnDate = AssignedOnDate;
            actionItem.DueByDate = DueByDate;
            actionItem.CompletedOnDate = CompletedOnDate;
            actionItem.SubprojectProjectStatusID = SubprojectProjectStatusID;
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
