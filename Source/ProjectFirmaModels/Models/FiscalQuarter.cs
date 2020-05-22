using System;

namespace ProjectFirmaModels.Models
{
    public partial class FiscalQuarter
    {
        /// <summary>
        /// Gets a specific DateTime by combining a specific Calendar Year with this FiscalQuarter's
        /// start month/day.
        /// </summary>
        /// <param name="calendarYear"></param>
        /// <returns></returns>
        public DateTime GetCompleteStartDateUsingCalendarYear(int calendarYear)
        {
            return new DateTime(calendarYear, this.FiscalQuarterStartMonth, FiscalQuarterStartDay);
        }
    }
}