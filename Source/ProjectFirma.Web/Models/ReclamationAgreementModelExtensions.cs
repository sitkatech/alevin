using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReclamationAgreementModelExtensions
    {
        /// <summary>
        /// Convenience accessor for *SINGLE* Reclamation Cost Authorities.
        /// Unsure if this is a safe assumption yet. If it is, we don't need ReclamationCostAuthorities above.
        /// </summary>
        public static ReclamationCostAuthority GetReclamationCostAuthority(this ReclamationAgreement reclamationAgreement)
        {
            //var blah2 = ReclamationAgreementReclamationCostAuthorities.ToList();

            /*
            var blah = ReclamationCostAuthorities;
            var otherBlah = blah.SingleOrDefault();
            return otherBlah;
            */
            // This crashes: Invalid column name 'ReclamationAgreement_ReclamationAgreementID'
            return reclamationAgreement.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationCostAuthority)
                .SingleOrDefault();
        }

    }
}