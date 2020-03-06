using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApprovalUtilities.Utilities;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.AgreementRequest;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AgreementRequestController : FirmaBaseController
    {
        [AgreementRequestIndexViewFeature]
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

        [AgreementRequestIndexViewFeature]
        public GridJsonNetJObjectResult<AgreementRequest> AgreementRequestGridJsonData()
        {
            var gridSpec = new AgreementRequestGridSpec(CurrentFirmaSession);
            var agreements = HttpRequestStorage.DatabaseEntities.AgreementRequests.ToList().OrderBy(x => x.AgreementRequestID).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<AgreementRequest>(agreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult EditCostAuthorityAgreementRequest(CostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey)
        {
            var costAuthorityAgreementRequest = reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditCostAuthorityAgreementRequestViewModel(costAuthorityAgreementRequest);
            var projectStatusFirmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
            return ViewEditCostAuthorityAgreementRequest(reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject,viewModel, projectStatusFirmaPage);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditCostAuthorityAgreementRequest(CostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey, EditCostAuthorityAgreementRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
                return ViewEditCostAuthorityAgreementRequest(reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject, viewModel, firmaPage);
            }
            viewModel.UpdateModel(reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject, CurrentFirmaSession);
           
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditCostAuthorityAgreementRequest(CostAuthorityAgreementRequest costAuthorityAgreementRequest, EditCostAuthorityAgreementRequestViewModel viewModel, FirmaPage firmaPage)
        {
            var projectStatusFirmaPage = firmaPage;
            var viewData = new EditCostAuthorityAgreementRequestViewData(projectStatusFirmaPage, CurrentFirmaSession, costAuthorityAgreementRequest.AgreementRequest);
            return RazorPartialView<EditCostAuthorityAgreementRequest, EditCostAuthorityAgreementRequestViewData, EditCostAuthorityAgreementRequestViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditAgreementRequestViewModel();
            var projectStatusFirmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
            return ViewEdit(viewModel,  projectStatusFirmaPage);
        }

        private PartialViewResult ViewEdit(EditAgreementRequestViewModel viewModel, FirmaPage firmaPage)
        {
            var projectStatusFirmaPage = firmaPage;
            var allAgreements = HttpRequestStorage.DatabaseEntities.Agreements.ToList();
            var allContractTypes = HttpRequestStorage.DatabaseEntities.ContractTypes.ToList();
            var allRequestStatuses = AgreementRequestStatus.All;
            var allFundingPriorities = AgreementRequestFundingPriority.All;
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList();
            var viewData = new EditAgreementRequestViewData(projectStatusFirmaPage, CurrentFirmaSession, allAgreements,allContractTypes, allRequestStatuses, allFundingPriorities, allOrganizations, allPeople );
            return RazorPartialView<EditAgreementRequest, EditAgreementRequestViewData, EditAgreementRequestViewModel>(viewData, viewModel);
        }

       
        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult EditCostAuthorityAgreementRequests(AgreementRequestPrimaryKey reclamationAgreementRequestPrimaryKey)
        {
            var reclamationAgreementRequest = reclamationAgreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditCostAuthorityAgreementRequestsViewModel(reclamationAgreementRequest);
            var firmaPage = FirmaPageTypeEnum.AddCostAuthorityToAgreementRequest.GetFirmaPage();
            return ViewEditCostAuthorityAgreementRequests(reclamationAgreementRequest, viewModel, firmaPage );
        }

        private PartialViewResult ViewEditCostAuthorityAgreementRequests(AgreementRequest agreementRequest, EditCostAuthorityAgreementRequestsViewModel viewModel, FirmaPage firmaPage)
        {
            var allCostAuthorities= HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList();
            var viewData = new EditCostAuthorityAgreementRequestsViewData(firmaPage, CurrentFirmaSession, allCostAuthorities, agreementRequest);
            return RazorPartialView<EditCostAuthorityAgreementRequests, EditCostAuthorityAgreementRequestsViewData, EditCostAuthorityAgreementRequestsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditCostAuthorityAgreementRequests(AgreementRequestPrimaryKey reclamationAgreementRequestPrimaryKey, EditCostAuthorityAgreementRequestsViewModel viewModel)
        {
            var reclamationAgreementRequest = reclamationAgreementRequestPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.AddCostAuthorityToAgreementRequest.GetFirmaPage();
                return ViewEditCostAuthorityAgreementRequests(reclamationAgreementRequest,viewModel, firmaPage);
            }

            var listOfCostAuthorityIDs = viewModel.CostAuthorityJsonList.Select(x => x.ReclamationCostAuthorityID).ToList();
            var existingCostAuthorityAgreementRequests = reclamationAgreementRequest.CostAuthorityAgreementRequests;
            
            foreach (var costAuthorityID in listOfCostAuthorityIDs)
            {
                var costAuthorityJson =
                    viewModel.CostAuthorityJsonList.Single(x => x.ReclamationCostAuthorityID == costAuthorityID);
                if (!existingCostAuthorityAgreementRequests.Select(x => x.CostAuthorityID).Contains(costAuthorityID))
                {
                    var newCostAuthorityReclamationAgreement =
                        new CostAuthorityAgreementRequest(costAuthorityID,reclamationAgreementRequest.AgreementRequestID)
                        {
                            ProjectedObligation = costAuthorityJson.ProjectedObligation
                            , ReclamationCostAuthorityAgreementRequestNote = costAuthorityJson.Note
                        };
                    reclamationAgreementRequest.CostAuthorityAgreementRequests.Add(newCostAuthorityReclamationAgreement);
                }
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }


        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditAgreementRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
                return ViewEdit(viewModel, firmaPage);
            }
            return MakeTheNewAgreementRequest(viewModel);
        }

        private ActionResult MakeTheNewAgreementRequest(EditAgreementRequestViewModel viewModel)
        {
            var contractType = HttpRequestStorage.DatabaseEntities.ContractTypes.Single(x => x.ContractTypeID == viewModel.ContractTypeID);
            var requestStatus = AgreementRequestStatus.AllLookupDictionary[viewModel.AgreementRequestStatusID];
            var agreementRequestFromViewModel = new AgreementRequest(viewModel.IsModification, contractType, requestStatus, viewModel.DescriptionOfNeed,DateTime.Now, CurrentFirmaSession.Person);
            viewModel.UpdateModel(agreementRequestFromViewModel, CurrentFirmaSession);

            if (viewModel.IsModification)
            {
                var agreement = HttpRequestStorage.DatabaseEntities.Agreements.Single(x => x.AgreementID == viewModel.AgreementID.Value);
                var costAuthorities = HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList();
                var agreementCostAuthorities = agreement.AgreementCostAuthorities;
                var listOfCostAuthorityIDs = agreementCostAuthorities.Select(x => x.CostAuthorityID).ToList();
                foreach (var costAuthorityID in listOfCostAuthorityIDs)
                {
                    var costAuthority = costAuthorities.Single(x => x.CostAuthorityID == costAuthorityID);
                    var newCostAuthorityReclamationAgreement = new CostAuthorityAgreementRequest(costAuthority, agreementRequestFromViewModel);
                    agreementRequestFromViewModel.CostAuthorityAgreementRequests.Add(newCostAuthorityReclamationAgreement);
                }
            }

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        [AgreementRequestIndexViewFeature]
        public ViewResult AgreementRequestDetail(AgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var agreementRequest = agreementRequestPrimaryKey.EntityObject;

            var userCanInteractWithSubmissionNotes = new AgreementRequestSubmissionNoteFeature().HasPermissionByFirmaSession(CurrentFirmaSession);

            var agreementRequestNotesViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(agreementRequest.AgreementRequestSubmissionNotesWhereYouAreTheReclamationAgreementRequest),
                SitkaRoute<AgreementRequestSubmissionNotesController>.BuildUrlFromExpression(x => x.New(agreementRequest)),
                FieldDefinitionEnum.AgreementRequest.ToType().FieldDefinitionDisplayName,
                userCanInteractWithSubmissionNotes);

            var viewData = new AgreementRequestDetailViewData(CurrentFirmaSession, agreementRequest, userCanInteractWithSubmissionNotes, agreementRequestNotesViewData);
            return RazorView<AgreementRequestDetail, AgreementRequestDetailViewData>(viewData);
        }


        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult Edit(AgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var agreementRequest = agreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditAgreementRequestViewModel(agreementRequest);
            var projectStatusFirmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
            return ViewEdit(viewModel, projectStatusFirmaPage);
        }


        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(AgreementRequestPrimaryKey agreementRequestPrimaryKey, EditAgreementRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
                return ViewEdit(viewModel, firmaPage);
            }
            viewModel.UpdateModel(agreementRequestPrimaryKey.EntityObject, CurrentFirmaSession);
            if (viewModel.IsModification)
            {
                var agreementRequest = agreementRequestPrimaryKey.EntityObject;
                var agreement = HttpRequestStorage.DatabaseEntities.Agreements.Single(x => x.AgreementID == viewModel.AgreementID.Value);
                var costAuthorities = HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList();
                var agreementCostAuthorities = agreement.AgreementCostAuthorities;
                var listOfCostAuthorityIDs = agreementCostAuthorities.Select(x => x.CostAuthorityID).ToList();
                var currentListOfCostAuthoritiesOnAgreementRequest = agreementRequest
                    .CostAuthorityAgreementRequests
                    .Select(x => x.CostAuthorityID).ToList();
                foreach (var costAuthorityID in listOfCostAuthorityIDs)
                {
                    if (!currentListOfCostAuthoritiesOnAgreementRequest.Contains(costAuthorityID))
                    {
                        var costAuthority = costAuthorities.Single(x => x.CostAuthorityID == costAuthorityID);
                        var newCostAuthorityReclamationAgreement = new CostAuthorityAgreementRequest(costAuthority, agreementRequest);
                        agreementRequest.CostAuthorityAgreementRequests.Add(newCostAuthorityReclamationAgreement);
                    }
                    
                }
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult Delete(AgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var reclamationAgreementRequest = agreementRequestPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(reclamationAgreementRequest.AgreementRequestID);
            return ViewDelete(reclamationAgreementRequest, viewModel);
        }


        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult DeleteCostAuthority(CostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey)
        {
            var reclamationCostAuthorityAgreementRequest = reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(reclamationCostAuthorityAgreementRequest.CostAuthorityAgreementRequestID);
            return ViewDeleteCostAuthority(reclamationCostAuthorityAgreementRequest, viewModel);
        }

        private PartialViewResult ViewDeleteCostAuthority(CostAuthorityAgreementRequest costAuthorityAgreementRequest, ConfirmDialogFormViewModel viewModel)
        {
            var displayName = $"this Projected Obligation from Cost Authority: {costAuthorityAgreementRequest.CostAuthority.CostAuthorityWorkBreakdownStructure}";
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{displayName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteCostAuthority(CostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var reclamationCostAuthorityAgreementRequest = reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject;
            var displayName = $"this Projected Obligation from Cost Authority: {reclamationCostAuthorityAgreementRequest.CostAuthority.CostAuthorityWorkBreakdownStructure}";
            if (!ModelState.IsValid)
            {
                return ViewDeleteCostAuthority(reclamationCostAuthorityAgreementRequest, viewModel);
            }

            reclamationCostAuthorityAgreementRequest.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Successfully deleted \"{displayName}\".");

            return new ModalDialogFormJsonResult();
        }



        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(AgreementRequestPrimaryKey agreementRequestPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var reclamationAgreementRequest = agreementRequestPrimaryKey.EntityObject;
            var displayName = $"Agreement Request: {reclamationAgreementRequest.AgreementRequestID.ToString("D4")}";
            if (!ModelState.IsValid)
            {
                return ViewDelete(reclamationAgreementRequest, viewModel);
            }

            reclamationAgreementRequest.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Successfully deleted \"{displayName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDelete(AgreementRequest agreementRequest, ConfirmDialogFormViewModel viewModel)
        {
            var displayName = $"Agreement Request: {agreementRequest.AgreementRequestID.ToString("D4")}";
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{displayName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult EditRequisitionInformation(AgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var agreementRequest = agreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditRequisitionInformationViewModel(agreementRequest);
            return ViewEditRequisitionInformation(viewModel);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRequisitionInformation(AgreementRequestPrimaryKey agreementRequestPrimaryKey, EditRequisitionInformationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditRequisitionInformation(viewModel);
            }
            viewModel.UpdateModel(agreementRequestPrimaryKey.EntityObject, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditRequisitionInformation(EditRequisitionInformationViewModel viewModel)
        {
            var viewData = new EditRequisitionInformationViewData(CurrentFirmaSession);
            return RazorPartialView<EditRequisitionInformation, EditRequisitionInformationViewData, EditRequisitionInformationViewModel>(viewData, viewModel);
        }


        [AgreementRequestIndexViewFeature]
        public GridJsonNetJObjectResult<CostAuthorityAgreementRequest> CostAuthorityAgreementRequestsJsonData(AgreementRequestPrimaryKey reclamationAgreementRequestPrimaryKey)
        {
            var reclamationAgreementRequest = reclamationAgreementRequestPrimaryKey.EntityObject;
            var costAuthorityIDList = reclamationAgreementRequest.Agreement != null
                ? reclamationAgreementRequest.Agreement.AgreementCostAuthorities.Select(x => x.CostAuthorityID).ToList()
                : new List<int>();
            var gridSpec = new CostAuthorityAgreementRequestGridSpec(CurrentFirmaSession, reclamationAgreementRequest.AgreementRequestStatus == AgreementRequestStatus.Draft, costAuthorityIDList);
            var reclamationCostAuthorityAgreementRequests = reclamationAgreementRequestPrimaryKey.EntityObject
                .CostAuthorityAgreementRequests.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<CostAuthorityAgreementRequest>(reclamationCostAuthorityAgreementRequests, gridSpec);
            return gridJsonNetJObjectResult;
        }


    }
}