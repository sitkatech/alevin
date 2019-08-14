using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReclamationAgreementModelExtensions
    {
        /// <summary>
        /// Convenience accessor for Reclamation Cost Authorities.
        /// </summary>
        public static List<ReclamationCostAuthority> GetReclamationCostAuthorities(this ReclamationAgreement reclamationAgreement)
        {
            return reclamationAgreement.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationCostAuthority).ToList();
        }

        /// <summary>
        /// Convenience accessor for Reclamation Cost Authorities.
        /// </summary>
        public static string GetReclamationWorkBreakdownStructuresAsCommaDelimitedString(this ReclamationAgreement reclamationAgreement)
        {
            var costAuthorities = reclamationAgreement.GetReclamationCostAuthorities();
            return string.Join(", ", costAuthorities.Select(ca => ca.CostAuthorityWorkBreakdownStructure));
        }
    }
}