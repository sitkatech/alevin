namespace ProjectFirmaModels.Models
{
    public class AgreementSimple
    {
        //3/6/2019 TK -- Leaving the properties on this class with the Reclamation Prefix because of their use in front end code
        public int ReclamationAgreementID { get; set; }
        public string ReclamationAgreementDisplayName { get; set; }
        public string AgreementNumber { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public AgreementSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public AgreementSimple(Agreement agreement)
            : this()
        {
            ReclamationAgreementID = agreement.AgreementID;
            ReclamationAgreementDisplayName = $"{agreement.AgreementNumber} - {agreement.GetOrganizationDisplayName()} - {agreement.ContractType.ContractTypeDisplayName}";
            AgreementNumber = agreement.AgreementNumber;
        }
    }
}