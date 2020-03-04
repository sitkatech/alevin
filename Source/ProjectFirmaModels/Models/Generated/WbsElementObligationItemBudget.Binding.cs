//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementObligationItemBudget]
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
    // Table [ImportFinancial].[WbsElementObligationItemBudget] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[WbsElementObligationItemBudget]")]
    public partial class WbsElementObligationItemBudget : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected WbsElementObligationItemBudget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElementObligationItemBudget(int wbsElementObligationItemBudgetID, int wbsElementID, int obligationItemID, double? obligation, string goodsReceipt, double? invoiced, double? disbursed, double? unexpendedBalance) : this()
        {
            this.WbsElementObligationItemBudgetID = wbsElementObligationItemBudgetID;
            this.WbsElementID = wbsElementID;
            this.ObligationItemID = obligationItemID;
            this.Obligation = obligation;
            this.GoodsReceipt = goodsReceipt;
            this.Invoiced = invoiced;
            this.Disbursed = disbursed;
            this.UnexpendedBalance = unexpendedBalance;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElementObligationItemBudget(int wbsElementID, int obligationItemID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WbsElementObligationItemBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.WbsElementID = wbsElementID;
            this.ObligationItemID = obligationItemID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public WbsElementObligationItemBudget(WbsElement wbsElement, ObligationItem obligationItem) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WbsElementObligationItemBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.WbsElementID = wbsElement.WbsElementID;
            this.WbsElement = wbsElement;
            wbsElement.WbsElementObligationItemBudgets.Add(this);
            this.ObligationItemID = obligationItem.ObligationItemID;
            this.ObligationItem = obligationItem;
            obligationItem.WbsElementObligationItemBudgets.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static WbsElementObligationItemBudget CreateNewBlank(WbsElement wbsElement, ObligationItem obligationItem)
        {
            return new WbsElementObligationItemBudget(wbsElement, obligationItem);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(WbsElementObligationItemBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.WbsElementObligationItemBudgets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int WbsElementObligationItemBudgetID { get; set; }
        public int WbsElementID { get; set; }
        public int ObligationItemID { get; set; }
        public double? Obligation { get; set; }
        public string GoodsReceipt { get; set; }
        public double? Invoiced { get; set; }
        public double? Disbursed { get; set; }
        public double? UnexpendedBalance { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return WbsElementObligationItemBudgetID; } set { WbsElementObligationItemBudgetID = value; } }

        public virtual WbsElement WbsElement { get; set; }
        public virtual ObligationItem ObligationItem { get; set; }

        public static class FieldLengths
        {
            public const int GoodsReceipt = 255;
        }
    }
}