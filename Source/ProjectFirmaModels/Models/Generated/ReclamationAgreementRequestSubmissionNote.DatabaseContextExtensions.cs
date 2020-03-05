//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationAgreementRequestSubmissionNote]
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
        public static ReclamationAgreementRequestSubmissionNote GetReclamationAgreementRequestSubmissionNote(this IQueryable<ReclamationAgreementRequestSubmissionNote> reclamationAgreementRequestSubmissionNotes, int reclamationAgreementRequestSubmissionNoteID)
        {
            var reclamationAgreementRequestSubmissionNote = reclamationAgreementRequestSubmissionNotes.SingleOrDefault(x => x.ReclamationAgreementRequestSubmissionNoteID == reclamationAgreementRequestSubmissionNoteID);
            Check.RequireNotNullThrowNotFound(reclamationAgreementRequestSubmissionNote, "ReclamationAgreementRequestSubmissionNote", reclamationAgreementRequestSubmissionNoteID);
            return reclamationAgreementRequestSubmissionNote;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationAgreementRequestSubmissionNote(this IQueryable<ReclamationAgreementRequestSubmissionNote> reclamationAgreementRequestSubmissionNotes, List<int> reclamationAgreementRequestSubmissionNoteIDList)
        {
            if(reclamationAgreementRequestSubmissionNoteIDList.Any())
            {
                reclamationAgreementRequestSubmissionNotes.Where(x => reclamationAgreementRequestSubmissionNoteIDList.Contains(x.ReclamationAgreementRequestSubmissionNoteID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationAgreementRequestSubmissionNote(this IQueryable<ReclamationAgreementRequestSubmissionNote> reclamationAgreementRequestSubmissionNotes, ICollection<ReclamationAgreementRequestSubmissionNote> reclamationAgreementRequestSubmissionNotesToDelete)
        {
            if(reclamationAgreementRequestSubmissionNotesToDelete.Any())
            {
                var reclamationAgreementRequestSubmissionNoteIDList = reclamationAgreementRequestSubmissionNotesToDelete.Select(x => x.ReclamationAgreementRequestSubmissionNoteID).ToList();
                reclamationAgreementRequestSubmissionNotes.Where(x => reclamationAgreementRequestSubmissionNoteIDList.Contains(x.ReclamationAgreementRequestSubmissionNoteID)).Delete();
            }
        }

        public static void DeleteReclamationAgreementRequestSubmissionNote(this IQueryable<ReclamationAgreementRequestSubmissionNote> reclamationAgreementRequestSubmissionNotes, int reclamationAgreementRequestSubmissionNoteID)
        {
            DeleteReclamationAgreementRequestSubmissionNote(reclamationAgreementRequestSubmissionNotes, new List<int> { reclamationAgreementRequestSubmissionNoteID });
        }

        public static void DeleteReclamationAgreementRequestSubmissionNote(this IQueryable<ReclamationAgreementRequestSubmissionNote> reclamationAgreementRequestSubmissionNotes, ReclamationAgreementRequestSubmissionNote reclamationAgreementRequestSubmissionNoteToDelete)
        {
            DeleteReclamationAgreementRequestSubmissionNote(reclamationAgreementRequestSubmissionNotes, new List<ReclamationAgreementRequestSubmissionNote> { reclamationAgreementRequestSubmissionNoteToDelete });
        }
    }
}