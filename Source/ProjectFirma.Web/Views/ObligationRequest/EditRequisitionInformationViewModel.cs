using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class EditRequisitionInformationViewModel : FormViewModel, IValidatableObject
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.Agreement)]
        public int? AgreementID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RequisitionNumber)]
        public string RequisitionNumber { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.RequisitionDate)]
        public DateTime? RequisitionDate { get; set; }

        [StringLength(ProjectFirmaModels.Models.ObligationRequest.FieldLengths.ContractSpecialist)]
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

        public EditRequisitionInformationViewModel(ProjectFirmaModels.Models.ObligationRequest obligationRequest)
        {
            AgreementID = obligationRequest.AgreementID;
            RequisitionNumber = obligationRequest.RequisitionNumber;
            RequisitionDate = obligationRequest.RequisitionDate;
            ContractSpecialist = obligationRequest.ContractSpecialist;
            AssignedDate = obligationRequest.AssignedDate;
            DateSentForDeptReview = obligationRequest.DateSentForDeptReview;
            DCApprovalDate = obligationRequest.DCApprovalDate;
            ActualAwardDate = obligationRequest.ActualAwardDate;
        }


        public void UpdateModel(ProjectFirmaModels.Models.ObligationRequest obligationRequest, FirmaSession currentFirmaSession)
        {
            obligationRequest.AgreementID = AgreementID;
            obligationRequest.RequisitionNumber = RequisitionNumber;
            obligationRequest.RequisitionDate = RequisitionDate;
            obligationRequest.ContractSpecialist = ContractSpecialist;
            obligationRequest.AssignedDate = AssignedDate;
            obligationRequest.DateSentForDeptReview = DateSentForDeptReview;
            obligationRequest.DCApprovalDate = DCApprovalDate;
            obligationRequest.ActualAwardDate = ActualAwardDate;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}