//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationPacificNorthActivityType]
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
    // Table [dbo].[ReclamationPacificNorthActivityType] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationPacificNorthActivityType]")]
    public partial class ReclamationPacificNorthActivityType : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationPacificNorthActivityType()
        {
            this.ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityType = new HashSet<ReclamationPacificNorthActivityList>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationPacificNorthActivityType(int reclamationPacificNorthActivityTypeID, string pacificNorthActivityTypeName) : this()
        {
            this.ReclamationPacificNorthActivityTypeID = reclamationPacificNorthActivityTypeID;
            this.PacificNorthActivityTypeName = pacificNorthActivityTypeName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationPacificNorthActivityType CreateNewBlank()
        {
            return new ReclamationPacificNorthActivityType();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityType.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationPacificNorthActivityType).Name, typeof(ReclamationPacificNorthActivityList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationPacificNorthActivityTypes.Remove(this);
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

            foreach(var x in ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityType.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationPacificNorthActivityTypeID { get; set; }
        public string PacificNorthActivityTypeName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationPacificNorthActivityTypeID; } set { ReclamationPacificNorthActivityTypeID = value; } }

        public virtual ICollection<ReclamationPacificNorthActivityList> ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityType { get; set; }

        public static class FieldLengths
        {
            public const int PacificNorthActivityTypeName = 100;
        }
    }
}