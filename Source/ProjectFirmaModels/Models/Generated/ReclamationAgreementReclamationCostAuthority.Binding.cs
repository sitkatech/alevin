//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementReclamationCostAuthority]
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
    // Table [dbo].[ReclamationAgreementReclamationCostAuthority] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationAgreementReclamationCostAuthority]")]
    public partial class ReclamationAgreementReclamationCostAuthority : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationAgreementReclamationCostAuthority()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementReclamationCostAuthority(int reclamationAgreementReclamationCostAuthorityID, int reclamationAgreementID, int reclamationCostAuthorityID) : this()
        {
            this.ReclamationAgreementReclamationCostAuthorityID = reclamationAgreementReclamationCostAuthorityID;
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationAgreementReclamationCostAuthority(int reclamationAgreementID, int reclamationCostAuthorityID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementReclamationCostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ReclamationAgreementID = reclamationAgreementID;
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ReclamationAgreementReclamationCostAuthority(ReclamationAgreement reclamationAgreement, ReclamationCostAuthority reclamationCostAuthority) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationAgreementReclamationCostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ReclamationAgreementID = reclamationAgreement.ReclamationAgreementID;
            this.ReclamationAgreement = reclamationAgreement;
            reclamationAgreement.ReclamationAgreementReclamationCostAuthorities.Add(this);
            this.ReclamationCostAuthorityID = reclamationCostAuthority.ReclamationCostAuthorityID;
            this.ReclamationCostAuthority = reclamationCostAuthority;
            reclamationCostAuthority.ReclamationAgreementReclamationCostAuthorities.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationAgreementReclamationCostAuthority CreateNewBlank(ReclamationAgreement reclamationAgreement, ReclamationCostAuthority reclamationCostAuthority)
        {
            return new ReclamationAgreementReclamationCostAuthority(reclamationAgreement, reclamationCostAuthority);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationAgreementReclamationCostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationAgreementReclamationCostAuthorities.Remove(this);
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

        public virtual ReclamationAgreement ReclamationAgreement { get; set; }
        public virtual ReclamationCostAuthority ReclamationCostAuthority { get; set; }

        public static class FieldLengths
        {

        }
    }
}