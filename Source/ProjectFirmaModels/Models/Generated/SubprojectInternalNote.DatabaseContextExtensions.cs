//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectInternalNote]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SubprojectInternalNote GetSubprojectInternalNote(this IQueryable<SubprojectInternalNote> subprojectInternalNotes, int subprojectInternalNoteID)
        {
            var subprojectInternalNote = subprojectInternalNotes.SingleOrDefault(x => x.SubprojectInternalNoteID == subprojectInternalNoteID);
            Check.RequireNotNullThrowNotFound(subprojectInternalNote, "SubprojectInternalNote", subprojectInternalNoteID);
            return subprojectInternalNote;
        }

    }
}