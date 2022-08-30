namespace ProjectFirmaModels.Models
{
    public partial class SubprojectPerformanceMeasureActualSubcategoryOption : IAuditableEntity, IPerformanceMeasureValueSubcategoryOption
    {
        public string GetPerformanceMeasureSubcategoryOptionName() =>
            PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;

        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, PerformanceMeasureSubcategory: {PerformanceMeasureSubcategoryID}, PerformanceMeasureSubcategory Option: {PerformanceMeasureSubcategoryOptionID}";
        }
    }
}