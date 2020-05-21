using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    public class ProjectRunningBalanceObligationsAndExpendituresViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceObligationsAndExpendituresRecord> ProjectRunningBalanceObligationsAndExpendituresRecords { get; set; }

        public ProjectRunningBalanceObligationsAndExpendituresViewData(List<ProjectRunningBalanceObligationsAndExpendituresRecord> projectRunningBalanceObligationsAndExpendituresRecords)
        {
            ProjectRunningBalanceObligationsAndExpendituresRecords = projectRunningBalanceObligationsAndExpendituresRecords.OrderBy(x => x.Date).ToList();
        }
    }
}