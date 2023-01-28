using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ActionItem;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ActionItemController : FirmaBaseController
    {
        [ActionItemViewFeature]
        public GridJsonNetJObjectResult<ActionItem> ActionItemsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var gridSpec = new ActionItemsGridSpec(CurrentFirmaSession);
            var actionItems = project.ActionItems.OrderByDescending(x => x.DueByDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ActionItem>(actionItems, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [UserViewFeature]
        public GridJsonNetJObjectResult<ActionItem> ActionItemsUserGridJsonData(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var gridSpec = new ActionItemsUserGridSpec(CurrentFirmaSession);
            var actionItems = person.ActionItemsWhereYouAreTheAssignedToPerson.OrderByDescending(x => x.DueByDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ActionItem>(actionItems, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ActionItemAdminFeature]
        public GridJsonNetJObjectResult<ActionItem> ActionItemsIndexGridJsonData()
        {
            var gridSpec = new ActionItemsAdminGridSpec(CurrentFirmaSession);
            var actionItems = HttpRequestStorage.DatabaseEntities.ActionItems.OrderByDescending(x => x.DueByDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ActionItem>(actionItems, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [ActionItemAdminFeature]
        public ViewResult Index()
        {
            var actionItemsGridDataUrl = SitkaRoute<ActionItemController>.BuildUrlFromExpression(x => x.ActionItemsIndexGridJsonData());
            var subprojectActionItemGridDataUrl = SitkaRoute<SubprojectActionItemController>.BuildUrlFromExpression(x => x.SubprojectActionItemsIndexGridJsonData());
            return ViewIndex(actionItemsGridDataUrl, subprojectActionItemGridDataUrl);
        }

        [ActionItemAdminFeature]
        public ViewResult ViewIndex(string gridDataUrl, string subprojectActionItemGridDataUrl)
        {
            var firmaPage = FirmaPageTypeEnum.ActionItemIndexList.GetFirmaPage();
            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl, subprojectActionItemGridDataUrl);
            return RazorView<Index, IndexViewData>(viewData);
        }
        
        [HttpGet]
        [ActionItemCreateFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditViewModel()
            {
                ActionItemStateEnum = ActionItemStateEnum.Incomplete,
                ProjectID = project.ProjectID,
                AssignedOnDate =  DateTime.Now,
                DueByDate = DateTime.Now
            };
            
            return ViewEdit(viewModel);
        }
        
        [HttpPost]
        [ActionItemCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            
            var actionItem = new ActionItem(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, DateTime.Now, DateTime.Now, ModelObjectHelpers.NotYetAssignedID);

            viewModel.UpdateModel(actionItem, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllActionItems.Add(actionItem);

            var shouldCreateProjectProjectStatus = IsNewProjectProjectStatusNeeded(actionItem);
            if (shouldCreateProjectProjectStatus)
            {
                CreateNewProjectProjectStatus(actionItem);
            }

            SetMessageForDisplay($"Successfully added new {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()}.");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [ActionItemCreateFeature]
        public PartialViewResult NewForProjectStatus(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;

            var viewModel = new EditViewModel()
            {
                ActionItemStateEnum = ActionItemStateEnum.Incomplete,
                ProjectID = project.ProjectID,
                ProjectProjectStatusID = projectProjectStatus.ProjectProjectStatusID,
                AssignedOnDate = DateTime.Now,
                DueByDate = DateTime.Now
            };

            return ViewEdit(viewModel);
        }

        [HttpPost]
        [ActionItemCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewForProjectStatus(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var actionItem = new ActionItem(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, DateTime.Now, DateTime.Now, ModelObjectHelpers.NotYetAssignedID);

            viewModel.UpdateModel(actionItem, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllActionItems.Add(actionItem);

            var shouldCreateProjectProjectStatus = IsNewProjectProjectStatusNeeded(actionItem);
            if (shouldCreateProjectProjectStatus)
            {
                CreateNewProjectProjectStatus(actionItem);
            }

            SetMessageForDisplay($"Successfully added new {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()}.");
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [ActionItemManageFeature]
        public PartialViewResult Edit(ActionItemPrimaryKey actionItemPrimaryKey)
        {
            var actionItem = actionItemPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(actionItem);
            return ViewEdit(viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.ActionItemEditDialog.GetFirmaPage();
            var peopleSelectListItems = HttpRequestStorage.DatabaseEntities.People.AsEnumerable()
                .ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(), x => x.GetFullNameFirstLastAndOrg());

            var projectProjectStatuses = HttpRequestStorage.DatabaseEntities.ProjectProjectStatuses.Where(pps => pps.ProjectID == viewModel.ProjectID);
            var projectProjectStatusesSelectListItems = projectProjectStatuses.Any() 
                ? projectProjectStatuses.AsEnumerable().ToSelectListWithEmptyFirstRow(x => x.ProjectProjectStatusID.ToString(), x => x.GetDropdownDisplayName()) 
                : new List<SelectListItem>().AsEnumerable();

            var viewData = new EditViewData(CurrentFirmaSession, firmaPage, peopleSelectListItems, projectProjectStatusesSelectListItems);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ActionItemManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ActionItemPrimaryKey actionItemPrimaryKey, EditViewModel viewModel)
        {
            var actionItem = actionItemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var shouldCreateProjectProjectStatus = IsNewProjectProjectStatusNeeded(viewModel, actionItem);
            viewModel.UpdateModel(actionItem, CurrentFirmaSession);

            if (shouldCreateProjectProjectStatus)
            {
                CreateNewProjectProjectStatus(actionItem);
            }

            SetMessageForDisplay($"Successfully edited {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()}.");
            return new ModalDialogFormJsonResult();
        }

        private static bool IsNewProjectProjectStatusNeeded(EditViewModel viewModel, ActionItem actionItem)
        {
            var previouslyIncomplete = actionItem.ActionItemState == ActionItemState.Incomplete;
            var nowComplete = (int)viewModel.ActionItemStateEnum == ActionItemState.Complete.ActionItemStateID;

            return viewModel.ProjectProjectStatusID == null && previouslyIncomplete && nowComplete;
        }

        private static bool IsNewProjectProjectStatusNeeded(ActionItem actionItem)
        {
            return actionItem.ProjectProjectStatusID == null && actionItem.ActionItemState == ActionItemState.Complete;
        }

        private void CreateNewProjectProjectStatus(ActionItem actionItem)
        {
            var project = actionItem.Project;

            var finalStatusReport = project.ProjectProjectStatuses.Where(x => x.IsFinalStatusUpdate);
            if (finalStatusReport.Any())
            {
                return;
            }

            var lastStatusReport = project.ProjectProjectStatuses
                .OrderByDescending(x => x.ProjectProjectStatusCreateDate).FirstOrDefault();

            var defaultProjectStatus = HttpRequestStorage.DatabaseEntities.ProjectStatuses
                .OrderBy(ps => ps.ProjectStatusSortOrder).First();
            var projectStatus = lastStatusReport?.ProjectStatus ?? defaultProjectStatus;

            var projectProjectStatus = new ProjectProjectStatus(project, projectStatus, DateTime.Now,
                CurrentFirmaSession.Person, DateTime.Now, false);
            projectProjectStatus.ActionItems.Add(actionItem);

            projectProjectStatus.ProjectProjectStatusRecentActivities =
                $"This is a system generated {FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} indicating the related {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()} " +
                $"has been marked {actionItem.ActionItemState.ActionItemStateDisplayName} " + 
                $"by {CurrentFirmaSession.Person.GetFullNameFirstLastAndOrgShortName()} for this project ({project.GetDisplayName()}).";

            projectProjectStatus.ProjectProjectStatusComment =
                $"When marked {actionItem.ActionItemState.ActionItemStateDisplayName}, the related {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()} text read: {actionItem.ActionItemText}";

            project.ProjectProjectStatuses.Add(projectProjectStatus);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
        }

        [HttpGet]
        [ActionItemManageFeature]
        public PartialViewResult Delete(ActionItemPrimaryKey actionItemPrimaryKey)
        {
            var actionItem = actionItemPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(actionItem.ActionItemID);
            return ViewDelete(actionItem, viewModel);
        }

        private PartialViewResult ViewDelete(ActionItem actionItem, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage =
                $"Are you sure you want to delete this {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()} assigned to \"{actionItem.AssignedToPerson.GetFullNameFirstLastAndOrg()}\"?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ActionItemManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(ActionItemPrimaryKey actionItemPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var actionItem = actionItemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(actionItem, viewModel);
            }

            var message = $"{FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()} successfully deleted.";
            actionItem.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

    }
}