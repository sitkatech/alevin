//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementObligationItemInvoice]
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
    // Table [ImportFinancial].[WbsElementObligationItemInvoice] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[WbsElementObligationItemInvoice]")]
    public partial class WbsElementObligationItemInvoice : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected WbsElementObligationItemInvoice()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElementObligationItemInvoice(int wbsElementObligationItemInvoiceID, int wbsElementID, int obligationItemID, double? debitAmount, double? creditAmount, double? debitCreditTotal) : this()
        {
            this.WbsElementObligationItemInvoiceID = wbsElementObligationItemInvoiceID;
            this.WbsElementID = wbsElementID;
            this.ObligationItemID = obligationItemID;
            this.DebitAmount = debitAmount;
            this.CreditAmount = creditAmount;
            this.DebitCreditTotal = debitCreditTotal;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElementObligationItemInvoice(int wbsElementID, int obligationItemID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WbsElementObligationItemInvoiceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.WbsElementID = wbsElementID;
            this.ObligationItemID = obligationItemID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public WbsElementObligationItemInvoice(WbsElement wbsElement, ObligationItem obligationItem) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WbsElementObligationItemInvoiceID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.WbsElementID = wbsElement.WbsElementID;
            this.WbsElement = wbsElement;
            wbsElement.WbsElementObligationItemInvoices.Add(this);
            this.ObligationItemID = obligationItem.ObligationItemID;
            this.ObligationItem = obligationItem;
            obligationItem.WbsElementObligationItemInvoices.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static WbsElementObligationItemInvoice CreateNewBlank(WbsElement wbsElement, ObligationItem obligationItem)
        {
            return new WbsElementObligationItemInvoice(wbsElement, obligationItem);
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(WbsElementObligationItemInvoice).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.WbsElementObligationItemInvoices.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int WbsElementObligationItemInvoiceID { get; set; }
        public int WbsElementID { get; set; }
        public int ObligationItemID { get; set; }
        public double? DebitAmount { get; set; }
        public double? CreditAmount { get; set; }
        public double? DebitCreditTotal { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return WbsElementObligationItemInvoiceID; } set { WbsElementObligationItemInvoiceID = value; } }

        public virtual WbsElement WbsElement { get; set; }
        public virtual ObligationItem ObligationItem { get; set; }

        public static class FieldLengths
        {

        }
    }
}