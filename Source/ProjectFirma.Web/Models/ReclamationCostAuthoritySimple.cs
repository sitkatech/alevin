using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ReclamationCostAuthoritySimple
    {

        public int ReclamationCostAuthorityID { get; set; }
        public string ReclamationCostAuthorityDisplayName { get; set; }
        public List<ReclamationAgreementSimple> ReclamationCostAuthorityAgreementSimplesList { get; set; }
        public int CountOfRelatedAgreements { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReclamationCostAuthoritySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ReclamationCostAuthoritySimple(ReclamationCostAuthority reclamationCostAuthority)
            : this()
        {
            ReclamationCostAuthorityID = reclamationCostAuthority.ReclamationCostAuthorityID;
            ReclamationCostAuthorityAgreementSimplesList = reclamationCostAuthority.ReclamationAgreementReclamationCostAuthorities.Select(x => new ReclamationAgreementSimple(x.ReclamationAgreement)).ToList();
            ReclamationCostAuthorityDisplayName = $"{reclamationCostAuthority.CostAuthorityWorkBreakdownStructure} - {reclamationCostAuthority.AccountStructureDescription}";
            CountOfRelatedAgreements = ReclamationCostAuthorityAgreementSimplesList.Count;
        }
    }
}