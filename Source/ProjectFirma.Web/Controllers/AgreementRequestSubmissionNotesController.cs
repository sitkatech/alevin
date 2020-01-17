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
    public class AgreementRequestSubmissionNotesController : FirmaBaseController
    {
        [HttpGet]
        [AgreementRequestSubmissionNoteFeature]
        public PartialViewResult New(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [AgreementRequestSubmissionNoteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ReclamationAgreementRequestPrimaryKey agreementRequestPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var agreementRequest = agreementRequestPrimaryKey.EntityObject;
            var agreementRequestNote = ReclamationAgreementRequestSubmissionNote.CreateNewBlank(agreementRequest);
            viewModel.UpdateModel(agreementRequestNote, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.ReclamationAgreementRequestSubmissionNotes.Add(agreementRequestNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [AgreementRequestSubmissionNoteFeature]
        public PartialViewResult Edit(ReclamationAgreementRequestSubmissionNotePrimaryKey agreementRequestNotePrimaryKey)
        {
            var agreementRequestNote = agreementRequestNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(agreementRequestNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [AgreementRequestSubmissionNoteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ReclamationAgreementRequestSubmissionNotePrimaryKey agreementRequestNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var agreementRequestNote = agreementRequestNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(agreementRequestNote, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [AgreementRequestSubmissionNoteFeature]
        public PartialViewResult DeleteReclamationAgreementRequestSubmissionNote(ReclamationAgreementRequestSubmissionNotePrimaryKey agreementRequestNotePrimaryKey)
        {
            var agreementRequestNote = agreementRequestNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(agreementRequestNote.ReclamationAgreementRequestSubmissionNoteID);
            return ViewDeleteReclamationAgreementRequestSubmissionNote(agreementRequestNote, viewModel);
        }

        private PartialViewResult ViewDeleteReclamationAgreementRequestSubmissionNote(ReclamationAgreementRequestSubmissionNote agreementRequestNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !agreementRequestNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.AgreementRequest.ToType().GetFieldDefinitionLabel()} '{agreementRequestNote.ReclamationAgreementRequest.ReclamationAgreementRequestID}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.AgreementRequestSubmissionNote.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [AgreementRequestSubmissionNoteFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteReclamationAgreementRequestSubmissionNote(ReclamationAgreementRequestSubmissionNotePrimaryKey agreementRequestNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var agreementRequestNote = agreementRequestNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteReclamationAgreementRequestSubmissionNote(agreementRequestNote, viewModel);
            }
            agreementRequestNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }


    }
}