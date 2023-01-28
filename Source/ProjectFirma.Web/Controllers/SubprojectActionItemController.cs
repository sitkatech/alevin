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
using ProjectFirma.Web.Views.SubprojectActionItem;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectActionItemController : FirmaBaseController
    {
        [SubprojectActionItemViewFeature]
        public GridJsonNetJObjectResult<SubprojectActionItem> SubprojectActionItemsGridJsonData(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            var gridSpec = new SubprojectActionItemsGridSpec(CurrentFirmaSession);
            var actionItems = subproject.SubprojectActionItems.OrderByDescending(x => x.DueByDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<SubprojectActionItem>(actionItems, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [UserViewFeature]
        public GridJsonNetJObjectResult<SubprojectActionItem> SubprojectActionItemsUserGridJsonData(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var gridSpec = new SubprojectActionItemsUserGridSpec(CurrentFirmaSession);
            var actionItems = person.SubprojectActionItemsWhereYouAreTheAssignedToPerson.OrderByDescending(x => x.DueByDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<SubprojectActionItem>(actionItems, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [SubprojectActionItemAdminFeature]
        public GridJsonNetJObjectResult<SubprojectActionItem> SubprojectActionItemsIndexGridJsonData()
        {
            var gridSpec = new SubprojectActionItemsAdminGridSpec(CurrentFirmaSession);
            var actionItems = HttpRequestStorage.DatabaseEntities.SubprojectActionItems.OrderByDescending(x => x.DueByDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<SubprojectActionItem>(actionItems, gridSpec);
            return gridJsonNetJObjectResult;
        }


        
        [HttpGet]
        [SubprojectActionItemCreateFeature]
        public PartialViewResult New(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            var viewModel = new EditViewModel()
            {
                ActionItemStateEnum = ActionItemStateEnum.Incomplete,
                SubprojectID = subproject.SubprojectID,
                AssignedOnDate =  DateTime.Now,
                DueByDate = DateTime.Now
            };
            
            return ViewEdit(viewModel);
        }
        
        [HttpPost]
        [SubprojectActionItemCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(SubprojectPrimaryKey subprojectPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            
            var actionItem = new SubprojectActionItem(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, DateTime.Now, DateTime.Now, ModelObjectHelpers.NotYetAssignedID);

            viewModel.UpdateModel(actionItem, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllSubprojectActionItems.Add(actionItem);

            var shouldCreateProjectProjectStatus = IsNewSubprojectProjectStatusNeeded(actionItem);
            if (shouldCreateProjectProjectStatus)
            {
                CreateNewSubprojectProjectStatus(actionItem);
            }

            SetMessageForDisplay($"Successfully added new {FieldDefinitionEnum.SubprojectActionItem.ToType().GetFieldDefinitionLabel()}.");
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [SubprojectActionItemCreateFeature]
        public PartialViewResult NewForSubprojectStatus(SubprojectPrimaryKey subprojectPrimaryKey, SubprojectProjectStatusPrimaryKey subprojectProjectStatusPrimaryKey)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            var subprojectProjectStatus = subprojectProjectStatusPrimaryKey.EntityObject;

            var viewModel = new EditViewModel()
            {
                ActionItemStateEnum = ActionItemStateEnum.Incomplete,
                SubprojectID = subproject.SubprojectID,
                SubprojectProjectStatusID = subprojectProjectStatus.SubprojectProjectStatusID,
                AssignedOnDate = DateTime.Now,
                DueByDate = DateTime.Now
            };

            return ViewEdit(viewModel);
        }

        [HttpPost]
        [SubprojectActionItemCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult NewForSubprojectStatus(SubprojectPrimaryKey subprojectPrimaryKey, SubprojectProjectStatusPrimaryKey subprojectProjectStatusPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var actionItem = new SubprojectActionItem(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, DateTime.Now, DateTime.Now, ModelObjectHelpers.NotYetAssignedID);

            viewModel.UpdateModel(actionItem, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllSubprojectActionItems.Add(actionItem);

            var shouldCreateProjectProjectStatus = IsNewSubprojectProjectStatusNeeded(actionItem);
            if (shouldCreateProjectProjectStatus)
            {
                CreateNewSubprojectProjectStatus(actionItem);
            }

            SetMessageForDisplay($"Successfully added new {FieldDefinitionEnum.SubprojectActionItem.ToType().GetFieldDefinitionLabel()}.");
            return new ModalDialogFormJsonResult();
        }


        [HttpGet]
        [SubprojectActionItemManageFeature]
        public PartialViewResult Edit(SubprojectActionItemPrimaryKey subprojectActionItemPrimaryKey)
        {
            var actionItem = subprojectActionItemPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(actionItem);
            return ViewEdit(viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.SubprojectActionItemEditDialog.GetFirmaPage();
            var peopleSelectListItems = HttpRequestStorage.DatabaseEntities.People.AsEnumerable()
                .ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(), x => PersonModelExtensions.GetFullNameFirstLastAndOrg(x));

            var projectProjectStatuses = HttpRequestStorage.DatabaseEntities.SubprojectProjectStatuses.Where(pps => pps.SubprojectID == viewModel.SubprojectID);
            var projectProjectStatusesSelectListItems = projectProjectStatuses.Any() 
                ? projectProjectStatuses.AsEnumerable().ToSelectListWithEmptyFirstRow(x => x.SubprojectProjectStatusID.ToString(), x => x.GetDropdownDisplayName()) 
                : new List<SelectListItem>().AsEnumerable();

            var viewData = new EditViewData(CurrentFirmaSession, firmaPage, peopleSelectListItems, projectProjectStatusesSelectListItems);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SubprojectActionItemManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(SubprojectActionItemPrimaryKey subprojectActionItemPrimaryKey, EditViewModel viewModel)
        {
            var actionItem = subprojectActionItemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }

            var shouldCreateProjectProjectStatus = IsNewSubprojectProjectStatusNeeded(viewModel, actionItem);
            viewModel.UpdateModel(actionItem, CurrentFirmaSession);

            if (shouldCreateProjectProjectStatus)
            {
                CreateNewSubprojectProjectStatus(actionItem);
            }

            SetMessageForDisplay($"Successfully edited {FieldDefinitionEnum.SubprojectActionItem.ToType().GetFieldDefinitionLabel()}.");
            return new ModalDialogFormJsonResult();
        }

        private static bool IsNewSubprojectProjectStatusNeeded(EditViewModel viewModel, SubprojectActionItem actionItem)
        {
            var previouslyIncomplete = actionItem.ActionItemState == ActionItemState.Incomplete;
            var nowComplete = (int)viewModel.ActionItemStateEnum == ActionItemState.Complete.ActionItemStateID;

            return viewModel.SubprojectProjectStatusID == null && previouslyIncomplete && nowComplete;
        }

        private static bool IsNewSubprojectProjectStatusNeeded(SubprojectActionItem actionItem)
        {
            return actionItem.SubprojectProjectStatusID == null && actionItem.ActionItemState == ActionItemState.Complete;
        }

        private void CreateNewSubprojectProjectStatus(SubprojectActionItem actionItem)
        {
            var subproject = actionItem.Subproject;

            var finalStatusReport = subproject.SubprojectProjectStatuses.Where(x => x.IsFinalStatusUpdate);
            if (finalStatusReport.Any())
            {
                return;
            }

            var lastStatusReport = subproject.SubprojectProjectStatuses
                .OrderByDescending(x => x.SubprojectProjectStatusCreateDate).FirstOrDefault();

            var defaultProjectStatus = HttpRequestStorage.DatabaseEntities.ProjectStatuses
                .OrderBy(ps => ps.ProjectStatusSortOrder).First();
            var projectStatus = lastStatusReport?.ProjectStatus ?? defaultProjectStatus;

            var projectProjectStatus = new SubprojectProjectStatus(subproject, projectStatus, DateTime.Now,
                CurrentFirmaSession.Person, DateTime.Now, false);
            projectProjectStatus.SubprojectActionItems.Add(actionItem);

            projectProjectStatus.SubprojectProjectStatusRecentActivities =
                $"This is a system generated {FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} indicating the related {FieldDefinitionEnum.SubprojectActionItem.ToType().GetFieldDefinitionLabel()} " +
                $"has been marked {actionItem.ActionItemState.ActionItemStateDisplayName} " + 
                $"by {CurrentFirmaSession.Person.GetFullNameFirstLastAndOrgShortName()} for this subproject ({subproject.GetDisplayName()}).";

            projectProjectStatus.SubprojectProjectStatusComment =
                $"When marked {actionItem.ActionItemState.ActionItemStateDisplayName}, the related {FieldDefinitionEnum.SubprojectActionItem.ToType().GetFieldDefinitionLabel()} text read: {actionItem.SubprojectActionItemText}";

            subproject.SubprojectProjectStatuses.Add(projectProjectStatus);

            HttpRequestStorage.DatabaseEntities.SaveChanges();
        }

        [HttpGet]
        [SubprojectActionItemManageFeature]
        public PartialViewResult Delete(SubprojectActionItemPrimaryKey subprojectActionItemPrimaryKey)
        {
            var actionItem = subprojectActionItemPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(actionItem.SubprojectActionItemID);
            return ViewDelete(actionItem, viewModel);
        }

        private PartialViewResult ViewDelete(SubprojectActionItem subprojectActionItem, ConfirmDialogFormViewModel viewModel)
        {
            var confirmMessage =
                $"Are you sure you want to delete this {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()} assigned to \"{subprojectActionItem.AssignedToPerson.GetFullNameFirstLastAndOrg()}\"?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [SubprojectActionItemManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(SubprojectActionItemPrimaryKey subprojectActionItemPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var actionItem = subprojectActionItemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(actionItem, viewModel);
            }

            var message = $"{FieldDefinitionEnum.SubprojectActionItem.ToType().GetFieldDefinitionLabel()} successfully deleted.";
            actionItem.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

    }
}