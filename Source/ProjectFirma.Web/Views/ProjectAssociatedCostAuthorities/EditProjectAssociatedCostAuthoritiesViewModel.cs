/*-----------------------------------------------------------------------
<copyright file="EditContactsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectAssociatedCostAuthorities
{
    public class EditProjectAssociatedCostAuthoritiesViewModel : FormViewModel, IValidatableObject
    {

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure)]
        public List<int> SelectedReclamationCostAuthorityIDs { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditProjectAssociatedCostAuthoritiesViewModel()
        {
        }

        public EditProjectAssociatedCostAuthoritiesViewModel(ProjectFirmaModels.Models.Project project, Person currentPerson)
        {
            SelectedReclamationCostAuthorityIDs = project.ReclamationCostAuthorityProjects
                .Select(x => x.ReclamationCostAuthorityID).ToList();
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            DbSet<ReclamationCostAuthorityProject> allProjectReclamationCostAuthoritiesInDatabase, Person currentPerson)
        {
            var projectReclamationCostAuthoritiesUpdated =
                SelectedReclamationCostAuthorityIDs.Select(x =>
                    new ReclamationCostAuthorityProject(x, project.ProjectID)).ToList();

            project.ReclamationCostAuthorityProjects.Merge(
                projectReclamationCostAuthoritiesUpdated,
                allProjectReclamationCostAuthoritiesInDatabase.Local,  
                (x, y) => x.ProjectID == y.ProjectID && x.ReclamationCostAuthorityID == y.ReclamationCostAuthorityID, 
                HttpRequestStorage.DatabaseEntities);
            
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            if (!SelectedReclamationCostAuthorityIDs.Any())
            {
                var error = new SitkaValidationResult<EditProjectAssociatedCostAuthoritiesViewModel, List<int>>($"Must submit at least one value for {FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabelPluralized()}", x => x.SelectedReclamationCostAuthorityIDs);
                errors.Add(error);
            }

            return errors;
        }
    }
}
