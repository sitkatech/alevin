namespace ProjectFirmaModels.Models
{
    public partial class CostAuthorityProject : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"CostAuthorityProject --ReclamationCostAuthorityProjectID: {ReclamationCostAuthorityProjectID} - ReclamationCostAuthorityID: {this.ReclamationCostAuthorityID} = {this.ReclamationCostAuthority?.GetAuditDescriptionString()} - ProjectID: {this.ProjectID} = {this.Project?.GetAuditDescriptionString()}";
        }
    }
}