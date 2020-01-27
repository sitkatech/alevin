using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ActionItemModelExtensions
    {
        public static string GetDeleteUrl(this ActionItem actionItem)
        {
            return SitkaRoute<ActionItemController>.BuildUrlFromExpression(c => c.Delete(actionItem.ActionItemID));
        }

        public static string GetEditUrl(this ActionItem actionItem)
        {
            return SitkaRoute<ActionItemController>.BuildUrlFromExpression(c => c.Edit(actionItem.ActionItemID));
        }
    }
}