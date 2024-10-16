//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthority]
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
    // Table [Reclamation].[CostAuthority] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[CostAuthority]")]
    public partial class CostAuthority : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostAuthority()
        {
            this.WbsElementObligationItemBudgets = new HashSet<WbsElementObligationItemBudget>();
            this.WbsElementPnBudgets = new HashSet<WbsElementPnBudget>();
            this.AgreementCostAuthorities = new HashSet<AgreementCostAuthority>();
            this.CostAuthorityObligationRequests = new HashSet<CostAuthorityObligationRequest>();
            this.CostAuthorityProjects = new HashSet<CostAuthorityProject>();
            this.ReclamationStagingCostAuthorityAgreements = new HashSet<ReclamationStagingCostAuthorityAgreement>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthority(int costAuthorityID, string costAuthorityWorkBreakdownStructure, string costAuthorityNumber, string accountStructureDescription, string costCenter, string agencyProjectType, string projectNumber, string authority, string job, string number, string jobNumber, string wBSStatus, double? hCategoryLU, string wBSNoDot, int? habitatCategoryID, int? basinID, int? subbasinID, int taxonomyLeafID) : this()
        {
            this.CostAuthorityID = costAuthorityID;
            this.CostAuthorityWorkBreakdownStructure = costAuthorityWorkBreakdownStructure;
            this.CostAuthorityNumber = costAuthorityNumber;
            this.AccountStructureDescription = accountStructureDescription;
            this.CostCenter = costCenter;
            this.AgencyProjectType = agencyProjectType;
            this.ProjectNumber = projectNumber;
            this.Authority = authority;
            this.Job = job;
            this.Number = number;
            this.JobNumber = jobNumber;
            this.WBSStatus = wBSStatus;
            this.HCategoryLU = hCategoryLU;
            this.WBSNoDot = wBSNoDot;
            this.HabitatCategoryID = habitatCategoryID;
            this.BasinID = basinID;
            this.SubbasinID = subbasinID;
            this.TaxonomyLeafID = taxonomyLeafID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthority(int taxonomyLeafID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.TaxonomyLeafID = taxonomyLeafID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public CostAuthority(TaxonomyLeaf taxonomyLeaf) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostAuthorityID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.TaxonomyLeafID = taxonomyLeaf.TaxonomyLeafID;
            this.TaxonomyLeaf = taxonomyLeaf;
            taxonomyLeaf.CostAuthorities.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostAuthority CreateNewBlank(TaxonomyLeaf taxonomyLeaf)
        {
            return new CostAuthority(taxonomyLeaf);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return WbsElementObligationItemBudgets.Any() || WbsElementPnBudgets.Any() || AgreementCostAuthorities.Any() || CostAuthorityObligationRequests.Any() || CostAuthorityProjects.Any() || ReclamationStagingCostAuthorityAgreements.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(WbsElementObligationItemBudgets.Any())
            {
                dependentObjects.Add(typeof(WbsElementObligationItemBudget).Name);
            }

            if(WbsElementPnBudgets.Any())
            {
                dependentObjects.Add(typeof(WbsElementPnBudget).Name);
            }

            if(AgreementCostAuthorities.Any())
            {
                dependentObjects.Add(typeof(AgreementCostAuthority).Name);
            }

            if(CostAuthorityObligationRequests.Any())
            {
                dependentObjects.Add(typeof(CostAuthorityObligationRequest).Name);
            }

            if(CostAuthorityProjects.Any())
            {
                dependentObjects.Add(typeof(CostAuthorityProject).Name);
            }

            if(ReclamationStagingCostAuthorityAgreements.Any())
            {
                dependentObjects.Add(typeof(ReclamationStagingCostAuthorityAgreement).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostAuthority).Name, typeof(WbsElementObligationItemBudget).Name, typeof(WbsElementPnBudget).Name, typeof(AgreementCostAuthority).Name, typeof(CostAuthorityObligationRequest).Name, typeof(CostAuthorityProject).Name, typeof(ReclamationStagingCostAuthorityAgreement).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.CostAuthorities.Remove(this);
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

            foreach(var x in WbsElementObligationItemBudgets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in WbsElementPnBudgets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in AgreementCostAuthorities.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorityObligationRequests.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorityProjects.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationStagingCostAuthorityAgreements.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int CostAuthorityID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public string CostAuthorityNumber { get; set; }
        public string AccountStructureDescription { get; set; }
        public string CostCenter { get; set; }
        public string AgencyProjectType { get; set; }
        public string ProjectNumber { get; set; }
        public string Authority { get; set; }
        public string Job { get; set; }
        public string Number { get; set; }
        public string JobNumber { get; set; }
        public string WBSStatus { get; set; }
        public double? HCategoryLU { get; set; }
        public string WBSNoDot { get; set; }
        public int? HabitatCategoryID { get; set; }
        public int? BasinID { get; set; }
        public int? SubbasinID { get; set; }
        public int TaxonomyLeafID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CostAuthorityID; } set { CostAuthorityID = value; } }

        public virtual ICollection<WbsElementObligationItemBudget> WbsElementObligationItemBudgets { get; set; }
        public virtual ICollection<WbsElementPnBudget> WbsElementPnBudgets { get; set; }
        public virtual ICollection<AgreementCostAuthority> AgreementCostAuthorities { get; set; }
        public virtual ICollection<CostAuthorityObligationRequest> CostAuthorityObligationRequests { get; set; }
        public virtual ICollection<CostAuthorityProject> CostAuthorityProjects { get; set; }
        public virtual ICollection<ReclamationStagingCostAuthorityAgreement> ReclamationStagingCostAuthorityAgreements { get; set; }
        public virtual HCategory HabitatCategory { get; set; }
        public virtual Basin Basin { get; set; }
        public virtual Subbasin Subbasin { get; set; }
        public virtual TaxonomyLeaf TaxonomyLeaf { get; set; }

        public static class FieldLengths
        {
            public const int CostAuthorityWorkBreakdownStructure = 255;
            public const int CostAuthorityNumber = 255;
            public const int AccountStructureDescription = 255;
            public const int CostCenter = 255;
            public const int AgencyProjectType = 255;
            public const int ProjectNumber = 255;
            public const int Authority = 255;
            public const int Job = 3;
            public const int Number = 4;
            public const int JobNumber = 255;
            public const int WBSStatus = 255;
            public const int WBSNoDot = 255;
        }
    }
}