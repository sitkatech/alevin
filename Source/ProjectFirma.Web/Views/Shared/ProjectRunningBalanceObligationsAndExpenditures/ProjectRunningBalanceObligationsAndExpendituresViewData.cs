using System.Collections.Generic;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    public class ProjectRunningBalanceObligationsAndExpendituresViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceObligationsAndExpendituresRecord> ProjectRunningBalanceObligationsAndExpendituresRecords { get; set; }

        public ProjectRunningBalanceObligationsAndExpendituresViewData(List<ProjectRunningBalanceObligationsAndExpendituresRecord> projectRunningBalanceObligationsAndExpendituresRecords)
        {
            this.ProjectRunningBalanceObligationsAndExpendituresRecords =  projectRunningBalanceObligationsAndExpendituresRecords;
        }

        public string GetFiscalMonthPeriodGridDisplayString(int fiscalMonthPeriod)
        {
            string calendarMonthName = FiscalMonthPeriodHelper.GetCalendarMonthName(fiscalMonthPeriod);
            return $"{fiscalMonthPeriod} ({calendarMonthName})";
        }
    }
}