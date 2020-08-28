namespace ProjectFirmaModels.Models
{
    public partial class ObligationRequest : IAuditableEntity
    {

        public string GetAuditDescriptionString()
        {
            return $"ObligationRequest: {this.ObligationRequestID}";
        }

        public decimal? ProjectedObligation => null;
    }
}