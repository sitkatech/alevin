//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpPayrecV3]
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
    // Table [ImportFinancial].[ImpPayrecV3] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[ImpPayrecV3]")]
    public partial class ImpPayrecV3 : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ImpPayrecV3()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImpPayrecV3(int impPayrecV3ID, string businessAreaKey, string fABudgetActivityKey, string functionalAreaText, string obligationNumberKey, string obligationItemKey, string fundKey, string fundedProgramKey, string wBSElementKey, string wBSElementText, string budgetObjectClassKey, string vendorKey, string vendorText, double? obligation, double? goodsReceipt, double? invoiced, double? disbursed, double? unexpendedBalance, DateTime? createdOnKey, DateTime? dateOfUpdateKey, DateTime? postingDateKey, DateTime? postingDatePerSplKey, DateTime? documentDateOfBlKey) : this()
        {
            this.ImpPayrecV3ID = impPayrecV3ID;
            this.BusinessAreaKey = businessAreaKey;
            this.FABudgetActivityKey = fABudgetActivityKey;
            this.FunctionalAreaText = functionalAreaText;
            this.ObligationNumberKey = obligationNumberKey;
            this.ObligationItemKey = obligationItemKey;
            this.FundKey = fundKey;
            this.FundedProgramKey = fundedProgramKey;
            this.WBSElementKey = wBSElementKey;
            this.WBSElementText = wBSElementText;
            this.BudgetObjectClassKey = budgetObjectClassKey;
            this.VendorKey = vendorKey;
            this.VendorText = vendorText;
            this.Obligation = obligation;
            this.GoodsReceipt = goodsReceipt;
            this.Invoiced = invoiced;
            this.Disbursed = disbursed;
            this.UnexpendedBalance = unexpendedBalance;
            this.CreatedOnKey = createdOnKey;
            this.DateOfUpdateKey = dateOfUpdateKey;
            this.PostingDateKey = postingDateKey;
            this.PostingDatePerSplKey = postingDatePerSplKey;
            this.DocumentDateOfBlKey = documentDateOfBlKey;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ImpPayrecV3 CreateNewBlank()
        {
            return new ImpPayrecV3();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ImpPayrecV3).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ImpPayrecV3s.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ImpPayrecV3ID { get; set; }
        public string BusinessAreaKey { get; set; }
        public string FABudgetActivityKey { get; set; }
        public string FunctionalAreaText { get; set; }
        public string ObligationNumberKey { get; set; }
        public string ObligationItemKey { get; set; }
        public string FundKey { get; set; }
        public string FundedProgramKey { get; set; }
        public string WBSElementKey { get; set; }
        public string WBSElementText { get; set; }
        public string BudgetObjectClassKey { get; set; }
        public string VendorKey { get; set; }
        public string VendorText { get; set; }
        public double? Obligation { get; set; }
        public double? GoodsReceipt { get; set; }
        public double? Invoiced { get; set; }
        public double? Disbursed { get; set; }
        public double? UnexpendedBalance { get; set; }
        public DateTime? CreatedOnKey { get; set; }
        public DateTime? DateOfUpdateKey { get; set; }
        public DateTime? PostingDateKey { get; set; }
        public DateTime? PostingDatePerSplKey { get; set; }
        public DateTime? DocumentDateOfBlKey { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ImpPayrecV3ID; } set { ImpPayrecV3ID = value; } }



        public static class FieldLengths
        {
            public const int BusinessAreaKey = 255;
            public const int FABudgetActivityKey = 255;
            public const int FunctionalAreaText = 255;
            public const int ObligationNumberKey = 255;
            public const int ObligationItemKey = 255;
            public const int FundKey = 255;
            public const int FundedProgramKey = 255;
            public const int WBSElementKey = 255;
            public const int WBSElementText = 255;
            public const int BudgetObjectClassKey = 255;
            public const int VendorKey = 255;
            public const int VendorText = 255;
        }
    }
}