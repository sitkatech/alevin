//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostType]
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
    // Table [dbo].[CostType] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[CostType]")]
    public partial class CostType : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected CostType()
        {
            this.ProjectFundingSourceExpenditures = new HashSet<ProjectFundingSourceExpenditure>();
            this.ProjectFundingSourceExpenditureUpdates = new HashSet<ProjectFundingSourceExpenditureUpdate>();
            this.ProjectNoFundingSourceIdentifieds = new HashSet<ProjectNoFundingSourceIdentified>();
            this.ProjectNoFundingSourceIdentifiedUpdates = new HashSet<ProjectNoFundingSourceIdentifiedUpdate>();
            this.ProjectRelevantCostTypes = new HashSet<ProjectRelevantCostType>();
            this.ProjectRelevantCostTypeUpdates = new HashSet<ProjectRelevantCostTypeUpdate>();
            this.BudgetObjectCodesWhereYouAreTheOverrideCostType = new HashSet<BudgetObjectCode>();
            this.BudgetObjectCodeGroups = new HashSet<BudgetObjectCodeGroup>();
            this.ProjectFundingSourceBudgets = new HashSet<ProjectFundingSourceBudget>();
            this.ProjectFundingSourceBudgetUpdates = new HashSet<ProjectFundingSourceBudgetUpdate>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostType(int costTypeID, string costTypeName) : this()
        {
            this.CostTypeID = costTypeID;
            this.CostTypeName = costTypeName;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public CostType(string costTypeName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.CostTypeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.CostTypeName = costTypeName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static CostType CreateNewBlank()
        {
            return new CostType(default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return ProjectFundingSourceExpenditures.Any() || ProjectFundingSourceExpenditureUpdates.Any() || ProjectNoFundingSourceIdentifieds.Any() || ProjectNoFundingSourceIdentifiedUpdates.Any() || ProjectRelevantCostTypes.Any() || ProjectRelevantCostTypeUpdates.Any() || BudgetObjectCodesWhereYouAreTheOverrideCostType.Any() || BudgetObjectCodeGroups.Any() || ProjectFundingSourceBudgets.Any() || ProjectFundingSourceBudgetUpdates.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(ProjectFundingSourceExpenditures.Any())
            {
                dependentObjects.Add(typeof(ProjectFundingSourceExpenditure).Name);
            }

            if(ProjectFundingSourceExpenditureUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectFundingSourceExpenditureUpdate).Name);
            }

            if(ProjectNoFundingSourceIdentifieds.Any())
            {
                dependentObjects.Add(typeof(ProjectNoFundingSourceIdentified).Name);
            }

            if(ProjectNoFundingSourceIdentifiedUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectNoFundingSourceIdentifiedUpdate).Name);
            }

            if(ProjectRelevantCostTypes.Any())
            {
                dependentObjects.Add(typeof(ProjectRelevantCostType).Name);
            }

            if(ProjectRelevantCostTypeUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectRelevantCostTypeUpdate).Name);
            }

            if(BudgetObjectCodesWhereYouAreTheOverrideCostType.Any())
            {
                dependentObjects.Add(typeof(BudgetObjectCode).Name);
            }

            if(BudgetObjectCodeGroups.Any())
            {
                dependentObjects.Add(typeof(BudgetObjectCodeGroup).Name);
            }

            if(ProjectFundingSourceBudgets.Any())
            {
                dependentObjects.Add(typeof(ProjectFundingSourceBudget).Name);
            }

            if(ProjectFundingSourceBudgetUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectFundingSourceBudgetUpdate).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(CostType).Name, typeof(ProjectFundingSourceExpenditure).Name, typeof(ProjectFundingSourceExpenditureUpdate).Name, typeof(ProjectNoFundingSourceIdentified).Name, typeof(ProjectNoFundingSourceIdentifiedUpdate).Name, typeof(ProjectRelevantCostType).Name, typeof(ProjectRelevantCostTypeUpdate).Name, typeof(BudgetObjectCode).Name, typeof(BudgetObjectCodeGroup).Name, typeof(ProjectFundingSourceBudget).Name, typeof(ProjectFundingSourceBudgetUpdate).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllCostTypes.Remove(this);
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

            foreach(var x in ProjectFundingSourceExpenditures.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceExpenditureUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNoFundingSourceIdentifieds.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectNoFundingSourceIdentifiedUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectRelevantCostTypes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectRelevantCostTypeUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in BudgetObjectCodesWhereYouAreTheOverrideCostType.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in BudgetObjectCodeGroups.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceBudgets.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectFundingSourceBudgetUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int CostTypeID { get; set; }
        public int TenantID { get; set; }
        public string CostTypeName { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return CostTypeID; } set { CostTypeID = value; } }

        public virtual ICollection<ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; set; }
        public virtual ICollection<ProjectFundingSourceExpenditureUpdate> ProjectFundingSourceExpenditureUpdates { get; set; }
        public virtual ICollection<ProjectNoFundingSourceIdentified> ProjectNoFundingSourceIdentifieds { get; set; }
        public virtual ICollection<ProjectNoFundingSourceIdentifiedUpdate> ProjectNoFundingSourceIdentifiedUpdates { get; set; }
        public virtual ICollection<ProjectRelevantCostType> ProjectRelevantCostTypes { get; set; }
        public virtual ICollection<ProjectRelevantCostTypeUpdate> ProjectRelevantCostTypeUpdates { get; set; }
        public virtual ICollection<BudgetObjectCode> BudgetObjectCodesWhereYouAreTheOverrideCostType { get; set; }
        public virtual ICollection<BudgetObjectCodeGroup> BudgetObjectCodeGroups { get; set; }
        public virtual ICollection<ProjectFundingSourceBudget> ProjectFundingSourceBudgets { get; set; }
        public virtual ICollection<ProjectFundingSourceBudgetUpdate> ProjectFundingSourceBudgetUpdates { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }

        public static class FieldLengths
        {
            public const int CostTypeName = 100;
        }
    }
}