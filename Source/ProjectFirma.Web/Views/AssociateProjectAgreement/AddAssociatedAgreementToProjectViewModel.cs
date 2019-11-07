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
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.AttachmentRelationshipType;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AssociateProjectAgreement
{
    public class AddAssociatedAgreementToProjectViewModel : FormViewModel, IValidatableObject
    {

        
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.Agreement)]
        public int SelectedReclamationAgreementID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure)]
        public int SelectedReclamationCostAuthorityID { get; set; }


        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public AddAssociatedAgreementToProjectViewModel()
        {
        }

        public AddAssociatedAgreementToProjectViewModel(ProjectFirmaModels.Models.Project project, Person currentPerson)
        {
            
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, ICollection<ProjectFirmaModels.Models.ProjectContact> allProjectContacts)
        {
           
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();

            // the value 0 is reserved for the default disabled option. If it is submitted, return an error.
            if (SelectedReclamationAgreementID == 0)
            {
                var error = new SitkaValidationResult<AddAssociatedAgreementToProjectViewModel, int>($"Must submit a value for {FieldDefinitionEnum.Agreement.ToType().FieldDefinitionDisplayName}", x => x.SelectedReclamationAgreementID);
                errors.Add(error);
            }

            return errors;
        }
    }
}
