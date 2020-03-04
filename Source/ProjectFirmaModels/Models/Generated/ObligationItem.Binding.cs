//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ObligationItem]
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
    // Table [ImportFinancial].[ObligationItem] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[ObligationItem]")]
    public partial class ObligationItem : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ObligationItem()
        {
            this.WbsElementObligationItemBudgets = new HashSet<WbsElementObligationItemBudget>();
            this.WbsElementObligationItemInvoices = new HashSet<WbsElementObligationItemInvoice>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationItem(int obligationItemID, string obligationItemKey, int obligationNumberID) : this()
        {
            this.ObligationItemID = obligationItemID;
            this.ObligationItemKey = obligationItemKey;
            this.ObligationNumberID = obligationNumberID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public ObligationItem(string obligationItemKey, int obligationNumberID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ObligationItemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.ObligationItemKey = obligationItemKey;
            this.ObligationNumberID = obligationNumberID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public ObligationItem(string obligationItemKey, ObligationNumber obligationNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.ObligationItemID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ObligationItemKey = obligationItemKey;
            this.ObligationNumberID = obligationNumber.ObligationNumberID;
            this.ObligationNumber = obligationNumber;
            obligationNumber.ObligationItems.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ObligationItem CreateNewBlank(ObligationNumber obligationNumber)
        {
            return new ObligationItem(default(string), obligationNumber);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ObligationItem).Name, typeof(WbsElementObligationItemBudget).Name, typeof(WbsElementObligationItemInvoice).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ObligationItems.Remove(this);
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
        public int ObligationItemID { get; set; }
        public string ObligationItemKey { get; set; }
        public int ObligationNumberID { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ObligationItemID; } set { ObligationItemID = value; } }

        public virtual ICollection<WbsElementObligationItemBudget> WbsElementObligationItemBudgets { get; set; }
        public virtual ICollection<WbsElementObligationItemInvoice> WbsElementObligationItemInvoices { get; set; }
        public virtual ObligationNumber ObligationNumber { get; set; }

        public static class FieldLengths
        {
            public const int ObligationItemKey = 100;
        }
    }
}