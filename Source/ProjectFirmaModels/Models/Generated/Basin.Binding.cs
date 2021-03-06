//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Basin]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [Reclamation].[Basin] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[Basin]")]
    public partial class Basin : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Basin()
        {
            this.CostAuthorities = new HashSet<CostAuthority>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Basin(int basinID, string basinAbbreviation, string basinName) : this()
        {
            this.BasinID = basinID;
            this.BasinAbbreviation = basinAbbreviation;
            this.BasinName = basinName;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Basin CreateNewBlank()
        {
            return new Basin();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return CostAuthorities.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(CostAuthorities.Any())
            {
                dependentObjects.Add(typeof(CostAuthority).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Basin).Name, typeof(CostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.Basins.Remove(this);
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

            foreach(var x in CostAuthorities.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int BasinID { get; set; }
        public string BasinAbbreviation { get; set; }
        public string BasinName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return BasinID; } set { BasinID = value; } }

        public virtual ICollection<CostAuthority> CostAuthorities { get; set; }

        public static class FieldLengths
        {
            public const int BasinAbbreviation = 255;
            public const int BasinName = 255;
        }
    }
}