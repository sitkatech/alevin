﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualSimple.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSimple
    {
        /// <summary>
        /// This may be used by SubprojectPerformanceMeasureActualID, when this class is used for SubprojectPerformanceMeasureActuals
        /// </summary>
        public int? PerformanceMeasureActualID { get; set; }
        [Required]
        public int? PerformanceMeasureID { get; set; }
        [DisplayName("Calendar Year")]
        public int CalendarYear { get; set; }
        [DisplayName("Reported Value")]
        public double? ActualValue { get; set; }
        public List<PerformanceMeasureActualSubcategoryOptionSimple> PerformanceMeasureActualSubcategoryOptions { get; set; }
        public string PerformanceMeasureActualName { get; set; }
        public int PerformanceMeasureReportingPeriodID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSimple(int performanceMeasureActualID, int performanceMeasureID, int calendarYear, double actualValue, int performanceMeasureReportingPeriodID)
            : this()
        {
            PerformanceMeasureActualID = performanceMeasureActualID;
            PerformanceMeasureID = performanceMeasureID;
            CalendarYear = calendarYear;
            ActualValue = actualValue;
            PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriodID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualSimple(PerformanceMeasureActual performanceMeasureActual)
            : this()
        {
            PerformanceMeasureActualID = performanceMeasureActual.PerformanceMeasureActualID;
            PerformanceMeasureID = performanceMeasureActual.PerformanceMeasureID;
            CalendarYear = performanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
            ActualValue = performanceMeasureActual.ActualValue;
            PerformanceMeasureActualSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureActual);
            PerformanceMeasureReportingPeriodID = performanceMeasureActual.PerformanceMeasureReportingPeriodID;
        }

        public PerformanceMeasureActualSimple(SubprojectPerformanceMeasureActual performanceMeasureActual)
            : this()
        {
            PerformanceMeasureActualID = performanceMeasureActual.SubprojectPerformanceMeasureActualID;
            PerformanceMeasureID = performanceMeasureActual.PerformanceMeasureID;
            CalendarYear = performanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
            ActualValue = performanceMeasureActual.ActualValue;
            PerformanceMeasureActualSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureActual);
            PerformanceMeasureReportingPeriodID = performanceMeasureActual.PerformanceMeasureReportingPeriodID;
        }


        public PerformanceMeasureActualSimple(PerformanceMeasureExpected performanceMeasureExpected, int calendarYear, int decrementingPerformanceMeasureActual)
            : this()
        {
            var reportingPeriods =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.Where(x =>
                    x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear).ToList();
            var reportingPeriod = reportingPeriods.Single();
            PerformanceMeasureActualID = decrementingPerformanceMeasureActual;
            PerformanceMeasureID = performanceMeasureExpected.PerformanceMeasureID;
            CalendarYear = calendarYear;
            ActualValue = null;
            PerformanceMeasureActualSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptionsToActual(performanceMeasureExpected);
            PerformanceMeasureReportingPeriodID = reportingPeriod.PerformanceMeasureReportingPeriodID;
        }

        public PerformanceMeasureActualSimple(SubprojectPerformanceMeasureExpected performanceMeasureExpected, int calendarYear, int decrementingPerformanceMeasureActual)
            : this()
        {
            var reportingPeriods =
                HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.Where(x =>
                    x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear).ToList();
            var reportingPeriod = reportingPeriods.Single();
            PerformanceMeasureActualID = decrementingPerformanceMeasureActual;
            PerformanceMeasureID = performanceMeasureExpected.PerformanceMeasureID;
            CalendarYear = calendarYear;
            ActualValue = null;
            PerformanceMeasureActualSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptionsToActual(performanceMeasureExpected);
            PerformanceMeasureReportingPeriodID = reportingPeriod.PerformanceMeasureReportingPeriodID;
        }
    }
}
