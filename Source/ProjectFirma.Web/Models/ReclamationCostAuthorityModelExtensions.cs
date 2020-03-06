using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReclamationCostAuthorityModelExtensions
    {

        public static string GetDisplayName(this ReclamationCostAuthority reclamationCostAuthority)
        {
            return $"{reclamationCostAuthority.CostAuthorityWorkBreakdownStructure}";
        }

        /// <summary>
        /// Convenience accessor for Reclamation Agreements.
        /// </summary>
        public static List<Agreement> GetReclamationAgreements(this ReclamationCostAuthority reclamationCostAuthority)
        {
            return reclamationCostAuthority.AgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationAgreement).ToList();
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(cac => cac.CostAuthorityDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this ReclamationCostAuthority costAuthority)
        {
            return DetailUrlTemplate.ParameterReplace(costAuthority.PrimaryKey);
        }

        public static HtmlString GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(this ReclamationCostAuthority reclamationCostAuthority)
        {
            return new HtmlString(SitkaRoute<CostAuthorityController>.BuildLinkFromExpression(cac => cac.CostAuthorityDetail(reclamationCostAuthority), reclamationCostAuthority.CostAuthorityWorkBreakdownStructure));
        }

        /// <summary>
        /// Get the Projects associated with this Cost Authority through its associated agreements
        /// </summary>
        /// <param name="reclamationCostAuthority"></param>
        /// <returns></returns>
        public static List<Project> GetAssociatedProjects(this ReclamationCostAuthority reclamationCostAuthority)
        {
            var projects = reclamationCostAuthority.ReclamationCostAuthorityProjects.Select(x => x.Project).ToList();
            return projects;
        }

    }
}