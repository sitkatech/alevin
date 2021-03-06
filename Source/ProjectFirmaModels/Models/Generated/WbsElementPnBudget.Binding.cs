//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementPnBudget]
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
    // Table [ImportFinancial].[WbsElementPnBudget] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[ImportFinancial].[WbsElementPnBudget]")]
    public partial class WbsElementPnBudget : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected WbsElementPnBudget()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElementPnBudget(int wbsElementPnBudgetID, int wbsElementID, int? costAuthorityID, int pnBudgetFundTypeID, int fundingSourceID, string fundsCenter, int fiscalMonthPeriod, int fiscalQuarterID, int fiscalYear, int calendarMonthNumber, int calendarYear, int? budgetObjectCodeID, string fIDocNumber, double? recoveries, double? committedButNotObligated, double? totalObligations, double? totalExpenditures, double? undeliveredOrders) : this()
        {
            this.WbsElementPnBudgetID = wbsElementPnBudgetID;
            this.WbsElementID = wbsElementID;
            this.CostAuthorityID = costAuthorityID;
            this.PnBudgetFundTypeID = pnBudgetFundTypeID;
            this.FundingSourceID = fundingSourceID;
            this.FundsCenter = fundsCenter;
            this.FiscalMonthPeriod = fiscalMonthPeriod;
            this.FiscalQuarterID = fiscalQuarterID;
            this.FiscalYear = fiscalYear;
            this.CalendarMonthNumber = calendarMonthNumber;
            this.CalendarYear = calendarYear;
            this.BudgetObjectCodeID = budgetObjectCodeID;
            this.FIDocNumber = fIDocNumber;
            this.Recoveries = recoveries;
            this.CommittedButNotObligated = committedButNotObligated;
            this.TotalObligations = totalObligations;
            this.TotalExpenditures = totalExpenditures;
            this.UndeliveredOrders = undeliveredOrders;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public WbsElementPnBudget(int wbsElementID, int pnBudgetFundTypeID, int fundingSourceID, string fundsCenter, int fiscalMonthPeriod, int fiscalQuarterID, int fiscalYear, int calendarMonthNumber, int calendarYear, string fIDocNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WbsElementPnBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.WbsElementID = wbsElementID;
            this.PnBudgetFundTypeID = pnBudgetFundTypeID;
            this.FundingSourceID = fundingSourceID;
            this.FundsCenter = fundsCenter;
            this.FiscalMonthPeriod = fiscalMonthPeriod;
            this.FiscalQuarterID = fiscalQuarterID;
            this.FiscalYear = fiscalYear;
            this.CalendarMonthNumber = calendarMonthNumber;
            this.CalendarYear = calendarYear;
            this.FIDocNumber = fIDocNumber;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public WbsElementPnBudget(WbsElement wbsElement, PnBudgetFundType pnBudgetFundType, FundingSource fundingSource, string fundsCenter, int fiscalMonthPeriod, FiscalQuarter fiscalQuarter, int fiscalYear, int calendarMonthNumber, int calendarYear, string fIDocNumber) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.WbsElementPnBudgetID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.WbsElementID = wbsElement.WbsElementID;
            this.WbsElement = wbsElement;
            wbsElement.WbsElementPnBudgets.Add(this);
            this.PnBudgetFundTypeID = pnBudgetFundType.PnBudgetFundTypeID;
            this.PnBudgetFundType = pnBudgetFundType;
            pnBudgetFundType.WbsElementPnBudgets.Add(this);
            this.FundingSourceID = fundingSource.FundingSourceID;
            this.FundingSource = fundingSource;
            fundingSource.WbsElementPnBudgets.Add(this);
            this.FundsCenter = fundsCenter;
            this.FiscalMonthPeriod = fiscalMonthPeriod;
            this.FiscalQuarterID = fiscalQuarter.FiscalQuarterID;
            this.FiscalQuarter = fiscalQuarter;
            fiscalQuarter.WbsElementPnBudgets.Add(this);
            this.FiscalYear = fiscalYear;
            this.CalendarMonthNumber = calendarMonthNumber;
            this.CalendarYear = calendarYear;
            this.FIDocNumber = fIDocNumber;
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static WbsElementPnBudget CreateNewBlank(WbsElement wbsElement, PnBudgetFundType pnBudgetFundType, FundingSource fundingSource, FiscalQuarter fiscalQuarter)
        {
            return new WbsElementPnBudget(wbsElement, pnBudgetFundType, fundingSource, default(string), default(int), fiscalQuarter, default(int), default(int), default(int), default(string));
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(WbsElementPnBudget).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.WbsElementPnBudgets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int WbsElementPnBudgetID { get; set; }
        public int WbsElementID { get; set; }
        public int? CostAuthorityID { get; set; }
        public int PnBudgetFundTypeID { get; set; }
        public int FundingSourceID { get; set; }
        public string FundsCenter { get; set; }
        public int FiscalMonthPeriod { get; set; }
        public int FiscalQuarterID { get; set; }
        public int FiscalYear { get; set; }
        public int CalendarMonthNumber { get; set; }
        public int CalendarYear { get; set; }
        public int? BudgetObjectCodeID { get; set; }
        public string FIDocNumber { get; set; }
        public double? Recoveries { get; set; }
        public double? CommittedButNotObligated { get; set; }
        public double? TotalObligations { get; set; }
        public double? TotalExpenditures { get; set; }
        public double? UndeliveredOrders { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return WbsElementPnBudgetID; } set { WbsElementPnBudgetID = value; } }

        public virtual WbsElement WbsElement { get; set; }
        public virtual CostAuthority CostAuthority { get; set; }
        public virtual PnBudgetFundType PnBudgetFundType { get; set; }
        public virtual FundingSource FundingSource { get; set; }
        public virtual FiscalQuarter FiscalQuarter { get; set; }
        public virtual BudgetObjectCode BudgetObjectCode { get; set; }

        public static class FieldLengths
        {
            public const int FundsCenter = 10;
            public const int FIDocNumber = 200;
        }
    }
}