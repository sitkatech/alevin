using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ObligationItemBudgetRollUpByYearAndCostTypeAndFundingSourceSimple
    {
        public int FundingSourceID { get; set; }
        public int CostTypeID { get; set; }
        public int CalendarYear { get; set; }
        public double Amount { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ObligationItemBudgetRollUpByYearAndCostTypeAndFundingSourceSimple()
        {
        }

        public ObligationItemBudgetRollUpByYearAndCostTypeAndFundingSourceSimple(ProjectFundingSourceBudget projectFundingSourceBudget, List<WbsElementObligationItemBudget> wbsElementObligationItemBudgets)
        {
            this.FundingSourceID = projectFundingSourceBudget.FundingSourceID;
            this.CostTypeID = projectFundingSourceBudget.CostTypeID.Value;
            this.CalendarYear = projectFundingSourceBudget.CalendarYear.Value;
            this.Amount = wbsElementObligationItemBudgets.Sum(obi => obi.Obligation ?? 0);
        }

        public ObligationItemBudgetRollUpByYearAndCostTypeAndFundingSourceSimple(int fundingSourceID, int costTypeId, int calendarYear, double amount)
        {
            FundingSourceID = fundingSourceID;
            CostTypeID = costTypeId;
            CalendarYear = calendarYear;
            Amount = amount;
        }
    }
}