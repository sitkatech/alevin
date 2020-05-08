using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.PnBudget;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class PnBudgetController : FirmaBaseController
    {
        [PnBudgetViewFeature]
        public ViewResult PnBudgetIndex()
        {
            return PnBudgetIndexImpl();
        }

        private ViewResult PnBudgetIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.PnBudgetList.GetFirmaPage();
            var viewData = new PnBudgetIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<PnBudgetIndex, PnBudgetIndexViewData>(viewData);
        }

        [PnBudgetViewFeature]
        public GridJsonNetJObjectResult<WbsElementPnBudget> PnBudgetNumberGridJsonData()
        {
            var gridSpec = new PnBudgetGridSpec(CurrentFirmaSession);
            var pnBudgets = HttpRequestStorage.DatabaseEntities.WbsElementPnBudgets.ToList().OrderBy(x => x.WbsElementPnBudgetID).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementPnBudget>(pnBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}