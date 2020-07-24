namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class ObligationRequestStatusJson
    {
        public int ReclamationObligationRequestStatusID { get; set; }
        public string ReclamationObligationRequestStatusDisplayName { get; set; }

        public ObligationRequestStatusJson(ProjectFirmaModels.Models.ObligationRequestStatus obligationRequestStatus)
        {
            ReclamationObligationRequestStatusID = obligationRequestStatus.ObligationRequestStatusID;
            ReclamationObligationRequestStatusDisplayName = obligationRequestStatus.ObligationRequestStatusDisplayName;
        }
    }
}