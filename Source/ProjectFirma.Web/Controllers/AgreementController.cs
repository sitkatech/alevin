using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Agreement;
using ProjectFirma.Web.Views.CostAuthority;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AgreementController : FirmaBaseController
    {
        [AgreementViewFeature]
        public ViewResult AgreementIndex()
        {
            return AgreementIndexImpl();
        }

        private ViewResult AgreementIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.AgreementList.GetFirmaPage();
            var viewData = new AgreementIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<AgreementIndex, AgreementIndexViewData>(viewData);
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<Agreement> AgreementGridJsonData()
        {
            var gridSpec = new AgreementGridSpec(CurrentFirmaSession);
            var agreements = HttpRequestStorage.DatabaseEntities.Agreements.ToList().OrderBy(x => x.AgreementNumber).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Agreement>(agreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<Agreement> AgreementGridForOrganizationJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var gridSpec = new AgreementGridSpec(CurrentFirmaSession);
            var agreementsForOrganization = organization.Agreements.ToList().OrderBy(x => x.AgreementNumber).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Agreement>(agreementsForOrganization, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AgreementViewFeature]
        public ActionResult AgreementDetail(string agreementNumber)
        {
            // If just a pure int, likely an OLD URL where we just took AgreementID.
            if (int.TryParse(agreementNumber, out var possibleAgreementID))
            {
                var possibleAgreement = HttpRequestStorage.DatabaseEntities.Agreements.SingleOrDefault(a => a.AgreementID == possibleAgreementID);
                if (possibleAgreement != null)
                {
                    // We want this to be a permanent redirect since Google is the one hitting us with these old IDs.
                    return RedirectToActionWithPermanentRedirect(new SitkaRoute<AgreementController>(pc => pc.AgreementDetail(possibleAgreement.AgreementNumber)));
                }
            }

            var agreement = HttpRequestStorage.DatabaseEntities.Agreements.SingleOrDefault(a => a.AgreementNumber == agreementNumber);
            Check.EnsureNotNull(agreement, $"Agreement with Agreement Number {agreementNumber} not found!");
            var viewData = new AgreementDetailViewData(CurrentFirmaSession, agreement);
            return RazorView<AgreementDetail, AgreementDetailViewData>(viewData);
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<Project> AgreementProjectsGridJsonData(AgreementPrimaryKey agreementPrimaryKey)
        {
            var reclamationAgreement = agreementPrimaryKey.EntityObject;
            var gridSpec = new BasicProjectInfoGridSpec(CurrentFirmaSession, true, reclamationAgreement);
            //var projectTaxonomyBranches = taxonomyBranchPrimaryKey.EntityObject.GetAssociatedProjects(CurrentPerson);
            var projectReclamationAgreements = reclamationAgreement.GetAssociatedProjects();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectReclamationAgreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [AgreementViewFeature]
        public GridJsonNetJObjectResult<CostAuthority> AgreementCostAuthorityGridJsonData(AgreementPrimaryKey agreementPrimaryKey)
        {
            var gridSpec = new BasicCostAuthorityGridSpec(CurrentPerson);
            var projectReclamationAgreements = agreementPrimaryKey.EntityObject.GetReclamationCostAuthorities();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<CostAuthority>(projectReclamationAgreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        #region New/Edit Agreement

        [HttpGet]
        [AgreementManageFeature]
        public PartialViewResult NewAgreement()
        {
            var viewModel = new AgreementEditViewModel();
            return AgreementViewEdit(viewModel, CurrentFirmaSession, null);
        }

        [HttpPost]
        [AgreementManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewAgreement(AgreementEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return AgreementViewEdit(viewModel, CurrentFirmaSession, null);
            }

            var agreement = new Agreement(false, false, viewModel.ContractTypeID.Value);
            viewModel.UpdateModelAndSaveChanges(agreement, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Agreement {agreement.GetDetailLinkUsingAgreementNumber()} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [AgreementManageFeature]
        public PartialViewResult EditBasics(AgreementPrimaryKey agreementPrimaryKey)
        {
            var agreement = agreementPrimaryKey.EntityObject;

            var viewModel = new AgreementEditViewModel(agreement);
            return AgreementViewEdit(viewModel, CurrentFirmaSession, agreement);
        }

        [HttpPost]
        [AgreementManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBasics(AgreementPrimaryKey agreementPrimaryKey, AgreementEditViewModel viewModel)
        {
            var agreement = agreementPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return AgreementViewEdit(viewModel, CurrentFirmaSession, agreement);
            }

            viewModel.UpdateModelAndSaveChanges(agreement, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Agreement {agreement.GetDetailLinkUsingAgreementNumber()} saved.");

            // They may have edited the Agreement Number, so we need to redirect in case this has happened.
            string redirectUrl = SitkaRoute<AgreementController>.BuildAbsoluteUrlHttpsFromExpression(x => x.AgreementDetail(viewModel.AgreementNumber));
            return new ModalDialogFormJsonResult(redirectUrl);
        }

        private PartialViewResult AgreementViewEdit(AgreementEditViewModel viewModel, FirmaSession currentFirmaSession, Agreement optionalAgreement)
        {
            var viewData = new AgreementEditViewData(optionalAgreement);
            return RazorPartialView<AgreementEdit, AgreementEditViewData, AgreementEditViewModel>(viewData, viewModel);
        }

        #endregion New/Edit Agreement

        #region Delete Agreement

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteAgreement(AgreementPrimaryKey agreementPrimaryKey)
        {
            var agreement = agreementPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(agreement.AgreementID);
            return ViewDeleteAgreement(agreement, viewModel);
        }

        private PartialViewResult ViewDeleteAgreement(Agreement agreement, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage = $"Are you sure you want to delete Agreement Number {agreement.AgreementNumber}?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteAgreement(AgreementPrimaryKey agreementPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var agreement = agreementPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteAgreement(agreement, viewModel);
            }

            Check.Ensure(agreement.AgreementCanBeDeleted(), $"Agreement {agreement.AgreementNumber} can't be deleted.");

            // Unhook ObligationNumber from the Reclamation.Agreement object we are deleting
            foreach (var obligationNumber in agreement.ObligationNumbersWhereYouAreTheReclamationAgreement)
            {
                obligationNumber.ReclamationAgreement = null;
                obligationNumber.ReclamationAgreementID = null;
            }
            // We do NOT want to DeleteFull here, since we never want to delete when the Agreement has associations with any
            // other objects.
            string agreementNumber = agreement.AgreementNumber;
            agreement.Delete(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay($"Successfully deleted Agreement \"{agreementNumber}\".");
            return new ModalDialogFormJsonResult();
        }

        #endregion Delete Agreement

    }
}