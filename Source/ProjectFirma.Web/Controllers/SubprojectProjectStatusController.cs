using System;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.SubprojectProjectStatus;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectProjectStatusController : FirmaBaseController
    {
        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult NewFromGrid(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var viewModel = new EditSubprojectProjectStatusViewModel(DateTime.Now);
            var allowEditFinal = AllowUserToSetNewStatusReportToFinal(subprojectPrimaryKey.EntityObject, CurrentFirmaSession);
            viewModel.IsFinalStatusUpdate = allowEditFinal;


            var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromGridDialog.GetFirmaPage();
            return ViewEdit( viewModel, false, null, null, projectStatusFirmaPage, subprojectPrimaryKey.EntityObject, false);
        }

        public static bool AllowUserToSetNewStatusReportToFinal(Subproject subproject, FirmaSession currentFirmaSession)
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            if (!tenantAttribute.EnableStatusUpdates)
            {
                return false;
            }

            var allowEditFinal = false;
            var userHasPermissionToEditTimeline = new SubprojectManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (subproject.SubprojectStage == ProjectStage.Completed)
            {
                var finalStatusReport = subproject.SubprojectProjectStatuses.Where(x => x.IsFinalStatusUpdate);

                if (!finalStatusReport.Any())
                {
                    if (userHasPermissionToEditTimeline)
                    {
                        allowEditFinal = true;
                    }
                }
            }

            return allowEditFinal;
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewFromGrid(SubprojectPrimaryKey subprojectPrimaryKey, EditSubprojectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromGridDialog.GetFirmaPage();
                return ViewEdit(viewModel, false, null, null, projectStatusFirmaPage, subprojectPrimaryKey.EntityObject, false);
            }
            return MakeTheNewSubprojectProjectStatus(subprojectPrimaryKey, viewModel);
        }


        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult New(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var viewModel = new EditSubprojectProjectStatusViewModel();
            var allowEditFinal = AllowUserToSetNewStatusReportToFinal(subprojectPrimaryKey.EntityObject, CurrentFirmaSession);
            viewModel.IsFinalStatusUpdate = allowEditFinal;
            var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
            return ViewEdit(viewModel, true, null, null, projectStatusFirmaPage, subprojectPrimaryKey.EntityObject, false);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(SubprojectPrimaryKey subprojectPrimaryKey, EditSubprojectProjectStatusViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
                return ViewEdit(viewModel, true, null, null, projectStatusFirmaPage, subprojectPrimaryKey.EntityObject, false);
            }
            return MakeTheNewSubprojectProjectStatus(subprojectPrimaryKey, viewModel);
        }

        private ActionResult MakeTheNewSubprojectProjectStatus(SubprojectPrimaryKey subprojectPrimaryKey, EditSubprojectProjectStatusViewModel viewModel)
        {
            var project = subprojectPrimaryKey.EntityObject;
            var projectStatusFromViewModel = new ProjectStatusPrimaryKey(viewModel.ProjectStatusID).EntityObject;
            var subprojectProjectStatus =
                SubprojectProjectStatus.CreateNewBlank(project, projectStatusFromViewModel, CurrentFirmaSession.Person);
            viewModel.UpdateModel(subprojectProjectStatus, CurrentFirmaSession);
            project.SubprojectProjectStatuses.Add(subprojectProjectStatus);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult Edit(SubprojectPrimaryKey subprojectPrimaryKey, SubprojectProjectStatusPrimaryKey subprojectProjectStatusPrimaryKey)
        {
            var subprojectProjectStatus = subprojectProjectStatusPrimaryKey.EntityObject;
            var viewModel = new EditSubprojectProjectStatusViewModel(subprojectProjectStatus);
            var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
            return ViewEdit(viewModel, true, subprojectProjectStatus.SubprojectProjectStatusCreatePerson.GetFullNameFirstLast(), subprojectProjectStatus.GetDeleteSubprojectProjectStatusUrl(), projectStatusFirmaPage, subprojectPrimaryKey.EntityObject, subprojectProjectStatus.IsFinalStatusUpdate);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(SubprojectPrimaryKey subprojectPrimaryKey, SubprojectProjectStatusPrimaryKey subprojectProjectStatusPrimaryKey, EditSubprojectProjectStatusViewModel viewModel)
        {
            var subprojectProjectStatus = subprojectProjectStatusPrimaryKey.EntityObject;
            var project = subprojectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                var projectStatusFirmaPage = FirmaPageTypeEnum.ProjectStatusFromTimelineDialog.GetFirmaPage();
                return ViewEdit(viewModel, true, subprojectProjectStatus.SubprojectProjectStatusCreatePerson.GetFullNameFirstLast(), subprojectProjectStatus.GetDeleteSubprojectProjectStatusUrl(), projectStatusFirmaPage, project, subprojectProjectStatus.IsFinalStatusUpdate);
            }
            viewModel.UpdateModel(subprojectProjectStatus, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditSubprojectProjectStatusViewModel viewModel, bool allowEditUpdateDate, string personCreatedDisplay, string deleteUrl, FirmaPage firmaPage, ProjectFirmaModels.Models.Subproject subproject, bool isFinalStatusReport)
        {
            var projectStatusFirmaPage = firmaPage;
            var allProjectStatuses = HttpRequestStorage.DatabaseEntities.ProjectStatuses.ToList();
            var projectStatusesForLegend = HttpRequestStorage.DatabaseEntities.ProjectStatuses.OrderBy(ps => ps.ProjectStatusSortOrder).ToList();
            var projectStatusLegendDisplayViewData = new ProjectStatusLegendDisplayViewData(projectStatusesForLegend);
            var viewData = new EditSubprojectProjectStatusViewData(subproject,allowEditUpdateDate, personCreatedDisplay, deleteUrl, projectStatusFirmaPage, CurrentFirmaSession, allProjectStatuses, projectStatusLegendDisplayViewData, isFinalStatusReport);
            return RazorPartialView<EditSubprojectProjectStatus, EditSubprojectProjectStatusViewData, EditSubprojectProjectStatusViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult DeleteSubprojectProjectStatus(SubprojectPrimaryKey subprojectPrimaryKey, SubprojectProjectStatusPrimaryKey subprojectProjectStatusPrimaryKey)
        {
            var subprojectProjectStatus = subprojectProjectStatusPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(subprojectProjectStatus.SubprojectProjectStatusID);
            return ViewDeleteSubprojectProjectStatus(subprojectProjectStatus, viewModel);
        }

        private PartialViewResult ViewDeleteSubprojectProjectStatus(SubprojectProjectStatus subprojectProjectStatus, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !subprojectProjectStatus.HasDependentObjects();
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete this {FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()} '{subprojectProjectStatus.Subproject.GetDisplayName()}'?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage($"{FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()}");
            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteSubprojectProjectStatus(SubprojectPrimaryKey subprojectPrimaryKey, SubprojectProjectStatusPrimaryKey subprojectProjectStatusPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var subprojectProjectStatus = subprojectProjectStatusPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteSubprojectProjectStatus(subprojectProjectStatus, viewModel);
            }
            subprojectProjectStatus.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [SubprojectViewFeature]
        public PartialViewResult Details(SubprojectPrimaryKey subprojectPrimaryKey, SubprojectProjectStatusPrimaryKey subprojectProjectStatusPrimaryKey)
        {
            var subprojectProjectStatus = subprojectProjectStatusPrimaryKey.EntityObject;
            var viewData = new SubprojectProjectStatusDetailsViewData(subprojectProjectStatus);
            return RazorPartialView<SubprojectProjectStatusDetails, SubprojectProjectStatusDetailsViewData>(viewData);
        }
    }
}