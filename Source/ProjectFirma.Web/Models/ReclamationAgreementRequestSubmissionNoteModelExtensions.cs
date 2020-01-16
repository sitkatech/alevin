using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReclamationAgreementRequestSubmissionNoteModelExtensions
    {
        public static string GetDeleteUrl(this ReclamationAgreementRequestSubmissionNote reclamationAgreementRequestSubmissionNote)
        {
            return SitkaRoute<AgreementRequestSubmissionNotesController>.BuildUrlFromExpression(c =>
                c.DeleteReclamationAgreementRequestSubmissionNote(reclamationAgreementRequestSubmissionNote.ReclamationAgreementRequestSubmissionNoteID));
        }

        public static string GetEditUrl(this ReclamationAgreementRequestSubmissionNote reclamationAgreementRequestSubmissionNote)
        {
            return SitkaRoute<AgreementRequestSubmissionNotesController>.BuildUrlFromExpression(c => c.Edit(reclamationAgreementRequestSubmissionNote.ReclamationAgreementRequestSubmissionNoteID));
        }
    }
}