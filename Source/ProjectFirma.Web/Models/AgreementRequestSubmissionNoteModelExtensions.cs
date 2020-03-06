using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class AgreementRequestSubmissionNoteModelExtensions
    {
        public static string GetDeleteUrl(this AgreementRequestSubmissionNote agreementRequestSubmissionNote)
        {
            return SitkaRoute<AgreementRequestSubmissionNotesController>.BuildUrlFromExpression(c =>
                c.DeleteReclamationAgreementRequestSubmissionNote(agreementRequestSubmissionNote.AgreementRequestSubmissionNoteID));
        }

        public static string GetEditUrl(this AgreementRequestSubmissionNote agreementRequestSubmissionNote)
        {
            return SitkaRoute<AgreementRequestSubmissionNotesController>.BuildUrlFromExpression(c => c.Edit(agreementRequestSubmissionNote.AgreementRequestSubmissionNoteID));
        }
    }
}