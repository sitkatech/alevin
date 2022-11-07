/*-----------------------------------------------------------------------
<copyright file="EditNoteViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class EditCostAuthorityObligationRequestViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure)]
        public string CostAuthorityWorkBreakdownStructure { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.AccountStructureDescription)]
        public string AccountStructureDescription { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectedObligation)]
        public Money? ProjectedObligation { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityObligationRequestNote)]
        public string CostAuthorityObligationRequestNote { get; set; }


        [FieldDefinitionDisplay(FieldDefinitionEnum.BudgetObjectCode)]
        public int? BudgetObjectCodeID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RecipientOrganization)]
        public int? RecipientOgranizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TechnicalRepresentative)]
        public int? TechnicalRepresentativeID { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditCostAuthorityObligationRequestViewModel()
        {

        }


        public EditCostAuthorityObligationRequestViewModel(CostAuthorityObligationRequest costAuthorityObligationRequest)
        {
            CostAuthorityWorkBreakdownStructure = costAuthorityObligationRequest.CostAuthority.CostAuthorityWorkBreakdownStructure;
            AccountStructureDescription = costAuthorityObligationRequest.CostAuthority.AccountStructureDescription;
            ProjectedObligation = costAuthorityObligationRequest.ProjectedObligation;
            CostAuthorityObligationRequestNote = costAuthorityObligationRequest.CostAuthorityObligationRequestNote;
            TechnicalRepresentativeID = costAuthorityObligationRequest.TechnicalRepresentativePersonID;
            RecipientOgranizationID = costAuthorityObligationRequest.RecipientOrganizationID;
            BudgetObjectCodeID = costAuthorityObligationRequest.BudgetObjectCodeID;
        }

        public void UpdateModel(CostAuthorityObligationRequest costAuthorityObligationRequest, FirmaSession currentFirmaSession)
        {
            costAuthorityObligationRequest.ProjectedObligation = ProjectedObligation;
            costAuthorityObligationRequest.CostAuthorityObligationRequestNote = CostAuthorityObligationRequestNote;
            costAuthorityObligationRequest.RecipientOrganizationID = RecipientOgranizationID;
            costAuthorityObligationRequest.TechnicalRepresentativePersonID = TechnicalRepresentativeID;
            costAuthorityObligationRequest.BudgetObjectCodeID = BudgetObjectCodeID;


        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}
