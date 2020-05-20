﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.ProjectCustomAttributeType;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectCustomAttributeTypeController : FirmaBaseController
    {
        [FirmaAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ManageProjectCustomAttributeTypesList.GetFirmaPage();
            var viewData = new ManageViewData(CurrentFirmaSession, firmaPage);
            return RazorView<Manage, ManageViewData>(viewData);
        }

        [FirmaAdminFeature]
        public GridJsonNetJObjectResult<ProjectCustomAttributeType> ProjectCustomAttributeTypeGridJsonData()
        {
            var projectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().OrderBy(x => x.ProjectCustomAttributeTypeName).ToList();
            var gridSpec = new ProjectCustomAttributeTypeGridSpec();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ProjectCustomAttributeType>(projectCustomAttributeTypes, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ContentResult Description(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            return Content(projectCustomAttributeTypePrimaryKey.EntityObject.ProjectCustomAttributeTypeDescription);
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult New()
        {
            var viewModel = new EditViewModel();
            return ViewEdit(viewModel, null);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, null);
            }

            ProjectCustomAttributeGroupPrimaryKey projectCustomAttributeGroupPrimaryKey = viewModel.ProjectCustomAttributeGroupID;
            var projectCustomAttributeGroup = projectCustomAttributeGroupPrimaryKey.EntityObject;
            var projectCustomAttributeType = new ProjectCustomAttributeType(String.Empty, ProjectCustomAttributeDataType.String, false, false, projectCustomAttributeGroup);
            viewModel.UpdateModel(projectCustomAttributeType, CurrentFirmaSession);
            HttpRequestStorage.DatabaseEntities.AllProjectCustomAttributeTypes.Add(projectCustomAttributeType);
            HttpRequestStorage.DatabaseEntities.SaveChanges();
            SetMessageForDisplay($"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} {projectCustomAttributeType.ProjectCustomAttributeTypeName} successfully created.");
            SetWarningAboutHiddenRequiredAttributesIfNeeded(projectCustomAttributeType);
            

            return new ModalDialogFormJsonResult();
        }

        private void SetWarningAboutHiddenRequiredAttributesIfNeeded(ProjectCustomAttributeType projectCustomAttributeType)
        {
            var normalRoleDoesntExistOnAttribute = !projectCustomAttributeType.ProjectCustomAttributeTypeRoles.Any(x => x.Role == Role.Normal && x.ProjectCustomAttributeTypeRolePermissionType == ProjectCustomAttributeTypeRolePermissionType.Edit);
            if (projectCustomAttributeType.IsRequired &&
                normalRoleDoesntExistOnAttribute)
            {
                SetWarningForDisplay(
                    $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} {projectCustomAttributeType.ProjectCustomAttributeTypeName} is marked as required, but is not editable " +
                    $"by normal users. This may cause users to get blocked from completing the workflow for a new {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}. You should consider allowing" +
                    $" normal users to edit {FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} {projectCustomAttributeType.ProjectCustomAttributeTypeName} or making it not required.");
            }
        }

        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult Edit(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            var viewModel = new EditViewModel(projectCustomAttributeType);
            return ViewEdit(viewModel, projectCustomAttributeType);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey, EditViewModel viewModel)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel, projectCustomAttributeType);
            }
            viewModel.UpdateModel(projectCustomAttributeType, CurrentFirmaSession);
            SetWarningAboutHiddenRequiredAttributesIfNeeded(projectCustomAttributeType);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, ProjectCustomAttributeType projectCustomAttributeType)
        {
            var instructionsFirmaPage = FirmaPageTypeEnum.ManageProjectCustomAttributeTypeInstructions.GetFirmaPage();
            var submitUrl = ModelObjectHelpers.IsRealPrimaryKeyValue(viewModel.ProjectCustomAttributeTypeID)
                ? SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.Edit(viewModel.ProjectCustomAttributeTypeID))
                : SitkaRoute<ProjectCustomAttributeTypeController>.BuildUrlFromExpression(x => x.New());
            var allProjectCustomAttributeGroups =
                HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups.ToList();
            var viewData = new EditViewData(CurrentFirmaSession, MeasurementUnitType.All, ProjectCustomAttributeDataType.All, Role.All, 
                submitUrl, instructionsFirmaPage, projectCustomAttributeType, allProjectCustomAttributeGroups);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [FirmaAdminFeature]
        public ViewResult Detail(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentFirmaSession, projectCustomAttributeType);
            return RazorView<Detail, DetailViewData>(viewData);
        }


        [HttpGet]
        [FirmaAdminFeature]
        public PartialViewResult DeleteProjectCustomAttributeType(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(projectCustomAttributeType.ProjectCustomAttributeTypeID);
            return ViewDeleteProjectCustomAttributeType(projectCustomAttributeType, viewModel);
        }

        private PartialViewResult ViewDeleteProjectCustomAttributeType(ProjectCustomAttributeType projectCustomAttributeType, ConfirmDialogFormViewModel viewModel)
        {
            var viewData = new ConfirmDialogFormViewData($"Are you sure you want to delete {FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} \"{projectCustomAttributeType.ProjectCustomAttributeTypeName}\"?", true);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteProjectCustomAttributeType(ProjectCustomAttributeTypePrimaryKey projectCustomAttributeTypePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var projectCustomAttributeType = projectCustomAttributeTypePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteProjectCustomAttributeType(projectCustomAttributeType, viewModel);
            }

            var message = $"{FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} '{projectCustomAttributeType.ProjectCustomAttributeTypeName}' successfully deleted!";
            projectCustomAttributeType.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }



        [FirmaAdminFeature]
        public PartialViewResult EditSortOrder()
        {
            var projectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups;
            EditSortOrderInGroupViewModel viewModel = new EditSortOrderInGroupViewModel();
            return ViewEditSortOrder(projectCustomAttributeGroups, viewModel);
        }

        private PartialViewResult ViewEditSortOrder(IQueryable<ProjectCustomAttributeGroup> projectCustomAttributeGroups, EditSortOrderInGroupViewModel viewModel)
        {
            EditSortOrderInGroupViewData viewData = new EditSortOrderInGroupViewData(new List<ISortingGroup>(projectCustomAttributeGroups), FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabelPluralized());
            return RazorPartialView<EditSortOrderInGroup, EditSortOrderInGroupViewData, EditSortOrderInGroupViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [FirmaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditSortOrder(EditSortOrderInGroupViewModel viewModel)
        {
            var projectCustomAttributeGroups = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeGroups;


            if (!ModelState.IsValid)
            {
                return ViewEditSortOrder(projectCustomAttributeGroups, viewModel);
            }

            viewModel.UpdateModel(new List<ISortingGroup>(projectCustomAttributeGroups));
            SetMessageForDisplay($"Successfully Updated {FieldDefinitionEnum.ProjectCustomAttribute.ToType().GetFieldDefinitionLabel()} Sort Order");
            return new ModalDialogFormJsonResult();
        }

    }
}
