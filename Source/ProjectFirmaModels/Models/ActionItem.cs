namespace ProjectFirmaModels.Models
{
    public partial class ActionItem : IAuditableEntity, IActionItem
    {
        public string GetAuditDescriptionString()
        {
            return $"Action Item: {ActionItemID}, ProjectID: {ProjectID}";
        }
    }
}