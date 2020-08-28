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
            
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("001/2020").Year == 2019);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("002/2020").Year == 2019);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("003/2020").Year == 2019);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("004/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("005/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("006/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("007/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("008/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("009/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("010/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("011/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("012/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("013/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("014/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("015/2020").Year == 2020);
            Check.Ensure(FiscalMonthPeriodHelper.SqlGetCalendarDateTimeForFiscalYearPeriod("016/2020").Year == 2020);

        }



    }
}