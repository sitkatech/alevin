//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]
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
    // Table [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]")]
    public partial class SubprojectPerformanceMeasureExpectedSubcategoryOption : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SubprojectPerformanceMeasureExpectedSubcategoryOption()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectPerformanceMeasureExpectedSubcategoryOption(int subprojectPerformanceMeasureExpectedSubcategoryOptionID, int subprojectPerformanceMeasureExpectedID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            this.SubprojectPerformanceMeasureExpectedSubcategoryOptionID = subprojectPerformanceMeasureExpectedSubcategoryOptionID;
            this.SubprojectPerformanceMeasureExpectedID = subprojectPerformanceMeasureExpectedID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectPerformanceMeasureExpectedSubcategoryOption(int subprojectPerformanceMeasureExpectedID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectPerformanceMeasureExpectedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SubprojectPerformanceMeasureExpectedID = subprojectPerformanceMeasureExpectedID;
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SubprojectPerformanceMeasureExpectedSubcategoryOption(SubprojectPerformanceMeasureExpected subprojectPerformanceMeasureExpected, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectPerformanceMeasureExpectedSubcategoryOptionID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SubprojectPerformanceMeasureExpectedID = subprojectPerformanceMeasureExpected.SubprojectPerformanceMeasureExpectedID;
            this.SubprojectPerformanceMeasureExpected = subprojectPerformanceMeasureExpected;
            subprojectPerformanceMeasureExpected.SubprojectPerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            this.PerformanceMeasureSubcategoryOption = performanceMeasureSubcategoryOption;
            performanceMeasureSubcategoryOption.SubprojectPerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.SubprojectPerformanceMeasureExpectedSubcategoryOptions.Add(this);
            this.PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            this.PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            performanceMeasureSubcategory.SubprojectPerformanceMeasureExpectedSubcategoryOptions.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SubprojectPerformanceMeasureExpectedSubcategoryOption CreateNewBlank(SubprojectPerformanceMeasureExpected subprojectPerformanceMeasureExpected, PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            return new SubprojectPerformanceMeasureExpectedSubcategoryOption(subprojectPerformanceMeasureExpected, performanceMeasureSubcategoryOption, performanceMeasure, performanceMeasureSubcategory);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SubprojectPerformanceMeasureExpectedSubcategoryOption).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSubprojectPerformanceMeasureExpectedSubcategoryOptions.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int SubprojectPerformanceMeasureExpectedSubcategoryOptionID { get; set; }
        public int TenantID { get; set; }
        public int SubprojectPerformanceMeasureExpectedID { get; set; }
        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SubprojectPerformanceMeasureExpectedSubcategoryOptionID; } set { SubprojectPerformanceMeasureExpectedSubcategoryOptionID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual SubprojectPerformanceMeasureExpected SubprojectPerformanceMeasureExpected { get; set; }
        public virtual PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; set; }

        public static class FieldLengths
        {

        }
    }
}