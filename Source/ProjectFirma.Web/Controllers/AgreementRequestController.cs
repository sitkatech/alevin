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
        public GridJsonNetJObjectResult<ReclamationAgreementRequest> AgreementRequestGridJsonData()
        {
            var gridSpec = new AgreementRequestGridSpec(CurrentFirmaSession);
            var agreements = HttpRequestStorage.DatabaseEntities.ReclamationAgreementRequests.ToList().OrderBy(x => x.ReclamationAgreementRequestID).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ReclamationAgreementRequest>(agreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult EditCostAuthorityAgreementRequest(ReclamationCostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey)
        {
            var costAuthorityAgreementRequest = reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditCostAuthorityAgreementRequestViewModel(costAuthorityAgreementRequest);
            var projectStatusFirmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
            return ViewEditCostAuthorityAgreementRequest(reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject,viewModel, projectStatusFirmaPage);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditCostAuthorityAgreementRequest(ReclamationCostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey, EditCostAuthorityAgreementRequestViewModel viewModel)
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

        private PartialViewResult ViewEditCostAuthorityAgreementRequest(ReclamationCostAuthorityAgreementRequest reclamationCostAuthorityAgreementRequest, EditCostAuthorityAgreementRequestViewModel viewModel, FirmaPage firmaPage)
        {
            var projectStatusFirmaPage = firmaPage;
            var viewData = new EditCostAuthorityAgreementRequestViewData(projectStatusFirmaPage, CurrentFirmaSession, reclamationCostAuthorityAgreementRequest.AgreementRequest);
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
            var allAgreements = HttpRequestStorage.DatabaseEntities.ReclamationAgreements.ToList();
            var allContractTypes = HttpRequestStorage.DatabaseEntities.ReclamationContractTypes.ToList();
            var allRequestStatuses = ReclamationAgreementRequestStatus.All;
            var allFundingPriorities = ReclamationAgreementRequestFundingPriority.All;
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList();
            var viewData = new EditAgreementRequestViewData(projectStatusFirmaPage, CurrentFirmaSession, allAgreements,allContractTypes, allRequestStatuses, allFundingPriorities, allOrganizations, allPeople );
            return RazorPartialView<EditAgreementRequest, EditAgreementRequestViewData, EditAgreementRequestViewModel>(viewData, viewModel);
        }

       
        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult EditCostAuthorityAgreementRequests(ReclamationAgreementRequestPrimaryKey reclamationAgreementRequestPrimaryKey)
        {
            var reclamationAgreementRequest = reclamationAgreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditCostAuthorityAgreementRequestsViewModel(reclamationAgreementRequest);
            var projectStatusFirmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
            return ViewEditCostAuthorityAgreementRequests(reclamationAgreementRequest, viewModel, projectStatusFirmaPage );
        }

        private PartialViewResult ViewEditCostAuthorityAgreementRequests(ReclamationAgreementRequest reclamationAgreementRequest, EditCostAuthorityAgreementRequestsViewModel viewModel, FirmaPage firmaPage)
        {
            var projectStatusFirmaPage = firmaPage;
            var allCostAuthorities= HttpRequestStorage.DatabaseEntities.ReclamationCostAuthorities.ToList();
            var viewData = new EditCostAuthorityAgreementRequestsViewData(projectStatusFirmaPage, CurrentFirmaSession, allCostAuthorities, reclamationAgreementRequest);
            return RazorPartialView<EditCostAuthorityAgreementRequests, EditCostAuthorityAgreementRequestsViewData, EditCostAuthorityAgreementRequestsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditCostAuthorityAgreementRequests(ReclamationAgreementRequestPrimaryKey reclamationAgreementRequestPrimaryKey, EditCostAuthorityAgreementRequestsViewModel viewModel)
        {
            var reclamationAgreementRequest = reclamationAgreementRequestPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
                return ViewEditCostAuthorityAgreementRequests(reclamationAgreementRequest,viewModel, firmaPage);
            }

            var listOfCostAuthorityIDs = viewModel.CostAuthorityJsonList.Select(x => x.ReclamationCostAuthorityID).ToList();
            var existingCostAuthorityAgreementRequests = reclamationAgreementRequest
                .ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest;
            
            foreach (var costAuthorityID in listOfCostAuthorityIDs)
            {
                var costAuthorityJson =
                    viewModel.CostAuthorityJsonList.Single(x => x.ReclamationCostAuthorityID == costAuthorityID);
                if (!existingCostAuthorityAgreementRequests.Select(x => x.CostAuthorityID).Contains(costAuthorityID))
                {
                    var newCostAuthorityReclamationAgreement =
                        new ReclamationCostAuthorityAgreementRequest(costAuthorityID,reclamationAgreementRequest.ReclamationAgreementRequestID)
                        {
                            ProjectedObligation = costAuthorityJson.ProjectedObligation
                            , ReclamationCostAuthorityAgreementRequestNote = costAuthorityJson.Note
                        };
                    reclamationAgreementRequest.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest.Add(newCostAuthorityReclamationAgreement);
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
            var contractType = HttpRequestStorage.DatabaseEntities.ReclamationContractTypes.Single(x => x.ReclamationContractTypeID == viewModel.ContractTypeID);
            var requestStatus = ReclamationAgreementRequestStatus.AllLookupDictionary[viewModel.AgreementRequestStatusID];
            var agreementRequestFromViewModel = new ReclamationAgreementRequest(viewModel.IsModification, contractType, requestStatus, viewModel.DescriptionOfNeed,DateTime.Now, CurrentFirmaSession.Person);
            viewModel.UpdateModel(agreementRequestFromViewModel, CurrentFirmaSession);

            if (viewModel.IsModification)
            {
                var agreement = HttpRequestStorage.DatabaseEntities.ReclamationAgreements.Single(x => x.ReclamationAgreementID == viewModel.AgreementID.Value);
                var costAuthorities = HttpRequestStorage.DatabaseEntities.ReclamationCostAuthorities.ToList();
                var agreementCostAuthorities = agreement.ReclamationAgreementReclamationCostAuthorities;
                var listOfCostAuthorityIDs = agreementCostAuthorities.Select(x => x.ReclamationCostAuthorityID).ToList();
                foreach (var costAuthorityID in listOfCostAuthorityIDs)
                {
                    var costAuthority = costAuthorities.Single(x => x.ReclamationCostAuthorityID == costAuthorityID);
                    var newCostAuthorityReclamationAgreement = new ReclamationCostAuthorityAgreementRequest(costAuthority, agreementRequestFromViewModel);
                    agreementRequestFromViewModel.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest.Add(newCostAuthorityReclamationAgreement);
                }
            }

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        [AgreementRequestIndexViewFeature]
        public ViewResult AgreementRequestDetail(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var agreementRequest = agreementRequestPrimaryKey.EntityObject;

            var userCanInteractWithSubmissionNotes = new AgreementRequestSubmissionNoteFeature().HasPermissionByFirmaSession(CurrentFirmaSession);

            var agreementRequestNotesViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(agreementRequest.ReclamationAgreementRequestSubmissionNotes),
                SitkaRoute<AgreementRequestSubmissionNotesController>.BuildUrlFromExpression(x => x.New(agreementRequest)),
                FieldDefinitionEnum.AgreementRequest.ToType().FieldDefinitionDisplayName,
                userCanInteractWithSubmissionNotes);

            var viewData = new AgreementRequestDetailViewData(CurrentFirmaSession, agreementRequest, userCanInteractWithSubmissionNotes, agreementRequestNotesViewData);
            return RazorView<AgreementRequestDetail, AgreementRequestDetailViewData>(viewData);
        }


        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult Edit(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var agreementRequest = agreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditAgreementRequestViewModel(agreementRequest);
            var projectStatusFirmaPage = FirmaPageTypeEnum.AgreementRequestFromGridDialog.GetFirmaPage();
            return ViewEdit(viewModel, projectStatusFirmaPage);
        }


        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey, EditAgreementRequestViewModel viewModel)
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
                var agreement = HttpRequestStorage.DatabaseEntities.ReclamationAgreements.Single(x => x.ReclamationAgreementID == viewModel.AgreementID.Value);
                var costAuthorities = HttpRequestStorage.DatabaseEntities.ReclamationCostAuthorities.ToList();
                var agreementCostAuthorities = agreement.ReclamationAgreementReclamationCostAuthorities;
                var listOfCostAuthorityIDs = agreementCostAuthorities.Select(x => x.ReclamationCostAuthorityID).ToList();
                var currentListOfCostAuthoritiesOnAgreementRequest = agreementRequest
                    .ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest
                    .Select(x => x.CostAuthorityID).ToList();
                foreach (var costAuthorityID in listOfCostAuthorityIDs)
                {
                    if (!currentListOfCostAuthoritiesOnAgreementRequest.Contains(costAuthorityID))
                    {
                        var costAuthority = costAuthorities.Single(x => x.ReclamationCostAuthorityID == costAuthorityID);
                        var newCostAuthorityReclamationAgreement = new ReclamationCostAuthorityAgreementRequest(costAuthority, agreementRequest);
                        agreementRequest.ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest.Add(newCostAuthorityReclamationAgreement);
                    }
                    
                }
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult Delete(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var reclamationAgreementRequest = agreementRequestPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(reclamationAgreementRequest.ReclamationAgreementRequestID);
            return ViewDelete(reclamationAgreementRequest, viewModel);
        }


        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult DeleteCostAuthority(ReclamationCostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey)
        {
            var reclamationCostAuthorityAgreementRequest = reclamationCostAuthorityAgreementRequestPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(reclamationCostAuthorityAgreementRequest.ReclamationCostAuthorityAgreementRequestID);
            return ViewDeleteCostAuthority(reclamationCostAuthorityAgreementRequest, viewModel);
        }

        private PartialViewResult ViewDeleteCostAuthority(ReclamationCostAuthorityAgreementRequest reclamationCostAuthorityAgreementRequest, ConfirmDialogFormViewModel viewModel)
        {
            var displayName = $"this Projected Obligation from Cost Authority: {reclamationCostAuthorityAgreementRequest.CostAuthority.CostAuthorityWorkBreakdownStructure}";
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{displayName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteCostAuthority(ReclamationCostAuthorityAgreementRequestPrimaryKey reclamationCostAuthorityAgreementRequestPrimaryKey,
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
        public ActionResult Delete(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var reclamationAgreementRequest = agreementRequestPrimaryKey.EntityObject;
            var displayName = $"Agreement Request: {reclamationAgreementRequest.ReclamationAgreementRequestID.ToString("D4")}";
            if (!ModelState.IsValid)
            {
                return ViewDelete(reclamationAgreementRequest, viewModel);
            }

            reclamationAgreementRequest.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Successfully deleted \"{displayName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDelete(ReclamationAgreementRequest reclamationAgreementRequest, ConfirmDialogFormViewModel viewModel)
        {
            var displayName = $"Agreement Request: {reclamationAgreementRequest.ReclamationAgreementRequestID.ToString("D4")}";
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{displayName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AgreementRequestCreateFeature]
        public PartialViewResult EditRequisitionInformation(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var agreementRequest = agreementRequestPrimaryKey.EntityObject;
            var viewModel = new EditRequisitionInformationViewModel(agreementRequest);
            return ViewEditRequisitionInformation(viewModel);
        }

        [HttpPost]
        [AgreementRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRequisitionInformation(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey, EditRequisitionInformationViewModel viewModel)
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
        public GridJsonNetJObjectResult<ReclamationCostAuthorityAgreementRequest> CostAuthorityAgreementRequestsJsonData(ReclamationAgreementRequestPrimaryKey reclamationAgreementRequestPrimaryKey)
        {
            var reclamationAgreementRequest = reclamationAgreementRequestPrimaryKey.EntityObject;
            var costAuthorityIDList = reclamationAgreementRequest.Agreement != null
                ? reclamationAgreementRequest.Agreement.ReclamationAgreementReclamationCostAuthorities
                    .Select(x => x.ReclamationCostAuthorityID).ToList()
                : new List<int>();
            var gridSpec = new CostAuthorityAgreementRequestGridSpec(CurrentFirmaSession, reclamationAgreementRequest.AgreementRequestStatus == ReclamationAgreementRequestStatus.Draft, costAuthorityIDList);
            var reclamationCostAuthorityAgreementRequests = reclamationAgreementRequestPrimaryKey.EntityObject
                .ReclamationCostAuthorityAgreementRequestsWhereYouAreTheAgreementRequest.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ReclamationCostAuthorityAgreementRequest>(reclamationCostAuthorityAgreementRequests, gridSpec);
            return gridJsonNetJObjectResult;
        }


    }
}