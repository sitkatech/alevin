namespace ProjectFirmaModels.Models
{
    public partial class ActionItem : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Action Item: {ActionItemID}, ProjectID: {ProjectID}";
        }
    }
}