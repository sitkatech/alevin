using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationItemBudgetIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData ObligationIndexViewPageContentViewData { get; }
        public ObligationItemBudgetGridSpec ObligationItemBudgetGridSpec { get; }
        public string ObligationItemBudgetGridName { get; }
        public string ObligationItemBudgetGridDataUrl { get; }

        //public ObligationItemBudgetIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        public ObligationItemBudgetIndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Obligation Item Budgets";

            ObligationItemBudgetGridSpec = new ObligationItemBudgetGridSpec(currentFirmaSession);



            ObligationItemBudgetGridName = "obligationItemBudgetGrid";
            ObligationItemBudgetGridDataUrl = SitkaRoute<ObligationController>.BuildUrlFromExpression(c => c.ObligationItemBudgetIndexGridJsonData());
            //ObligationIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



