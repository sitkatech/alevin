﻿/*-----------------------------------------------------------------------
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

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClosedXML.Excel;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using System;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementEditViewModel : FormViewModel, IValidatableObject
    {
        public int AgreementID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.Agreement.FieldLengths.AgreementNumber)]
        [DisplayName("Agreement Number")]
        public string AgreementNumber { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.Organization)]
        public int? OrganizationID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ContractType)]
        public int? ContractTypeID { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set;}
        
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set;}

        [FieldDefinitionDisplay(FieldDefinitionEnum.Obligation)]
        public int? ObligationNumberID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public AgreementEditViewModel()
        {
        }

        public AgreementEditViewModel(ProjectFirmaModels.Models.Agreement agreement)
        {
            AgreementNumber = agreement.AgreementNumber;
            OrganizationID = agreement.OrganizationID;
            ContractTypeID = agreement.ContractTypeID;
            StartDate = agreement.StartDate;
            EndDate = agreement.EndDate;
            var associatedObligationNumber = agreement.ObligationNumbersWhereYouAreTheReclamationAgreement.SingleOrDefault();
            ObligationNumberID = associatedObligationNumber?.ObligationNumberID;
        }

        public void UpdateModelAndSaveChanges(ProjectFirmaModels.Models.Agreement agreement,
                                              FirmaSession currentFirmaSession,
                                              DatabaseEntities databaseEntities)
        {
            agreement.AgreementNumber = this.AgreementNumber.ToUpper();
            agreement.OrganizationID = this.OrganizationID;
            agreement.ContractTypeID = this.ContractTypeID.Value;
            agreement.StartDate = this.StartDate;
            agreement.EndDate = this.EndDate;

            if (agreement.AgreementID <= 0)
            {
                // We need to save the Agreement in order to get it's primary key before it can be associated
                // with an ObligationNumber
                HttpRequestStorage.DatabaseEntities.Agreements.Add(agreement);
                HttpRequestStorage.DatabaseEntities.SaveChanges();
            }
            Check.Ensure(agreement.AgreementID > 0, "Was expecting valid primary key by now");

            // Is Obligation already set in the Agreement?
            var currentObligationNumber = agreement.ObligationNumbersWhereYouAreTheReclamationAgreement.SingleOrDefault();
            bool currentObligationNumberSet = currentObligationNumber != null;

            // Did the user set an Obligation number in their form POST?
            bool obligationWasSetInFormPost = this.ObligationNumberID.HasValue;

            // Do we need to clear the current Obligation?
            bool needToClearCurrentObligationNumber = currentObligationNumberSet;

            // Do we need to set the Obligation?
            bool needToSetObligation = obligationWasSetInFormPost;

            // Special case: User is setting Obligation to what it is already set to.
            if (obligationWasSetInFormPost && currentObligationNumberSet)
            {
                // Is the Agreement already wired to this Obligation?
                if (currentObligationNumber.ObligationNumberID == this.ObligationNumberID.Value)
                {
                    // Nothing to do
                    needToSetObligation = false;
                    needToClearCurrentObligationNumber = false;
                }
            }

            if (needToClearCurrentObligationNumber)
            {
                currentObligationNumber.ReclamationAgreement = null;
                currentObligationNumber.ReclamationAgreementID = null;
            }

            if (needToSetObligation)
            {
                var obligationNumber = databaseEntities.ObligationNumbers.Single(oNum => oNum.ObligationNumberID == this.ObligationNumberID.Value);
                obligationNumber.ReclamationAgreementID = agreement.AgreementID;
            }

            // Save changes to ObligationNumber
            HttpRequestStorage.DatabaseEntities.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (this.ObligationNumberID.HasValue)
            {
                var requestedObligationNumber = HttpRequestStorage.DatabaseEntities.ObligationNumbers.Single(oNum => oNum.ObligationNumberID == this.ObligationNumberID.Value);
                if (requestedObligationNumber.ObligationNumberKey.ToUpper() != this.AgreementNumber.ToUpper())
                {
                    validationResults.Add(new SitkaValidationResult<AgreementEditViewModel, string>($"If you want to associate to Obligation {requestedObligationNumber.ObligationNumberKey},<br/> Agreement Number must be the same as the Obligation Number (\"{requestedObligationNumber.ObligationNumberKey}\"),<br/> and not \"{this.AgreementNumber}\".", x => x.AgreementNumber));
                }
            }

            if (this.StartDate > this.EndDate)
            {
                validationResults.Add(new SitkaValidationResult<AgreementEditViewModel, DateTime?>($"The start date, {this.StartDate.ToStringDate()}, cannot be after the end date, {this.EndDate.ToStringDate()}.", x=>x.StartDate));
            }

            return validationResults;
        }

    }
}
