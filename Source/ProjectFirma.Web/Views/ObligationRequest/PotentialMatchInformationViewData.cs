using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public enum PotentialMatchDialogMode
    {
        ReadOnlyReview,
        ConfirmWithPostAction
    }

    public class PotentialMatchInformationViewData : FirmaViewData
    {
        public CostAuthorityObligationRequestPotentialObligationNumberMatch PotentialObligationNumberMatch { get; }
        public PotentialMatchDialogMode PotentialMatchDialogMode { get; }

        public PotentialMatchInformationViewData(FirmaSession currentFirmaSession,
            CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey costAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey, 
            PotentialMatchDialogMode potentialMatchDialogMode) : base(currentFirmaSession)
        {
            this.PotentialObligationNumberMatch = costAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey.EntityObject;
            this.PotentialMatchDialogMode = potentialMatchDialogMode;
        }
    }
}