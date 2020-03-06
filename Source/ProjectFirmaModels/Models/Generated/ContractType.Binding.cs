//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ContractType]
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
    // Table [Reclamation].[ContractType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ContractType]")]
    public partial class ContractType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ContractType()
        {
            this.Agreements = new HashSet<Agreement>();
            this.AgreementRequests = new HashSet<AgreementRequest>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContractType(int contractTypeID, string contractTypeName, string contractTypeDisplayName) : this()
        {
            this.ContractTypeID = contractTypeID;
            this.ContractTypeName = contractTypeName;
            this.ContractTypeDisplayName = contractTypeDisplayName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ContractType CreateNewBlank()
        {
            return new ContractType();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Agreements.Any() || AgreementRequests.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ContractType).Name, typeof(Agreement).Name, typeof(AgreementRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ContractTypes.Remove(this);
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

            foreach(var x in Agreements.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in AgreementRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ContractTypeID { get; set; }
        public string ContractTypeName { get; set; }
        public string ContractTypeDisplayName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ContractTypeID; } set { ContractTypeID = value; } }

        public virtual ICollection<Agreement> Agreements { get; set; }
        public virtual ICollection<AgreementRequest> AgreementRequests { get; set; }

        public static class FieldLengths
        {
            public const int ContractTypeName = 255;
            public const int ContractTypeDisplayName = 255;
        }
    }
}