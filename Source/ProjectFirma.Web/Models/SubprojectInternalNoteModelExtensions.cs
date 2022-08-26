using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SubprojectInternalNoteModelExtensions
    {
        public static string GetDeleteUrl(this SubprojectInternalNote subprojectInternalNote)
        {
            return SitkaRoute<SubprojectInternalNoteController>.BuildUrlFromExpression(c => c.DeleteSubprojectInternalNote(subprojectInternalNote));
        }

        public static string GetEditUrl(this SubprojectInternalNote subprojectInternalNote)
        {
            return SitkaRoute<SubprojectInternalNoteController>.BuildUrlFromExpression(c => c.Edit(subprojectInternalNote));
        }
    }
}