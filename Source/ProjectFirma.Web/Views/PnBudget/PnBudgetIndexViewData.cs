using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PnBudget
{
    public class PnBudgetIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData PnBudgetIndexViewPageContentViewData { get; }
        public PnBudgetGridSpec PnBudgetGridSpec { get; }
        public string PnBudgetGridName { get; }
        public string PnBudgetGridDataUrl { get; }

        public PnBudgetIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "PnBudgets";

            PnBudgetGridSpec = new PnBudgetGridSpec(currentFirmaSession);

            PnBudgetGridName = "PnBudgetsGrid";
            PnBudgetGridDataUrl = SitkaRoute<PnBudgetController>.BuildUrlFromExpression(c => c.PnBudgetNumberGridJsonData());
            PnBudgetIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}