//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingObligationsTable]
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
    // Table [Reclamation].[ReclamationStagingObligationsTable] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationStagingObligationsTable]")]
    public partial class ReclamationStagingObligationsTable : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingObligationsTable()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingObligationsTable(int reclamationStagingObligationsTableID, int? originalObligationsID, int? originalAgreementStatusID, DateTime? monthEnding, decimal? amount) : this()
        {
            this.ReclamationStagingObligationsTableID = reclamationStagingObligationsTableID;
            this.OriginalObligationsID = originalObligationsID;
            this.OriginalAgreementStatusID = originalAgreementStatusID;
            this.MonthEnding = monthEnding;
            this.Amount = amount;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingObligationsTable CreateNewBlank()
        {
            return new ReclamationStagingObligationsTable();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingObligationsTable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingObligationsTables.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationStagingObligationsTableID { get; set; }
        public int? OriginalObligationsID { get; set; }
        public int? OriginalAgreementStatusID { get; set; }
        public DateTime? MonthEnding { get; set; }
        public decimal? Amount { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingObligationsTableID; } set { ReclamationStagingObligationsTableID = value; } }



        public static class FieldLengths
        {

        }
    }
}