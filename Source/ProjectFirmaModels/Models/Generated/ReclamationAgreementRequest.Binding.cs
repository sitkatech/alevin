//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementRequest]
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
    // Table [dbo].[ReclamationAgreementRequest] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationAgreementRequest]")]
    public partial class ReclamationAgreementRequest : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationAgreementRequest()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementRequest(int reclamationAgreementRequestID, int contractTypeID, int agreementRequestStatusID, string descriptionOfNeed, int? reclamationAgreementRequestFundingPriorityID, int? recipientOrganizationID, int? technicalRepresentativePersonID, DateTime? targetAwardDate, int? pALT, DateTime? targetSubmittalDate, DateTime createDate, int createPersonID, DateTime? updateDate, int? updatePersonID) : this()
        {
            this.ReclamationAgreementRequestID = reclamationAgreementRequestID;
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
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementRequest(int contractTypeID, int agreementRequestStatusID, string descriptionOfNeed, DateTime createDate, int createPersonID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ContractTypeID = contractTypeID;
            this.AgreementRequestStatusID = agreementRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.CreateDate = createDate;
            this.CreatePersonID = createPersonID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReclamationAgreementRequest(ReclamationContractType contractType, ReclamationAgreementRequestStatus agreementRequestStatus, string descriptionOfNeed, DateTime createDate, Person createPerson) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementRequestID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ContractTypeID = contractType.ReclamationContractTypeID;
            this.ContractType = contractType;
            contractType.ReclamationAgreementRequestsWhereYouAreTheContractType.Add(this);
            this.AgreementRequestStatusID = agreementRequestStatus.ReclamationAgreementRequestStatusID;
            this.DescriptionOfNeed = descriptionOfNeed;
            this.CreateDate = createDate;
            this.CreatePersonID = createPerson.PersonID;
            this.CreatePerson = createPerson;
            createPerson.ReclamationAgreementRequestsWhereYouAreTheCreatePerson.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationAgreementRequest CreateNewBlank(ReclamationContractType contractType, ReclamationAgreementRequestStatus agreementRequestStatus, Person createPerson)
        {
            return new ReclamationAgreementRequest(contractType, agreementRequestStatus, default(string), default(DateTime), createPerson);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationAgreementRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationAgreementRequests.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationAgreementRequestID { get; set; }
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
        [NotMapped]
        public int PrimaryKey { get { return ReclamationAgreementRequestID; } set { ReclamationAgreementRequestID = value; } }

        public virtual ReclamationContractType ContractType { get; set; }
        public ReclamationAgreementRequestStatus AgreementRequestStatus { get { return ReclamationAgreementRequestStatus.AllLookupDictionary[AgreementRequestStatusID]; } }
        public ReclamationAgreementRequestFundingPriority ReclamationAgreementRequestFundingPriority { get { return ReclamationAgreementRequestFundingPriorityID.HasValue ? ReclamationAgreementRequestFundingPriority.AllLookupDictionary[ReclamationAgreementRequestFundingPriorityID.Value] : null; } }
        public virtual Organization RecipientOrganization { get; set; }
        public virtual Person CreatePerson { get; set; }
        public virtual Person TechnicalRepresentativePerson { get; set; }
        public virtual Person UpdatePerson { get; set; }

        public static class FieldLengths
        {
            public const int DescriptionOfNeed = 250;
        }
    }
}