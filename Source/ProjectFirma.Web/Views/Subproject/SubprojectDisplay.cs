using System.Web.Mvc;
using Antlr.Runtime.Misc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;


namespace ProjectFirma.Web.Views.Subproject
{
    public abstract class SubprojectDisplay : TypedWebPartialViewPage<SubprojectDisplayViewData>
    {
        public static void RenderPartialView(HtmlHelper html, SubprojectDisplayViewData displayViewData)
        {
            html.RenderRazorSitkaPartial<SubprojectDisplay, SubprojectDisplayViewData>(displayViewData);
        }
    }
}