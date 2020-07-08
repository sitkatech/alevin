using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures;

namespace ProjectFirma.Web.Views.Shared.ProjectBalanceBurnUp
{
    public class ProjectBalanceBurnUpViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceObligationsAndExpendituresRecord> ProjectRunningBalanceObligationsAndExpendituresRecords { get; set; }
        public ProjectBurnUpChartData ProjectBurnUpChartData { get; set; }

        public ProjectBalanceBurnUpViewData(
            List<ProjectRunningBalanceObligationsAndExpendituresRecord>
                projectRunningBalanceObligationsAndExpendituresRecords, ProjectFirmaModels.Models.Project project)
        {
            this.ProjectRunningBalanceObligationsAndExpendituresRecords =  projectRunningBalanceObligationsAndExpendituresRecords;
            this.ProjectBurnUpChartData = new ProjectBurnUpChartData(projectRunningBalanceObligationsAndExpendituresRecords, project);
        }
        
        public string GetFiscalMonthPeriodGridDisplayString(int fiscalMonthPeriod)
        {
            string calendarMonthName = FiscalMonthPeriodHelper.GetCalendarMonthName(fiscalMonthPeriod);
            return $"{fiscalMonthPeriod} ({calendarMonthName})";
        }

    }

    public class ExpenditureCalendarYearMonth
    {
        public int CalendarYear;
        public int CalendarMonthNumber;
        public double ExpenditureAmount;

        public ExpenditureCalendarYearMonth(int calendarYear, int calendarMonthNumber, double expenditureAmount)
        {
            CalendarYear = calendarYear;
            CalendarMonthNumber = calendarMonthNumber;
            ExpenditureAmount = expenditureAmount;
        }
    }

    public class ObligationCalendarYearMonth
    {
        public int CalendarYear;
        public int CalendarMonthNumber;
        public double ObligationAmount;

        public ObligationCalendarYearMonth(int calendarYear, int calendarMonthNumber, double obligationAmount)
        {
            CalendarYear = calendarYear;
            CalendarMonthNumber = calendarMonthNumber;
            ObligationAmount = obligationAmount;
        }
    }

    public class ProjectionCalendarYearMonth
    {
        public int CalendarYear;
        public float FundingSourceIdentifiedProjectionAmount;
        public float NoFundingSourceIdentifiedProjectionAmount;

        public ProjectionCalendarYearMonth(int calendarYear, float fundingSourceIdentifiedProjectionAmount, float noFundingSourceIdentifiedProjectionAmount)
        {
            CalendarYear = calendarYear;
            FundingSourceIdentifiedProjectionAmount = fundingSourceIdentifiedProjectionAmount;
            NoFundingSourceIdentifiedProjectionAmount = noFundingSourceIdentifiedProjectionAmount;
        }
    }

    public class ProjectBurnUpChartData
    {
        public List<ExpenditureCalendarYearMonth> ExpenditureCalendarYearMonths;
        public List<ObligationCalendarYearMonth> ObligationCalendarYearMonths;
        public List<ProjectionCalendarYearMonth> ProjectionCalendarYearMonths;

        public ProjectBurnUpChartData(
            List<ProjectRunningBalanceObligationsAndExpendituresRecord>
                projectRunningBalanceObligationsAndExpendituresRecords, ProjectFirmaModels.Models.Project project)
        {
            ExpenditureCalendarYearMonths = new List<ExpenditureCalendarYearMonth>();
            ObligationCalendarYearMonths = new List<ObligationCalendarYearMonth>();
            ProjectionCalendarYearMonths = new List<ProjectionCalendarYearMonth>();


            var groupedRecords =
                projectRunningBalanceObligationsAndExpendituresRecords.GroupBy(
                    x => new DataGroup()
                    {
                        CalendarYear = x.CalendarYear,
                        CalendarMonthNumber = x.CalendarMonthNumber
                    }
                ).ToList();

            var projections = project.ProjectFundingSourceBudgets;
            var fundingSourceNoIdentifieds = project.ProjectNoFundingSourceIdentifieds;

            List<int> calendarYears = projections.Select(x => x.CalendarYear.Value).Distinct().OrderBy(y => y).ToList();
            foreach (var currentCalendarYear in calendarYears)
            {
                var currentProjections = projections.Where(p => p.CalendarYear == currentCalendarYear).ToList();
                float fundingSourceIdentifiedProjectionAmountTotal = (float) currentProjections.Sum(p => p.ProjectedAmount ?? 0);

                var currentNoFundingProjections = fundingSourceNoIdentifieds.Where(p => p.CalendarYear == currentCalendarYear).ToList();
                float noFundingSourceIdentifiedProjectAmountTotal = (float) currentNoFundingProjections.Sum(p => p.NoFundingSourceIdentifiedYet ?? 0 );

                ProjectionCalendarYearMonths.Add(new ProjectionCalendarYearMonth(currentCalendarYear, fundingSourceIdentifiedProjectionAmountTotal, noFundingSourceIdentifiedProjectAmountTotal));
            }

            
            foreach (var groupedRecord in groupedRecords)
            {
                var expenditureAmount = groupedRecord.Sum(x => x.Expenditures);
                ExpenditureCalendarYearMonths.Add(new ExpenditureCalendarYearMonth(groupedRecord.Key.CalendarYear, groupedRecord.Key.CalendarMonthNumber, expenditureAmount));

                var obligationAmount = groupedRecord.Sum(x => x.Obligations);
                ObligationCalendarYearMonths.Add(new ObligationCalendarYearMonth(groupedRecord.Key.CalendarYear, groupedRecord.Key.CalendarMonthNumber, obligationAmount));

            }
        }
        public struct DataGroup
        {
            public int CalendarYear;
            public int CalendarMonthNumber;
        }
    }
   
}