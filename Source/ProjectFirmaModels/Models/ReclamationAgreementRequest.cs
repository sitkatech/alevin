namespace ProjectFirmaModels.Models
{
    public partial class ReclamationAgreementRequest : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationAgreementRequest: {this.ReclamationAgreementRequestID}";
        }

        public decimal? ProjectedObligation => null;
    }
}