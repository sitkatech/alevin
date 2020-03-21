using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Fund;
using ProjectFirmaModels.Models;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Obligation;

namespace ProjectFirma.Web.Controllers
{
    public class FundController : FirmaBaseController
    {

        [FundViewFeature]
        public ViewResult FundIndex()
        {
            return FundIndexImpl();
        }

        private ViewResult FundIndexImpl()
        {
            var viewData = new FundIndexViewData(CurrentFirmaSession);
            return RazorView<FundIndex, FundIndexViewData>(viewData);
        }

        [FundViewFeature]
        public GridJsonNetJObjectResult<Fund> FundGridJsonData()
        {
            var gridSpec = new FundGridSpec(CurrentFirmaSession);
            var Funds = HttpRequestStorage.DatabaseEntities.Funds.ToList().OrderBy(x => x.ReclamationFundNumber).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Fund>(Funds, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [FundViewFeature]
        public ViewResult FundDetail(FundPrimaryKey fundPrimaryKey)
        {
            var fund = fundPrimaryKey.EntityObject;
            var viewData = new FundDetailViewData(CurrentFirmaSession, fund);
            return RazorView<FundDetail, FundDetailViewData>(viewData);
        }


        [FundViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ObligationItemBudgetGridOnFundDetailJsonData(FundPrimaryKey fundPrimaryKey)
        {
            var gridSpec = new ObligationItemBudgetGridSpec(CurrentFirmaSession);
            var fund = fundPrimaryKey.EntityObject;
            var obligationItemBudgets = fund.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [FundViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ObligationItemInvoiceGridOnFundDetailJsonData(FundPrimaryKey fundPrimaryKey)
        {
            var gridSpec = new ObligationItemBudgetGridSpec(CurrentFirmaSession);
            var fund = fundPrimaryKey.EntityObject;
            var obligationItemBudgets = fund.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}