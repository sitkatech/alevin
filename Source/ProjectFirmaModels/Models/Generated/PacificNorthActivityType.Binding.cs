//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[PacificNorthActivityType]
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
    // Table [Reclamation].[PacificNorthActivityType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[PacificNorthActivityType]")]
    public partial class PacificNorthActivityType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PacificNorthActivityType()
        {
            this.PacificNorthActivityLists = new HashSet<PacificNorthActivityList>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PacificNorthActivityType(int pacificNorthActivityTypeID, string pacificNorthActivityTypeName) : this()
        {
            this.PacificNorthActivityTypeID = pacificNorthActivityTypeID;
            this.PacificNorthActivityTypeName = pacificNorthActivityTypeName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PacificNorthActivityType CreateNewBlank()
        {
            return new PacificNorthActivityType();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PacificNorthActivityType).Name, typeof(PacificNorthActivityList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.PacificNorthActivityTypes.Remove(this);
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
        public int PacificNorthActivityTypeID { get; set; }
        public string PacificNorthActivityTypeName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PacificNorthActivityTypeID; } set { PacificNorthActivityTypeID = value; } }

        public virtual ICollection<PacificNorthActivityList> PacificNorthActivityLists { get; set; }

        public static class FieldLengths
        {
            public const int PacificNorthActivityTypeName = 100;
        }
    }
}