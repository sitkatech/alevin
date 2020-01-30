using System.Web.Mvc;
using Antlr.Runtime.Misc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.ActionItem
{
    public abstract class ActionItemsDisplay : TypedWebPartialViewPage<ActionItemsDisplayViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ActionItemsDisplayViewData displayViewData)
        {
            html.RenderRazorSitkaPartial<ActionItemsDisplay, ActionItemsDisplayViewData>(displayViewData);
        }
    }
}