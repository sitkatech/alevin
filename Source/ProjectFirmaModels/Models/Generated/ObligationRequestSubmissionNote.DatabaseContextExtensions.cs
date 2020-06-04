//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequestSubmissionNote]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ObligationRequestSubmissionNote GetObligationRequestSubmissionNote(this IQueryable<ObligationRequestSubmissionNote> obligationRequestSubmissionNotes, int obligationRequestSubmissionNoteID)
        {
            var obligationRequestSubmissionNote = obligationRequestSubmissionNotes.SingleOrDefault(x => x.ObligationRequestSubmissionNoteID == obligationRequestSubmissionNoteID);
            Check.RequireNotNullThrowNotFound(obligationRequestSubmissionNote, "ObligationRequestSubmissionNote", obligationRequestSubmissionNoteID);
            return obligationRequestSubmissionNote;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteObligationRequestSubmissionNote(this IQueryable<ObligationRequestSubmissionNote> obligationRequestSubmissionNotes, List<int> obligationRequestSubmissionNoteIDList)
        {
            if(obligationRequestSubmissionNoteIDList.Any())
            {
                obligationRequestSubmissionNotes.Where(x => obligationRequestSubmissionNoteIDList.Contains(x.ObligationRequestSubmissionNoteID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteObligationRequestSubmissionNote(this IQueryable<ObligationRequestSubmissionNote> obligationRequestSubmissionNotes, ICollection<ObligationRequestSubmissionNote> obligationRequestSubmissionNotesToDelete)
        {
            if(obligationRequestSubmissionNotesToDelete.Any())
            {
                var obligationRequestSubmissionNoteIDList = obligationRequestSubmissionNotesToDelete.Select(x => x.ObligationRequestSubmissionNoteID).ToList();
                obligationRequestSubmissionNotes.Where(x => obligationRequestSubmissionNoteIDList.Contains(x.ObligationRequestSubmissionNoteID)).Delete();
            }
        }

        public static void DeleteObligationRequestSubmissionNote(this IQueryable<ObligationRequestSubmissionNote> obligationRequestSubmissionNotes, int obligationRequestSubmissionNoteID)
        {
            DeleteObligationRequestSubmissionNote(obligationRequestSubmissionNotes, new List<int> { obligationRequestSubmissionNoteID });
        }

        public static void DeleteObligationRequestSubmissionNote(this IQueryable<ObligationRequestSubmissionNote> obligationRequestSubmissionNotes, ObligationRequestSubmissionNote obligationRequestSubmissionNoteToDelete)
        {
            DeleteObligationRequestSubmissionNote(obligationRequestSubmissionNotes, new List<ObligationRequestSubmissionNote> { obligationRequestSubmissionNoteToDelete });
        }
    }
}