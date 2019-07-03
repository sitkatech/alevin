//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostAuthorityAgreement]
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
    // Table [dbo].[CostAuthorityAgreement] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[CostAuthorityAgreement]")]
    public partial class CostAuthorityAgreement : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostAuthorityAgreement()
        {
            this.Deliverables = new HashSet<Deliverable>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthorityAgreement(int costAuthorityAgreementID, int? reclamationCostAuthorityAgreementID, string costAuthorityWorkBreakdownStructure, string costAuthorityNumber, string agreementNumber, int? pacificNorthActivityNumber, string pacificNorthActivityName, int? agreementID, int? costAuthorityID) : this()
        {
            this.CostAuthorityAgreementID = costAuthorityAgreementID;
            this.ReclamationCostAuthorityAgreementID = reclamationCostAuthorityAgreementID;
            this.CostAuthorityWorkBreakdownStructure = costAuthorityWorkBreakdownStructure;
            this.CostAuthorityNumber = costAuthorityNumber;
            this.AgreementNumber = agreementNumber;
            this.PacificNorthActivityNumber = pacificNorthActivityNumber;
            this.PacificNorthActivityName = pacificNorthActivityName;
            this.AgreementID = agreementID;
            this.CostAuthorityID = costAuthorityID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostAuthorityAgreement CreateNewBlank()
        {
            return new CostAuthorityAgreement();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Deliverables.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostAuthorityAgreement).Name, typeof(Deliverable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.CostAuthorityAgreements.Remove(this);
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

            foreach(var x in Deliverables.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int CostAuthorityAgreementID { get; set; }
        public int? ReclamationCostAuthorityAgreementID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public string CostAuthorityNumber { get; set; }
        public string AgreementNumber { get; set; }
        public int? PacificNorthActivityNumber { get; set; }
        public string PacificNorthActivityName { get; set; }
        public int? AgreementID { get; set; }
        public int? CostAuthorityID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CostAuthorityAgreementID; } set { CostAuthorityAgreementID = value; } }

        public virtual ICollection<Deliverable> Deliverables { get; set; }
        public virtual Agreement Agreement { get; set; }
        public virtual CostAuthority CostAuthority { get; set; }

        public static class FieldLengths
        {
            public const int CostAuthorityWorkBreakdownStructure = 255;
            public const int CostAuthorityNumber = 255;
            public const int AgreementNumber = 255;
            public const int PacificNorthActivityName = 255;
        }
    }
}