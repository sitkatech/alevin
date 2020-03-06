//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementCostAuthority]
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
    // Table [Reclamation].[AgreementCostAuthority] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[AgreementCostAuthority]")]
    public partial class AgreementCostAuthority : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AgreementCostAuthority()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AgreementCostAuthority(int agreementCostAuthorityID, int agreementID, int costAuthorityID) : this()
        {
            this.AgreementCostAuthorityID = agreementCostAuthorityID;
            this.AgreementID = agreementID;
            this.CostAuthorityID = costAuthorityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AgreementCostAuthority(int agreementID, int costAuthorityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AgreementCostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.AgreementID = agreementID;
            this.CostAuthorityID = costAuthorityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AgreementCostAuthority(Agreement agreement, CostAuthority costAuthority) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.AgreementCostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.AgreementID = agreement.AgreementID;
            this.Agreement = agreement;
            agreement.AgreementCostAuthorities.Add(this);
            this.CostAuthorityID = costAuthority.ReclamationCostAuthorityID;
            this.CostAuthority = costAuthority;
            costAuthority.AgreementCostAuthoritiesWhereYouAreTheCostAuthority.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AgreementCostAuthority CreateNewBlank(Agreement agreement, CostAuthority costAuthority)
        {
            return new AgreementCostAuthority(agreement, costAuthority);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AgreementCostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AgreementCostAuthorities.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int AgreementCostAuthorityID { get; set; }
        public int AgreementID { get; set; }
        public int CostAuthorityID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return AgreementCostAuthorityID; } set { AgreementCostAuthorityID = value; } }

        public virtual Agreement Agreement { get; set; }
        public virtual CostAuthority CostAuthority { get; set; }

        public static class FieldLengths
        {

        }
    }
}