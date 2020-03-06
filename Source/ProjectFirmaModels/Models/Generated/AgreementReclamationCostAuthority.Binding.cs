//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementReclamationCostAuthority]
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
    // Table [Reclamation].[AgreementReclamationCostAuthority] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[AgreementReclamationCostAuthority]")]
    public partial class AgreementReclamationCostAuthority : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected AgreementReclamationCostAuthority()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public AgreementReclamationCostAuthority(int reclamationAgreementReclamationCostAuthorityID, int reclamationAgreementID, int reclamationCostAuthorityID) : this()
        {
            this.ReclamationAgreementReclamationCostAuthorityID = reclamationAgreementReclamationCostAuthorityID;
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public AgreementReclamationCostAuthority(int reclamationAgreementID, int reclamationCostAuthorityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementReclamationCostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public AgreementReclamationCostAuthority(Agreement reclamationAgreement, CostAuthority reclamationCostAuthority) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementReclamationCostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ReclamationAgreementID = reclamationAgreement.ReclamationAgreementID;
            this.ReclamationAgreement = reclamationAgreement;
            reclamationAgreement.AgreementReclamationCostAuthorities.Add(this);
            this.ReclamationCostAuthorityID = reclamationCostAuthority.ReclamationCostAuthorityID;
            this.ReclamationCostAuthority = reclamationCostAuthority;
            reclamationCostAuthority.AgreementReclamationCostAuthorities.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static AgreementReclamationCostAuthority CreateNewBlank(Agreement reclamationAgreement, CostAuthority reclamationCostAuthority)
        {
            return new AgreementReclamationCostAuthority(reclamationAgreement, reclamationCostAuthority);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(AgreementReclamationCostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AgreementReclamationCostAuthorities.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationAgreementReclamationCostAuthorityID { get; set; }
        public int ReclamationAgreementID { get; set; }
        public int ReclamationCostAuthorityID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationAgreementReclamationCostAuthorityID; } set { ReclamationAgreementReclamationCostAuthorityID = value; } }

        public virtual Agreement ReclamationAgreement { get; set; }
        public virtual CostAuthority ReclamationCostAuthority { get; set; }

        public static class FieldLengths
        {

        }
    }
}