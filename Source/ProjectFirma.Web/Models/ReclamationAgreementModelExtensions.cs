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

        public static string GetDisplayName(this ReclamationAgreement reclamationAgreement)
        {
            return $"{reclamationAgreement.AgreementNumber}";
        }

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

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<AgreementController>.BuildUrlFromExpression(t => t.AgreementDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this ReclamationAgreement agreement)
        {
            return DetailUrlTemplate.ParameterReplace(agreement.PrimaryKey);
        }

        public static string GetDetailLinkUsingAgreementNumber(this ReclamationAgreement reclamationAgreement)
        {
            return SitkaRoute<AgreementController>.BuildLinkFromExpression(c => c.AgreementDetail(reclamationAgreement), reclamationAgreement.AgreementNumber);
        }

        /// <summary>
        /// Get the Projects associated with this Agreement
        /// </summary>
        /// <param name="reclamationAgreement"></param>
        /// <returns></returns>
        public static List<Project> GetAssociatedProjects(this ReclamationAgreement reclamationAgreement)
        {
            var costAuthorities = reclamationAgreement.GetReclamationCostAuthorities();
            var projects = costAuthorities.SelectMany(x => x.GetAssociatedProjects()).ToList();
            return projects;
        }

    }
}