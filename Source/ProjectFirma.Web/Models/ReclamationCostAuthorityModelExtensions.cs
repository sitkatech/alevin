﻿using System.Collections.Generic;
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
        public static List<ReclamationAgreement> GetReclamationAgreements(this ReclamationCostAuthority reclamationCostAuthority)
        {
            return reclamationCostAuthority.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationAgreement).ToList();
        }

        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(cac => cac.CostAuthorityDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this ReclamationCostAuthority costAuthority)
        {
            return DetailUrlTemplate.ParameterReplace(costAuthority.PrimaryKey);
        }

        public static string GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(this ReclamationCostAuthority reclamationCostAuthority)
        {
            return SitkaRoute<CostAuthorityController>.BuildLinkFromExpression(cac => cac.CostAuthorityDetail(reclamationCostAuthority), reclamationCostAuthority.CostAuthorityWorkBreakdownStructure);
        }

        /// <summary>
        /// Get the Projects associated with this Cost Authority through its associated agreements
        /// </summary>
        /// <param name="reclamationCostAuthority"></param>
        /// <returns></returns>
        public static List<Project> GetAssociatedProjects(this ReclamationCostAuthority reclamationCostAuthority)
        {
            List<ReclamationAgreement> agreements = reclamationCostAuthority.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationAgreement).ToList();
            List<Project> projects = agreements.SelectMany(a => a.GetAssociatedProjects()).Distinct().ToList();

            return projects;
        }

    }
}