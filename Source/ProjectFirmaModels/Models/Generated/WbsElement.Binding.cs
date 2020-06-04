//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElement]
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
    // Table [ImportFinancial].[WbsElement] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[WbsElement]")]
    public partial class WbsElement : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected WbsElement()
        {
            this.WbsElementObligationItemBudgets = new HashSet<WbsElementObligationItemBudget>();
            this.WbsElementObligationItemInvoices = new HashSet<WbsElementObligationItemInvoice>();
            this.WbsElementPnBudgets = new HashSet<WbsElementPnBudget>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElement(int wbsElementID, string wbsElementKey, string wbsElementText) : this()
        {
            this.WbsElementID = wbsElementID;
            this.WbsElementKey = wbsElementKey;
            this.WbsElementText = wbsElementText;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElement(string wbsElementKey, string wbsElementText) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WbsElementID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.WbsElementKey = wbsElementKey;
            this.WbsElementText = wbsElementText;
        }


        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static WbsElement CreateNewBlank()
        {
            return new WbsElement(default(string), default(string));
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return WbsElementObligationItemBudgets.Any() || WbsElementObligationItemInvoices.Any() || WbsElementPnBudgets.Any();
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

            if(WbsElementObligationItemInvoices.Any())
            {
                dependentObjects.Add(typeof(WbsElementObligationItemInvoice).Name);
            }

            if(WbsElementPnBudgets.Any())
            {
                dependentObjects.Add(typeof(WbsElementPnBudget).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(WbsElement).Name, typeof(WbsElementObligationItemBudget).Name, typeof(WbsElementObligationItemInvoice).Name, typeof(WbsElementPnBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.WbsElements.Remove(this);
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

            foreach(var x in WbsElementPnBudgets.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int WbsElementID { get; set; }
        public string WbsElementKey { get; set; }
        public string WbsElementText { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return WbsElementID; } set { WbsElementID = value; } }

        public virtual ICollection<WbsElementObligationItemBudget> WbsElementObligationItemBudgets { get; set; }
        public virtual ICollection<WbsElementObligationItemInvoice> WbsElementObligationItemInvoices { get; set; }
        public virtual ICollection<WbsElementPnBudget> WbsElementPnBudgets { get; set; }

        public static class FieldLengths
        {
            public const int WbsElementKey = 100;
            public const int WbsElementText = 500;
        }
    }
}