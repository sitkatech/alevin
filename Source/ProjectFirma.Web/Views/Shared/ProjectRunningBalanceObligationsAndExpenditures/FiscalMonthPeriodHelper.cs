using System;
using System.Globalization;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    public class FiscalMonthPeriodHelper
    {
        public static string GetCalendarMonthName(int fiscalMonthPeriod)
        {
            int calendarMonthNumber = GetCalendarMonthNumberForFiscalMonthPeriod(fiscalMonthPeriod);
            var tempDateTimeWithCalendarMonthNumber = new DateTime(1900, calendarMonthNumber, 1);
            string calendarMonthName = tempDateTimeWithCalendarMonthNumber.ToString("MMM", CultureInfo.InvariantCulture);
            return calendarMonthName;
        }

        public static int GetCalendarMonthNumberForFiscalMonthPeriod(int fiscalMonthPeriod)
        {
            // Hard coded for Reclamation
            if (fiscalMonthPeriod < 1 || fiscalMonthPeriod > 16)
            {
                throw new SitkaDisplayErrorException($"FiscalMontPeriod out of expected range (1-16): {fiscalMonthPeriod}");
            }

            // 12-16 are all September
            if (fiscalMonthPeriod > 12)
            {
                fiscalMonthPeriod = 12;
            }

            int adjustedMonthNumber = fiscalMonthPeriod - 3;
            if (adjustedMonthNumber <= 0)
            {
                adjustedMonthNumber += 12;
            }

            return adjustedMonthNumber;
        }
    }
}