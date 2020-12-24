using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class AgreementModelExtensions
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
            return agreement.AgreementCostAuthorities.Select(rarca => rarca.CostAuthority).ToList();
        }

        /// <summary>
        /// Convenience accessor for Reclamation Cost Authorities.
        /// </summary>
        public static string GetReclamationWorkBreakdownStructuresAsCommaDelimitedString(this Agreement agreement)
        {
            var costAuthorities = agreement.GetReclamationCostAuthorities();
            return string.Join(", ", costAuthorities.Select(ca => ca.CostAuthorityWorkBreakdownStructure));
        }

        public static readonly UrlTemplate<string> DetailUrlTemplate = new UrlTemplate<string>(SitkaRoute<AgreementController>.BuildUrlFromExpression(t => t.AgreementDetail(UrlTemplate.Parameter1String)));
        public static string GetDetailUrl(this Agreement agreement)
        {
            if (agreement == null)
            {
                return null;
            }
            return DetailUrlTemplate.ParameterReplace(agreement.AgreementNumber);
        }

        public static string GetDetailLinkUsingAgreementNumber(this Agreement agreement)
        {
            return SitkaRoute<AgreementController>.BuildLinkFromExpression(c => c.AgreementDetail(agreement.AgreementNumber), agreement.AgreementNumber);
        }

        public static string GetDetailLinkUsingFullDisplayName(this Agreement agreement)
        {
            return SitkaRoute<AgreementController>.BuildLinkFromExpression(c => c.AgreementDetail(agreement.AgreementNumber), agreement.GetFullDisplayName());
        }

        public static readonly UrlTemplate<int> DeleteAgreementUrlTemplate = new UrlTemplate<int>(SitkaRoute<AgreementController>.BuildUrlFromExpression(t => t.DeleteAgreement(UrlTemplate.Parameter1Int)));
        public static string GetDeleteAgreementUrl(this Agreement agreement)
        {
            return DeleteAgreementUrlTemplate.ParameterReplace(agreement.AgreementID);
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

        public static bool AgreementHasProjectAssociations(this Agreement agreement)
        {
            bool hasProjectAssociations = GetAssociatedProjects(agreement).Any();
            return hasProjectAssociations;
        }

        public static bool AgreementHasCostAuthorityAssociations(this Agreement agreement)
        {
            bool hasCostAuthorityAssociations = agreement.GetReclamationCostAuthorities().Any();
            return hasCostAuthorityAssociations;
        }

        public static bool AgreementHasReclamationStagingCostAuthorityAgreementAssociations(this Agreement agreement)
        {
            bool hasReclamationStagingCostAuthorityAgreementAssociations = agreement.ReclamationStagingCostAuthorityAgreements.Any();
            return hasReclamationStagingCostAuthorityAgreementAssociations;
        }

        /// <summary>
        /// Can this Agreement be safely deleted?
        /// </summary>
        /// <param name="agreement"></param>
        /// <returns></returns>
        public static bool AgreementCanBeDeleted(this Agreement agreement)
        {
            bool noCostAuthorityAssociations = !AgreementHasCostAuthorityAssociations(agreement);
            bool noProjectAssociations = !AgreementHasProjectAssociations(agreement);
            bool noReclamationStagingCostAuthorityAgreementAssociations = !AgreementHasReclamationStagingCostAuthorityAgreementAssociations(agreement);

            bool noBlockingAssociations = noCostAuthorityAssociations && noProjectAssociations && noReclamationStagingCostAuthorityAgreementAssociations;

            return noBlockingAssociations;
        }

    }
}