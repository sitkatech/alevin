//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationDeliverableType]
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
    // Table [dbo].[ReclamationDeliverableType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationDeliverableType]")]
    public partial class ReclamationDeliverableType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationDeliverableType()
        {
            this.ReclamationDeliverablesWhereYouAreTheDeliverableType = new HashSet<ReclamationDeliverable>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationDeliverableType(int reclamationDeliverableTypeID, string deliverableTypeDisplayName, string deliverableTypeName) : this()
        {
            this.ReclamationDeliverableTypeID = reclamationDeliverableTypeID;
            this.DeliverableTypeDisplayName = deliverableTypeDisplayName;
            this.DeliverableTypeName = deliverableTypeName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationDeliverableType CreateNewBlank()
        {
            return new ReclamationDeliverableType();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationDeliverablesWhereYouAreTheDeliverableType.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationDeliverableType).Name, typeof(ReclamationDeliverable).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationDeliverableTypes.Remove(this);
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

            foreach(var x in ReclamationDeliverablesWhereYouAreTheDeliverableType.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationDeliverableTypeID { get; set; }
        public string DeliverableTypeDisplayName { get; set; }
        public string DeliverableTypeName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationDeliverableTypeID; } set { ReclamationDeliverableTypeID = value; } }

        public virtual ICollection<ReclamationDeliverable> ReclamationDeliverablesWhereYouAreTheDeliverableType { get; set; }

        public static class FieldLengths
        {
            public const int DeliverableTypeDisplayName = 255;
            public const int DeliverableTypeName = 255;
        }
    }
}