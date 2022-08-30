/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportedValue.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureReportedValue : IPerformanceMeasureReportedValue
    {
        public readonly Subproject Subproject;
        private readonly double? _reportedValue;
        public int CalendarYear { get; }
        public PerformanceMeasure PerformanceMeasure { get; }
        public PerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod { get; }

        public double? GetReportedValue()
        {
            return _reportedValue;
        }

        public int PerformanceMeasureID => PerformanceMeasure.PerformanceMeasureID;

        public string GetPerformanceMeasureName() => PerformanceMeasure.PerformanceMeasureDisplayName;

        public string SubprojectName => Subproject.GetDisplayName();

        public MeasurementUnitType GetMeasurementUnitType() => PerformanceMeasure.MeasurementUnitType;

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }

        private SubprojectPerformanceMeasureReportedValue(SubprojectPerformanceMeasureActual subprojectPerformanceMeasureActual)
        {
            PerformanceMeasure = subprojectPerformanceMeasureActual.PerformanceMeasure;
            CalendarYear = subprojectPerformanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
            _reportedValue = subprojectPerformanceMeasureActual.ActualValue;
            Subproject = subprojectPerformanceMeasureActual.Subproject;
            PerformanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>(subprojectPerformanceMeasureActual.SubprojectPerformanceMeasureActualSubcategoryOptions);
            PerformanceMeasureReportingPeriod = subprojectPerformanceMeasureActual.PerformanceMeasureReportingPeriod;
        }

        //private SubprojectPerformanceMeasureReportedValue(PerformanceMeasureActualUpdate performanceMeasureActualUpdate)
        //{
        //    PerformanceMeasure = performanceMeasureActualUpdate.PerformanceMeasure;
        //    CalendarYear = performanceMeasureActualUpdate.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
        //    _reportedValue = performanceMeasureActualUpdate.ActualValue;
        //    Subproject = performanceMeasureActualUpdate.ProjectUpdateBatch.Subproject;
        //    PerformanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>(performanceMeasureActualUpdate.PerformanceMeasureActualSubcategoryOptionUpdates);
        //    PerformanceMeasureReportingPeriod = performanceMeasureActualUpdate.PerformanceMeasureReportingPeriod;
        //}


        public SubprojectPerformanceMeasureReportedValue(PerformanceMeasure performanceMeasure, Subproject subproject, int calendarYear, double reportedValue)
        {
            PerformanceMeasure = performanceMeasure;
            CalendarYear = calendarYear;
            _reportedValue = reportedValue;
            Subproject = subproject;
            PerformanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>();

        }

        public string GetPerformanceMeasureSubcategoriesAsString()
        {
            return PerformanceMeasureActualSubcategoryOptions.Any()
                ? string.Join("\r\n",
                    PerformanceMeasureActualSubcategoryOptions.OrderBy(x =>
                            x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                        .Select(x =>
                            $"{x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName}: {x.GetPerformanceMeasureSubcategoryOptionName()}"))
                : ViewUtilities.NoneString;
        }

        public static List<SubprojectPerformanceMeasureReportedValue> MakeFromList(IEnumerable<SubprojectPerformanceMeasureActual> performanceMeasureActuals)
        {
            return performanceMeasureActuals.Select(x => new SubprojectPerformanceMeasureReportedValue(x)).ToList();
        }


        //public static List<SubprojectPerformanceMeasureReportedValue> MakeFromList(IEnumerable<PerformanceMeasureActualUpdate> performanceMeasureActualUpdates)
        //{
        //    return performanceMeasureActualUpdates.Select(x => new SubprojectPerformanceMeasureReportedValue(x)).ToList();
        //}


        public List<IPerformanceMeasureValueSubcategoryOption> GetPerformanceMeasureSubcategoryOptions() =>
            new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureActualSubcategoryOptions);
    }
}
