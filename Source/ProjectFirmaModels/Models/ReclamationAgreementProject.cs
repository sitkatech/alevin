namespace ProjectFirmaModels.Models
{
    public partial class ReclamationAgreementProject : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationAgreementProject --ReclamationAgreementProjectID: {ReclamationAgreementProjectID} - ReclamationAgreementID: {this.ReclamationAgreementID} = {this.ReclamationAgreement?.GetAuditDescriptionString()} - ProjectID: {this.ProjectID} = {this.Project?.GetAuditDescriptionString()}";
        }
    }
}