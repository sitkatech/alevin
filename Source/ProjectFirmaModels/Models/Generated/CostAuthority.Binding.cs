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
            this.AgreementReclamationCostAuthorities = new HashSet<AgreementReclamationCostAuthority>();
            this.CostAuthorityAgreementRequestsWhereYouAreTheCostAuthority = new HashSet<CostAuthorityAgreementRequest>();
            this.CostAuthorityProjects = new HashSet<CostAuthorityProject>();
            this.ReclamationStagingCostAuthorityAgreementsWhereYouAreTheCostAuthority = new HashSet<ReclamationStagingCostAuthorityAgreement>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthority(int reclamationCostAuthorityID, string costAuthorityWorkBreakdownStructure, string costAuthorityNumber, string accountStructureDescription, string costCenter, string agencyProjectType, string projectNumber, string jobNumber, string authority, string wBSStatus, double? hCategoryLU, string wBSNoDot, int? habitatCategoryID, int? basinID, int? subbasinID) : this()
        {
            this.ReclamationCostAuthorityID = reclamationCostAuthorityID;
            this.CostAuthorityWorkBreakdownStructure = costAuthorityWorkBreakdownStructure;
            this.CostAuthorityNumber = costAuthorityNumber;
            this.AccountStructureDescription = accountStructureDescription;
            this.CostCenter = costCenter;
            this.AgencyProjectType = agencyProjectType;
            this.ProjectNumber = projectNumber;
            this.JobNumber = jobNumber;
            this.Authority = authority;
            this.WBSStatus = wBSStatus;
            this.HCategoryLU = hCategoryLU;
            this.WBSNoDot = wBSNoDot;
            this.HabitatCategoryID = habitatCategoryID;
            this.BasinID = basinID;
            this.SubbasinID = subbasinID;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostAuthority CreateNewBlank()
        {
            return new CostAuthority();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return AgreementReclamationCostAuthorities.Any() || CostAuthorityAgreementRequestsWhereYouAreTheCostAuthority.Any() || CostAuthorityProjects.Any() || ReclamationStagingCostAuthorityAgreementsWhereYouAreTheCostAuthority.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostAuthority).Name, typeof(AgreementReclamationCostAuthority).Name, typeof(CostAuthorityAgreementRequest).Name, typeof(CostAuthorityProject).Name, typeof(ReclamationStagingCostAuthorityAgreement).Name};


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

            foreach(var x in AgreementReclamationCostAuthorities.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorityAgreementRequestsWhereYouAreTheCostAuthority.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorityProjects.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ReclamationStagingCostAuthorityAgreementsWhereYouAreTheCostAuthority.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int ReclamationCostAuthorityID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public string CostAuthorityNumber { get; set; }
        public string AccountStructureDescription { get; set; }
        public string CostCenter { get; set; }
        public string AgencyProjectType { get; set; }
        public string ProjectNumber { get; set; }
        public string JobNumber { get; set; }
        public string Authority { get; set; }
        public string WBSStatus { get; set; }
        public double? HCategoryLU { get; set; }
        public string WBSNoDot { get; set; }
        public int? HabitatCategoryID { get; set; }
        public int? BasinID { get; set; }
        public int? SubbasinID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ReclamationCostAuthorityID; } set { ReclamationCostAuthorityID = value; } }

        public virtual ICollection<AgreementReclamationCostAuthority> AgreementReclamationCostAuthorities { get; set; }
        public virtual ICollection<CostAuthorityAgreementRequest> CostAuthorityAgreementRequestsWhereYouAreTheCostAuthority { get; set; }
        public virtual ICollection<CostAuthorityProject> CostAuthorityProjects { get; set; }
        public virtual ICollection<ReclamationStagingCostAuthorityAgreement> ReclamationStagingCostAuthorityAgreementsWhereYouAreTheCostAuthority { get; set; }
        public virtual HCategory HabitatCategory { get; set; }
        public virtual Basin Basin { get; set; }
        public virtual Subbasin Subbasin { get; set; }

        public static class FieldLengths
        {
            public const int CostAuthorityWorkBreakdownStructure = 255;
            public const int CostAuthorityNumber = 255;
            public const int AccountStructureDescription = 255;
            public const int CostCenter = 255;
            public const int AgencyProjectType = 255;
            public const int ProjectNumber = 255;
            public const int JobNumber = 255;
            public const int Authority = 255;
            public const int WBSStatus = 255;
            public const int WBSNoDot = 255;
        }
    }
}