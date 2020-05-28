using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectNoFundingSourceCostTypeAmount
    {
        public CostType CostType { get; set; }
        public int CostTypeID { get; set; }
        public int? CalendarYear { get; set; }
        public decimal Amount { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectNoFundingSourceCostTypeAmount()
        {
        }

        public ProjectNoFundingSourceCostTypeAmount(int costTypeID, int? calendarYear, decimal amount) : this()
        {
            CostTypeID = costTypeID;
            CalendarYear = calendarYear;
            Amount = amount;
        }

        public ProjectNoFundingSourceCostTypeAmount(CostType costType, int? calendarYear, decimal amount) : this()
        {
            CostType = costType;
            CostTypeID = costType.CostTypeID;
            CalendarYear = calendarYear;
            Amount = amount;
        }

        public ProjectNoFundingSourceCostTypeAmount(ProjectNoFundingSourceIdentified projectNoFundingSourceIdentified) : this()
        {
            CostType = projectNoFundingSourceIdentified.CostType;
            CostTypeID = projectNoFundingSourceIdentified.CostTypeID;
            CalendarYear = projectNoFundingSourceIdentified.CalendarYear;
            Amount = projectNoFundingSourceIdentified.NoFundingSourceIdentifiedYet ?? 0;
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