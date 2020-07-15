using LtInfo.Common;
using ProjectFirmaModels.UnitTestCommon;
using System;
using System.Data.SqlClient;
using System.Globalization;

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

        public static DateTime SqlGetCalendarDateTimeForFiscalYearPeriod(string fiscalYearPeriodString)
        {
            DateTime dateTime;
            try
            {
                string calendarDateFiscalYearPeriodFunction = "dbo.GetCalendarDateForStartOfFiscalYearPeriod";
                using (SqlConnection sqlConnection = CreateAndOpenSqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(calendarDateFiscalYearPeriodFunction, sqlConnection))
                    {
                        // If we needed parameters, here's how we'd add them.
                        cmd.CommandText = $"Select { calendarDateFiscalYearPeriodFunction} ('{fiscalYearPeriodString}')";
                        //cmd.Parameters.AddWithValue("@fiscalYearPeriodString", fiscalYearPeriodString);
                        dateTime = DateTime.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new SitkaDisplayErrorException($"Problem calling SQL: {e.Message}");
            }

            return dateTime;
        }

        public static SqlConnection CreateAndOpenSqlConnection()
        {
            var db = new ProjectFirmaSqlDatabase();
            var sqlConnection = db.CreateConnection();
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}