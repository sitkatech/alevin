namespace ProjectFirmaModels.Models
{
    public static class ObligationRequestModelExtensions
    {
        public static string GetObligationRequestNumber(this ObligationRequest obligationRequest)
        {
            return $"OBREQ-{obligationRequest.ObligationRequestID:D4}";
        }
    }
}