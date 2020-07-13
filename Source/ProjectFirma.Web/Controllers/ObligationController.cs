using System.Linq;
using System.Web.Mvc;
using ApprovalUtilities.Utilities;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ObligationController : FirmaBaseController
    {

        [ObligationViewFeature]
        public ViewResult ObligationIndex()
        {
            return ObligationIndexImpl();
        }

        private ViewResult ObligationIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.ObligationList.GetFirmaPage();
            var viewData = new ObligationIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<ObligationIndex, ObligationIndexViewData>(viewData);
        }

        [ObligationViewFeature]
        public ViewResult ContractualInvoiceIndex()
        {
            //var firmaPage = FirmaPageTypeEnum.ObligationList.GetFirmaPage();
            var viewData = new ContractualInvoiceIndexViewData(CurrentFirmaSession);//, firmaPage);
            return RazorView<ContractualInvoiceIndex, ContractualInvoiceIndexViewData>(viewData);
        }

        [ObligationViewFeature]
        public GridJsonNetJObjectResult<ObligationNumber> ObligationNumberGridJsonData()
        {
            var gridSpec = new ObligationGridSpec(CurrentFirmaSession);
            var obligations = HttpRequestStorage.DatabaseEntities.ObligationNumbers.ToList().OrderBy(x => x.ObligationNumberKey).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ObligationNumber>(obligations, gridSpec);
            return gridJsonNetJObjectResult;
        }

        /*
        [ObligationViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemInvoice> ObligationItemInvoiceGridJsonData(ObligationNumberPrimaryKey obligationNumberPrimaryKey)
        {
            var gridSpec = new ContractualInvoiceGridSpec(CurrentFirmaSession);
            var obligationNumber = obligationNumberPrimaryKey.EntityObject;
            var obligationItems = obligationNumber.ObligationItems;
            var obligationItemInvoices = obligationItems.GetWbsElementObligationItemInvoicesSorted();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemInvoice>(obligationItemInvoices, gridSpec);
            return gridJsonNetJObjectResult;
        }
        */

        [ObligationViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ContractualObligationByObligationNumberGridJsonData(ObligationNumberPrimaryKey obligationNumberPrimaryKey)
        {
            var gridSpec = new ContractualInvoiceGridSpec(CurrentFirmaSession);
            var obligationNumber = obligationNumberPrimaryKey.EntityObject;
            var obligationItems = obligationNumber.ObligationItems;
            var obligationItemBudgets = obligationItems.GetWbsElementObligationItemBudgetsSorted();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ObligationViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ContractualObligationByObligationItemGridJsonData(ObligationItemPrimaryKey obligationItemPrimaryKey)
        {
            var gridSpec = new ContractualInvoiceGridSpec(CurrentFirmaSession);
            var obligationItem = obligationItemPrimaryKey.EntityObject;
            var obligationItemBudgets = obligationItem.GetWbsElementObligationItemBudgetsSorted();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }




        [ObligationViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ContractualObligationIndexGridJsonData()
        {
            var gridSpec = new ContractualInvoiceGridSpec(CurrentFirmaSession);
            var obligationItemBudgets = HttpRequestStorage.DatabaseEntities.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }


        /*
        [ObligationViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ObligationItemBudgetIndexGridJsonData()
        {
            var gridSpec = new ObligationItemBudgetGridSpec(CurrentFirmaSession);
            var obligationItemBudgets = HttpRequestStorage.DatabaseEntities.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }
        */

        [ObligationViewFeature]
        public ViewResult ObligationDetail(string obligationNumber)
        {
            var obligation = HttpRequestStorage.DatabaseEntities.ObligationNumbers.SingleOrDefault(ob => ob.ObligationNumberKey == obligationNumber);
            Check.EnsureNotNull(obligation, $"Obligation Number {obligationNumber} Not found");
            var viewData = new ObligationDetailViewData(CurrentFirmaSession, obligation);
            return RazorView<ObligationDetail, ObligationDetailViewData>(viewData);
        }



    }
}
