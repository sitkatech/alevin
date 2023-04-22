using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    public class ProjectRunningBalanceObligationsAndExpendituresViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceObligationsAndExpendituresRecord> ProjectRunningBalanceObligationsAndExpendituresRecords { get; set; }
        public List<ProjectRunningBalanceGroupedRecord> ProjectRunningBalanceGroupedRecords { get; set; }

        public ProjectRunningBalanceObligationsAndExpendituresViewData(List<ProjectRunningBalanceObligationsAndExpendituresRecord> projectRunningBalanceObligationsAndExpendituresRecords)
        {
            ProjectRunningBalanceObligationsAndExpendituresRecords =  projectRunningBalanceObligationsAndExpendituresRecords;




            var projectRunningBalanceObligationsAndExpendituresRecordsTemp = projectRunningBalanceObligationsAndExpendituresRecords.GroupBy(
                prb =>
                    new
                    {
                        prb.FiscalYear,
                        prb.FiscalQuarter.FiscalQuarterNumber,
                        prb.FiscalMonthPeriod,
                        BudgetObjectCodeName = prb.BudgetObjectCode != null ? prb.BudgetObjectCode.BudgetObjectCodeName : string.Empty
                    }
                ).ToList();

           var projectRunningBalanceObligationsAndExpendituresRecordsGrouped =
                projectRunningBalanceObligationsAndExpendituresRecordsTemp.
                    OrderBy(g => g.Key.FiscalYear)
                    .ThenBy(g => g.Key.FiscalMonthPeriod)
                    .ThenBy(g => g.Key.BudgetObjectCodeName)
                    .ToList();

           ProjectRunningBalanceGroupedRecords = new List<ProjectRunningBalanceGroupedRecord>();

           foreach (var prbGroup in projectRunningBalanceObligationsAndExpendituresRecordsGrouped)
           {
                ProjectRunningBalanceGroupedRecords.Add(new ProjectRunningBalanceGroupedRecord(prbGroup));
           }



        }

        public string GetFiscalMonthPeriodGridDisplayString(int fiscalMonthPeriod)
        {
            string calendarMonthName = FiscalMonthPeriodHelper.GetCalendarMonthName(fiscalMonthPeriod);
            return $"{fiscalMonthPeriod} ({calendarMonthName})";
        }
    }
}