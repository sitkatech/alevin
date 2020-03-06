//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[HCategory]
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
    // Table [Reclamation].[HCategory] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[HCategory]")]
    public partial class HCategory : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected HCategory()
        {
            this.CostAuthoritiesWhereYouAreTheHabitatCategory = new HashSet<CostAuthority>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public HCategory(int hCategoryID, string habitatCategoryName) : this()
        {
            this.HCategoryID = hCategoryID;
            this.HabitatCategoryName = habitatCategoryName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static HCategory CreateNewBlank()
        {
            return new HCategory();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return CostAuthoritiesWhereYouAreTheHabitatCategory.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(HCategory).Name, typeof(CostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.HCategories.Remove(this);
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

            foreach(var x in CostAuthoritiesWhereYouAreTheHabitatCategory.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int HCategoryID { get; set; }
        public string HabitatCategoryName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return HCategoryID; } set { HCategoryID = value; } }

        public virtual ICollection<CostAuthority> CostAuthoritiesWhereYouAreTheHabitatCategory { get; set; }

        public static class FieldLengths
        {
            public const int HabitatCategoryName = 50;
        }
    }
}