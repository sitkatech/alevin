using System.Collections.Generic;
using System.Linq;

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
        public ReclamationAgreementSimple(ReclamationAgreement reclamationAgreement)
            : this()
        {
            ReclamationAgreementID = reclamationAgreement.ReclamationAgreementID;
            ReclamationAgreementDisplayName = $"{reclamationAgreement.AgreementNumber} - {reclamationAgreement.GetOrganizationDisplayName()} - {reclamationAgreement.ContractType.ContractTypeDisplayName}";
            AgreementNumber = reclamationAgreement.AgreementNumber;
        }

    }
}