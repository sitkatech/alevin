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

        public static string GetDisplayName(this Agreement agreement)
        {
            if (agreement == null)
            {
                return null;
            }
            return $"{agreement.AgreementNumber}";
        }

        public static string GetFullDisplayName(this Agreement agreement)
        {
            return $"{agreement.AgreementNumber} - {agreement.GetOrganizationDisplayName()} - {agreement.ContractType.ContractTypeDisplayName}";
        }

        /// <summary>
        /// Convenience accessor for Reclamation Cost Authorities.
        /// </summary>
        public static List<CostAuthority> GetReclamationCostAuthorities(this Agreement agreement)
        {
            //return agreement.AgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationCostAuthority).ToList();
            return agreement.AgreementReclamationCostAuthoritiesWhereYouAreTheReclamationAgreement.Select(rarca => rarca.ReclamationCostAuthority).ToList();
        }

        /// <summary>
        /// Convenience accessor for Reclamation Cost Authorities.
        /// </summary>
        public static string GetReclamationWorkBreakdownStructuresAsCommaDelimitedString(this Agreement agreement)
        {
            var costAuthorities = agreement.GetReclamationCostAuthorities();
            return string.Join(", ", costAuthorities.Select(ca => ca.CostAuthorityWorkBreakdownStructure));
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<AgreementController>.BuildUrlFromExpression(t => t.AgreementDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Agreement agreement)
        {
            if (agreement == null)
            {
                return null;
            }
            return DetailUrlTemplate.ParameterReplace(agreement.PrimaryKey);
        }

        public static string GetDetailLinkUsingAgreementNumber(this Agreement agreement)
        {
            return SitkaRoute<AgreementController>.BuildLinkFromExpression(c => c.AgreementDetail(agreement), agreement.AgreementNumber);
        }

        public static string GetDetailLinkUsingFullDisplayName(this Agreement agreement)
        {
            return SitkaRoute<AgreementController>.BuildLinkFromExpression(c => c.AgreementDetail(agreement), agreement.GetFullDisplayName());
        }

        /// <summary>
        /// Get the Projects associated with this Agreement
        /// </summary>
        /// <param name="agreement"></param>
        /// <returns></returns>
        public static List<Project> GetAssociatedProjects(this Agreement agreement)
        {
            var costAuthorities = agreement.GetReclamationCostAuthorities();
            var projects = costAuthorities.SelectMany(x => x.GetAssociatedProjects()).Distinct().ToList();
            return projects;
        }

    }
}