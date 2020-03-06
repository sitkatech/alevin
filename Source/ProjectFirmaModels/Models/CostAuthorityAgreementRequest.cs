namespace ProjectFirmaModels.Models
{
    public partial class CostAuthorityAgreementRequest : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"CostAuthorityAgreementRequest: {this.CostAuthorityAgreementRequestID}";
        }
    }
}