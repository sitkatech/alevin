using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Agreement;
using ProjectFirma.Web.Views.CostAuthority;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirma.Web.Views.Project;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class CostAuthorityController : FirmaBaseController
    {
        [CostAuthorityViewFeature]
        public ViewResult CostAuthorityIndex()
        {
            return CostAuthorityIndexImpl();
        }

        private ViewResult CostAuthorityIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.CostAuthorityList.GetFirmaPage();
            var viewData = new CostAuthorityIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<CostAuthorityIndex, CostAuthorityIndexViewData>(viewData);
        }

        [CostAuthorityViewFeature]
        public GridJsonNetJObjectResult<CostAuthority> CostAuthorityGridJsonData()
        {
            var gridSpec = new CostAuthorityGridSpec(CurrentFirmaSession);
            var CostAuthorities = HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList().OrderBy(x => x.CostAuthorityNumber).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<CostAuthority>(CostAuthorities, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [CostAuthorityViewFeature]
        public ActionResult CostAuthorityDetail(string costAuthorityWorkBreakdownStructureString)
        {
            string correctedCawbsString = CostAuthority.CorrectedCostAuthorityWorkBreakdownStructureString(costAuthorityWorkBreakdownStructureString);
            // If they did enter a CAWBS string we could fix, we redirect permanently in case they bookmark
            if (correctedCawbsString != costAuthorityWorkBreakdownStructureString)
            {
                return RedirectToAction(new SitkaRoute<CostAuthorityController>(pc => pc.CostAuthorityDetail(correctedCawbsString)));
            }
            var costAuthority = HttpRequestStorage.DatabaseEntities.CostAuthorities.SingleOrDefault(ca => ca.CostAuthorityWorkBreakdownStructure == correctedCawbsString);
            Check.EnsureNotNull(costAuthority, $"Could not find Cost Authority with CostAuthorityWorkBreakdownStructure of {correctedCawbsString}");
            var viewData = new CostAuthorityDetailViewData(CurrentFirmaSession, costAuthority);
            return RazorView<CostAuthorityDetail, CostAuthorityDetailViewData>(viewData);
        }

        /*
        [ObligationViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ObligationItemInvoiceGridJsonData(CostAuthorityPrimaryKey costAuthorityPrimaryKey)
        {
            var gridSpec = new ContractualInvoiceGridSpec(CurrentFirmaSession);
            var costAuthority = costAuthorityPrimaryKey.EntityObject;
            var obligationItemBudgets = costAuthority.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }
        */

        [ObligationViewFeature]
        public GridJsonNetJObjectResult<WbsElementObligationItemBudget> ContractualInvoiceGridJsonData(CostAuthorityPrimaryKey costAuthorityPrimaryKey)
        {
            var gridSpec = new ContractualInvoiceGridSpec(CurrentFirmaSession);
            var costAuthority = costAuthorityPrimaryKey.EntityObject;
            var obligationItemBudgets = costAuthority.WbsElementObligationItemBudgets.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<WbsElementObligationItemBudget>(obligationItemBudgets, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [CostAuthorityViewFeature]
        public GridJsonNetJObjectResult<Project> CostAuthorityProjectsGridJsonData(CostAuthorityPrimaryKey costAuthorityPrimaryKey)
        {
            var costAuthority = costAuthorityPrimaryKey.EntityObject;
            var gridSpec = new BasicProjectInfoGridSpec(CurrentFirmaSession, true, costAuthority);
            var projectReclamationAgreements = costAuthority.GetAssociatedProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectReclamationAgreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [CostAuthorityViewFeature]
        public GridJsonNetJObjectResult<Agreement> CostAuthorityAgreementGridJsonData(CostAuthorityPrimaryKey costAuthorityPrimaryKey)
        {
            var gridSpec = new AgreementGridSpec(CurrentFirmaSession);
            var projectReclamationAgreements = costAuthorityPrimaryKey.EntityObject.GetReclamationAgreements();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Agreement>(projectReclamationAgreements, gridSpec);
            return gridJsonNetJObjectResult;
        }
    }
}