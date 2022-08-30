using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirmaModels.Models
{
    public partial class SubprojectPerformanceMeasureActual : IAuditableEntity, IPerformanceMeasureValue
    {
        public string GetAuditDescriptionString()
        {
            return $"Subproject: {SubprojectID}, Performance Measure: {PerformanceMeasureID}, Actual Value: {ActualValue}";
        }

        public List<IPerformanceMeasureValueSubcategoryOption> GetPerformanceMeasureSubcategoryOptions() => new List<IPerformanceMeasureValueSubcategoryOption>(SubprojectPerformanceMeasureActualSubcategoryOptions.ToList());

        public double? GetReportedValue() => ActualValue;

        public string GetPerformanceMeasureSubcategoriesAsString()
        {
            if (PerformanceMeasure.HasRealSubcategories())
            {
                return SubprojectPerformanceMeasureActualSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        SubprojectPerformanceMeasureActualSubcategoryOptions.OrderBy(x =>
                                x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x =>
                                $"{x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName}: {x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName}"))
                    : ViewUtilities.NoneString;
            }

            return string.Empty;
        }
    }
}