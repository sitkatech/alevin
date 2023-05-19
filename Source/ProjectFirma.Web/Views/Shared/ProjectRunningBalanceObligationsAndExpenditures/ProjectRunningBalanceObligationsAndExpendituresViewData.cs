using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    public class ProjectRunningBalanceObligationsAndExpendituresViewData : FirmaUserControlViewData
    {
        public ProjectRunningBalanceGroupedRecordsGridSpec ProjectRunningBalanceGroupedRecordsGridSpec { get; }
        public string ProjectRunningBalanceGroupedRecordsGridName { get; }
        public string ProjectRunningBalanceGroupedRecordsGridDataUrl { get; }

        public ProjectRunningBalanceObligationsAndExpendituresViewData(string projectRunningBalanceGroupedRecordsGridDataUrl)
        {
            ProjectRunningBalanceGroupedRecordsGridSpec = new ProjectRunningBalanceGroupedRecordsGridSpec();
            ProjectRunningBalanceGroupedRecordsGridName = "projectRunningBalanceGroupedRecordsGrid";
            ProjectRunningBalanceGroupedRecordsGridDataUrl = projectRunningBalanceGroupedRecordsGridDataUrl;


        }
    }
}