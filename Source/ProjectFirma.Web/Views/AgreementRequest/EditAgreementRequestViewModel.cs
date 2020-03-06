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
    public class EditAgreementRequestViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IsModification)]
        public bool IsModification { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.Agreement)]
        public int? AgreementID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ContractType)]
        public int ContractTypeID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.RequestStatus)]
        public int AgreementRequestStatusID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.AgreementRequest.FieldLengths.DescriptionOfNeed)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.DescriptionOfNeed)]
        public string DescriptionOfNeed { get; set; }


        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingPriority)]
        public int? ReclamationAgreementRequestFundingPriorityID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RecipientOrganization)]
        public int? RecipientOrganizationID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TechnicalRepresentative)]
        public int? TechnicalRepresentativePersonID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TargetAwardDate)]
        public DateTime? TargetAwardDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PALT)]
        public int? Palt { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TargetSubmittalDate)]
        public DateTime? TargetSubmittalDate { get; set; }

       



        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAgreementRequestViewModel()
        {

        }


        public EditAgreementRequestViewModel(ProjectFirmaModels.Models.AgreementRequest agreementRequest)
        {
            IsModification = agreementRequest.IsModification;
            AgreementID = agreementRequest.AgreementID;
            ContractTypeID = agreementRequest.ContractTypeID;
            AgreementRequestStatusID = agreementRequest.AgreementRequestStatusID;
            DescriptionOfNeed = agreementRequest.DescriptionOfNeed;
            ReclamationAgreementRequestFundingPriorityID = agreementRequest.ReclamationAgreementRequestFundingPriorityID;
            RecipientOrganizationID = agreementRequest.RecipientOrganizationID;
            TechnicalRepresentativePersonID = agreementRequest.TechnicalRepresentativePersonID;
            TargetAwardDate = agreementRequest.TargetAwardDate;
            Palt = agreementRequest.PALT;
            TargetSubmittalDate = agreementRequest.TargetSubmittalDate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.AgreementRequest agreementRequest, FirmaSession currentFirmaSession)
        {

            if (IsModification)
            {
                agreementRequest.AgreementID = AgreementID;
            }
            else
            {
                agreementRequest.AgreementID = null;
            }
            agreementRequest.IsModification = IsModification;
            agreementRequest.ContractTypeID = ContractTypeID;
            agreementRequest.AgreementRequestStatusID = AgreementRequestStatusID;
            agreementRequest.DescriptionOfNeed = DescriptionOfNeed;
            agreementRequest.ReclamationAgreementRequestFundingPriorityID = ReclamationAgreementRequestFundingPriorityID;
            agreementRequest.RecipientOrganizationID = RecipientOrganizationID;
            agreementRequest.TechnicalRepresentativePersonID = TechnicalRepresentativePersonID;
            agreementRequest.TargetAwardDate = TargetAwardDate;
            agreementRequest.PALT = Palt;
            agreementRequest.TargetSubmittalDate = TargetSubmittalDate;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Agreement is required if is mod
            if (IsModification && !AgreementID.HasValue)
            {
                errors.Add(new SitkaValidationResult<EditAgreementRequestViewModel, int?>($"An Agreement must be selected if the Agreement Request is a modification to an existing Agreement.", x => x.AgreementID));
            }

            if (Palt.HasValue && (Palt > 365 || Palt < 1))
            {
                errors.Add(new SitkaValidationResult<EditAgreementRequestViewModel, int?>("The PALT value must be between 1 and 365", x => x.Palt));
            }

            return errors;
        }
    }
}
