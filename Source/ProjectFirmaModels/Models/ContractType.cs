namespace ProjectFirmaModels.Models
{
    public partial class ContractType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ContractType: {this.ContractTypeID} - {this.ContractTypeDisplayName}";
        }
    }
}