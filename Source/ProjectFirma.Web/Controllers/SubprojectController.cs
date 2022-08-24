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
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Subproject;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirmaModels.Models;
using Detail = ProjectFirma.Web.Views.Subproject.Detail;
using DetailViewData = ProjectFirma.Web.Views.Subproject.DetailViewData;

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
        [SubprojectManageFeature]
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
        [SubprojectManageFeature]
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
            SetMessageForDisplay($"Successfully edited Subproject {Subproject.SubprojectName}.");
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
                $"Are you sure you want to delete the Subproject {Subproject.SubprojectName}?";
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

            var message = $"Subproject {Subproject.SubprojectName} has been successfully deleted.";
            Subproject.DeleteFull(HttpRequestStorage.DatabaseEntities);
            SetMessageForDisplay(message);
            return new ModalDialogFormJsonResult();
        }

        private static List<ProjectStage> GetActiveSubprojectStages(Subproject subproject)
        {
            var activeProjectStages = new List<ProjectStage> { ProjectStage.Proposal, ProjectStage.PlanningDesign, ProjectStage.Implementation, ProjectStage.Completed, ProjectStage.PostImplementation };

            if (subproject.SubprojectStage == ProjectStage.Terminated)
            {
                activeProjectStages.Remove(ProjectStage.Implementation);
                activeProjectStages.Remove(ProjectStage.Completed);
                activeProjectStages.Remove(ProjectStage.PostImplementation);

                activeProjectStages.Add(subproject.SubprojectStage);
            }
            else if (subproject.SubprojectStage == ProjectStage.Deferred)
            {
                activeProjectStages.Add(subproject.SubprojectStage);
            }

            activeProjectStages = activeProjectStages.OrderBy(p => p.SortOrder).ToList();
            return activeProjectStages;
        }

        [SubprojectViewFeature]
        public ViewResult Detail(SubprojectPrimaryKey subprojectPrimaryKey)
        {

            var subproject = subprojectPrimaryKey.EntityObject;
            var subprojectStages = GetActiveSubprojectStages(subproject);
            var performanceMeasureExpectedsSummaryViewData = new PerformanceMeasureExpectedSummaryViewData(new List<IPerformanceMeasureValue>(subproject.SubprojectPerformanceMeasureExpecteds.OrderBy(x => x.PerformanceMeasure.PerformanceMeasureSortOrder)), true);
            var performanceMeasureReportedValuesGroupedViewData = BuildPerformanceMeasureReportedValuesGroupedViewData(subproject);
            var editPerformanceMeasureExpectedsUrl = SitkaRoute<SubprojectPerformanceMeasureExpectedController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureExpectedsForSubproject(subproject));
            bool userHasEditSubprojectPermissions = new SubprojectManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);

            var editPerformanceMeasureActualsUrl = SitkaRoute<SubprojectPerformanceMeasureActualController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureActualsForProject(subproject));

            var subprojectBasicsViewData = new SubprojectBasicsViewData(subproject, false);
           
            var viewData = new DetailViewData(CurrentFirmaSession,
                subproject,
                subprojectStages,
                subprojectBasicsViewData,
                userHasEditSubprojectPermissions,
                editPerformanceMeasureExpectedsUrl,
                editPerformanceMeasureActualsUrl,
                performanceMeasureExpectedsSummaryViewData,
                performanceMeasureReportedValuesGroupedViewData);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        private static PerformanceMeasureReportedValuesGroupedViewData BuildPerformanceMeasureReportedValuesGroupedViewData(Subproject subproject)
        {
            var performanceMeasureReportedValues = subproject.GetPerformanceMeasureReportedValues();
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(performanceMeasureReportedValues.OrderBy(x => x.PerformanceMeasure.GetSortOrder()).ThenBy(x => x.PerformanceMeasure.GetDisplayName())));
            var performanceMeasureReportedValuesGroupedViewData = new PerformanceMeasureReportedValuesGroupedViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                performanceMeasureReportedValues.Select(x => x.CalendarYear).Distinct().Select(x => new CalendarYearString(x)).ToList(),
                false);
            return performanceMeasureReportedValuesGroupedViewData;
        }

    }
}