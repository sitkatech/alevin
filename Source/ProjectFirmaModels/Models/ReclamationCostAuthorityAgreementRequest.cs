namespace ProjectFirmaModels.Models
{
    public partial class ReclamationCostAuthorityAgreementRequest : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationCostAuthorityAgreementRequest: {this.ReclamationCostAuthorityAgreementRequestID}";
        }
    }
}