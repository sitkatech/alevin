//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementRequest]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [Reclamation].[AgreementRequest] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[AgreementRequest]")]
    public partial class AgreementRequest : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AgreementRequest()
        {
            this.AgreementRequestSubmissionNotesWhereYouAreTheReclamationAgreementRequest = new HashSet<AgreementRequestSubmissionNote>();
            this.CostAuthorityAgreementRequests = new HashSet<CostAuthorityAgreementRequest>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AgreementRequest(int agreementRequestID, bool isModification, int? agreementID, int contractTypeID, int agreementRequestStatusID, string descriptionOfNeed, int? reclamationAgreementRequestFundingPriorityID, int? recipientOrganizationID, int? technicalRepresentativePersonID, DateTime? targetAwardDate, int? pALT, DateTime? targetSubmittalDate, DateTime createDate, int createPersonID, DateTime? updateDate, int? updatePersonID, string requisitionNumber, DateTime? requisitionDate, string contractSpecialist, DateTime? assignedDate, DateTime? dateSentForDeptReview, DateTime? dCApprovalDate, DateTime? actualAwardDate) : this()
        {
            this.AgreementRequestID = agreementRequestID;
            this.IsModification = isModification;
            this.AgreementID = agreementID;
            this.ContractTypeID = contractTypeID;
            this.AgreementRequestStatusID = agreementRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.ReclamationAgreementRequestFundingPriorityID = reclamationAgreementRequestFundingPriorityID;
            this.RecipientOrganizationID = recipientOrganizationID;
            this.TechnicalRepresentativePersonID = technicalRepresentativePersonID;
            this.TargetAwardDate = targetAwardDate;
            this.PALT = pALT;
            this.TargetSubmittalDate = targetSubmittalDate;
            this.CreateDate = createDate;
            this.CreatePersonID = createPersonID;
            this.UpdateDate = updateDate;
            this.UpdatePersonID = updatePersonID;
            this.RequisitionNumber = requisitionNumber;
            this.RequisitionDate = requisitionDate;
            this.ContractSpecialist = contractSpecialist;
            this.AssignedDate = assignedDate;
            this.DateSentForDeptReview = dateSentForDeptReview;
            this.DCApprovalDate = dCApprovalDate;
            this.ActualAwardDate = actualAwardDate;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AgreementRequest(bool isModification, int contractTypeID, int agreementRequestStatusID, string descriptionOfNeed, DateTime createDate, int createPersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IsModification = isModification;
            this.ContractTypeID = contractTypeID;
            this.AgreementRequestStatusID = agreementRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.CreateDate = createDate;
            this.CreatePersonID = createPersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AgreementRequest(bool isModification, ContractType contractType, AgreementRequestStatus agreementRequestStatus, string descriptionOfNeed, DateTime createDate, Person createPerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IsModification = isModification;
            this.ContractTypeID = contractType.ContractTypeID;
            this.ContractType = contractType;
            contractType.AgreementRequests.Add(this);
            this.AgreementRequestStatusID = agreementRequestStatus.AgreementRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.CreateDate = createDate;
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.AgreementRequestsWhereYouAreTheCreatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AgreementRequest CreateNewBlank(ContractType contractType, AgreementRequestStatus agreementRequestStatus, Person createPerson)
        {
            return new AgreementRequest(default(bool), contractType, agreementRequestStatus, default(string), default(DateTime), createPerson);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AgreementRequestSubmissionNotesWhereYouAreTheReclamationAgreementRequest.Any() || CostAuthorityAgreementRequests.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AgreementRequest).Name, typeof(AgreementRequestSubmissionNote).Name, typeof(CostAuthorityAgreementRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AgreementRequests.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in AgreementRequestSubmissionNotesWhereYouAreTheReclamationAgreementRequest.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorityAgreementRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int AgreementRequestID { get; set; }
        public bool IsModification { get; set; }
        public int? AgreementID { get; set; }
        public int ContractTypeID { get; set; }
        public int AgreementRequestStatusID { get; set; }
        public string DescriptionOfNeed { get; set; }
        public int? ReclamationAgreementRequestFundingPriorityID { get; set; }
        public int? RecipientOrganizationID { get; set; }
        public int? TechnicalRepresentativePersonID { get; set; }
        public DateTime? TargetAwardDate { get; set; }
        public int? PALT { get; set; }
        public DateTime? TargetSubmittalDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatePersonID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdatePersonID { get; set; }
        public string RequisitionNumber { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public string ContractSpecialist { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? DateSentForDeptReview { get; set; }
        public DateTime? DCApprovalDate { get; set; }
        public DateTime? ActualAwardDate { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AgreementRequestID; } set { AgreementRequestID = value; } }

        public virtual ICollection<AgreementRequestSubmissionNote> AgreementRequestSubmissionNotesWhereYouAreTheReclamationAgreementRequest { get; set; }
        public virtual ICollection<CostAuthorityAgreementRequest> CostAuthorityAgreementRequests { get; set; }
        public virtual Agreement Agreement { get; set; }
        public virtual ContractType ContractType { get; set; }
        public AgreementRequestStatus AgreementRequestStatus { get { return AgreementRequestStatus.AllLookupDictionary[AgreementRequestStatusID]; } }
        public AgreementRequestFundingPriority ReclamationAgreementRequestFundingPriority { get { return ReclamationAgreementRequestFundingPriorityID.HasValue ? AgreementRequestFundingPriority.AllLookupDictionary[ReclamationAgreementRequestFundingPriorityID.Value] : null; } }
        public virtual Organization RecipientOrganization { get; set; }
        public virtual Person CreatePerson { get; set; }
        public virtual Person TechnicalRepresentativePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int DescriptionOfNeed = 250;
            public const int RequisitionNumber = 50;
            public const int ContractSpecialist = 250;
        }
    }
}