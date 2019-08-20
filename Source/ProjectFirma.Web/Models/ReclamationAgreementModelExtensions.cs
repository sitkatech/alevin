using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
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

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<AgreementController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this ReclamationAgreement agreement)
        {
            return DetailUrlTemplate.ParameterReplace(agreement.PrimaryKey);
        }

    }
}