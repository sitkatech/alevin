namespace ProjectFirmaModels.Models
{
    public partial class CostAuthorityProject : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"CostAuthorityProject --CostAuthorityProjectID: {CostAuthorityProjectID} - ReclamationCostAuthorityID: {this.ReclamationCostAuthorityID} = {this.ReclamationCostAuthority?.GetAuditDescriptionString()} - ProjectID: {this.ProjectID} = {this.Project?.GetAuditDescriptionString()}";
        }
    }
}