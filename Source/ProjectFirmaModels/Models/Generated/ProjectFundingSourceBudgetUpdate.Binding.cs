//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ProjectFundingSourceBudgetUpdate]
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
    // Table [Reclamation].[ProjectFundingSourceBudgetUpdate] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[Reclamation].[ProjectFundingSourceBudgetUpdate]")]
    public partial class ProjectFundingSourceBudgetUpdate : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ProjectFundingSourceBudgetUpdate()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceBudgetUpdate(int projectFundingSourceBudgetUpdateID, int projectUpdateBatchID, int fundingSourceID, decimal? projectedAmount, int? calendarYear, int? costTypeID) : this()
        {
            this.ProjectFundingSourceBudgetUpdateID = projectFundingSourceBudgetUpdateID;
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
            this.ProjectedAmount = projectedAmount;
            this.CalendarYear = calendarYear;
            this.CostTypeID = costTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectFundingSourceBudgetUpdate(int projectUpdateBatchID, int fundingSourceID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceBudgetUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ProjectUpdateBatchID = projectUpdateBatchID;
            this.FundingSourceID = fundingSourceID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ProjectFundingSourceBudgetUpdate(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ProjectFundingSourceBudgetUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            this.ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectFundingSourceBudgetUpdates.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.ProjectFundingSourceBudgetUpdates.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ProjectFundingSourceBudgetUpdate CreateNewBlank(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource)
        {
            return new ProjectFundingSourceBudgetUpdate(projectUpdateBatch, fundingSource);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ProjectFundingSourceBudgetUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllProjectFundingSourceBudgetUpdates.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ProjectFundingSourceBudgetUpdateID { get; set; }
        public int TenantID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal? ProjectedAmount { get; set; }
        public int? CalendarYear { get; set; }
        public int? CostTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ProjectFundingSourceBudgetUpdateID; } set { ProjectFundingSourceBudgetUpdateID = value; } }

        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual ProjectUpdateBatch ProjectUpdateBatch { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public virtual CostType CostType { get; set; }

        public static class FieldLengths
        {

        }
    }
}