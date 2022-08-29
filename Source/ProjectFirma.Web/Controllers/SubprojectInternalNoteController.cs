using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectInternalNoteController : FirmaBaseController
    {
        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult New(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(SubprojectPrimaryKey subprojectPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var subproject = subprojectPrimaryKey.EntityObject;
            var subprojectInternalNote = SubprojectInternalNote.CreateNewBlank(subproject);
            viewModel.UpdateModel(subprojectInternalNote, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllSubprojectInternalNotes.Add(subprojectInternalNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult Edit(SubprojectInternalNotePrimaryKey subprojectInternalNotePrimaryKey)
        {
            var subprojectInternalNote = subprojectInternalNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(subprojectInternalNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(SubprojectInternalNotePrimaryKey subprojectInternalNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var subprojectInternalNote = subprojectInternalNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(subprojectInternalNote, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult DeleteSubprojectInternalNote(SubprojectInternalNotePrimaryKey subprojectInternalNotePrimaryKey)
        {
            var subprojectInternalNote = subprojectInternalNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(subprojectInternalNote.SubprojectInternalNoteID);
            return ViewDeleteSubprojectInternalNote(subprojectInternalNote, viewModel);
        }

        private PartialViewResult ViewDeleteSubprojectInternalNote(SubprojectInternalNote subprojectInternalNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !subprojectInternalNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()} '{subprojectInternalNote.Subproject.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.ProjectInternalNote.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteSubprojectInternalNote(SubprojectInternalNotePrimaryKey subprojectInternalNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var subprojectInternalNote = subprojectInternalNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteSubprojectInternalNote(subprojectInternalNote, viewModel);
            }
            subprojectInternalNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}