//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingCostAuthorityAgreement]
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
    // Table [Reclamation].[ReclamationStagingCostAuthorityAgreement] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationStagingCostAuthorityAgreement]")]
    public partial class ReclamationStagingCostAuthorityAgreement : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingCostAuthorityAgreement()
        {
            this.ReclamationDeliverablesWhereYouAreTheCostAuthorityAgreement = new HashSet<ReclamationDeliverable>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingCostAuthorityAgreement(int reclamationStagingCostAuthorityAgreementID, int? originalReclamationCostAuthorityAgreementID, string costAuthorityWorkBreakdownStructure, string costAuthorityNumber, string agreementNumber, int? pacificNorthActivityNumber, string pacificNorthActivityName, int? agreementID, int? costAuthorityID) : this()
        {
            this.ReclamationStagingCostAuthorityAgreementID = reclamationStagingCostAuthorityAgreementID;
            this.OriginalReclamationCostAuthorityAgreementID = originalReclamationCostAuthorityAgreementID;
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
        public static ReclamationStagingCostAuthorityAgreement CreateNewBlank()
        {
            return new ReclamationStagingCostAuthorityAgreement();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationDeliverablesWhereYouAreTheCostAuthorityAgreement.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingCostAuthorityAgreement).Name, typeof(ReclamationDeliverable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingCostAuthorityAgreements.Remove(this);
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

            foreach(var x in ReclamationDeliverablesWhereYouAreTheCostAuthorityAgreement.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationStagingCostAuthorityAgreementID { get; set; }
        public int? OriginalReclamationCostAuthorityAgreementID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public string CostAuthorityNumber { get; set; }
        public string AgreementNumber { get; set; }
        public int? PacificNorthActivityNumber { get; set; }
        public string PacificNorthActivityName { get; set; }
        public int? AgreementID { get; set; }
        public int? CostAuthorityID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingCostAuthorityAgreementID; } set { ReclamationStagingCostAuthorityAgreementID = value; } }

        public virtual ICollection<ReclamationDeliverable> ReclamationDeliverablesWhereYouAreTheCostAuthorityAgreement { get; set; }
        public virtual ReclamationAgreement Agreement { get; set; }
        public virtual ReclamationCostAuthority CostAuthority { get; set; }

        public static class FieldLengths
        {
            public const int CostAuthorityWorkBreakdownStructure = 255;
            public const int CostAuthorityNumber = 255;
            public const int AgreementNumber = 255;
            public const int PacificNorthActivityName = 255;
        }
    }
}