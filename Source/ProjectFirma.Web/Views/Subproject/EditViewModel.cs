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

namespace ProjectFirma.Web.Views.Subproject
{

    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int SubprojectID { get; set; }

        public int ProjectStageID { get; set; }
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ImplementationStartYear)]
        public int? ImplementationStartYear { get; set; }
        public int? CompletionYear { get; set; }
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
            SubprojectID = subproject.SubprojectID;
            ProjectStageID = subproject.ProjectStageID;
            ImplementationStartYear = subproject.ImplementationStartYear;
            CompletionYear = subproject.CompletionYear;
            Notes = subproject.Notes;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Subproject subproject, FirmaSession currentFirmaSession)
        {
            subproject.ProjectStageID = ProjectStageID;
            subproject.ImplementationStartYear = ImplementationStartYear;
            subproject.CompletionYear = CompletionYear;
            subproject.Notes = Notes;

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            

            return validationResults;
        }

    }
}
