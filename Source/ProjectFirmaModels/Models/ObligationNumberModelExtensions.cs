namespace ProjectFirmaModels.Models
{
    public static class ObligationNumberModelExtensions
    {
        public static string GetDisplayName(this ObligationNumber obligationNumber)
        {
            return $"{obligationNumber.ObligationNumberKey}";
        }
    }
}