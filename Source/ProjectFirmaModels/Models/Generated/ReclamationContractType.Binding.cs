//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationContractType]
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
    // Table [Reclamation].[ReclamationContractType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationContractType]")]
    public partial class ReclamationContractType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationContractType()
        {
            this.ReclamationAgreementsWhereYouAreTheContractType = new HashSet<ReclamationAgreement>();
            this.ReclamationAgreementRequestsWhereYouAreTheContractType = new HashSet<ReclamationAgreementRequest>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationContractType(int reclamationContractTypeID, string contractTypeName, string contractTypeDisplayName) : this()
        {
            this.ReclamationContractTypeID = reclamationContractTypeID;
            this.ContractTypeName = contractTypeName;
            this.ContractTypeDisplayName = contractTypeDisplayName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationContractType CreateNewBlank()
        {
            return new ReclamationContractType();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationAgreementsWhereYouAreTheContractType.Any() || ReclamationAgreementRequestsWhereYouAreTheContractType.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationContractType).Name, typeof(ReclamationAgreement).Name, typeof(ReclamationAgreementRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationContractTypes.Remove(this);
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

            foreach(var x in ReclamationAgreementsWhereYouAreTheContractType.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationAgreementRequestsWhereYouAreTheContractType.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationContractTypeID { get; set; }
        public string ContractTypeName { get; set; }
        public string ContractTypeDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationContractTypeID; } set { ReclamationContractTypeID = value; } }

        public virtual ICollection<ReclamationAgreement> ReclamationAgreementsWhereYouAreTheContractType { get; set; }
        public virtual ICollection<ReclamationAgreementRequest> ReclamationAgreementRequestsWhereYouAreTheContractType { get; set; }

        public static class FieldLengths
        {
            public const int ContractTypeName = 255;
            public const int ContractTypeDisplayName = 255;
        }
    }
}