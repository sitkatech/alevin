//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TaxonomyLeaf]
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
    // Table [dbo].[TaxonomyLeaf] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[TaxonomyLeaf]")]
    public partial class TaxonomyLeaf : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected TaxonomyLeaf()
        {
            this.ProjectsWhereYouAreTheOverrideTaxonomyLeaf = new HashSet<Project>();
            this.SecondaryProjectTaxonomyLeafs = new HashSet<SecondaryProjectTaxonomyLeaf>();
            this.TaxonomyLeafPerformanceMeasures = new HashSet<TaxonomyLeafPerformanceMeasure>();
            this.CostAuthorities = new HashSet<CostAuthority>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyLeaf(int taxonomyLeafID, int taxonomyBranchID, string taxonomyLeafName, string taxonomyLeafDescription, string taxonomyLeafCode, string themeColor, int? taxonomyLeafSortOrder, string reclamationAuthority, string reclamationJob, string reclamationAuthorityJob) : this()
        {
            this.TaxonomyLeafID = taxonomyLeafID;
            this.TaxonomyBranchID = taxonomyBranchID;
            this.TaxonomyLeafName = taxonomyLeafName;
            this.TaxonomyLeafDescription = taxonomyLeafDescription;
            this.TaxonomyLeafCode = taxonomyLeafCode;
            this.ThemeColor = themeColor;
            this.TaxonomyLeafSortOrder = taxonomyLeafSortOrder;
            this.ReclamationAuthority = reclamationAuthority;
            this.ReclamationJob = reclamationJob;
            this.ReclamationAuthorityJob = reclamationAuthorityJob;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyLeaf(int taxonomyBranchID, string taxonomyLeafName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyBranchID = taxonomyBranchID;
            this.TaxonomyLeafName = taxonomyLeafName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public TaxonomyLeaf(TaxonomyBranch taxonomyBranch, string taxonomyLeafName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.TaxonomyLeafID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyBranchID = taxonomyBranch.TaxonomyBranchID;
            this.TaxonomyBranch = taxonomyBranch;
            taxonomyBranch.TaxonomyLeafs.Add(this);
            this.TaxonomyLeafName = taxonomyLeafName;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static TaxonomyLeaf CreateNewBlank(TaxonomyBranch taxonomyBranch)
        {
            return new TaxonomyLeaf(taxonomyBranch, default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectsWhereYouAreTheOverrideTaxonomyLeaf.Any() || SecondaryProjectTaxonomyLeafs.Any() || TaxonomyLeafPerformanceMeasures.Any() || CostAuthorities.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ProjectsWhereYouAreTheOverrideTaxonomyLeaf.Any())
            {
                dependentObjects.Add(typeof(Project).Name);
            }

            if(SecondaryProjectTaxonomyLeafs.Any())
            {
                dependentObjects.Add(typeof(SecondaryProjectTaxonomyLeaf).Name);
            }

            if(TaxonomyLeafPerformanceMeasures.Any())
            {
                dependentObjects.Add(typeof(TaxonomyLeafPerformanceMeasure).Name);
            }

            if(CostAuthorities.Any())
            {
                dependentObjects.Add(typeof(CostAuthority).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(TaxonomyLeaf).Name, typeof(Project).Name, typeof(SecondaryProjectTaxonomyLeaf).Name, typeof(TaxonomyLeafPerformanceMeasure).Name, typeof(CostAuthority).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllTaxonomyLeafs.Remove(this);
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

            foreach(var x in ProjectsWhereYouAreTheOverrideTaxonomyLeaf.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in SecondaryProjectTaxonomyLeafs.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in TaxonomyLeafPerformanceMeasures.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorities.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int TaxonomyLeafID { get; set; }
        public int TenantID { get; set; }
        public int TaxonomyBranchID { get; set; }
        public string TaxonomyLeafName { get; set; }
        public string TaxonomyLeafDescription { get; set; }
        [NotMapped]
        public HtmlString TaxonomyLeafDescriptionHtmlString
        { 
            get { return TaxonomyLeafDescription == null ? null : new HtmlString(TaxonomyLeafDescription); }
            set { TaxonomyLeafDescription = value?.ToString(); }
        }
        public string TaxonomyLeafCode { get; set; }
        public string ThemeColor { get; set; }
        public int? TaxonomyLeafSortOrder { get; set; }
        public string ReclamationAuthority { get; set; }
        public string ReclamationJob { get; set; }
        public string ReclamationAuthorityJob { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return TaxonomyLeafID; } set { TaxonomyLeafID = value; } }

        public virtual ICollection<Project> ProjectsWhereYouAreTheOverrideTaxonomyLeaf { get; set; }
        public virtual ICollection<SecondaryProjectTaxonomyLeaf> SecondaryProjectTaxonomyLeafs { get; set; }
        public virtual ICollection<TaxonomyLeafPerformanceMeasure> TaxonomyLeafPerformanceMeasures { get; set; }
        public virtual ICollection<CostAuthority> CostAuthorities { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual TaxonomyBranch TaxonomyBranch { get; set; }

        public static class FieldLengths
        {
            public const int TaxonomyLeafName = 100;
            public const int TaxonomyLeafCode = 10;
            public const int ThemeColor = 7;
            public const int ReclamationAuthority = 4;
            public const int ReclamationJob = 3;
            public const int ReclamationAuthorityJob = 8;
        }
    }
}