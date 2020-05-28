using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectNoFundingSourceIdentifiedSimple
    {
        public int CostTypeID { get; set; }
        public int? CalendarYear { get; set; }
        public decimal Amount { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectNoFundingSourceIdentifiedSimple()
        {
        }

        public ProjectNoFundingSourceIdentifiedSimple(int costTypeID, int? calendarYear, decimal amount) : this()
        {
            CostTypeID = costTypeID;
            CalendarYear = calendarYear;
            Amount = amount;
        }


        public ProjectNoFundingSourceIdentifiedSimple(ProjectNoFundingSourceIdentified projectNoFundingSourceIdentified) : this()
        {
            CostTypeID = projectNoFundingSourceIdentified.CostTypeID;
            CalendarYear = projectNoFundingSourceIdentified.CalendarYear;
            Amount = projectNoFundingSourceIdentified.NoFundingSourceIdentifiedYet ?? 0;
        }


        // Budgets
        public static List<ProjectNoFundingSourceIdentifiedSimple> CreateFromProjectNoFundingSourceIdentifieds(List<ProjectNoFundingSourceIdentified> projectNoFundingSourceIdentifieds)
        {
            var projectNoFundingSourceCostTypeAmounts = new List<ProjectNoFundingSourceIdentifiedSimple>();
            foreach (var projectNoFundingSourceIdentified in projectNoFundingSourceIdentifieds)
            {
                projectNoFundingSourceCostTypeAmounts.Add(new ProjectNoFundingSourceIdentifiedSimple( projectNoFundingSourceIdentified.CostTypeID, projectNoFundingSourceIdentified.CalendarYear, projectNoFundingSourceIdentified.NoFundingSourceIdentifiedYet ?? 0));

            }
            return projectNoFundingSourceCostTypeAmounts;
        }
        public static List<ProjectNoFundingSourceIdentifiedSimple> CreateFromProjectNoFundingSourceIdentifieds(List<ProjectNoFundingSourceIdentifiedUpdate> projectNoFundingSourceIdentifiedUpdates)
        {
            var projectNoFundingSourceCostTypeAmounts = new List<ProjectNoFundingSourceIdentifiedSimple>();
            // Get Secured and Targeted amounts for each FundingSource/CostType/Year
            foreach (var projectNoFundingSourceIdentifiedUpdate in projectNoFundingSourceIdentifiedUpdates)
            {
                projectNoFundingSourceCostTypeAmounts.Add(new ProjectNoFundingSourceIdentifiedSimple( projectNoFundingSourceIdentifiedUpdate.CostTypeID, projectNoFundingSourceIdentifiedUpdate.CalendarYear, projectNoFundingSourceIdentifiedUpdate.NoFundingSourceIdentifiedYet ?? 0));
            }
            return projectNoFundingSourceCostTypeAmounts;
        }

    }
}