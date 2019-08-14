using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ReclamationAgreement : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationAgreement: {this.ReclamationAgreementID} - {this.AgreementNumber}";
        }

        /// <summary>
        /// Convenience accessor for Reclamation Cost Authorities
        /// </summary>
        public List<ReclamationCostAuthority> ReclamationCostAuthorities
        {
            get
            {
                return this.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationCostAuthority).ToList();
            }
        }

        /// <summary>
        /// Convenience accessor for *SINGLE* Reclamation Cost Authorities.
        /// Unsure if this is a safe assumption yet. If it is, we don't need ReclamationCostAuthorities above.
        /// </summary>
        public ReclamationCostAuthority ReclamationCostAuthority
        {
            get
            {
                //var blah2 = ReclamationAgreementReclamationCostAuthorities.ToList();

                /*
                var blah = ReclamationCostAuthorities;
                var otherBlah = blah.SingleOrDefault();
                return otherBlah;
                */
                // This crashes: Invalid column name 'ReclamationAgreement_ReclamationAgreementID'
                return this.ReclamationAgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationCostAuthority).SingleOrDefault();
            }
        }


    }
}