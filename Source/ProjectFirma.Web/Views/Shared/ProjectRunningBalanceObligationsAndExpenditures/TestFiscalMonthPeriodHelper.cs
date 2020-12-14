using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{
    [TestFixture]
    public class TestFiscalMonthPeriodHelper
    {
        [Test]
        public void TestFiscalMonthPeriodToCalendarYear()
        {
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(1) == 10);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(2) == 11);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(3) == 12);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(4) == 1);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(5) == 2);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(6) == 3);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(7) == 4);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(8) == 5);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(9) == 6);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(10) == 7);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(11) == 8);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(12) == 9);
            // These extra periods are all also September
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(13) == 9);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(14) == 9);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(15) == 9);
            Check.Ensure(FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(16) == 9);
            // These are out of range though
            Assert.Throws<SitkaDisplayErrorException>(() => FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(-1));
            Assert.Throws<SitkaDisplayErrorException>(() => FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(0));
            Assert.Throws<SitkaDisplayErrorException>(() => FiscalMonthPeriodHelper.GetCalendarMonthNumberForFiscalMonthPeriod(17));
        }

        [Test]
        public void TestGetCalendarDateTimeForFiscalYearPeriod()
        {
            
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("001/2020").Year == 2019);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("002/2020").Year == 2019);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("003/2020").Year == 2019);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("004/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("005/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("006/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("007/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("008/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("009/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("010/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("011/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("012/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("013/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("014/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("015/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriodString("016/2020").Year == 2020);

        }



    }
}