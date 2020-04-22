namespace ProjectFirmaModels.Models
{
    public partial class CostAuthorityObligationRequest : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"CostAuthorityObligationRequest: {this.CostAuthorityObligationRequestID}";
        }
    }
}