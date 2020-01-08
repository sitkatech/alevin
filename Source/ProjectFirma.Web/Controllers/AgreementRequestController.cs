using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Agreement;
using ProjectFirma.Web.Views.AgreementRequest;
using ProjectFirma.Web.Views.ProjectProjectStatus;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AgreementRequestController : FirmaBaseController
    {
        [AgreementRequestViewFeature]
        public ViewResult AgreementRequestIndex()
        {
            return AgreementRequestIndexImpl();
        }

        private ViewResult AgreementRequestIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.AgreementRequestList.GetFirmaPage();
            var viewData = new AgreementRequestIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<AgreementRequestIndex, AgreementRequestIndexViewData>(viewData);
        }

        [AgreementRequestViewFeature]
        public GridJsonNetJObjectResult<ReclamationAgreement> AgreementGridJsonData()
        {
            var gridSpec = new AgreementGridSpec(CurrentFirmaSession);
            var agreements = HttpRequestStorage.DatabaseEntities.ReclamationAgreements.ToList().OrderBy(x => x.AgreementNumber).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ReclamationAgreement>(agreements, gridSpec);
            return gridJsonNetJObjectResult;
        }


        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditAgreementRequestViewModel();
            var projectStatusFirmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
            return ViewEdit(viewModel,  projectStatusFirmaPage);
        }

        private PartialViewResult ViewEdit(EditAgreementRequestViewModel viewModel, FirmaPage firmaPage)
        {
            var projectStatusFirmaPage = firmaPage;
            var allAgreementRequests = ReclamationAgreementRequestStatus.All;
            var viewData = new EditAgreementRequestViewData(projectStatusFirmaPage, CurrentFirmaSession, allAgreementRequests);
            return RazorPartialView<EditAgreementRequest, EditAgreementRequestViewData, EditAgreementRequestViewModel>(viewData, viewModel);
        }


    }
}