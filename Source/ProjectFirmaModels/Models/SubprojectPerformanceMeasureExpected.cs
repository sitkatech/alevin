using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirmaModels.Models
{
    public partial class SubprojectPerformanceMeasureExpected : IAuditableEntity, IPerformanceMeasureValue
    {
        public string GetAuditDescriptionString()
        {
            return $"Subproject: {SubprojectID}, Performance Measure: {PerformanceMeasureID}, Expected Value: {ExpectedValue}";
        }

        public string GetPerformanceMeasureSubcategoriesAsString()
        {
            if (PerformanceMeasure.HasRealSubcategories())
            {
                return SubprojectPerformanceMeasureExpectedSubcategoryOptions.Any()
                    ? String.Join("\r\n",
                        SubprojectPerformanceMeasureExpectedSubcategoryOptions.OrderBy(x =>
                                x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x =>
                                $"{x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName}: {x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName}"))
                    : ViewUtilities.NoneString;
            }

            return string.Empty;
        }

        public List<IPerformanceMeasureValueSubcategoryOption> GetPerformanceMeasureSubcategoryOptions()
        {
            return new List<IPerformanceMeasureValueSubcategoryOption>(SubprojectPerformanceMeasureExpectedSubcategoryOptions.ToList());
        }

        public double? GetReportedValue()
        {
            return ExpectedValue;
        }
    }
}