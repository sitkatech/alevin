using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class CostAuthoritySimple
    {
        //3/6/2019 TK -- Leaving the properties on this class with the Reclamation Prefix because of their use in front end code
        public int ReclamationCostAuthorityID { get; set; }
        public string ReclamationCostAuthorityDisplayName { get; set; }
        public string ReclamationCostAuthorityDropdownDisplayName { get; set; }
        public List<AgreementSimple> ReclamationCostAuthorityAgreementSimplesList { get; set; }
        public int CountOfRelatedAgreements { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public CostAuthoritySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public CostAuthoritySimple(CostAuthority costAuthority)
            : this()
        {
            ReclamationCostAuthorityID = costAuthority.CostAuthorityID;
            ReclamationCostAuthorityAgreementSimplesList = costAuthority.AgreementCostAuthorities.Select(x => new AgreementSimple(x.Agreement)).ToList();
            ReclamationCostAuthorityDisplayName = $"{costAuthority.CostAuthorityWorkBreakdownStructure} - {costAuthority.AccountStructureDescription}";
            CountOfRelatedAgreements = ReclamationCostAuthorityAgreementSimplesList.Count;
            ReclamationCostAuthorityDropdownDisplayName =
                $"{costAuthority.CostAuthorityWorkBreakdownStructure} - {costAuthority.AccountStructureDescription}{(ReclamationCostAuthorityAgreementSimplesList.Any() ? GetRelatedAgreementIDsAsCommaDelimitedString() : "")}";
        }

        private string GetRelatedAgreementIDsAsCommaDelimitedString()
        {
            var agreementNumbersList = ReclamationCostAuthorityAgreementSimplesList
                .Select(x => x.AgreementNumber.ToString()).ToList();

            return $" (Agreement Numbers: {string.Join(", ", agreementNumbersList)})";
        }

    }
}