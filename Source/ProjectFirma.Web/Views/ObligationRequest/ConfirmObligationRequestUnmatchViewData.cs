using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class ConfirmObligationRequestUnmatchViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.ObligationRequest ObligationRequest { get; }

        public ConfirmObligationRequestUnmatchViewData(FirmaSession currentFirmaSession,
                                                       ProjectFirmaModels.Models.ObligationRequest obligationRequest) : base(currentFirmaSession)
        {
            this.ObligationRequest = obligationRequest;
        }
    }
}