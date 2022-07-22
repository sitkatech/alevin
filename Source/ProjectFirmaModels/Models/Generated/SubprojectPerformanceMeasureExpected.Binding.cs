//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureExpected]
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
    // Table [dbo].[SubprojectPerformanceMeasureExpected] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[SubprojectPerformanceMeasureExpected]")]
    public partial class SubprojectPerformanceMeasureExpected : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SubprojectPerformanceMeasureExpected()
        {
            this.SubprojectPerformanceMeasureExpectedSubcategoryOptions = new HashSet<SubprojectPerformanceMeasureExpectedSubcategoryOption>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectPerformanceMeasureExpected(int subprojectPerformanceMeasureExpectedID, int subprojectID, int performanceMeasureID, double? expectedValue) : this()
        {
            this.SubprojectPerformanceMeasureExpectedID = subprojectPerformanceMeasureExpectedID;
            this.SubprojectID = subprojectID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectPerformanceMeasureExpected(int subprojectID, int performanceMeasureID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectPerformanceMeasureExpectedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SubprojectID = subprojectID;
            this.PerformanceMeasureID = performanceMeasureID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SubprojectPerformanceMeasureExpected(Subproject subproject, PerformanceMeasure performanceMeasure) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectPerformanceMeasureExpectedID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SubprojectID = subproject.SubprojectID;
            this.Subproject = subproject;
            subproject.SubprojectPerformanceMeasureExpecteds.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.SubprojectPerformanceMeasureExpecteds.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SubprojectPerformanceMeasureExpected CreateNewBlank(Subproject subproject, PerformanceMeasure performanceMeasure)
        {
            return new SubprojectPerformanceMeasureExpected(subproject, performanceMeasure);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return SubprojectPerformanceMeasureExpectedSubcategoryOptions.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(SubprojectPerformanceMeasureExpectedSubcategoryOptions.Any())
            {
                dependentObjects.Add(typeof(SubprojectPerformanceMeasureExpectedSubcategoryOption).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SubprojectPerformanceMeasureExpected).Name, typeof(SubprojectPerformanceMeasureExpectedSubcategoryOption).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSubprojectPerformanceMeasureExpecteds.Remove(this);
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

            foreach(var x in SubprojectPerformanceMeasureExpectedSubcategoryOptions.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int SubprojectPerformanceMeasureExpectedID { get; set; }
        public int TenantID { get; set; }
        public int SubprojectID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SubprojectPerformanceMeasureExpectedID; } set { SubprojectPerformanceMeasureExpectedID = value; } }

        public virtual ICollection<SubprojectPerformanceMeasureExpectedSubcategoryOption> SubprojectPerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Subproject Subproject { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}