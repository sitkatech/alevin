﻿/*-----------------------------------------------------------------------
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

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class EditObligationRequestViewModel : FormViewModel, IValidatableObject
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
        public int ObligationRequestStatusID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ObligationRequest.FieldLengths.DescriptionOfNeed)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.DescriptionOfNeed)]
        public string DescriptionOfNeed { get; set; }


        [FieldDefinitionDisplay(FieldDefinitionEnum.FundingPriority)]
        public int? ReclamationObligationRequestFundingPriorityID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TargetAwardDate)]
        public DateTime? TargetAwardDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.PALT)]
        public int? Palt { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.TargetSubmittalDate)]
        public DateTime? TargetSubmittalDate { get; set; }

       



        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditObligationRequestViewModel()
        {

        }


        public EditObligationRequestViewModel(ProjectFirmaModels.Models.ObligationRequest obligationRequest)
        {
            IsModification = obligationRequest.IsModification;
            AgreementID = obligationRequest.AgreementID;
            ContractTypeID = obligationRequest.ContractTypeID;
            ObligationRequestStatusID = obligationRequest.ObligationRequestStatusID;
            DescriptionOfNeed = obligationRequest.DescriptionOfNeed;
            ReclamationObligationRequestFundingPriorityID = obligationRequest.ReclamationObligationRequestFundingPriorityID;
            TargetAwardDate = obligationRequest.TargetAwardDate;
            Palt = obligationRequest.PALT;
            TargetSubmittalDate = obligationRequest.TargetSubmittalDate;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ObligationRequest obligationRequest, FirmaSession currentFirmaSession)
        {

            if (IsModification)
            {
                obligationRequest.AgreementID = AgreementID;
            }
            else
            {
                obligationRequest.AgreementID = null;
            }
            obligationRequest.IsModification = IsModification;
            obligationRequest.ContractTypeID = ContractTypeID;
            obligationRequest.ObligationRequestStatusID = ObligationRequestStatusID;
            obligationRequest.DescriptionOfNeed = DescriptionOfNeed;
            obligationRequest.ReclamationObligationRequestFundingPriorityID = ReclamationObligationRequestFundingPriorityID;
            obligationRequest.TargetAwardDate = TargetAwardDate;
            obligationRequest.PALT = Palt;
            obligationRequest.TargetSubmittalDate = TargetSubmittalDate;
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            // Agreement is required if is mod
            if (IsModification && !AgreementID.HasValue)
            {
                errors.Add(new SitkaValidationResult<EditObligationRequestViewModel, int?>($"An Agreement must be selected if the Obligation Request is a modification to an existing Agreement.", x => x.AgreementID));
            }

            if (Palt.HasValue && (Palt > 365 || Palt < 1))
            {
                errors.Add(new SitkaValidationResult<EditObligationRequestViewModel, int?>("The PALT value must be between 1 and 365", x => x.Palt));
            }

            return errors;
        }
    }
}
