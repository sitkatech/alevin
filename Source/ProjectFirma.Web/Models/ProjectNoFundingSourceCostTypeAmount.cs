using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectNoFundingSourceCostTypeAmount
    {
        public CostType CostType { get; }
        public int CostTypeID { get; }
        public int? CalendarYear { get; }
        public decimal Amount { get; }


        private ProjectNoFundingSourceCostTypeAmount(CostType costType, int? calendarYear, decimal amount)
        {
            CostType = costType;
            CostTypeID = costType.CostTypeID;
            CalendarYear = calendarYear;
            Amount = amount;
        }


        // Budgets
        public static List<ProjectNoFundingSourceCostTypeAmount> CreateFromProjectNoFundingSourceIdentifieds(List<ProjectNoFundingSourceIdentified> projectNoFundingSourceIdentifieds)
        {
            var projectNoFundingSourceCostTypeAmounts = new List<ProjectNoFundingSourceCostTypeAmount>();
            foreach (var projectNoFundingSourceIdentified in projectNoFundingSourceIdentifieds)
            {
                projectNoFundingSourceCostTypeAmounts.Add(new ProjectNoFundingSourceCostTypeAmount( projectNoFundingSourceIdentified.CostType, projectNoFundingSourceIdentified.CalendarYear, projectNoFundingSourceIdentified.NoFundingSourceIdentifiedYet ?? 0));

            }
            return projectNoFundingSourceCostTypeAmounts;
        }
        public static List<ProjectNoFundingSourceCostTypeAmount> CreateFromProjectNoFundingSourceIdentifieds(List<ProjectNoFundingSourceIdentifiedUpdate> projectNoFundingSourceIdentifiedUpdates)
        {
            var projectNoFundingSourceCostTypeAmounts = new List<ProjectNoFundingSourceCostTypeAmount>();
            // Get Secured and Targeted amounts for each FundingSource/CostType/Year
            foreach (var projectNoFundingSourceIdentifiedUpdate in projectNoFundingSourceIdentifiedUpdates)
            {
                projectNoFundingSourceCostTypeAmounts.Add(new ProjectNoFundingSourceCostTypeAmount( projectNoFundingSourceIdentifiedUpdate.CostType, projectNoFundingSourceIdentifiedUpdate.CalendarYear, projectNoFundingSourceIdentifiedUpdate.NoFundingSourceIdentifiedYet ?? 0));
            }
            return projectNoFundingSourceCostTypeAmounts;
        }

    }
}