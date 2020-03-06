namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementSimple
    {
        public int ReclamationAgreementID { get; set; }
        public string ReclamationAgreementDisplayName { get; set; }
        public string AgreementNumber { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReclamationAgreementSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ReclamationAgreementSimple(Agreement agreement)
            : this()
        {
            ReclamationAgreementID = agreement.AgreementID;
            ReclamationAgreementDisplayName = $"{agreement.AgreementNumber} - {agreement.GetOrganizationDisplayName()} - {agreement.ContractType.ContractTypeDisplayName}";
            AgreementNumber = agreement.AgreementNumber;
        }
    }
}