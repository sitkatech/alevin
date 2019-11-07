namespace ProjectFirmaModels.Models
{
    public partial class ReclamationCostAuthorityProject : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationCostAuthorityProject --ReclamationCostAuthorityProjectID: {ReclamationCostAuthorityProjectID} - ReclamationCostAuthorityID: {this.ReclamationCostAuthorityID} = {this.ReclamationCostAuthority?.GetAuditDescriptionString()} - ProjectID: {this.ProjectID} = {this.Project?.GetAuditDescriptionString()}";
        }
    }
}