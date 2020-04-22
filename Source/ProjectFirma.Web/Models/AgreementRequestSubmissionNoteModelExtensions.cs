using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ObligationRequestSubmissionNoteModelExtensions
    {
        public static string GetDeleteUrl(this ObligationRequestSubmissionNote obligationRequestSubmissionNote)
        {
            return SitkaRoute<ObligationRequestSubmissionNotesController>.BuildUrlFromExpression(c =>
                c.DeleteReclamationObligationRequestSubmissionNote(obligationRequestSubmissionNote.ObligationRequestSubmissionNoteID));
        }

        public static string GetEditUrl(this ObligationRequestSubmissionNote obligationRequestSubmissionNote)
        {
            return SitkaRoute<ObligationRequestSubmissionNotesController>.BuildUrlFromExpression(c => c.Edit(obligationRequestSubmissionNote.ObligationRequestSubmissionNoteID));
        }
    }
}