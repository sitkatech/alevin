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

        ///// <summary>
        ///// Convenience accessor for *SINGLE* Reclamation Cost Authorities.
        ///// Unsure if this is a safe assumption yet. If it is, we don't need ReclamationCostAuthorities above.
        ///// </summary>
        //public static ReclamationCostAuthority GetReclamationCostAuthority(this ReclamationAgreement reclamationAgreement)
        //{
        //    //var blah2 = ReclamationAgreementReclamationCostAuthorities.ToList();

        //    /*
        //    var blah = ReclamationCostAuthorities;
        //    var otherBlah = blah.SingleOrDefault();
        //    return otherBlah;
        //    */
        //    // This crashes: Invalid column name 'ReclamationAgreement_ReclamationAgreementID'
        //    return reclamationAgreement.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationCostAuthority)
        //        .SingleOrDefault();
        //}

    }
}