//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpApGenSheet]
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
    // Table [ImportFinancial].[ImpApGenSheet] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[ImpApGenSheet]")]
    public partial class ImpApGenSheet : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ImpApGenSheet()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImpApGenSheet(int impApGenSheetID, string pONumberKey, string purchOrdLineItmKey, string referenceKey, string vendorKey, string vendorText, string fundKey, string fundedProgramKey, string wBSElementKey, string wBSElementText, string budgetObjectClassKey, double? debitAmount, double? creditAmount, double? debitCreditTotal, DateTime? createdOnKey, DateTime? postingDateKey) : this()
        {
            this.ImpApGenSheetID = impApGenSheetID;
            this.PONumberKey = pONumberKey;
            this.PurchOrdLineItmKey = purchOrdLineItmKey;
            this.ReferenceKey = referenceKey;
            this.VendorKey = vendorKey;
            this.VendorText = vendorText;
            this.FundKey = fundKey;
            this.FundedProgramKey = fundedProgramKey;
            this.WBSElementKey = wBSElementKey;
            this.WBSElementText = wBSElementText;
            this.BudgetObjectClassKey = budgetObjectClassKey;
            this.DebitAmount = debitAmount;
            this.CreditAmount = creditAmount;
            this.DebitCreditTotal = debitCreditTotal;
            this.CreatedOnKey = createdOnKey;
            this.PostingDateKey = postingDateKey;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ImpApGenSheet CreateNewBlank()
        {
            return new ImpApGenSheet();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ImpApGenSheet).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ImpApGenSheets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ImpApGenSheetID { get; set; }
        public string PONumberKey { get; set; }
        public string PurchOrdLineItmKey { get; set; }
        public string ReferenceKey { get; set; }
        public string VendorKey { get; set; }
        public string VendorText { get; set; }
        public string FundKey { get; set; }
        public string FundedProgramKey { get; set; }
        public string WBSElementKey { get; set; }
        public string WBSElementText { get; set; }
        public string BudgetObjectClassKey { get; set; }
        public double? DebitAmount { get; set; }
        public double? CreditAmount { get; set; }
        public double? DebitCreditTotal { get; set; }
        public DateTime? CreatedOnKey { get; set; }
        public DateTime? PostingDateKey { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ImpApGenSheetID; } set { ImpApGenSheetID = value; } }



        public static class FieldLengths
        {
            public const int PONumberKey = 255;
            public const int PurchOrdLineItmKey = 255;
            public const int ReferenceKey = 255;
            public const int VendorKey = 255;
            public const int VendorText = 255;
            public const int FundKey = 255;
            public const int FundedProgramKey = 255;
            public const int WBSElementKey = 255;
            public const int WBSElementText = 255;
            public const int BudgetObjectClassKey = 255;
        }
    }
}