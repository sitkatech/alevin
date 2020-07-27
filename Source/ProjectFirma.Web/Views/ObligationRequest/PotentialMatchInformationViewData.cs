using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class PotentialMatchInformationViewData : FirmaViewData
    {
        public CostAuthorityObligationRequestPotentialObligationNumberMatch PotentialObligationNumberMatch;

        public PotentialMatchInformationViewData(FirmaSession currentFirmaSession,
            CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey
                costAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey) : base(currentFirmaSession)
        {
            PotentialObligationNumberMatch = costAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey.EntityObject;
        }
    }
}