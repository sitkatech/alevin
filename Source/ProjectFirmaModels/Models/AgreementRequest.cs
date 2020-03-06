namespace ProjectFirmaModels.Models
{
    public partial class AgreementRequest : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"AgreementRequest: {this.AgreementRequestID}";
        }

        public decimal? ProjectedObligation => null;
    }
}