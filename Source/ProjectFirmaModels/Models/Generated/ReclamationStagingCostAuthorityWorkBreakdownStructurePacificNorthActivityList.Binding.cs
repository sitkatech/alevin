//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList]
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
    // Table [Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList]")]
    public partial class ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(int reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID, string costAuthorityWorkBreakdownStructure, int? activityID, string pacificNorthActivityName, int? eSABiOpIDNumber, int? pacificNorthActivityListID) : this()
        {
            this.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID = reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID;
            this.CostAuthorityWorkBreakdownStructure = costAuthorityWorkBreakdownStructure;
            this.ActivityID = activityID;
            this.PacificNorthActivityName = pacificNorthActivityName;
            this.ESABiOpIDNumber = eSABiOpIDNumber;
            this.PacificNorthActivityListID = pacificNorthActivityListID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList CreateNewBlank()
        {
            return new ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public int? ActivityID { get; set; }
        public string PacificNorthActivityName { get; set; }
        public int? ESABiOpIDNumber { get; set; }
        public int? PacificNorthActivityListID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID; } set { ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID = value; } }

        public virtual PacificNorthActivityList PacificNorthActivityList { get; set; }

        public static class FieldLengths
        {
            public const int CostAuthorityWorkBreakdownStructure = 255;
            public const int PacificNorthActivityName = 255;
        }
    }
}