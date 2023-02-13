using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class FinancialDataByProjectAndCawbsForGeospatialArea
    {
        public ProjectFirmaModels.Models.Project Project { get; }
        public ProjectFirmaModels.Models.CostAuthority CostAuthority { get; }

        public WbsElementPnBudget WbsElementPnBudget { get; }

        public FinancialDataByProjectAndCawbsForGeospatialArea(ProjectFirmaModels.Models.Project project, ProjectFirmaModels.Models.CostAuthority costAuthority, WbsElementPnBudget wbsElementPnBudget)
        {
            Project = project;
            CostAuthority = costAuthority;
            WbsElementPnBudget = wbsElementPnBudget;
        }
    }
}