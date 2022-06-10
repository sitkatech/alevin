//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequest]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [Reclamation].[ObligationRequest] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ObligationRequest]")]
    public partial class ObligationRequest : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ObligationRequest()
        {
            this.CostAuthorityObligationRequests = new HashSet<CostAuthorityObligationRequest>();
            this.ObligationRequestSubmissionNotes = new HashSet<ObligationRequestSubmissionNote>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationRequest(int obligationRequestID, bool isModification, int? agreementID, int? obligationNumberID, int contractTypeID, int obligationRequestStatusID, string descriptionOfNeed, int? reclamationObligationRequestFundingPriorityID, DateTime? targetAwardDate, int? pALT, DateTime? targetSubmittalDate, DateTime createDate, int createPersonID, DateTime? updateDate, int? updatePersonID, string requisitionNumber, DateTime? requisitionDate, string contractSpecialist, DateTime? assignedDate, DateTime? dateSentForDeptReview, DateTime? dCApprovalDate, DateTime? actualAwardDate, int? modNumber) : this()
        {
            this.ObligationRequestID = obligationRequestID;
            this.IsModification = isModification;
            this.AgreementID = agreementID;
            this.ObligationNumberID = obligationNumberID;
            this.ContractTypeID = contractTypeID;
            this.ObligationRequestStatusID = obligationRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.ReclamationObligationRequestFundingPriorityID = reclamationObligationRequestFundingPriorityID;
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
            this.ModNumber = modNumber;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationRequest(bool isModification, int contractTypeID, int obligationRequestStatusID, string descriptionOfNeed, DateTime createDate, int createPersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ObligationRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IsModification = isModification;
            this.ContractTypeID = contractTypeID;
            this.ObligationRequestStatusID = obligationRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.CreateDate = createDate;
            this.CreatePersonID = createPersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ObligationRequest(bool isModification, ContractType contractType, ObligationRequestStatus obligationRequestStatus, string descriptionOfNeed, DateTime createDate, Person createPerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ObligationRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.IsModification = isModification;
            this.ContractTypeID = contractType.ContractTypeID;
            this.ContractType = contractType;
            contractType.ObligationRequests.Add(this);
            this.ObligationRequestStatusID = obligationRequestStatus.ObligationRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.CreateDate = createDate;
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.ObligationRequestsWhereYouAreTheCreatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ObligationRequest CreateNewBlank(ContractType contractType, ObligationRequestStatus obligationRequestStatus, Person createPerson)
        {
            return new ObligationRequest(default(bool), contractType, obligationRequestStatus, default(string), default(DateTime), createPerson);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return CostAuthorityObligationRequests.Any() || ObligationRequestSubmissionNotes.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(CostAuthorityObligationRequests.Any())
            {
                dependentObjects.Add(typeof(CostAuthorityObligationRequest).Name);
            }

            if(ObligationRequestSubmissionNotes.Any())
            {
                dependentObjects.Add(typeof(ObligationRequestSubmissionNote).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ObligationRequest).Name, typeof(CostAuthorityObligationRequest).Name, typeof(ObligationRequestSubmissionNote).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ObligationRequests.Remove(this);
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

            foreach(var x in CostAuthorityObligationRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ObligationRequestSubmissionNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ObligationRequestID { get; set; }
        public bool IsModification { get; set; }
        public int? AgreementID { get; set; }
        public int? ObligationNumberID { get; set; }
        public int ContractTypeID { get; set; }
        public int ObligationRequestStatusID { get; set; }
        public string DescriptionOfNeed { get; set; }
        public int? ReclamationObligationRequestFundingPriorityID { get; set; }
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
        public int? ModNumber { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ObligationRequestID; } set { ObligationRequestID = value; } }

        public virtual ICollection<CostAuthorityObligationRequest> CostAuthorityObligationRequests { get; set; }
        public virtual ICollection<ObligationRequestSubmissionNote> ObligationRequestSubmissionNotes { get; set; }
        public virtual Agreement Agreement { get; set; }
        public virtual ObligationNumber ObligationNumber { get; set; }
        public virtual ContractType ContractType { get; set; }
        public ObligationRequestStatus ObligationRequestStatus { get { return ObligationRequestStatus.AllLookupDictionary[ObligationRequestStatusID]; } }
        public ObligationRequestFundingPriority ReclamationObligationRequestFundingPriority { get { return ReclamationObligationRequestFundingPriorityID.HasValue ? ObligationRequestFundingPriority.AllLookupDictionary[ReclamationObligationRequestFundingPriorityID.Value] : null; } }
        public virtual Person CreatePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int DescriptionOfNeed = 250;
            public const int RequisitionNumber = 50;
            public const int ContractSpecialist = 250;
        }
    }
}