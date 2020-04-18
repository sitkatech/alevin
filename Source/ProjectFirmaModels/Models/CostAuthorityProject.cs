namespace ProjectFirmaModels.Models
{
    public partial class CostAuthorityProject : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"CostAuthorityProject --CostAuthorityProjectID: {CostAuthorityProjectID} - ReclamationCostAuthorityID: {this.CostAuthorityID} = {this.CostAuthority?.GetAuditDescriptionString()} - ProjectID: {this.ProjectID} = {this.Project?.GetAuditDescriptionString()}";
        }
    }
}