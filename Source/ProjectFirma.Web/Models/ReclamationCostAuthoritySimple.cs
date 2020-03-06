using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ReclamationCostAuthoritySimple
    {

        public int ReclamationCostAuthorityID { get; set; }
        public string ReclamationCostAuthorityDisplayName { get; set; }
        public string ReclamationCostAuthorityDropdownDisplayName { get; set; }
        public List<ReclamationAgreementSimple> ReclamationCostAuthorityAgreementSimplesList { get; set; }
        public int CountOfRelatedAgreements { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReclamationCostAuthoritySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ReclamationCostAuthoritySimple(CostAuthority costAuthority)
            : this()
        {
            ReclamationCostAuthorityID = costAuthority.ReclamationCostAuthorityID;
            ReclamationCostAuthorityAgreementSimplesList = costAuthority.AgreementReclamationCostAuthorities.Select(x => new ReclamationAgreementSimple(x.ReclamationAgreement)).ToList();
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