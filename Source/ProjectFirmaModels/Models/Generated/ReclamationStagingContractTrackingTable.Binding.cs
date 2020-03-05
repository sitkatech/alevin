//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingContractTrackingTable]
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
    // Table [Reclamation].[ReclamationStagingContractTrackingTable] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationStagingContractTrackingTable]")]
    public partial class ReclamationStagingContractTrackingTable : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingContractTrackingTable()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingContractTrackingTable(int reclamationStagingContractTrackingTableID, int? originalContractTrackingID, int? originalAgreementStatusID, DateTime? statusDate, int? reclamationStagingContractStatusID, int? requisitionNumber) : this()
        {
            this.ReclamationStagingContractTrackingTableID = reclamationStagingContractTrackingTableID;
            this.OriginalContractTrackingID = originalContractTrackingID;
            this.OriginalAgreementStatusID = originalAgreementStatusID;
            this.StatusDate = statusDate;
            this.ReclamationStagingContractStatusID = reclamationStagingContractStatusID;
            this.RequisitionNumber = requisitionNumber;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingContractTrackingTable CreateNewBlank()
        {
            return new ReclamationStagingContractTrackingTable();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingContractTrackingTable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingContractTrackingTables.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationStagingContractTrackingTableID { get; set; }
        public int? OriginalContractTrackingID { get; set; }
        public int? OriginalAgreementStatusID { get; set; }
        public DateTime? StatusDate { get; set; }
        public int? ReclamationStagingContractStatusID { get; set; }
        public int? RequisitionNumber { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingContractTrackingTableID; } set { ReclamationStagingContractTrackingTableID = value; } }



        public static class FieldLengths
        {

        }
    }
}