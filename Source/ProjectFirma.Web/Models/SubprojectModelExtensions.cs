/*-----------------------------------------------------------------------
<copyright file="SubprojectModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SubprojectModelExtensions
    {
        public static List<Subproject> GetSubprojectFindResultsForSubprojectNameAndDescriptionAndNumber(this IQueryable<Subproject> subprojects, string subprojectKeyword)
        {
            return
                subprojects.Where(x => x.SubprojectName.Contains(subprojectKeyword) || x.SubprojectDescription.Contains(subprojectKeyword))
                    .OrderBy(x => x.SubprojectName)
                    .ToList();
        }
        public static HtmlString GetDisplayNameAsUrl(this Subproject subproject) => UrlTemplate.MakeHrefString(SitkaRoute<SubprojectController>.BuildUrlFromExpression(t => t.Detail(subproject.PrimaryKey)), subproject.SubprojectName);

        public static List<SubprojectPerformanceMeasureReportedValue> GetPerformanceMeasureReportedValues(this Subproject subproject)
        {
            var reportedPerformanceMeasures = subproject.GetNonVirtualPerformanceMeasureReportedValues();
            return reportedPerformanceMeasures.OrderByDescending<SubprojectPerformanceMeasureReportedValue, int>(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }
        public static List<SubprojectPerformanceMeasureReportedValue> GetNonVirtualPerformanceMeasureReportedValues(this Subproject subproject)
        {
            var performanceMeasures = subproject.SubprojectPerformanceMeasureActuals.Select(x => x.PerformanceMeasure).ToList();
            var performanceMeasureReportedValues = performanceMeasures.Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
                .SelectMany(x => x.GetReportedPerformanceMeasureValues(subproject)).ToList();
            var orderedPerformanceMeasureValues = performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
            return orderedPerformanceMeasureValues;
        }
        public static List<int> GetProjectUpdateImplementationStartToCompletionYearRange(this Subproject projectUpdate)
        {
            var startYear = projectUpdate?.ImplementationStartYear;
            return GetYearRangesImpl(projectUpdate, startYear);
        }
        private static List<int> GetYearRangesImpl(Subproject projectUpdate, int? startYear)
        {
            var currentYearToUse = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
            if (projectUpdate != null)
            {
                if (startYear.HasValue && startYear.Value < MultiTenantHelpers.GetMinimumYear() &&
                    (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value < MultiTenantHelpers.GetMinimumYear()))
                {
                    // both start and completion year are before the minimum year, so no year range required
                    return new List<int>();
                }

                if (startYear.HasValue && startYear.Value > currentYearToUse && (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value > currentYearToUse))
                {
                    return new List<int>();
                }

                if (startYear.HasValue && projectUpdate.CompletionYear.HasValue && startYear.Value > projectUpdate.CompletionYear.Value)
                {
                    return new List<int>();
                }
            }
            return FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(),
                startYear,
                projectUpdate?.CompletionYear,
                currentYearToUse,
                MultiTenantHelpers.GetMinimumYear(),
                currentYearToUse);
        }
    }
}