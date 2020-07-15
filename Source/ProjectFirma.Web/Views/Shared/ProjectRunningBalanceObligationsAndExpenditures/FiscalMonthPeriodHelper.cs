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
            string paddedMonth = fiscalMonthPeriod.ToString().PadLeft(3, '0');
            DateTime temp = SqlGetCalendarDateTimeForFiscalYearPeriod($"{paddedMonth}/2019");
            return temp.Month;
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