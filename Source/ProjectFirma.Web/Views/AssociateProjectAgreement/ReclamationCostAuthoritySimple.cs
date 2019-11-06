using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AssociateProjectAgreement
{
    public class ReclamationCostAuthoritySimple
    {

        public int ReclamationCostAuthorityID { get; set; }
        public string ReclamationCostAuthorityDisplayName { get; set; }

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
            ReclamationCostAuthorityDisplayName = $"{reclamationCostAuthority.CostAuthorityNumber} - {reclamationCostAuthority.AccountStructureDescription}";
        }
    }
}