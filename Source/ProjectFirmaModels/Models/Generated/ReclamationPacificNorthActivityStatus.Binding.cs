//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationPacificNorthActivityStatus]
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
    // Table [dbo].[ReclamationPacificNorthActivityStatus] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationPacificNorthActivityStatus]")]
    public partial class ReclamationPacificNorthActivityStatus : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationPacificNorthActivityStatus()
        {
            this.ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityStatus = new HashSet<ReclamationPacificNorthActivityList>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationPacificNorthActivityStatus(int reclamationPacificNorthActivityStatusID, string pacificNorthActivityStatusName) : this()
        {
            this.ReclamationPacificNorthActivityStatusID = reclamationPacificNorthActivityStatusID;
            this.PacificNorthActivityStatusName = pacificNorthActivityStatusName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationPacificNorthActivityStatus CreateNewBlank()
        {
            return new ReclamationPacificNorthActivityStatus();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityStatus.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationPacificNorthActivityStatus).Name, typeof(ReclamationPacificNorthActivityList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationPacificNorthActivityStatuses.Remove(this);
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

            foreach(var x in ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityStatus.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationPacificNorthActivityStatusID { get; set; }
        public string PacificNorthActivityStatusName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationPacificNorthActivityStatusID; } set { ReclamationPacificNorthActivityStatusID = value; } }

        public virtual ICollection<ReclamationPacificNorthActivityList> ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityStatus { get; set; }

        public static class FieldLengths
        {
            public const int PacificNorthActivityStatusName = 100;
        }
    }
}