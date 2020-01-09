namespace ProjectFirmaModels.Models
{
    public partial class ReclamationContractType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationContractType: {this.ReclamationContractTypeID} - {this.ContractTypeDisplayName}";
        }
    }
}