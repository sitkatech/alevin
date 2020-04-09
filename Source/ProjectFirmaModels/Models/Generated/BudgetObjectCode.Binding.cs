//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[BudgetObjectCode]
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
    // Table [Reclamation].[BudgetObjectCode] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[BudgetObjectCode]")]
    public partial class BudgetObjectCode : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected BudgetObjectCode()
        {
            this.WbsElementObligationItemBudgets = new HashSet<WbsElementObligationItemBudget>();
            this.WbsElementObligationItemInvoices = new HashSet<WbsElementObligationItemInvoice>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public BudgetObjectCode(int budgetObjectCodeID, string budgetObjectCodeName, string budgetObjectCodeItemDescription, string budgetObjectCodeDefinition, int fbmsYear, bool? reportable1099, string explanation1099, int budgetObjectCodeGroupID, int? overrideCostTypeID) : this()
        {
            this.BudgetObjectCodeID = budgetObjectCodeID;
            this.BudgetObjectCodeName = budgetObjectCodeName;
            this.BudgetObjectCodeItemDescription = budgetObjectCodeItemDescription;
            this.BudgetObjectCodeDefinition = budgetObjectCodeDefinition;
            this.FbmsYear = fbmsYear;
            this.Reportable1099 = reportable1099;
            this.Explanation1099 = explanation1099;
            this.BudgetObjectCodeGroupID = budgetObjectCodeGroupID;
            this.OverrideCostTypeID = overrideCostTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public BudgetObjectCode(string budgetObjectCodeName, string budgetObjectCodeItemDescription, int fbmsYear, int budgetObjectCodeGroupID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.BudgetObjectCodeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.BudgetObjectCodeName = budgetObjectCodeName;
            this.BudgetObjectCodeItemDescription = budgetObjectCodeItemDescription;
            this.FbmsYear = fbmsYear;
            this.BudgetObjectCodeGroupID = budgetObjectCodeGroupID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public BudgetObjectCode(string budgetObjectCodeName, string budgetObjectCodeItemDescription, int fbmsYear, BudgetObjectCodeGroup budgetObjectCodeGroup) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.BudgetObjectCodeID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.BudgetObjectCodeName = budgetObjectCodeName;
            this.BudgetObjectCodeItemDescription = budgetObjectCodeItemDescription;
            this.FbmsYear = fbmsYear;
            this.BudgetObjectCodeGroupID = budgetObjectCodeGroup.BudgetObjectCodeGroupID;
            this.BudgetObjectCodeGroup = budgetObjectCodeGroup;
            budgetObjectCodeGroup.BudgetObjectCodes.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static BudgetObjectCode CreateNewBlank(BudgetObjectCodeGroup budgetObjectCodeGroup)
        {
            return new BudgetObjectCode(default(string), default(string), default(int), budgetObjectCodeGroup);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return WbsElementObligationItemBudgets.Any() || WbsElementObligationItemInvoices.Any();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(BudgetObjectCode).Name, typeof(WbsElementObligationItemBudget).Name, typeof(WbsElementObligationItemInvoice).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.BudgetObjectCodes.Remove(this);
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

            foreach(var x in WbsElementObligationItemInvoices.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int BudgetObjectCodeID { get; set; }
        public string BudgetObjectCodeName { get; set; }
        public string BudgetObjectCodeItemDescription { get; set; }
        public string BudgetObjectCodeDefinition { get; set; }
        public int FbmsYear { get; set; }
        public bool? Reportable1099 { get; set; }
        public string Explanation1099 { get; set; }
        public int BudgetObjectCodeGroupID { get; set; }
        public int? OverrideCostTypeID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return BudgetObjectCodeID; } set { BudgetObjectCodeID = value; } }

        public virtual ICollection<WbsElementObligationItemBudget> WbsElementObligationItemBudgets { get; set; }
        public virtual ICollection<WbsElementObligationItemInvoice> WbsElementObligationItemInvoices { get; set; }
        public virtual BudgetObjectCodeGroup BudgetObjectCodeGroup { get; set; }
        public virtual CostType OverrideCostType { get; set; }

        public static class FieldLengths
        {
            public const int BudgetObjectCodeName = 6;
            public const int BudgetObjectCodeItemDescription = 1000;
            public const int BudgetObjectCodeDefinition = 1000;
            public const int Explanation1099 = 1000;
        }
    }
}