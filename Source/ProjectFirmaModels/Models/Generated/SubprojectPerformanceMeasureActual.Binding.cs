//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureActual]
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
    // Table [dbo].[SubprojectPerformanceMeasureActual] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[SubprojectPerformanceMeasureActual]")]
    public partial class SubprojectPerformanceMeasureActual : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected SubprojectPerformanceMeasureActual()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectPerformanceMeasureActual(int subprojectPerformanceMeasureActualID, int subprojectID, int performanceMeasureID, double actualValue, int performanceMeasureReportingPeriodID) : this()
        {
            this.SubprojectPerformanceMeasureActualID = subprojectPerformanceMeasureActualID;
            this.SubprojectID = subprojectID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.ActualValue = actualValue;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public SubprojectPerformanceMeasureActual(int subprojectID, int performanceMeasureID, double actualValue, int performanceMeasureReportingPeriodID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectPerformanceMeasureActualID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.SubprojectID = subprojectID;
            this.PerformanceMeasureID = performanceMeasureID;
            this.ActualValue = actualValue;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public SubprojectPerformanceMeasureActual(Subproject subproject, PerformanceMeasure performanceMeasure, double actualValue, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.SubprojectPerformanceMeasureActualID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.SubprojectID = subproject.SubprojectID;
            this.Subproject = subproject;
            subproject.SubprojectPerformanceMeasureActuals.Add(this);
            this.PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            this.PerformanceMeasure = performanceMeasure;
            performanceMeasure.SubprojectPerformanceMeasureActuals.Add(this);
            this.ActualValue = actualValue;
            this.PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID;
            this.PerformanceMeasureReportingPeriod = performanceMeasureReportingPeriod;
            performanceMeasureReportingPeriod.SubprojectPerformanceMeasureActuals.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static SubprojectPerformanceMeasureActual CreateNewBlank(Subproject subproject, PerformanceMeasure performanceMeasure, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod)
        {
            return new SubprojectPerformanceMeasureActual(subproject, performanceMeasure, default(double), performanceMeasureReportingPeriod);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(SubprojectPerformanceMeasureActual).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllSubprojectPerformanceMeasureActuals.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int SubprojectPerformanceMeasureActualID { get; set; }
        public int TenantID { get; set; }
        public int SubprojectID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double ActualValue { get; set; }
        public int PerformanceMeasureReportingPeriodID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return SubprojectPerformanceMeasureActualID; } set { SubprojectPerformanceMeasureActualID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Subproject Subproject { get; set; }
        public virtual PerformanceMeasure PerformanceMeasure { get; set; }
        public virtual PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod { get; set; }

        public static class FieldLengths
        {

        }
    }
}