using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ObligationRequestSubmissionNotesController : FirmaBaseController
    {
        [HttpGet]
        [ObligationRequestSubmissionNoteFeature]
        public PartialViewResult New(ObligationRequestPrimaryKey obligationRequestPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ObligationRequestSubmissionNoteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ObligationRequestPrimaryKey obligationRequestPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var obligationRequest = obligationRequestPrimaryKey.EntityObject;
            var obligationRequestNote = ObligationRequestSubmissionNote.CreateNewBlank(obligationRequest);
            viewModel.UpdateModel(obligationRequestNote, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.ObligationRequestSubmissionNotes.Add(obligationRequestNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ObligationRequestSubmissionNoteFeature]
        public PartialViewResult Edit(ObligationRequestSubmissionNotePrimaryKey obligationRequestNotePrimaryKey)
        {
            var obligationRequestNote = obligationRequestNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(obligationRequestNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ObligationRequestSubmissionNoteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ObligationRequestSubmissionNotePrimaryKey obligationRequestNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var obligationRequestNote = obligationRequestNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(obligationRequestNote, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ObligationRequestSubmissionNoteFeature]
        public PartialViewResult DeleteReclamationObligationRequestSubmissionNote(ObligationRequestSubmissionNotePrimaryKey obligationRequestNotePrimaryKey)
        {
            var obligationRequestNote = obligationRequestNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(obligationRequestNote.ObligationRequestSubmissionNoteID);
            return ViewDeleteReclamationObligationRequestSubmissionNote(obligationRequestNote, viewModel);
        }

        private PartialViewResult ViewDeleteReclamationObligationRequestSubmissionNote(ObligationRequestSubmissionNote obligationRequestNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !obligationRequestNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.ObligationRequest.ToType().GetFieldDefinitionLabel()} '{obligationRequestNote.ObligationRequest.ObligationRequestID}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.ObligationRequestSubmissionNote.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ObligationRequestSubmissionNoteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteReclamationObligationRequestSubmissionNote(ObligationRequestSubmissionNotePrimaryKey obligationRequestNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var obligationRequestNote = obligationRequestNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteReclamationObligationRequestSubmissionNote(obligationRequestNote, viewModel);
            }
            obligationRequestNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }


    }
}