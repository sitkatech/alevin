//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationBasin]
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
    // Table [dbo].[ReclamationBasin] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ReclamationBasin]")]
    public partial class ReclamationBasin : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ReclamationBasin()
        {
            this.ReclamationCostAuthoritiesWhereYouAreTheBasin = new HashSet<ReclamationCostAuthority>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ReclamationBasin(int reclamationBasinID, string basinAbbreviation, string basinName) : this()
        {
            this.ReclamationBasinID = reclamationBasinID;
            this.BasinAbbreviation = basinAbbreviation;
            this.BasinName = basinName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ReclamationBasin CreateNewBlank()
        {
            return new ReclamationBasin();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ReclamationCostAuthoritiesWhereYouAreTheBasin.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ReclamationBasin).Name, typeof(ReclamationCostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ReclamationBasins.Remove(this);
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

            foreach(var x in ReclamationCostAuthoritiesWhereYouAreTheBasin.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationBasinID { get; set; }
        public string BasinAbbreviation { get; set; }
        public string BasinName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationBasinID; } set { ReclamationBasinID = value; } }

        public virtual ICollection<ReclamationCostAuthority> ReclamationCostAuthoritiesWhereYouAreTheBasin { get; set; }

        public static class FieldLengths
        {
            public const int BasinAbbreviation = 255;
            public const int BasinName = 255;
        }
    }
}