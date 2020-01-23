/*-----------------------------------------------------------------------
<copyright file="EditNoteViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public class EditCostAuthorityAgreementRequestViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure)]
        public string CostAuthorityWorkBreakdownStructure { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.AccountStructureDescription)]
        public string AccountStructureDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectedObligation)]
        public Money? ProjectedObligation { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityAgreementRequestNote)]
        public string ReclamationCostAuthorityAgreementRequestNote { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditCostAuthorityAgreementRequestViewModel()
        {

        }


        public EditCostAuthorityAgreementRequestViewModel(ReclamationCostAuthorityAgreementRequest costAuthorityAgreementRequest)
        {
            CostAuthorityWorkBreakdownStructure = costAuthorityAgreementRequest.CostAuthority.CostAuthorityWorkBreakdownStructure;
            AccountStructureDescription = costAuthorityAgreementRequest.CostAuthority.AccountStructureDescription;
            ProjectedObligation = costAuthorityAgreementRequest.ProjectedObligation;
            ReclamationCostAuthorityAgreementRequestNote = costAuthorityAgreementRequest.ReclamationCostAuthorityAgreementRequestNote;
        }

        public void UpdateModel(ReclamationCostAuthorityAgreementRequest costAuthorityAgreementRequest, FirmaSession currentFirmaSession)
        {
            costAuthorityAgreementRequest.ProjectedObligation = ProjectedObligation;
            costAuthorityAgreementRequest.ReclamationCostAuthorityAgreementRequestNote = ReclamationCostAuthorityAgreementRequestNote;


        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}
