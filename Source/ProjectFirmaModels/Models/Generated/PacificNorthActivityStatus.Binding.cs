//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[PacificNorthActivityStatus]
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
    // Table [Reclamation].[PacificNorthActivityStatus] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[PacificNorthActivityStatus]")]
    public partial class PacificNorthActivityStatus : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PacificNorthActivityStatus()
        {
            this.PacificNorthActivityLists = new HashSet<PacificNorthActivityList>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PacificNorthActivityStatus(int pacificNorthActivityStatusID, string pacificNorthActivityStatusName) : this()
        {
            this.PacificNorthActivityStatusID = pacificNorthActivityStatusID;
            this.PacificNorthActivityStatusName = pacificNorthActivityStatusName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PacificNorthActivityStatus CreateNewBlank()
        {
            return new PacificNorthActivityStatus();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return PacificNorthActivityLists.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PacificNorthActivityStatus).Name, typeof(PacificNorthActivityList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PacificNorthActivityStatuses.Remove(this);
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

            foreach(var x in PacificNorthActivityLists.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PacificNorthActivityStatusID { get; set; }
        public string PacificNorthActivityStatusName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PacificNorthActivityStatusID; } set { PacificNorthActivityStatusID = value; } }

        public virtual ICollection<PacificNorthActivityList> PacificNorthActivityLists { get; set; }

        public static class FieldLengths
        {
            public const int PacificNorthActivityStatusName = 100;
        }
    }
}