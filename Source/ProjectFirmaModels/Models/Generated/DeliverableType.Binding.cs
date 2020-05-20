//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[DeliverableType]
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
    // Table [Reclamation].[DeliverableType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[DeliverableType]")]
    public partial class DeliverableType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected DeliverableType()
        {
            this.Deliverables = new HashSet<Deliverable>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public DeliverableType(int deliverableTypeID, string deliverableTypeDisplayName, string deliverableTypeName) : this()
        {
            this.DeliverableTypeID = deliverableTypeID;
            this.DeliverableTypeDisplayName = deliverableTypeDisplayName;
            this.DeliverableTypeName = deliverableTypeName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static DeliverableType CreateNewBlank()
        {
            return new DeliverableType();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return Deliverables.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(Deliverables.Any())
            {
                dependentObjects.Add(typeof(Deliverable).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(DeliverableType).Name, typeof(Deliverable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.DeliverableTypes.Remove(this);
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

            foreach(var x in Deliverables.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int DeliverableTypeID { get; set; }
        public string DeliverableTypeDisplayName { get; set; }
        public string DeliverableTypeName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return DeliverableTypeID; } set { DeliverableTypeID = value; } }

        public virtual ICollection<Deliverable> Deliverables { get; set; }

        public static class FieldLengths
        {
            public const int DeliverableTypeDisplayName = 255;
            public const int DeliverableTypeName = 255;
        }
    }
}