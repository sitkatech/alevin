using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DocumentFormat.OpenXml.EMMA;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Subproject;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectController : FirmaBaseController
    {
        [SubprojectViewFeature]
        public GridJsonNetJObjectResult<Subproject> SubprojectGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var gridSpec = new SubprojectGridSpec(projectPrimaryKey, CurrentFirmaSession);
            var Subproject = project.Subprojects.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Subproject>(Subproject, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [SubprojectCreateFeature]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditViewModel()
            {
               
                ProjectID = project.ProjectID
            };
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [SubprojectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var Subproject = new Subproject(project.ProjectID, ModelObjectHelpers.NotYetAssignedID, "", "");

            viewModel.UpdateModel(Subproject, CurrentFirmaSession);
             HttpRequestStorage.DatabaseEntities.AllSubprojects.Add(Subproject);

             SetMessageForDisplay($"Successfully added new Subproject.");
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult Edit(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var Subproject = subprojectPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(Subproject);
            return ViewEdit(viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.SubprojectEditDialog.GetFirmaPage();

            var projectStages =
                ProjectStage.All.ToList();

            var viewData = new EditViewData(CurrentFirmaSession, firmaPage, projectStages);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(SubprojectPrimaryKey subprojectPrimaryKey, EditViewModel viewModel)
        {
            var Subproject = subprojectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            viewModel.UpdateModel(Subproject, CurrentFirmaSession);
            SetMessageForDisplay($"Successfully edited Subproject.");
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult Delete(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var Subproject = subprojectPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(Subproject.SubprojectID);
            return ViewDelete(Subproject, viewModel);
        }

        private PartialViewResult ViewDelete(Subproject Subproject, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage =
                $"Are you sure you want to delete this subproject?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(SubprojectPrimaryKey subprojectPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var Subproject = subprojectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(Subproject, viewModel);
            }

            var message = $"Subproject successfully deleted.";
            Subproject.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

    }
}