//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostAuthority]
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
    // Table [dbo].[CostAuthority] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[CostAuthority]")]
    public partial class CostAuthority : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostAuthority()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostAuthority(int costAuthorityID, string costAuthorityWorkBreakdownStructure, string costAuthority, string accountStructureDescription, string basinNumber, string subbasin, string hCategory, string costCenter, string agencyProjectType, string projectNumber, string jobNumber, string authority, string wBSStatus, double? hCategoryLU, string wBSNoDot) : this()
        {
            this.CostAuthorityID = costAuthorityID;
            this.CostAuthorityWorkBreakdownStructure = costAuthorityWorkBreakdownStructure;
            this.CostAuthority = costAuthority;
            this.AccountStructureDescription = accountStructureDescription;
            this.BasinNumber = basinNumber;
            this.Subbasin = subbasin;
            this.HCategory = hCategory;
            this.CostCenter = costCenter;
            this.AgencyProjectType = agencyProjectType;
            this.ProjectNumber = projectNumber;
            this.JobNumber = jobNumber;
            this.Authority = authority;
            this.WBSStatus = wBSStatus;
            this.HCategoryLU = hCategoryLU;
            this.WBSNoDot = wBSNoDot;
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
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostAuthority).Name};


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
            
            Delete(dbContext);
        }

        [Key]
        public int CostAuthorityID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public string CostAuthority { get; set; }
        public string AccountStructureDescription { get; set; }
        public string BasinNumber { get; set; }
        public string Subbasin { get; set; }
        public string HCategory { get; set; }
        public string CostCenter { get; set; }
        public string AgencyProjectType { get; set; }
        public string ProjectNumber { get; set; }
        public string JobNumber { get; set; }
        public string Authority { get; set; }
        public string WBSStatus { get; set; }
        public double? HCategoryLU { get; set; }
        public string WBSNoDot { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CostAuthorityID; } set { CostAuthorityID = value; } }



        public static class FieldLengths
        {
            public const int CostAuthorityWorkBreakdownStructure = 255;
            public const int CostAuthority = 255;
            public const int AccountStructureDescription = 255;
            public const int BasinNumber = 255;
            public const int Subbasin = 255;
            public const int HCategory = 255;
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