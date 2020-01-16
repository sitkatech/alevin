using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public class EditRequisitionInformationViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.Agreement)]
        public int? AgreementID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RequisitionNumber)]
        public string RequisitionNumber { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RequisitionDate)]
        public DateTime? RequisitionDate { get; set; }

        [StringLength(ProjectFirmaModels.Models.ReclamationAgreementRequest.FieldLengths.ContractSpecialist)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ContractSpecialist)]
        public string ContractSpecialist { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.AssignedDate)]
        public DateTime? AssignedDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.DateSentForDeptReview)]
        public DateTime? DateSentForDeptReview { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.DCApprovalDate)]
        public DateTime? DCApprovalDate { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ActualAwardDate)]
        public DateTime? ActualAwardDate { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditRequisitionInformationViewModel()
        {

        }

        public EditRequisitionInformationViewModel(ReclamationAgreementRequest agreementRequest)
        {
            AgreementID = agreementRequest.AgreementID;
            RequisitionNumber = agreementRequest.RequisitionNumber;
            RequisitionDate = agreementRequest.RequisitionDate;
            ContractSpecialist = agreementRequest.ContractSpecialist;
            AssignedDate = agreementRequest.AssignedDate;
            DateSentForDeptReview = agreementRequest.DateSentForDeptReview;
            DCApprovalDate = agreementRequest.DCApprovalDate;
            ActualAwardDate = agreementRequest.ActualAwardDate;
        }


        public void UpdateModel(ProjectFirmaModels.Models.ReclamationAgreementRequest agreementRequest, FirmaSession currentFirmaSession)
        {
            agreementRequest.AgreementID = AgreementID;
            agreementRequest.RequisitionNumber = RequisitionNumber;
            agreementRequest.RequisitionDate = RequisitionDate;
            agreementRequest.ContractSpecialist = ContractSpecialist;
            agreementRequest.AssignedDate = AssignedDate;
            agreementRequest.DateSentForDeptReview = DateSentForDeptReview;
            agreementRequest.DCApprovalDate = DCApprovalDate;
            agreementRequest.ActualAwardDate = ActualAwardDate;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}