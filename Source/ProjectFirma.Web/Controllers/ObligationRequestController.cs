﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApprovalUtilities.Utilities;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ObligationRequest;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ObligationRequestController : FirmaBaseController
    {
        [ObligationRequestIndexViewFeature]
        public ViewResult ObligationRequestIndex()
        {
            return ObligationRequestIndexImpl();
        }

        private ViewResult ObligationRequestIndexImpl()
        {
            var firmaPage = FirmaPageTypeEnum.ObligationRequestList.GetFirmaPage();
            var viewData = new ObligationRequestIndexViewData(CurrentFirmaSession, firmaPage);
            return RazorView<ObligationRequestIndex, ObligationRequestIndexViewData>(viewData);
        }

        [ObligationRequestIndexViewFeature]
        public GridJsonNetJObjectResult<ObligationRequest> ObligationRequestGridJsonData()
        {
            var gridSpec = new ObligationRequestGridSpec(CurrentFirmaSession);
            var agreements = HttpRequestStorage.DatabaseEntities.ObligationRequests.ToList().OrderBy(x => x.ObligationRequestID).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ObligationRequest>(agreements, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [ObligationRequestCreateFeature]
        public PartialViewResult EditCostAuthorityObligationRequest(CostAuthorityObligationRequestPrimaryKey reclamationCostAuthorityObligationRequestPrimaryKey)
        {
            var costAuthorityObligationRequest = reclamationCostAuthorityObligationRequestPrimaryKey.EntityObject;
            var viewModel = new EditCostAuthorityObligationRequestViewModel(costAuthorityObligationRequest);
            var projectStatusFirmaPage = FirmaPageTypeEnum.ObligationRequestFromGridDialog.GetFirmaPage();
            return ViewEditCostAuthorityObligationRequest(reclamationCostAuthorityObligationRequestPrimaryKey.EntityObject,viewModel, projectStatusFirmaPage);
        }

        [HttpPost]
        [ObligationRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditCostAuthorityObligationRequest(CostAuthorityObligationRequestPrimaryKey reclamationCostAuthorityObligationRequestPrimaryKey, EditCostAuthorityObligationRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.ObligationRequestFromGridDialog.GetFirmaPage();
                return ViewEditCostAuthorityObligationRequest(reclamationCostAuthorityObligationRequestPrimaryKey.EntityObject, viewModel, firmaPage);
            }
            viewModel.UpdateModel(reclamationCostAuthorityObligationRequestPrimaryKey.EntityObject, CurrentFirmaSession);
           
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditCostAuthorityObligationRequest(CostAuthorityObligationRequest costAuthorityObligationRequest, EditCostAuthorityObligationRequestViewModel viewModel, FirmaPage firmaPage)
        {
            var projectStatusFirmaPage = firmaPage;
            var viewData = new EditCostAuthorityObligationRequestViewData(projectStatusFirmaPage, CurrentFirmaSession, costAuthorityObligationRequest.ObligationRequest);
            return RazorPartialView<EditCostAuthorityObligationRequest, EditCostAuthorityObligationRequestViewData, EditCostAuthorityObligationRequestViewModel>(viewData, viewModel);
        }


        [HttpGet]
        [ObligationRequestCreateFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditObligationRequestViewModel();
            var projectStatusFirmaPage = FirmaPageTypeEnum.ObligationRequestFromGridDialog.GetFirmaPage();
            return ViewEdit(viewModel,  projectStatusFirmaPage);
        }

        private PartialViewResult ViewEdit(EditObligationRequestViewModel viewModel, FirmaPage firmaPage)
        {
            var projectStatusFirmaPage = firmaPage;
            var allAgreements = HttpRequestStorage.DatabaseEntities.Agreements.ToList();
            var allContractTypes = HttpRequestStorage.DatabaseEntities.ContractTypes.ToList();
            var allRequestStatuses = ObligationRequestStatus.All;
            var allFundingPriorities = ObligationRequestFundingPriority.All;
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList();
            var viewData = new EditObligationRequestViewData(projectStatusFirmaPage, CurrentFirmaSession, allAgreements,allContractTypes, allRequestStatuses, allFundingPriorities, allOrganizations, allPeople );
            return RazorPartialView<EditObligationRequest, EditObligationRequestViewData, EditObligationRequestViewModel>(viewData, viewModel);
        }

       
        [HttpGet]
        [ObligationRequestCreateFeature]
        public PartialViewResult EditCostAuthorityObligationRequests(ObligationRequestPrimaryKey reclamationObligationRequestPrimaryKey)
        {
            var reclamationObligationRequest = reclamationObligationRequestPrimaryKey.EntityObject;
            var viewModel = new EditCostAuthorityObligationRequestsViewModel(reclamationObligationRequest);
            var firmaPage = FirmaPageTypeEnum.AddCostAuthorityToObligationRequest.GetFirmaPage();
            return ViewEditCostAuthorityObligationRequests(reclamationObligationRequest, viewModel, firmaPage );
        }

        private PartialViewResult ViewEditCostAuthorityObligationRequests(ObligationRequest obligationRequest, EditCostAuthorityObligationRequestsViewModel viewModel, FirmaPage firmaPage)
        {
            var allCostAuthorities= HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList();
            var viewData = new EditCostAuthorityObligationRequestsViewData(firmaPage, CurrentFirmaSession, allCostAuthorities, obligationRequest);
            return RazorPartialView<EditCostAuthorityObligationRequests, EditCostAuthorityObligationRequestsViewData, EditCostAuthorityObligationRequestsViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ObligationRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditCostAuthorityObligationRequests(ObligationRequestPrimaryKey reclamationObligationRequestPrimaryKey, EditCostAuthorityObligationRequestsViewModel viewModel)
        {
            var reclamationObligationRequest = reclamationObligationRequestPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.AddCostAuthorityToObligationRequest.GetFirmaPage();
                return ViewEditCostAuthorityObligationRequests(reclamationObligationRequest,viewModel, firmaPage);
            }

            var listOfCostAuthorityIDs = viewModel.CostAuthorityJsonList.Select(x => x.ReclamationCostAuthorityID).ToList();
            var existingCostAuthorityObligationRequests = reclamationObligationRequest.CostAuthorityObligationRequests;
            
            foreach (var costAuthorityID in listOfCostAuthorityIDs)
            {
                var costAuthorityJson =
                    viewModel.CostAuthorityJsonList.Single(x => x.ReclamationCostAuthorityID == costAuthorityID);
                if (!existingCostAuthorityObligationRequests.Select(x => x.CostAuthorityID).Contains(costAuthorityID))
                {
                    var newCostAuthorityReclamationAgreement =
                        new CostAuthorityObligationRequest(costAuthorityID,reclamationObligationRequest.ObligationRequestID)
                        {
                            ProjectedObligation = costAuthorityJson.ProjectedObligation
                            , CostAuthorityObligationRequestNote = costAuthorityJson.Note
                        };
                    reclamationObligationRequest.CostAuthorityObligationRequests.Add(newCostAuthorityReclamationAgreement);
                }
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }


        [HttpPost]
        [ObligationRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditObligationRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.ObligationRequestFromGridDialog.GetFirmaPage();
                return ViewEdit(viewModel, firmaPage);
            }
            return MakeTheNewObligationRequest(viewModel);
        }

        private ActionResult MakeTheNewObligationRequest(EditObligationRequestViewModel viewModel)
        {
            var contractType = HttpRequestStorage.DatabaseEntities.ContractTypes.Single(x => x.ContractTypeID == viewModel.ContractTypeID);
            var requestStatus = ObligationRequestStatus.AllLookupDictionary[viewModel.ObligationRequestStatusID];
            var obligationRequestFromViewModel = new ObligationRequest(viewModel.IsModification, contractType, requestStatus, viewModel.DescriptionOfNeed,DateTime.Now, CurrentFirmaSession.Person);
            viewModel.UpdateModel(obligationRequestFromViewModel, CurrentFirmaSession);

            if (viewModel.IsModification)
            {
                var agreement = HttpRequestStorage.DatabaseEntities.Agreements.Single(x => x.AgreementID == viewModel.AgreementID.Value);
                var costAuthorities = HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList();
                var agreementCostAuthorities = agreement.AgreementCostAuthorities;
                var listOfCostAuthorityIDs = agreementCostAuthorities.Select(x => x.CostAuthorityID).ToList();
                foreach (var costAuthorityID in listOfCostAuthorityIDs)
                {
                    var costAuthority = costAuthorities.Single(x => x.CostAuthorityID == costAuthorityID);
                    var newCostAuthorityReclamationAgreement = new CostAuthorityObligationRequest(costAuthority, obligationRequestFromViewModel);
                    obligationRequestFromViewModel.CostAuthorityObligationRequests.Add(newCostAuthorityReclamationAgreement);
                }
            }

            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        [ObligationRequestIndexViewFeature]
        public ViewResult ObligationRequestDetail(ObligationRequestPrimaryKey obligationRequestPrimaryKey)
        {
            var obligationRequest = obligationRequestPrimaryKey.EntityObject;

            var userCanInteractWithSubmissionNotes = new ObligationRequestSubmissionNoteFeature().HasPermissionByFirmaSession(CurrentFirmaSession);

            var obligationRequestNotesViewData = new EntityNotesViewData(
                EntityNote.CreateFromEntityNote(obligationRequest.ObligationRequestSubmissionNotes),
                SitkaRoute<ObligationRequestSubmissionNotesController>.BuildUrlFromExpression(x => x.New(obligationRequest)),
                FieldDefinitionEnum.ObligationRequest.ToType().FieldDefinitionDisplayName,
                userCanInteractWithSubmissionNotes);

            var viewData = new ObligationRequestDetailViewData(CurrentFirmaSession, obligationRequest, userCanInteractWithSubmissionNotes, obligationRequestNotesViewData);
            return RazorView<ObligationRequestDetail, ObligationRequestDetailViewData>(viewData);
        }


        [HttpGet]
        [ObligationRequestCreateFeature]
        public PartialViewResult Edit(ObligationRequestPrimaryKey obligationRequestPrimaryKey)
        {
            var obligationRequest = obligationRequestPrimaryKey.EntityObject;
            var viewModel = new EditObligationRequestViewModel(obligationRequest);
            var projectStatusFirmaPage = FirmaPageTypeEnum.ObligationRequestFromGridDialog.GetFirmaPage();
            return ViewEdit(viewModel, projectStatusFirmaPage);
        }


        [HttpPost]
        [ObligationRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ObligationRequestPrimaryKey obligationRequestPrimaryKey, EditObligationRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var firmaPage = FirmaPageTypeEnum.ObligationRequestFromGridDialog.GetFirmaPage();
                return ViewEdit(viewModel, firmaPage);
            }
            viewModel.UpdateModel(obligationRequestPrimaryKey.EntityObject, CurrentFirmaSession);
            if (viewModel.IsModification)
            {
                var obligationRequest = obligationRequestPrimaryKey.EntityObject;
                var agreement = HttpRequestStorage.DatabaseEntities.Agreements.Single(x => x.AgreementID == viewModel.AgreementID.Value);
                var costAuthorities = HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList();
                var agreementCostAuthorities = agreement.AgreementCostAuthorities;
                var listOfCostAuthorityIDs = agreementCostAuthorities.Select(x => x.CostAuthorityID).ToList();
                var currentListOfCostAuthoritiesOnObligationRequest = obligationRequest
                    .CostAuthorityObligationRequests
                    .Select(x => x.CostAuthorityID).ToList();
                foreach (var costAuthorityID in listOfCostAuthorityIDs)
                {
                    if (!currentListOfCostAuthoritiesOnObligationRequest.Contains(costAuthorityID))
                    {
                        var costAuthority = costAuthorities.Single(x => x.CostAuthorityID == costAuthorityID);
                        var newCostAuthorityReclamationAgreement = new CostAuthorityObligationRequest(costAuthority, obligationRequest);
                        obligationRequest.CostAuthorityObligationRequests.Add(newCostAuthorityReclamationAgreement);
                    }
                    
                }
            }
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [ObligationRequestCreateFeature]
        public PartialViewResult Delete(ObligationRequestPrimaryKey obligationRequestPrimaryKey)
        {
            var reclamationObligationRequest = obligationRequestPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(reclamationObligationRequest.ObligationRequestID);
            return ViewDelete(reclamationObligationRequest, viewModel);
        }


        [HttpGet]
        [ObligationRequestCreateFeature]
        public PartialViewResult DeleteCostAuthority(CostAuthorityObligationRequestPrimaryKey reclamationCostAuthorityObligationRequestPrimaryKey)
        {
            var reclamationCostAuthorityObligationRequest = reclamationCostAuthorityObligationRequestPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(reclamationCostAuthorityObligationRequest.CostAuthorityObligationRequestID);
            return ViewDeleteCostAuthority(reclamationCostAuthorityObligationRequest, viewModel);
        }

        private PartialViewResult ViewDeleteCostAuthority(CostAuthorityObligationRequest costAuthorityObligationRequest, ConfirmDialogFormViewModel viewModel)
        {
            var displayName = $"this Projected Obligation from Cost Authority: {costAuthorityObligationRequest.CostAuthority.CostAuthorityWorkBreakdownStructure}";
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{displayName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ObligationRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteCostAuthority(CostAuthorityObligationRequestPrimaryKey reclamationCostAuthorityObligationRequestPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var reclamationCostAuthorityObligationRequest = reclamationCostAuthorityObligationRequestPrimaryKey.EntityObject;
            var displayName = $"this Projected Obligation from Cost Authority: {reclamationCostAuthorityObligationRequest.CostAuthority.CostAuthorityWorkBreakdownStructure}";
            if (!ModelState.IsValid)
            {
                return ViewDeleteCostAuthority(reclamationCostAuthorityObligationRequest, viewModel);
            }

            reclamationCostAuthorityObligationRequest.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Successfully deleted \"{displayName}\".");

            return new ModalDialogFormJsonResult();
        }



        [HttpPost]
        [ObligationRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ObligationRequestPrimaryKey obligationRequestPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var obligationRequest = obligationRequestPrimaryKey.EntityObject;
            var displayName = $"Obligation Request: {obligationRequest.ObligationRequestID.ToString("D4")}";
            if (!ModelState.IsValid)
            {
                return ViewDelete(obligationRequest, viewModel);
            }

            obligationRequest.DeleteFull(HttpRequestStorage.DatabaseEntities);

            SetMessageForDisplay($"Successfully deleted \"{displayName}\".");

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDelete(ObligationRequest obligationRequest, ConfirmDialogFormViewModel viewModel)
        {
            var displayName = $"Obligation Request: {obligationRequest.ObligationRequestID.ToString("D4")}";
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete \"{displayName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ObligationRequestCreateFeature]
        public PartialViewResult EditRequisitionInformation(ObligationRequestPrimaryKey obligationRequestPrimaryKey)
        {
            var obligationRequest = obligationRequestPrimaryKey.EntityObject;
            var viewModel = new EditRequisitionInformationViewModel(obligationRequest);
            return ViewEditRequisitionInformation(viewModel);
        }

        [HttpPost]
        [ObligationRequestCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRequisitionInformation(ObligationRequestPrimaryKey obligationRequestPrimaryKey, EditRequisitionInformationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditRequisitionInformation(viewModel);
            }
            viewModel.UpdateModel(obligationRequestPrimaryKey.EntityObject, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditRequisitionInformation(EditRequisitionInformationViewModel viewModel)
        {
            var viewData = new EditRequisitionInformationViewData(CurrentFirmaSession);
            return RazorPartialView<EditRequisitionInformation, EditRequisitionInformationViewData, EditRequisitionInformationViewModel>(viewData, viewModel);
        }


        [ObligationRequestIndexViewFeature]
        public GridJsonNetJObjectResult<CostAuthorityObligationRequest> CostAuthorityObligationRequestsJsonData(ObligationRequestPrimaryKey reclamationObligationRequestPrimaryKey)
        {
            var reclamationObligationRequest = reclamationObligationRequestPrimaryKey.EntityObject;
            var costAuthorityIDList = reclamationObligationRequest.Agreement != null
                ? reclamationObligationRequest.Agreement.AgreementCostAuthorities.Select(x => x.CostAuthorityID).ToList()
                : new List<int>();
            var gridSpec = new CostAuthorityObligationRequestGridSpec(CurrentFirmaSession, reclamationObligationRequest.ObligationRequestStatus == ObligationRequestStatus.Draft, costAuthorityIDList);
            var reclamationCostAuthorityObligationRequests = reclamationObligationRequestPrimaryKey.EntityObject
                .CostAuthorityObligationRequests.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<CostAuthorityObligationRequest>(reclamationCostAuthorityObligationRequests, gridSpec);
            return gridJsonNetJObjectResult;
        }


    }
}