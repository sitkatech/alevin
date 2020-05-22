//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ClassificationPerformanceMeasure]
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
    // Table [dbo].[ClassificationPerformanceMeasure] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[ClassificationPerformanceMeasure]")]
    public partial class ClassificationPerformanceMeasure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ClassificationPerformanceMeasure()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationPerformanceMeasure(int classificationPerformanceMeasureID, int classificationID, int performanceMeasureID, bool isPrimaryChart) : this()
        {
            this.ClassificationPerformanceMeasureID = classificationPerformanceMeasureID;
            this.ClassificationID = classificationID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ClassificationPerformanceMeasure(int classificationID, int performanceMeasureID, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ClassificationID = classificationID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ClassificationPerformanceMeasure(Classification classification, PerformanceMeasure performanceMeasure, bool isPrimaryChart) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ClassificationPerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ClassificationID = classification.ClassificationID;
            this.Classification = classification;
            classification.ClassificationPerformanceMeasures.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.ClassificationPerformanceMeasures.Add(this);
            this.IsPrimaryChart = isPrimaryChart;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ClassificationPerformanceMeasure CreateNewBlank(Classification classification, PerformanceMeasure performanceMeasure)
        {
            return new ClassificationPerformanceMeasure(classification, performanceMeasure, default(bool));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ClassificationPerformanceMeasure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllClassificationPerformanceMeasures.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ClassificationPerformanceMeasureID { get; set; }
        public int TenantID { get; set; }
        public int ClassificationID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryChart { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ClassificationPerformanceMeasureID; } set { ClassificationPerformanceMeasureID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Classification Classification { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }

        public static class FieldLengths
        {

        }
    }
}