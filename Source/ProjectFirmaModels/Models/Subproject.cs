namespace ProjectFirmaModels.Models
{
    public partial class Subproject : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Subproject: {SubprojectID}, ProjectID: {ProjectID}";
        }
    }
}