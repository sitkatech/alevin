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
        public static AgreementRequestSubmissionNote GetAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, int agreementRequestSubmissionNoteID)
        {
            var agreementRequestSubmissionNote = agreementRequestSubmissionNotes.SingleOrDefault(x => x.AgreementRequestSubmissionNoteID == agreementRequestSubmissionNoteID);
            Check.RequireNotNullThrowNotFound(agreementRequestSubmissionNote, "AgreementRequestSubmissionNote", agreementRequestSubmissionNoteID);
            return agreementRequestSubmissionNote;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, List<int> agreementRequestSubmissionNoteIDList)
        {
            if(agreementRequestSubmissionNoteIDList.Any())
            {
                agreementRequestSubmissionNotes.Where(x => agreementRequestSubmissionNoteIDList.Contains(x.AgreementRequestSubmissionNoteID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, ICollection<AgreementRequestSubmissionNote> agreementRequestSubmissionNotesToDelete)
        {
            if(agreementRequestSubmissionNotesToDelete.Any())
            {
                var agreementRequestSubmissionNoteIDList = agreementRequestSubmissionNotesToDelete.Select(x => x.AgreementRequestSubmissionNoteID).ToList();
                agreementRequestSubmissionNotes.Where(x => agreementRequestSubmissionNoteIDList.Contains(x.AgreementRequestSubmissionNoteID)).Delete();
            }
        }

        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, int agreementRequestSubmissionNoteID)
        {
            DeleteAgreementRequestSubmissionNote(agreementRequestSubmissionNotes, new List<int> { agreementRequestSubmissionNoteID });
        }

        public static void DeleteAgreementRequestSubmissionNote(this IQueryable<AgreementRequestSubmissionNote> agreementRequestSubmissionNotes, AgreementRequestSubmissionNote agreementRequestSubmissionNoteToDelete)
        {
            DeleteAgreementRequestSubmissionNote(agreementRequestSubmissionNotes, new List<AgreementRequestSubmissionNote> { agreementRequestSubmissionNoteToDelete });
        }
    }
}