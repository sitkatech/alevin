//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationSubbasin]
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
    // Table [dbo].[ReclamationSubbasin] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationSubbasin]")]
    public partial class ReclamationSubbasin : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationSubbasin()
        {
            this.ReclamationCostAuthoritiesWhereYouAreTheSubbasin = new HashSet<ReclamationCostAuthority>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationSubbasin(int reclamationSubbasinID, string subbasinName) : this()
        {
            this.ReclamationSubbasinID = reclamationSubbasinID;
            this.SubbasinName = subbasinName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationSubbasin CreateNewBlank()
        {
            return new ReclamationSubbasin();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationCostAuthoritiesWhereYouAreTheSubbasin.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationSubbasin).Name, typeof(ReclamationCostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationSubbasins.Remove(this);
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

            foreach(var x in ReclamationCostAuthoritiesWhereYouAreTheSubbasin.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationSubbasinID { get; set; }
        public string SubbasinName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationSubbasinID; } set { ReclamationSubbasinID = value; } }

        public virtual ICollection<ReclamationCostAuthority> ReclamationCostAuthoritiesWhereYouAreTheSubbasin { get; set; }

        public static class FieldLengths
        {
            public const int SubbasinName = 100;
        }
    }
}