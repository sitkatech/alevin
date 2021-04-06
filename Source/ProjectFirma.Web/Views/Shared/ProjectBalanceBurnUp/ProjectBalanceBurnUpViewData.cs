using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures;
using ProjectFirmaModels.Models;

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
        public string TooltipHtml;

        public ExpenditureCalendarYearMonth(int calendarYear, int calendarMonthNumber, double expenditureAmount,
            double cumulativeExpenditureAmount)
        {
            CalendarYear = calendarYear;
            CalendarMonthNumber = calendarMonthNumber;
            ExpenditureAmount = expenditureAmount;
            Value = expenditureAmount;
            CumulativeValue = cumulativeExpenditureAmount;
            var dateTime = new DateTime(calendarYear, calendarMonthNumber, 01);
            Date = dateTime.ToString("MM/dd/yyyy");
            TooltipHtml = "<dl>" +
                          "<dt>Date</dt>" +
                          $"<dd>{dateTime:MM/dd/yyyy}</dd>" +
                          "<dt>Expenditures</dt>" +
                          $"<dd>{new Money((decimal)Value).ToStringCurrency()}</dd>" +
                          "<dt>Cumulative Expenditures</dt>" +
                          $"<dd>{new Money((decimal)CumulativeValue).ToStringCurrency()}</dd>" +
                          "</dl>";
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
        public string TooltipHtml;

        public ObligationCalendarYearMonth(int calendarYear, int calendarMonthNumber, double obligationAmount,
            double cumulativeObligationAmount)
        {
            CalendarYear = calendarYear;
            CalendarMonthNumber = calendarMonthNumber;
            ObligationAmount = obligationAmount;
            Value = obligationAmount;
            CumulativeValue = cumulativeObligationAmount;
            var dateTime = new DateTime(calendarYear, calendarMonthNumber, 01);
            Date = dateTime.ToString("MM/dd/yyyy");
            TooltipHtml = "<dl>" +
                          "<dt>Date</dt>" +
                          $"<dd>{dateTime:MM/dd/yyyy}</dd>" +
                          "<dt>Obligation</dt>" +
                          $"<dd>{new Money((decimal)Value).ToStringCurrency()}</dd>" +
                          "<dt>Cumulative Obligation</dt>" +
                          $"<dd>{new Money((decimal)CumulativeValue).ToStringCurrency()}</dd>" +
                          "</dl>";
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
        public string TooltipHtml;

        public ProjectionCalendarYear(int calendarYear, float fundingSourceIdentifiedProjectionAmount,
            float noFundingSourceIdentifiedProjectionAmount, double cumulativeProjectionAmount)
        {
            CalendarYear = calendarYear;
            FundingSourceIdentifiedProjectionAmount = fundingSourceIdentifiedProjectionAmount;
            NoFundingSourceIdentifiedProjectionAmount = noFundingSourceIdentifiedProjectionAmount;
            Value = fundingSourceIdentifiedProjectionAmount + noFundingSourceIdentifiedProjectionAmount;
            CumulativeValue = cumulativeProjectionAmount;
            var dateTime = new DateTime(calendarYear - 1, MultiTenantHelpers.GetStartDayOfReportingPeriod().Month, 01);
            Date = dateTime.ToString("MM/dd/yyyy");
            TooltipHtml = "<dl>" +
                          "<dt>Date</dt>" +
                          $"<dd>{dateTime:MM/dd/yyyy}</dd>" +
                          "<dt>Projection</dt>" +
                          $"<dd>{new Money((decimal)Value).ToStringCurrency()}</dd>" +
                          "<dt>Cumulative Projection</dt>" +
                          $"<dd>{new Money((decimal)CumulativeValue).ToStringCurrency()}</dd>" +
                          "</dl>";
        }
    }
    
    public class ProjectBurnUpChartData
    {
        public List<ExpenditureCalendarYearMonth> Expenditures;
        public List<ObligationCalendarYearMonth> Obligations;
        public List<ProjectionCalendarYear> Projections;

        public ProjectBurnUpChartData(
            List<ProjectRunningBalanceObligationsAndExpendituresRecord>
                projectRunningBalanceObligationsAndExpendituresRecords, ProjectFirmaModels.Models.Project project)
        {
            Expenditures = new List<ExpenditureCalendarYearMonth>();
            Obligations = new List<ObligationCalendarYearMonth>();
            Projections = new List<ProjectionCalendarYear>();


            var groupedRecords =
                projectRunningBalanceObligationsAndExpendituresRecords.GroupBy(
                    x => new DataGroup()
                    {
                        CalendarYear = x.CalendarYear,
                        CalendarMonthNumber = x.CalendarMonthNumber
                    }
                ).OrderBy(x => x.Key.CalendarYear).ThenBy(x => x.Key.CalendarMonthNumber).ToList();

            var projections = project.ProjectFundingSourceBudgets.ToList();
            var fundingSourceNoIdentifieds = project.ProjectNoFundingSourceIdentifieds.ToList();

            List<int> calendarYears = projections.Where(x => x.CalendarYear.HasValue).Select(x => x.CalendarYear.Value).ToList();
            calendarYears = calendarYears.Concat(fundingSourceNoIdentifieds.Where(x => x.CalendarYear.HasValue).Select(x => x.CalendarYear.Value)).ToList();

            calendarYears = calendarYears.Distinct().OrderBy(x => x).ToList();

            double cumulativeProjectionAmount = 0;
            foreach (var currentCalendarYear in calendarYears)
            {
                var currentProjections = projections.Where(p => p.CalendarYear == currentCalendarYear).ToList();
                float fundingSourceIdentifiedProjectionAmountTotal = (float) currentProjections.Sum(p => p.ProjectedAmount ?? 0);
                cumulativeProjectionAmount += fundingSourceIdentifiedProjectionAmountTotal;


                var currentNoFundingProjections = fundingSourceNoIdentifieds.Where(p => p.CalendarYear == currentCalendarYear).ToList();
                float noFundingSourceIdentifiedProjectAmountTotal = (float) currentNoFundingProjections.Sum(p => p.NoFundingSourceIdentifiedYet ?? 0 );
                cumulativeProjectionAmount += noFundingSourceIdentifiedProjectAmountTotal;

                Projections.Add(new ProjectionCalendarYear(currentCalendarYear, fundingSourceIdentifiedProjectionAmountTotal, noFundingSourceIdentifiedProjectAmountTotal, cumulativeProjectionAmount));
            }

            double cumulativeExpenditureAmount = 0;
            double cumulativeObligationAmount = 0;
            foreach (var groupedRecord in groupedRecords)
            {
                var expenditureAmount = groupedRecord.Sum(x => x.Expenditures);
                cumulativeExpenditureAmount += expenditureAmount;
                Expenditures.Add(new ExpenditureCalendarYearMonth(groupedRecord.Key.CalendarYear, groupedRecord.Key.CalendarMonthNumber, expenditureAmount, cumulativeExpenditureAmount));

                var obligationAmount = groupedRecord.Sum(x => x.Obligations);
                cumulativeObligationAmount += obligationAmount;
                Obligations.Add(new ObligationCalendarYearMonth(groupedRecord.Key.CalendarYear, groupedRecord.Key.CalendarMonthNumber, obligationAmount, cumulativeObligationAmount));

            }

            Obligations = Obligations.OrderBy(x => x.CalendarYear).ThenBy(x => x.CalendarMonthNumber).ToList();
            Expenditures = Expenditures.OrderBy(x => x.CalendarYear).ThenBy(x => x.CalendarMonthNumber).ToList();
            Projections = Projections.OrderBy(x => x.CalendarYear).ToList();
        }

        public struct DataGroup
        {
            public int CalendarYear;
            public int CalendarMonthNumber;
        }
    }
   
}