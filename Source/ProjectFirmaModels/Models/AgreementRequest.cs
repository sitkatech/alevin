namespace ProjectFirmaModels.Models
{
    public partial class AgreementRequest : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"AgreementRequest: {this.ReclamationAgreementRequestID}";
        }

        public decimal? ProjectedObligation => null;
    }
}