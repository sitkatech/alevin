using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
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
        public static HtmlString GetDisplayNameAsUrl(this Subproject subproject) => UrlTemplate.MakeHrefString("#", subproject.SubprojectName);

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

    }
}