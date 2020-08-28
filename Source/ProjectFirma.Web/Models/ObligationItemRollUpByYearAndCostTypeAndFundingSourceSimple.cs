namespace ProjectFirma.Web.Models
{
    public class ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple
    {
        public int FundingSourceID { get; set; }
        public int CostTypeID { get; set; }
        public int? CalendarYear { get; set; }
        public double Amount { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ObligationItemRollUpByYearAndCostTypeAndFundingSourceSimple()
        {
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