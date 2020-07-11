using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string Date;
        public double Value;
        public double CumulativeValue;

        public ExpenditureCalendarYearMonth(int calendarYear, int calendarMonthNumber, double expenditureAmount,
            double cumulativeExpenditureAmount)
        {
            CalendarYear = calendarYear;
            CalendarMonthNumber = calendarMonthNumber;
            ExpenditureAmount = expenditureAmount;
            Value = expenditureAmount;
            CumulativeValue = cumulativeExpenditureAmount;
            Date = new DateTime(calendarYear, calendarMonthNumber, 01).ToString(CultureInfo.InvariantCulture);

        }
    }

    public class ObligationCalendarYearMonth
    {
        public int CalendarYear;
        public int CalendarMonthNumber;
        public double ObligationAmount;
        public string Date;
        public double Value;
        public double CumulativeValue;

        public ObligationCalendarYearMonth(int calendarYear, int calendarMonthNumber, double obligationAmount,
            double cumulativeObligationAmount)
        {
            CalendarYear = calendarYear;
            CalendarMonthNumber = calendarMonthNumber;
            ObligationAmount = obligationAmount;
            Value = obligationAmount;
            CumulativeValue = cumulativeObligationAmount;
            Date = new DateTime(calendarYear, calendarMonthNumber, 01).ToString(CultureInfo.InvariantCulture);
        }
    }

    public class ProjectionCalendarYear
    {
        public int CalendarYear;
        public float FundingSourceIdentifiedProjectionAmount;
        public float NoFundingSourceIdentifiedProjectionAmount;
        public string Date;
        public double Value;
        public double CumulativeValue;

        public ProjectionCalendarYear(int calendarYear, float fundingSourceIdentifiedProjectionAmount,
            float noFundingSourceIdentifiedProjectionAmount, double cumulativeProjectionAmount)
        {
            CalendarYear = calendarYear;
            FundingSourceIdentifiedProjectionAmount = fundingSourceIdentifiedProjectionAmount;
            NoFundingSourceIdentifiedProjectionAmount = noFundingSourceIdentifiedProjectionAmount;
            Value = fundingSourceIdentifiedProjectionAmount + noFundingSourceIdentifiedProjectionAmount;
            CumulativeValue = cumulativeProjectionAmount;
            Date = new DateTime(calendarYear, 01, 01).ToString(CultureInfo.InvariantCulture);
            
        }
    }
    
    public class ProjectBurnUpChartData
    {
        public List<ExpenditureCalendarYearMonth> ExpenditureCalendarYearMonths;
        public List<ObligationCalendarYearMonth> ObligationCalendarYearMonths;
        public List<ProjectionCalendarYear> ProjectionCalendarYears;

        public ProjectBurnUpChartData(
            List<ProjectRunningBalanceObligationsAndExpendituresRecord>
                projectRunningBalanceObligationsAndExpendituresRecords, ProjectFirmaModels.Models.Project project)
        {
            ExpenditureCalendarYearMonths = new List<ExpenditureCalendarYearMonth>();
            ObligationCalendarYearMonths = new List<ObligationCalendarYearMonth>();
            ProjectionCalendarYears = new List<ProjectionCalendarYear>();


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
            double cumulativeProjectionAmount = 0;
            foreach (var currentCalendarYear in calendarYears)
            {
                var currentProjections = projections.Where(p => p.CalendarYear == currentCalendarYear).ToList();
                float fundingSourceIdentifiedProjectionAmountTotal = (float) currentProjections.Sum(p => p.ProjectedAmount ?? 0);
                cumulativeProjectionAmount += fundingSourceIdentifiedProjectionAmountTotal;


                var currentNoFundingProjections = fundingSourceNoIdentifieds.Where(p => p.CalendarYear == currentCalendarYear).ToList();
                float noFundingSourceIdentifiedProjectAmountTotal = (float) currentNoFundingProjections.Sum(p => p.NoFundingSourceIdentifiedYet ?? 0 );
                cumulativeProjectionAmount += noFundingSourceIdentifiedProjectAmountTotal;

                ProjectionCalendarYears.Add(new ProjectionCalendarYear(currentCalendarYear, fundingSourceIdentifiedProjectionAmountTotal, noFundingSourceIdentifiedProjectAmountTotal, cumulativeProjectionAmount));
            }

            double cumulativeExpenditureAmount = 0;
            double cumulativeObligationAmount = 0;
            foreach (var groupedRecord in groupedRecords)
            {
                var expenditureAmount = groupedRecord.Sum(x => x.Expenditures);
                cumulativeExpenditureAmount += expenditureAmount;
                ExpenditureCalendarYearMonths.Add(new ExpenditureCalendarYearMonth(groupedRecord.Key.CalendarYear, groupedRecord.Key.CalendarMonthNumber, expenditureAmount, cumulativeExpenditureAmount));

                var obligationAmount = groupedRecord.Sum(x => x.Obligations);
                cumulativeObligationAmount += obligationAmount;
                ObligationCalendarYearMonths.Add(new ObligationCalendarYearMonth(groupedRecord.Key.CalendarYear, groupedRecord.Key.CalendarMonthNumber, obligationAmount, cumulativeObligationAmount));

            }
        }
        public struct DataGroup
        {
            public int CalendarYear;
            public int CalendarMonthNumber;
        }
    }
   
}