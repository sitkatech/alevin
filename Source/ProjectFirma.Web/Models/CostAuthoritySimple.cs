using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class CostAuthoritySimple
    {
        //3/6/2019 TK -- Leaving the properties on this class with the Reclamation Prefix because of their use in front end code
        // 5/24/2020 SLG -- This is actually causing us issues and confusion, so now forcing it forward to drop Reclamation prefix
        public int CostAuthorityID { get; set; }
        public string CostAuthorityDisplayName { get; set; }
        public string CostAuthorityDropdownDisplayName { get; set; }
        public List<AgreementSimple> CostAuthorityAgreementSimplesList { get; set; }
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
            CostAuthorityID = costAuthority.CostAuthorityID;
            CostAuthorityAgreementSimplesList = costAuthority.AgreementCostAuthorities.Select(x => new AgreementSimple(x.Agreement)).ToList();
            CostAuthorityDisplayName = $"{costAuthority.CostAuthorityWorkBreakdownStructure} - {costAuthority.AccountStructureDescription}";
            CountOfRelatedAgreements = CostAuthorityAgreementSimplesList.Count;
            CostAuthorityDropdownDisplayName =
                $"{costAuthority.CostAuthorityWorkBreakdownStructure} - {costAuthority.AccountStructureDescription}{(CostAuthorityAgreementSimplesList.Any() ? GetRelatedAgreementIDsAsCommaDelimitedString() : "")}";
        }

        private string GetRelatedAgreementIDsAsCommaDelimitedString()
        {
            var agreementNumbersList = CostAuthorityAgreementSimplesList
                .Select(x => x.AgreementNumber.ToString()).ToList();

            return $" (Agreement Numbers: {string.Join(", ", agreementNumbersList)})";
        }

    }
}