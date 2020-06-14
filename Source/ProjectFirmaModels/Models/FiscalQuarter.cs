using System;

namespace ProjectFirmaModels.Models
{
    public partial class FiscalQuarter : IComparable<FiscalQuarter>
    {
        /// <summary>
        /// Gets a specific DateTime by combining a specific Calendar Year with this FiscalQuarter's
        /// start month/day.
        /// </summary>
        /// <param name="calendarYear"></param>
        /// <returns></returns>
        public DateTime GetCompleteStartDateUsingCalendarYear(int calendarYear)
        {
            return new DateTime(calendarYear, this.FiscalQuarterStartCalendarMonth, FiscalQuarterStartCalendarDay);
        }

        public int CompareTo(FiscalQuarter otherFiscalQuarter)
        {
            if (ReferenceEquals(this, otherFiscalQuarter)) return 0;
            if (ReferenceEquals(null, otherFiscalQuarter)) return 1;
            return FiscalQuarterNumber.CompareTo(otherFiscalQuarter.FiscalQuarterNumber);
        }
    }
}