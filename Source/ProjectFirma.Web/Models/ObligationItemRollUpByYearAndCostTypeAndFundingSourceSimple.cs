using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple
    {
        public int FundingSourceID { get; set; }
        public int CostTypeID { get; set; }
        public int CalendarYear { get; set; }
        public double Amount { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple()
        {
        }

        public ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple(ProjectFundingSourceBudget projectFundingSourceBudget, List<WbsElementObligationItemBudget> wbsElementObligationItemBudgets)
        {
            this.FundingSourceID = projectFundingSourceBudget.FundingSourceID;
            this.CostTypeID = projectFundingSourceBudget.CostTypeID.Value;
            this.CalendarYear = projectFundingSourceBudget.CalendarYear.Value;
            this.Amount = wbsElementObligationItemBudgets.Sum(oib => oib.Obligation ?? 0);
        }

        public ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple(ProjectFundingSourceBudget projectFundingSourceBudget, List<WbsElementObligationItemInvoice> wbsElementObligationItemInvoices)
        {
            this.FundingSourceID = projectFundingSourceBudget.FundingSourceID;
            this.CostTypeID = projectFundingSourceBudget.CostTypeID.Value;
            this.CalendarYear = projectFundingSourceBudget.CalendarYear.Value;
            this.Amount = wbsElementObligationItemInvoices.Sum(oii => oii.DebitAmount ?? 0);
        }

        public ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple(int fundingSourceID, int costTypeId, int calendarYear, double amount)
        {
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeId;
            CalendarYear = calendarYear;
            Amount = amount;
        }
    }
}