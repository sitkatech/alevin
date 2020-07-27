namespace ProjectFirmaModels.Models
{
    public partial class ObligationNumber : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ObligationNumber: {this.ObligationNumberID} - {this.ObligationNumberKey}";
        }
    }
}