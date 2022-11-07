/*-----------------------------------------------------------------------
<copyright file="SubprojectNoteController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectNoteController : FirmaBaseController
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
            var subprojectNote = SubprojectNote.CreateNewBlank(subproject);
            viewModel.UpdateModel(subprojectNote, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllSubprojectNotes.Add(subprojectNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult Edit(SubprojectNotePrimaryKey subprojectNotePrimaryKey)
        {
            var subprojectNote = subprojectNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(subprojectNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(SubprojectNotePrimaryKey subprojectNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var subprojectNote = subprojectNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(subprojectNote, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult DeleteProjectNote(SubprojectNotePrimaryKey subprojectNotePrimaryKey)
        {
            var subprojectNote = subprojectNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(subprojectNote.SubprojectNoteID);
            return ViewDeleteProjectNote(subprojectNote, viewModel);
        }

        private PartialViewResult ViewDeleteProjectNote(SubprojectNote subprojectNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !subprojectNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this note for {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()} '{subprojectNote.Subproject.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.ProjectNote.ToType().GetFieldDefinitionLabel()}");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectNote(SubprojectNotePrimaryKey subprojectNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var subprojectNote = subprojectNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectNote(subprojectNote, viewModel);
            }
            subprojectNote.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }
    }
}
