namespace ProjectFirmaModels.Models
{
    public partial class SubprojectPerformanceMeasureExpectedSubcategoryOption : IAuditableEntity, IPerformanceMeasureValueSubcategoryOption
    {
        public string GetPerformanceMeasureSubcategoryOptionName() =>
            PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;

        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Subcategory: {PerformanceMeasureSubcategoryID}, Subcategory Option: {PerformanceMeasureSubcategoryOptionID}";
        }
    }
}