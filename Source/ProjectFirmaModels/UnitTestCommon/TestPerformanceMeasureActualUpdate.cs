﻿/*-----------------------------------------------------------------------
<copyright file="TestPerformanceMeasureActualUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureActualUpdate
        {
            public static PerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, int calendarYear)
            {
                var performanceMeasureActualUpdate = Create(projectUpdateBatch, calendarYear, null);
                return performanceMeasureActualUpdate;
            }

            public static PerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasure performanceMeasure, int calendarYear)
            {
                var performanceMeasureActualUpdate = Create(projectUpdateBatch, performanceMeasure, calendarYear, null);
                return performanceMeasureActualUpdate;
            }

            public static PerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, int calendarYear, double? actualValue)
            {
                var newTestPerformanceMeasure = TestPerformanceMeasure.Create();
                return Create(projectUpdateBatch, newTestPerformanceMeasure, calendarYear, actualValue);
            }

            public static PerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, PerformanceMeasure performanceMeasure, int calendarYear, double? actualValue)
            {
                var performanceMeasureReportingPeriod = TestPerformanceMeasureReportingPeriod.Create(performanceMeasure, calendarYear);
                var performanceMeasureActualUpdate = new PerformanceMeasureActualUpdate(projectUpdateBatch, performanceMeasure, performanceMeasureReportingPeriod) { ActualValue = actualValue };
                return performanceMeasureActualUpdate;
            }


        }
    }
}
