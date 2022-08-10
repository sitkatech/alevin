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
            var gridSpec = new SubprojectGridSpec();
            var Subproject = project.Subprojects.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Subproject>(Subproject, gridSpec);
            return gridJsonNetJObjectResult;
        }

        /*[UserViewFeature]
        public GridJsonNetJObjectResult<Subproject> SubprojectUserGridJsonData(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var gridSpec = new SubprojectUserGridSpec(CurrentFirmaSession);
            var Subproject = person.SubprojectWhereYouAreTheAssignedToPerson.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Subproject>(Subproject, gridSpec);
            return gridJsonNetJObjectResult;
        }
        */
        //[SubprojectAdminFeature]
        public GridJsonNetJObjectResult<Subproject> SubprojectIndexGridJsonData()
        {
            var gridSpec = new SubprojectAdminGridSpec(CurrentFirmaSession);
            var Subproject = HttpRequestStorage.DatabaseEntities.Subprojects.ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Subproject>(Subproject, gridSpec);
            return gridJsonNetJObjectResult;
        }

        //[SubprojectAdminFeature]
        //public ViewResult Index()
        //{
        //    return ViewIndex(SitkaRoute<SubprojectController>.BuildUrlFromExpression(x => x.SubprojectIndexGridJsonData()));
        //}

        //[SubprojectAdminFeature]
        //public ViewResult ViewIndex(string gridDataUrl)
        //{
        //    //var firmaPage = FirmaPageTypeEnum.SubprojectIndexList.GetFirmaPage();
        //    //var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl);
        //    //return RazorView<Index, IndexViewData>(viewData);
        //}

        [HttpGet]
        //[SubprojectCreateFeature]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            //var subproject = projectPrimaryKey.EntityObject;
            //var viewModel = new EditViewModel()
            //{
            //    SubprojecttateEnum = SubprojecttateEnum.Incomplete,
            //    ProjectID = project.ProjectID,
            //    AssignedOnDate = DateTime.Now,
            //    DueByDate = DateTime.Now
            //};

            //return ViewEdit(viewModel);
            return new ModalDialogFormJsonResult();

        }

        [HttpPost]
        [SubprojectCreateFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(ProjectPrimaryKey projectPrimaryKey, EditViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return ViewEdit(viewModel);
            //}

            /* var Subproject = new Subproject(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, DateTime.Now, DateTime.Now, ModelObjectHelpers.NotYetAssignedID);

             viewModel.UpdateModel(Subproject, CurrentFirmaSession);
             HttpRequestStorage.DatabaseEntities.AllSubproject.Add(Subproject);

             var shouldCreateProjectProjectStatus = IsNewProjectProjectStatusNeeded(Subproject);
             if (shouldCreateProjectProjectStatus)
             {
                 CreateNewProjectProjectStatus(Subproject);
             }

             SetMessageForDisplay($"Successfully added new {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()}.");*/
            return new ModalDialogFormJsonResult();
        }

        //[HttpGet]
        //[SubprojectCreateFeature]
        //public PartialViewResult NewForProjectStatus(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey)
        //{
        //    var project = projectPrimaryKey.EntityObject;
        //    var projectProjectStatus = projectProjectStatusPrimaryKey.EntityObject;

        //    var viewModel = new EditViewModel()
        //    {
        //        SubprojecttateEnum = SubprojecttateEnum.Incomplete,
        //        ProjectID = project.ProjectID,
        //        ProjectProjectStatusID = projectProjectStatus.ProjectProjectStatusID,
        //        AssignedOnDate = DateTime.Now,
        //        DueByDate = DateTime.Now
        //    };

        //    return ViewEdit(viewModel);
        //}

        //[HttpPost]
        //[SubprojectCreateFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult NewForProjectStatus(ProjectPrimaryKey projectPrimaryKey, ProjectProjectStatusPrimaryKey projectProjectStatusPrimaryKey, EditViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewEdit(viewModel);
        //    }

        //    var Subproject = new Subproject(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, DateTime.Now, DateTime.Now, ModelObjectHelpers.NotYetAssignedID);

        //    viewModel.UpdateModel(Subproject, CurrentFirmaSession);
        //    HttpRequestStorage.DatabaseEntities.AllSubproject.Add(Subproject);

        //    var shouldCreateProjectProjectStatus = IsNewProjectProjectStatusNeeded(Subproject);
        //    if (shouldCreateProjectProjectStatus)
        //    {
        //        CreateNewProjectProjectStatus(Subproject);
        //    }

        //    SetMessageForDisplay($"Successfully added new {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()}.");
        //    return new ModalDialogFormJsonResult();
        //}


        //[HttpGet]
        //[SubprojectManageFeature]
        //public PartialViewResult Edit(SubprojectPrimaryKey SubprojectPrimaryKey)
        //{
        //    var Subproject = SubprojectPrimaryKey.EntityObject;
        //    var viewModel = new EditViewModel(Subproject);
        //    return ViewEdit(viewModel);
        //}

        //private PartialViewResult ViewEdit(EditViewModel viewModel)
        //{
        //    var firmaPage = FirmaPageTypeEnum.SubprojectEditDialog.GetFirmaPage();
        //    var peopleSelectListItems = HttpRequestStorage.DatabaseEntities.People.AsEnumerable()
        //        .ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(), x => x.GetFullNameFirstLastAndOrg());

        //    var projectProjectStatuses = HttpRequestStorage.DatabaseEntities.ProjectProjectStatuses.Where(pps => pps.ProjectID == viewModel.ProjectID);
        //    var projectProjectStatusesSelectListItems = projectProjectStatuses.Any() 
        //        ? projectProjectStatuses.AsEnumerable().ToSelectListWithEmptyFirstRow(x => x.ProjectProjectStatusID.ToString(), x => x.GetDropdownDisplayName()) 
        //        : new List<SelectListItem>().AsEnumerable();

        //    var viewData = new EditViewData(CurrentFirmaSession, firmaPage, peopleSelectListItems, projectProjectStatusesSelectListItems);
        //    return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        //}

        //[HttpPost]
        //[SubprojectManageFeature]
        //[AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        //public ActionResult Edit(SubprojectPrimaryKey subprojectPrimaryKey, EditViewModel viewModel)
        //{
        //    var Subproject = subprojectPrimaryKey.EntityObject;
        //    if (!ModelState.IsValid)
        //    {
        //        return ViewEdit(viewModel);
        //    }

        //    var shouldCreateProjectProjectStatus = IsNewProjectProjectStatusNeeded(viewModel, Subproject);
        //    viewModel.UpdateModel(Subproject, CurrentFirmaSession);

        //    if (shouldCreateProjectProjectStatus)
        //    {
        //        CreateNewProjectProjectStatus(Subproject);
        //    }

        //    //SetMessageForDisplay($"Successfully edited {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()}.");
        //    return new ModalDialogFormJsonResult();
        //}

        //private static bool IsNewProjectProjectStatusNeeded(EditViewModel viewModel, Subproject subproject)
        //{
        //    var previouslyIncomplete = subproject.Subprojecttate == Subprojecttate.Incomplete;
        //    var nowComplete = (int)viewModel.SubprojecttateEnum == Subprojecttate.Complete.SubprojecttateID;

        //    return viewModel.ProjectProjectStatusID == null && previouslyIncomplete && nowComplete;
        //}

        //private static bool IsNewProjectProjectStatusNeeded(Subproject Subproject)
        //{
        //    return Subproject.ProjectProjectStatusID == null && Subproject.Subprojecttate == Subprojecttate.Complete;
        //}

        //private void CreateNewProjectProjectStatus(Subproject subproject)
        //{
        //    var project = subproject.Project;

        //    var finalStatusReport = project.ProjectProjectStatuses.Where(x => x.IsFinalStatusUpdate);
        //    if (finalStatusReport.Any())
        //    {
        //        return;
        //    }

        //    var lastStatusReport = project.ProjectProjectStatuses
        //        .OrderByDescending(x => x.ProjectProjectStatusCreateDate).FirstOrDefault();

        //    var defaultProjectStatus = HttpRequestStorage.DatabaseEntities.ProjectStatuses
        //        .OrderBy(ps => ps.ProjectStatusSortOrder).First();
        //    var projectStatus = lastStatusReport?.ProjectStatus ?? defaultProjectStatus;

        //    var projectProjectStatus = new ProjectProjectStatus(project, projectStatus, DateTime.Now,
        //        CurrentFirmaSession.Person, DateTime.Now, false);
        //    projectProjectStatus.Subproject.Add(Subproject);

        //    projectProjectStatus.ProjectProjectStatusRecentActivities =
        //        $"This is a system generated {FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} indicating the related {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()} " +
        //        $"has been marked {Subproject.Subprojecttate.SubprojecttateDisplayName} " + 
        //        $"by {CurrentFirmaSession.Person.GetFullNameFirstLastAndOrgShortName()} for this project ({project.GetDisplayName()}).";

        //    projectProjectStatus.ProjectProjectStatusComment =
        //        $"When marked {Subproject.Subprojecttate.SubprojecttateDisplayName}, the related {FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()} text read: {Subproject.SubprojectText}";

        //    project.ProjectProjectStatuses.Add(projectProjectStatus);

        //    HttpRequestStorage.DatabaseEntities.SaveChanges();
        //}

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