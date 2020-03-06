//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementRequestSubmissionNote]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static AgreementRequestSubmissionNote GetAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, int reclamationAgreementRequestSubmissionNoteID)
        {
            var agreementRequestSubmissionNote = agreementRequestSubmissionNotes.SingleOrDefault(x => x.ReclamationAgreementRequestSubmissionNoteID == reclamationAgreementRequestSubmissionNoteID);
            Check.RequireNotNullThrowNotFound(agreementRequestSubmissionNote, "AgreementRequestSubmissionNote", reclamationAgreementRequestSubmissionNoteID);
            return agreementRequestSubmissionNote;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, List<int> reclamationAgreementRequestSubmissionNoteIDList)
        {
            if(reclamationAgreementRequestSubmissionNoteIDList.Any())
            {
                agreementRequestSubmissionNotes.Where(x => reclamationAgreementRequestSubmissionNoteIDList.Contains(x.ReclamationAgreementRequestSubmissionNoteID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, ICollection<AgreementRequestSubmissionNote> agreementRequestSubmissionNotesToDelete)
        {
            if(agreementRequestSubmissionNotesToDelete.Any())
            {
                var reclamationAgreementRequestSubmissionNoteIDList = agreementRequestSubmissionNotesToDelete.Select(x => x.ReclamationAgreementRequestSubmissionNoteID).ToList();
                agreementRequestSubmissionNotes.Where(x => reclamationAgreementRequestSubmissionNoteIDList.Contains(x.ReclamationAgreementRequestSubmissionNoteID)).Delete();
            }
        }

        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, int reclamationAgreementRequestSubmissionNoteID)
        {
            DeleteAgreementRequestSubmissionNote(agreementRequestSubmissionNotes, new List<int> { reclamationAgreementRequestSubmissionNoteID });
        }

        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, AgreementRequestSubmissionNote agreementRequestSubmissionNoteToDelete)
        {
            DeleteAgreementRequestSubmissionNote(agreementRequestSubmissionNotes, new List<AgreementRequestSubmissionNote> { agreementRequestSubmissionNoteToDelete });
        }
    }
}