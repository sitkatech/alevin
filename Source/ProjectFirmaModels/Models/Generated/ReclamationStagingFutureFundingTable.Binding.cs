//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingFutureFundingTable]
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
    // Table [Reclamation].[ReclamationStagingFutureFundingTable] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationStagingFutureFundingTable]")]
    public partial class ReclamationStagingFutureFundingTable : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingFutureFundingTable()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingFutureFundingTable(int reclamationStagingFutureFundingTableID, int? originalContractTrackingID, int? originalReclamationCostAuthorityAgreementID, int? plannedFundingYear, decimal? expectedAmt, decimal? awardAmt, double? awardYear, bool isFunded, int? contingencyYear, string notes) : this()
        {
            this.ReclamationStagingFutureFundingTableID = reclamationStagingFutureFundingTableID;
            this.OriginalContractTrackingID = originalContractTrackingID;
            this.OriginalReclamationCostAuthorityAgreementID = originalReclamationCostAuthorityAgreementID;
            this.PlannedFundingYear = plannedFundingYear;
            this.ExpectedAmt = expectedAmt;
            this.AwardAmt = awardAmt;
            this.AwardYear = awardYear;
            this.IsFunded = isFunded;
            this.ContingencyYear = contingencyYear;
            this.Notes = notes;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingFutureFundingTable(bool isFunded) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationStagingFutureFundingTableID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.IsFunded = isFunded;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingFutureFundingTable CreateNewBlank()
        {
            return new ReclamationStagingFutureFundingTable(default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingFutureFundingTable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingFutureFundingTables.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationStagingFutureFundingTableID { get; set; }
        public int? OriginalContractTrackingID { get; set; }
        public int? OriginalReclamationCostAuthorityAgreementID { get; set; }
        public int? PlannedFundingYear { get; set; }
        public decimal? ExpectedAmt { get; set; }
        public decimal? AwardAmt { get; set; }
        public double? AwardYear { get; set; }
        public bool IsFunded { get; set; }
        public int? ContingencyYear { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingFutureFundingTableID; } set { ReclamationStagingFutureFundingTableID = value; } }



        public static class FieldLengths
        {
            public const int Notes = 1000;
        }
    }
}