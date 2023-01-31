//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PerformanceMeasure]
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
    // Table [dbo].[PerformanceMeasure] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[PerformanceMeasure]")]
    public partial class PerformanceMeasure : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected PerformanceMeasure()
        {
            this.ClassificationPerformanceMeasures = new HashSet<ClassificationPerformanceMeasure>();
            this.GeospatialAreaPerformanceMeasureFixedTargets = new HashSet<GeospatialAreaPerformanceMeasureFixedTarget>();
            this.GeospatialAreaPerformanceMeasureNoTargets = new HashSet<GeospatialAreaPerformanceMeasureNoTarget>();
            this.GeospatialAreaPerformanceMeasureReportingPeriodTargets = new HashSet<GeospatialAreaPerformanceMeasureReportingPeriodTarget>();
            this.MatchmakerOrganizationPerformanceMeasures = new HashSet<MatchmakerOrganizationPerformanceMeasure>();
            this.PerformanceMeasureActuals = new HashSet<PerformanceMeasureActual>();
            this.PerformanceMeasureActualSubcategoryOptions = new HashSet<PerformanceMeasureActualSubcategoryOption>();
            this.PerformanceMeasureActualSubcategoryOptionUpdates = new HashSet<PerformanceMeasureActualSubcategoryOptionUpdate>();
            this.PerformanceMeasureActualUpdates = new HashSet<PerformanceMeasureActualUpdate>();
            this.PerformanceMeasureExpecteds = new HashSet<PerformanceMeasureExpected>();
            this.PerformanceMeasureExpectedSubcategoryOptions = new HashSet<PerformanceMeasureExpectedSubcategoryOption>();
            this.PerformanceMeasureExpectedSubcategoryOptionUpdates = new HashSet<PerformanceMeasureExpectedSubcategoryOptionUpdate>();
            this.PerformanceMeasureExpectedUpdates = new HashSet<PerformanceMeasureExpectedUpdate>();
            this.PerformanceMeasureFixedTargets = new HashSet<PerformanceMeasureFixedTarget>();
            this.PerformanceMeasureImages = new HashSet<PerformanceMeasureImage>();
            this.PerformanceMeasureNotes = new HashSet<PerformanceMeasureNote>();
            this.PerformanceMeasureReportingPeriodTargets = new HashSet<PerformanceMeasureReportingPeriodTarget>();
            this.PerformanceMeasureSubcategories = new HashSet<PerformanceMeasureSubcategory>();
            this.TaxonomyLeafPerformanceMeasures = new HashSet<TaxonomyLeafPerformanceMeasure>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasure(int performanceMeasureID, string criticalDefinitions, string projectReporting, string performanceMeasureDisplayName, int measurementUnitTypeID, int performanceMeasureTypeID, string performanceMeasureDefinition, string dataSourceText, string externalDataSourceUrl, string chartCaption, int? performanceMeasureSortOrder, bool isSummable, int performanceMeasureDataSourceTypeID, string additionalInformation, bool canBeChartedCumulatively, int? performanceMeasureGroupID) : this()
        {
            this.PerformanceMeasureID = performanceMeasureID;
            this.CriticalDefinitions = criticalDefinitions;
            this.ProjectReporting = projectReporting;
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.PerformanceMeasureTypeID = performanceMeasureTypeID;
            this.PerformanceMeasureDefinition = performanceMeasureDefinition;
            this.DataSourceText = dataSourceText;
            this.ExternalDataSourceUrl = externalDataSourceUrl;
            this.ChartCaption = chartCaption;
            this.PerformanceMeasureSortOrder = performanceMeasureSortOrder;
            this.IsSummable = isSummable;
            this.PerformanceMeasureDataSourceTypeID = performanceMeasureDataSourceTypeID;
            this.AdditionalInformation = additionalInformation;
            this.CanBeChartedCumulatively = canBeChartedCumulatively;
            this.PerformanceMeasureGroupID = performanceMeasureGroupID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasure(string performanceMeasureDisplayName, int measurementUnitTypeID, int performanceMeasureTypeID, bool isSummable, int performanceMeasureDataSourceTypeID, bool canBeChartedCumulatively) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.MeasurementUnitTypeID = measurementUnitTypeID;
            this.PerformanceMeasureTypeID = performanceMeasureTypeID;
            this.IsSummable = isSummable;
            this.PerformanceMeasureDataSourceTypeID = performanceMeasureDataSourceTypeID;
            this.CanBeChartedCumulatively = canBeChartedCumulatively;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public PerformanceMeasure(string performanceMeasureDisplayName, MeasurementUnitType measurementUnitType, PerformanceMeasureType performanceMeasureType, bool isSummable, PerformanceMeasureDataSourceType performanceMeasureDataSourceType, bool canBeChartedCumulatively) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.PerformanceMeasureDisplayName = performanceMeasureDisplayName;
            this.MeasurementUnitTypeID = measurementUnitType.MeasurementUnitTypeID;
            this.PerformanceMeasureTypeID = performanceMeasureType.PerformanceMeasureTypeID;
            this.IsSummable = isSummable;
            this.PerformanceMeasureDataSourceTypeID = performanceMeasureDataSourceType.PerformanceMeasureDataSourceTypeID;
            this.CanBeChartedCumulatively = canBeChartedCumulatively;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static PerformanceMeasure CreateNewBlank(MeasurementUnitType measurementUnitType, PerformanceMeasureType performanceMeasureType, PerformanceMeasureDataSourceType performanceMeasureDataSourceType)
        {
            return new PerformanceMeasure(default(string), measurementUnitType, performanceMeasureType, default(bool), performanceMeasureDataSourceType, default(bool));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ClassificationPerformanceMeasures.Any() || GeospatialAreaPerformanceMeasureFixedTargets.Any() || GeospatialAreaPerformanceMeasureNoTargets.Any() || GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any() || MatchmakerOrganizationPerformanceMeasures.Any() || PerformanceMeasureActuals.Any() || PerformanceMeasureActualSubcategoryOptions.Any() || PerformanceMeasureActualSubcategoryOptionUpdates.Any() || PerformanceMeasureActualUpdates.Any() || PerformanceMeasureExpecteds.Any() || PerformanceMeasureExpectedSubcategoryOptions.Any() || PerformanceMeasureExpectedSubcategoryOptionUpdates.Any() || PerformanceMeasureExpectedUpdates.Any() || PerformanceMeasureFixedTargets.Any() || PerformanceMeasureImages.Any() || PerformanceMeasureNotes.Any() || PerformanceMeasureReportingPeriodTargets.Any() || PerformanceMeasureSubcategories.Any() || TaxonomyLeafPerformanceMeasures.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ClassificationPerformanceMeasures.Any())
            {
                dependentObjects.Add(typeof(ClassificationPerformanceMeasure).Name);
            }

            if(GeospatialAreaPerformanceMeasureFixedTargets.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaPerformanceMeasureFixedTarget).Name);
            }

            if(GeospatialAreaPerformanceMeasureNoTargets.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaPerformanceMeasureNoTarget).Name);
            }

            if(GeospatialAreaPerformanceMeasureReportingPeriodTargets.Any())
            {
                dependentObjects.Add(typeof(GeospatialAreaPerformanceMeasureReportingPeriodTarget).Name);
            }

            if(MatchmakerOrganizationPerformanceMeasures.Any())
            {
                dependentObjects.Add(typeof(MatchmakerOrganizationPerformanceMeasure).Name);
            }

            if(PerformanceMeasureActuals.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureActual).Name);
            }

            if(PerformanceMeasureActualSubcategoryOptions.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureActualSubcategoryOption).Name);
            }

            if(PerformanceMeasureActualSubcategoryOptionUpdates.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name);
            }

            if(PerformanceMeasureActualUpdates.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureActualUpdate).Name);
            }

            if(PerformanceMeasureExpecteds.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureExpected).Name);
            }

            if(PerformanceMeasureExpectedSubcategoryOptions.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureExpectedSubcategoryOption).Name);
            }

            if(PerformanceMeasureExpectedSubcategoryOptionUpdates.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureExpectedSubcategoryOptionUpdate).Name);
            }

            if(PerformanceMeasureExpectedUpdates.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureExpectedUpdate).Name);
            }

            if(PerformanceMeasureFixedTargets.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureFixedTarget).Name);
            }

            if(PerformanceMeasureImages.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureImage).Name);
            }

            if(PerformanceMeasureNotes.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureNote).Name);
            }

            if(PerformanceMeasureReportingPeriodTargets.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureReportingPeriodTarget).Name);
            }

            if(PerformanceMeasureSubcategories.Any())
            {
                dependentObjects.Add(typeof(PerformanceMeasureSubcategory).Name);
            }

            if(TaxonomyLeafPerformanceMeasures.Any())
            {
                dependentObjects.Add(typeof(TaxonomyLeafPerformanceMeasure).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(PerformanceMeasure).Name, typeof(ClassificationPerformanceMeasure).Name, typeof(GeospatialAreaPerformanceMeasureFixedTarget).Name, typeof(GeospatialAreaPerformanceMeasureNoTarget).Name, typeof(GeospatialAreaPerformanceMeasureReportingPeriodTarget).Name, typeof(MatchmakerOrganizationPerformanceMeasure).Name, typeof(PerformanceMeasureActual).Name, typeof(PerformanceMeasureActualSubcategoryOption).Name, typeof(PerformanceMeasureActualSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureActualUpdate).Name, typeof(PerformanceMeasureExpected).Name, typeof(PerformanceMeasureExpectedSubcategoryOption).Name, typeof(PerformanceMeasureExpectedSubcategoryOptionUpdate).Name, typeof(PerformanceMeasureExpectedUpdate).Name, typeof(PerformanceMeasureFixedTarget).Name, typeof(PerformanceMeasureImage).Name, typeof(PerformanceMeasureNote).Name, typeof(PerformanceMeasureReportingPeriodTarget).Name, typeof(PerformanceMeasureSubcategory).Name, typeof(TaxonomyLeafPerformanceMeasure).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllPerformanceMeasures.Remove(this);
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

            foreach(var x in ClassificationPerformanceMeasures.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GeospatialAreaPerformanceMeasureFixedTargets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GeospatialAreaPerformanceMeasureNoTargets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in GeospatialAreaPerformanceMeasureReportingPeriodTargets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in MatchmakerOrganizationPerformanceMeasures.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureActuals.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureActualSubcategoryOptions.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureActualSubcategoryOptionUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureActualUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpecteds.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpectedSubcategoryOptions.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpectedSubcategoryOptionUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureExpectedUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureFixedTargets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureImages.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureNotes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureReportingPeriodTargets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PerformanceMeasureSubcategories.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TaxonomyLeafPerformanceMeasures.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int PerformanceMeasureID { get; set; }
        public int TenantID { get; set; }
        public string CriticalDefinitions { get; set; }
        [NotMapped]
        public HtmlString CriticalDefinitionsHtmlString
        { 
            get { return CriticalDefinitions == null ? null : new HtmlString(CriticalDefinitions); }
            set { CriticalDefinitions = value?.ToString(); }
        }
        public string ProjectReporting { get; set; }
        [NotMapped]
        public HtmlString ProjectReportingHtmlString
        { 
            get { return ProjectReporting == null ? null : new HtmlString(ProjectReporting); }
            set { ProjectReporting = value?.ToString(); }
        }
        public string PerformanceMeasureDisplayName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public int PerformanceMeasureTypeID { get; set; }
        public string PerformanceMeasureDefinition { get; set; }
        public string DataSourceText { get; set; }
        public string ExternalDataSourceUrl { get; set; }
        public string ChartCaption { get; set; }
        public int? PerformanceMeasureSortOrder { get; set; }
        public bool IsSummable { get; set; }
        public int PerformanceMeasureDataSourceTypeID { get; set; }
        public string AdditionalInformation { get; set; }
        [NotMapped]
        public HtmlString AdditionalInformationHtmlString
        { 
            get { return AdditionalInformation == null ? null : new HtmlString(AdditionalInformation); }
            set { AdditionalInformation = value?.ToString(); }
        }
        public bool CanBeChartedCumulatively { get; set; }
        public int? PerformanceMeasureGroupID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return PerformanceMeasureID; } set { PerformanceMeasureID = value; } }

        public virtual ICollection<ClassificationPerformanceMeasure> ClassificationPerformanceMeasures { get; set; }
        public virtual ICollection<GeospatialAreaPerformanceMeasureFixedTarget> GeospatialAreaPerformanceMeasureFixedTargets { get; set; }
        public virtual ICollection<GeospatialAreaPerformanceMeasureNoTarget> GeospatialAreaPerformanceMeasureNoTargets { get; set; }
        public virtual ICollection<GeospatialAreaPerformanceMeasureReportingPeriodTarget> GeospatialAreaPerformanceMeasureReportingPeriodTargets { get; set; }
        public virtual ICollection<MatchmakerOrganizationPerformanceMeasure> MatchmakerOrganizationPerformanceMeasures { get; set; }
        public virtual ICollection<PerformanceMeasureActual> PerformanceMeasureActuals { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureActualSubcategoryOptionUpdate> PerformanceMeasureActualSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureActualUpdate> PerformanceMeasureActualUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpected> PerformanceMeasureExpecteds { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOption> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedSubcategoryOptionUpdate> PerformanceMeasureExpectedSubcategoryOptionUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureExpectedUpdate> PerformanceMeasureExpectedUpdates { get; set; }
        public virtual ICollection<PerformanceMeasureFixedTarget> PerformanceMeasureFixedTargets { get; set; }
        public virtual ICollection<PerformanceMeasureImage> PerformanceMeasureImages { get; set; }
        public virtual ICollection<PerformanceMeasureNote> PerformanceMeasureNotes { get; set; }
        public virtual ICollection<PerformanceMeasureReportingPeriodTarget> PerformanceMeasureReportingPeriodTargets { get; set; }
        public virtual ICollection<PerformanceMeasureSubcategory> PerformanceMeasureSubcategories { get; set; }
        public virtual ICollection<TaxonomyLeafPerformanceMeasure> TaxonomyLeafPerformanceMeasures { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public MeasurementUnitType MeasurementUnitType { get { return MeasurementUnitType.AllLookupDictionary[MeasurementUnitTypeID]; } }
        public PerformanceMeasureType PerformanceMeasureType { get { return PerformanceMeasureType.AllLookupDictionary[PerformanceMeasureTypeID]; } }
        public PerformanceMeasureDataSourceType PerformanceMeasureDataSourceType { get { return PerformanceMeasureDataSourceType.AllLookupDictionary[PerformanceMeasureDataSourceTypeID]; } }
        public virtual PerformanceMeasureGroup PerformanceMeasureGroup { get; set; }

        public static class FieldLengths
        {
            public const int PerformanceMeasureDisplayName = 200;
            public const int DataSourceText = 200;
            public const int ExternalDataSourceUrl = 200;
            public const int ChartCaption = 1000;
        }
    }
}