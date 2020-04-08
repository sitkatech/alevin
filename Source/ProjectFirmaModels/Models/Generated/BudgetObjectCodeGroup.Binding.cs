//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[BudgetObjectCodeGroup]
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
    // Table [Reclamation].[BudgetObjectCodeGroup] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[BudgetObjectCodeGroup]")]
    public partial class BudgetObjectCodeGroup : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected BudgetObjectCodeGroup()
        {
            this.BudgetObjectCodes = new HashSet<BudgetObjectCode>();
            this.BudgetObjectCodeGroupsWhereYouAreTheParentBudgetObjectCodeGroup = new HashSet<BudgetObjectCodeGroup>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public BudgetObjectCodeGroup(int budgetObjectCodeGroupID, string budgetObjectCodeGroupPrefix, string budgetObjectCodeGroupName, string budgetObjectCodeGroupDefinition, int? parentBudgetObjectCodeGroupID) : this()
        {
            this.BudgetObjectCodeGroupID = budgetObjectCodeGroupID;
            this.BudgetObjectCodeGroupPrefix = budgetObjectCodeGroupPrefix;
            this.BudgetObjectCodeGroupName = budgetObjectCodeGroupName;
            this.BudgetObjectCodeGroupDefinition = budgetObjectCodeGroupDefinition;
            this.ParentBudgetObjectCodeGroupID = parentBudgetObjectCodeGroupID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public BudgetObjectCodeGroup(string budgetObjectCodeGroupPrefix, string budgetObjectCodeGroupName) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.BudgetObjectCodeGroupID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.BudgetObjectCodeGroupPrefix = budgetObjectCodeGroupPrefix;
            this.BudgetObjectCodeGroupName = budgetObjectCodeGroupName;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static BudgetObjectCodeGroup CreateNewBlank()
        {
            return new BudgetObjectCodeGroup(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return BudgetObjectCodes.Any() || BudgetObjectCodeGroupsWhereYouAreTheParentBudgetObjectCodeGroup.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(BudgetObjectCodeGroup).Name, typeof(BudgetObjectCode).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.BudgetObjectCodeGroups.Remove(this);
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

            foreach(var x in BudgetObjectCodes.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in BudgetObjectCodeGroupsWhereYouAreTheParentBudgetObjectCodeGroup.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int BudgetObjectCodeGroupID { get; set; }
        public string BudgetObjectCodeGroupPrefix { get; set; }
        public string BudgetObjectCodeGroupName { get; set; }
        public string BudgetObjectCodeGroupDefinition { get; set; }
        public int? ParentBudgetObjectCodeGroupID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return BudgetObjectCodeGroupID; } set { BudgetObjectCodeGroupID = value; } }

        public virtual ICollection<BudgetObjectCode> BudgetObjectCodes { get; set; }
        public virtual ICollection<BudgetObjectCodeGroup> BudgetObjectCodeGroupsWhereYouAreTheParentBudgetObjectCodeGroup { get; set; }
        public virtual BudgetObjectCodeGroup ParentBudgetObjectCodeGroup { get; set; }

        public static class FieldLengths
        {
            public const int BudgetObjectCodeGroupPrefix = 5;
            public const int BudgetObjectCodeGroupName = 100;
            public const int BudgetObjectCodeGroupDefinition = 500;
        }
    }
}