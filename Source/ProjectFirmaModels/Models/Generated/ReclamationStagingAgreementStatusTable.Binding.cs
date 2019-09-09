//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingAgreementStatusTable]
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
    // Table [dbo].[ReclamationStagingAgreementStatusTable] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationStagingAgreementStatusTable]")]
    public partial class ReclamationStagingAgreementStatusTable : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingAgreementStatusTable()
        {
            this.ReclamationDeliverables = new HashSet<ReclamationDeliverable>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingAgreementStatusTable(int reclamationStagingAgreementStatusTableID, int? originalAgreementStatusID, int? originalReclamationCostAuthorityAgreementID, int? requisitionNumber, int? mods, int? line, string fund, DateTime? beginDate, DateTime? endDate, double? fiscalYear, decimal? originalObligation, string notes, bool modDeObligationOrClosed) : this()
        {
            this.ReclamationStagingAgreementStatusTableID = reclamationStagingAgreementStatusTableID;
            this.OriginalAgreementStatusID = originalAgreementStatusID;
            this.OriginalReclamationCostAuthorityAgreementID = originalReclamationCostAuthorityAgreementID;
            this.RequisitionNumber = requisitionNumber;
            this.Mods = mods;
            this.Line = line;
            this.Fund = fund;
            this.BeginDate = beginDate;
            this.EndDate = endDate;
            this.FiscalYear = fiscalYear;
            this.OriginalObligation = originalObligation;
            this.Notes = notes;
            this.ModDeObligationOrClosed = modDeObligationOrClosed;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingAgreementStatusTable(bool modDeObligationOrClosed) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ReclamationStagingAgreementStatusTableID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ModDeObligationOrClosed = modDeObligationOrClosed;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingAgreementStatusTable CreateNewBlank()
        {
            return new ReclamationStagingAgreementStatusTable(default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationDeliverables.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingAgreementStatusTable).Name, typeof(ReclamationDeliverable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingAgreementStatusTables.Remove(this);
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

            foreach(var x in ReclamationDeliverables.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationStagingAgreementStatusTableID { get; set; }
        public int? OriginalAgreementStatusID { get; set; }
        public int? OriginalReclamationCostAuthorityAgreementID { get; set; }
        public int? RequisitionNumber { get; set; }
        public int? Mods { get; set; }
        public int? Line { get; set; }
        public string Fund { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? FiscalYear { get; set; }
        public decimal? OriginalObligation { get; set; }
        public string Notes { get; set; }
        public bool ModDeObligationOrClosed { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingAgreementStatusTableID; } set { ReclamationStagingAgreementStatusTableID = value; } }

        public virtual ICollection<ReclamationDeliverable> ReclamationDeliverables { get; set; }

        public static class FieldLengths
        {
            public const int Fund = 255;
        }
    }
}