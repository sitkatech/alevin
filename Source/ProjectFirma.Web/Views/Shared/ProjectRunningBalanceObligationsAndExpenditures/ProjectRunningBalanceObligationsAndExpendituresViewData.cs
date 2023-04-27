using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    public class ProjectRunningBalanceObligationsAndExpendituresViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceObligationsAndExpendituresRecord> ProjectRunningBalanceObligationsAndExpendituresRecords { get; set; }
        public ProjectRunningBalanceGroupedRecordsGridSpec ProjectRunningBalanceGroupedRecordsGridSpec { get; }
        public string ProjectRunningBalanceGroupedRecordsGridName { get; }
        public string ProjectRunningBalanceGroupedRecordsGridDataUrl { get; }

        public ProjectRunningBalanceObligationsAndExpendituresViewData(List<ProjectRunningBalanceObligationsAndExpendituresRecord> projectRunningBalanceObligationsAndExpendituresRecords, string projectRunningBalanceGroupedRecordsGridDataUrl)
        {
            ProjectRunningBalanceObligationsAndExpendituresRecords =  projectRunningBalanceObligationsAndExpendituresRecords;

            ProjectRunningBalanceGroupedRecordsGridSpec = new ProjectRunningBalanceGroupedRecordsGridSpec();
            ProjectRunningBalanceGroupedRecordsGridName = "projectRunningBalanceGroupedRecordsGrid";
            ProjectRunningBalanceGroupedRecordsGridDataUrl = projectRunningBalanceGroupedRecordsGridDataUrl;


        }

        public string GetFiscalMonthPeriodGridDisplayString(int fiscalMonthPeriod)
        {
            string calendarMonthName = FiscalMonthPeriodHelper.GetCalendarMonthName(fiscalMonthPeriod);
            return $"{fiscalMonthPeriod} ({calendarMonthName})";
        }
    }
}