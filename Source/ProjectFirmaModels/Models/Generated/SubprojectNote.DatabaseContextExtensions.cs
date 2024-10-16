//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectNote]
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
        public static SubprojectNote GetSubprojectNote(this IQueryable<SubprojectNote> subprojectNotes, int subprojectNoteID)
        {
            var subprojectNote = subprojectNotes.SingleOrDefault(x => x.SubprojectNoteID == subprojectNoteID);
            Check.RequireNotNullThrowNotFound(subprojectNote, "SubprojectNote", subprojectNoteID);
            return subprojectNote;
        }

    }
}