//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpPnBudget]
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
    // Table [ImportFinancial].[ImpPnBudget] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[ImpPnBudget]")]
    public partial class ImpPnBudget : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ImpPnBudget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ImpPnBudget(int impPnBudgetID, string fundedProgram, string fundType, string fund, string fundsCenter, string fiscalYearPeriod, string commitmentItem, string fiDocNumber, double? recoveries, double? committedButNotObligated, double? totalObligations, double? totalExpenditures, double? undeliveredOrders) : this()
        {
            this.ImpPnBudgetID = impPnBudgetID;
            this.FundedProgram = fundedProgram;
            this.FundType = fundType;
            this.Fund = fund;
            this.FundsCenter = fundsCenter;
            this.FiscalYearPeriod = fiscalYearPeriod;
            this.CommitmentItem = commitmentItem;
            this.FiDocNumber = fiDocNumber;
            this.Recoveries = recoveries;
            this.CommittedButNotObligated = committedButNotObligated;
            this.TotalObligations = totalObligations;
            this.TotalExpenditures = totalExpenditures;
            this.UndeliveredOrders = undeliveredOrders;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ImpPnBudget CreateNewBlank()
        {
            return new ImpPnBudget();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ImpPnBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ImpPnBudgets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ImpPnBudgetID { get; set; }
        public string FundedProgram { get; set; }
        public string FundType { get; set; }
        public string Fund { get; set; }
        public string FundsCenter { get; set; }
        public string FiscalYearPeriod { get; set; }
        public string CommitmentItem { get; set; }
        public string FiDocNumber { get; set; }
        public double? Recoveries { get; set; }
        public double? CommittedButNotObligated { get; set; }
        public double? TotalObligations { get; set; }
        public double? TotalExpenditures { get; set; }
        public double? UndeliveredOrders { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ImpPnBudgetID; } set { ImpPnBudgetID = value; } }



        public static class FieldLengths
        {
            public const int FundedProgram = 255;
            public const int FundType = 255;
            public const int Fund = 255;
            public const int FundsCenter = 255;
            public const int FiscalYearPeriod = 255;
            public const int CommitmentItem = 255;
            public const int FiDocNumber = 255;
        }
    }
}