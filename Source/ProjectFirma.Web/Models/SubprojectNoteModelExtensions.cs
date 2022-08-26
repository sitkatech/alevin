using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SubprojectNoteModelExtensions
    {
        public static string GetDeleteUrl(this SubprojectNote projectNote)
        {
            return SitkaRoute<SubprojectNoteController>.BuildUrlFromExpression(c => c.DeleteProjectNote(projectNote.SubprojectNoteID));
        }

        public static string GetEditUrl(this SubprojectNote projectNote)
        {
            return SitkaRoute<SubprojectNoteController>.BuildUrlFromExpression(c => c.Edit(projectNote.SubprojectNoteID));
        }
    }
}