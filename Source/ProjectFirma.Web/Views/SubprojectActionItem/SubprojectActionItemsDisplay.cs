using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.SubprojectActionItem
{
    public abstract class SubprojectActionItemsDisplay : TypedWebPartialViewPage<SubprojectActionItemsDisplayViewData>
    {
        public static void RenderPartialView(HtmlHelper html, SubprojectActionItemsDisplayViewData displayViewData)
        {
            html.RenderRazorSitkaPartial<SubprojectActionItemsDisplay, SubprojectActionItemsDisplayViewData>(displayViewData);
        }
    }
}