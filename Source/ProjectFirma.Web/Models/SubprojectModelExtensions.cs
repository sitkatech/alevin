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