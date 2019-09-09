//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationPacificNorthActivityList]
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
    // Table [dbo].[ReclamationPacificNorthActivityList] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationPacificNorthActivityList]")]
    public partial class ReclamationPacificNorthActivityList : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationPacificNorthActivityList()
        {
            this.ReclamationAgreementPacificNorthActivities = new HashSet<ReclamationAgreementPacificNorthActivity>();
            this.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsWhereYouAreThePacificNorthActivityList = new HashSet<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationPacificNorthActivityList(int reclamationPacificNorthActivityListID, int? activityID, string pacificNorthActivityName, int? sortOrder, int? pacificNorthActivityTypeID, int? pacificNorthActivityStatusID) : this()
        {
            this.ReclamationPacificNorthActivityListID = reclamationPacificNorthActivityListID;
            this.ActivityID = activityID;
            this.PacificNorthActivityName = pacificNorthActivityName;
            this.SortOrder = sortOrder;
            this.PacificNorthActivityTypeID = pacificNorthActivityTypeID;
            this.PacificNorthActivityStatusID = pacificNorthActivityStatusID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationPacificNorthActivityList CreateNewBlank()
        {
            return new ReclamationPacificNorthActivityList();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationAgreementPacificNorthActivities.Any() || ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsWhereYouAreThePacificNorthActivityList.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationPacificNorthActivityList).Name, typeof(ReclamationAgreementPacificNorthActivity).Name, typeof(ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationPacificNorthActivityLists.Remove(this);
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

            foreach(var x in ReclamationAgreementPacificNorthActivities.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsWhereYouAreThePacificNorthActivityList.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationPacificNorthActivityListID { get; set; }
        public int? ActivityID { get; set; }
        public string PacificNorthActivityName { get; set; }
        public int? SortOrder { get; set; }
        public int? PacificNorthActivityTypeID { get; set; }
        public int? PacificNorthActivityStatusID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationPacificNorthActivityListID; } set { ReclamationPacificNorthActivityListID = value; } }

        public virtual ICollection<ReclamationAgreementPacificNorthActivity> ReclamationAgreementPacificNorthActivities { get; set; }
        public virtual ICollection<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsWhereYouAreThePacificNorthActivityList { get; set; }
        public virtual ReclamationPacificNorthActivityType PacificNorthActivityType { get; set; }
        public virtual ReclamationPacificNorthActivityStatus PacificNorthActivityStatus { get; set; }

        public static class FieldLengths
        {
            public const int PacificNorthActivityName = 255;
        }
    }
}