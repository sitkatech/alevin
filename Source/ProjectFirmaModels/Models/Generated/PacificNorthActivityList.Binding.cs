//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PacificNorthActivityList]
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
    // Table [dbo].[PacificNorthActivityList] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[PacificNorthActivityList]")]
    public partial class PacificNorthActivityList : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PacificNorthActivityList()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PacificNorthActivityList(int pacificNorthActivityListID, int? activityID, string pacificNorthActivityName, string pacificNorthActivityType, string pacificNorthActivityStatus, int? sortOrder) : this()
        {
            this.PacificNorthActivityListID = pacificNorthActivityListID;
            this.ActivityID = activityID;
            this.PacificNorthActivityName = pacificNorthActivityName;
            this.PacificNorthActivityType = pacificNorthActivityType;
            this.PacificNorthActivityStatus = pacificNorthActivityStatus;
            this.SortOrder = sortOrder;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PacificNorthActivityList CreateNewBlank()
        {
            return new PacificNorthActivityList();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PacificNorthActivityList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PacificNorthActivityLists.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int PacificNorthActivityListID { get; set; }
        public int? ActivityID { get; set; }
        public string PacificNorthActivityName { get; set; }
        public string PacificNorthActivityType { get; set; }
        public string PacificNorthActivityStatus { get; set; }
        public int? SortOrder { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PacificNorthActivityListID; } set { PacificNorthActivityListID = value; } }



        public static class FieldLengths
        {
            public const int PacificNorthActivityName = 255;
            public const int PacificNorthActivityType = 255;
            public const int PacificNorthActivityStatus = 255;
        }
    }
}