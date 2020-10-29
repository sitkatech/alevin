using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Agreement;
using ProjectFirma.Web.Views.CostAuthority;
using ProjectFirma.Web.Views.Project;
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
            return AgreementViewEdit(viewModel, CurrentFirmaSession);
        }

        [HttpPost]
        [AgreementManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewAgreement(AgreementEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return AgreementViewEdit(viewModel, CurrentFirmaSession);
            }
            var agreement = new Agreement(false, false, viewModel.ContractTypeID.Value);
            viewModel.UpdateModel(agreement, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.Agreements.Add(agreement);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"Agreement {agreement.GetDetailLinkUsingAgreementNumber()} successfully created.");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult AgreementViewEdit(AgreementEditViewModel viewModel, FirmaSession currentFirmaSession)
        {
            /*
            var organizationTypesAsSelectListItems = HttpRequestStorage.DatabaseEntities.OrganizationTypes
                .OrderBy(x => x.OrganizationTypeName)
                .ToSelectListWithEmptyFirstRow(x => x.OrganizationTypeID.ToString(CultureInfo.InvariantCulture),
                    x => x.OrganizationTypeName);
            var activePeople = HttpRequestStorage.DatabaseEntities.People.GetActivePeople();
            if (currentPrimaryContactPerson != null && !activePeople.Contains(currentPrimaryContactPerson))
            {
                activePeople.Add(currentPrimaryContactPerson);
            }
            var people = activePeople.OrderBy(x => x.GetFullNameLastFirst()).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(CultureInfo.InvariantCulture),
                x => x.GetFullNameFirstLastAndOrg());
            var isSitkaAdmin = new SitkaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var userHasAdminPermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            string requestOrganizationChangeUrl = SitkaRoute<HelpController>.BuildUrlFromExpression(x => x.RequestOrganizationNameChange());
            */
            //var viewData = new AgreementEditViewData(organizationTypesAsSelectListItems, people, isInKeystone, requestOrganizationChangeUrl, isSitkaAdmin, userHasAdminPermissions, viewModel.KeystoneOrganizationGuid);

            var viewData = new AgreementEditViewData();
            return RazorPartialView<AgreementEdit, AgreementEditViewData, AgreementEditViewModel>(viewData, viewModel);
        }

        #endregion New/Edit Agreement

    }
}