using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectPerformanceMeasureExpectedController : FirmaBaseController
    {
        [HttpGet]
        [SubprojectManageFeature]
        public PartialViewResult EditPerformanceMeasureExpectedsForSubproject(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            var subprojectPerformanceMeasureExpectedSimples = subproject.SubprojectPerformanceMeasureExpecteds.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(x=>x.PerformanceMeasure.GetDisplayName()).Select(x => new PerformanceMeasureExpectedSimple(x)).ToList();
            var viewModel = new EditPerformanceMeasureExpectedViewModel(subprojectPerformanceMeasureExpectedSimples);
            return ViewEditPerformanceMeasureExpecteds(subproject, viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureExpectedsForSubproject(SubprojectPrimaryKey subprojectPrimaryKey, EditPerformanceMeasureExpectedViewModel viewModel)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPerformanceMeasureExpecteds(subproject, viewModel);
            }
            var currentPerformanceMeasureExpecteds = subproject.SubprojectPerformanceMeasureExpecteds.ToList();
            return UpdatePerformanceMeasureExpecteds(viewModel, currentPerformanceMeasureExpecteds, subproject);
        }

        private static ActionResult UpdatePerformanceMeasureExpecteds(EditPerformanceMeasureExpectedViewModel viewModel, List<SubprojectPerformanceMeasureExpected> currentPerformanceMeasureExpecteds, Subproject subproject)
        {
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureExpecteds.Load();
            var allPerformanceMeasureExpecteds = HttpRequestStorage.DatabaseEntities.AllSubprojectPerformanceMeasureExpecteds.Local;
            HttpRequestStorage.DatabaseEntities.SubprojectPerformanceMeasureExpectedSubcategoryOptions.Load();
            var allPerformanceMeasureExpectedSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllSubprojectPerformanceMeasureExpectedSubcategoryOptions.Local;
            viewModel.UpdateModel(currentPerformanceMeasureExpecteds, allPerformanceMeasureExpecteds, allPerformanceMeasureExpectedSubcategoryOptions, subproject);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPerformanceMeasureExpecteds(Subproject subproject, EditPerformanceMeasureExpectedViewModel viewModel)
        {
            var performanceMeasures = PerformanceMeasureModelExtensions.GetReportablePerformanceMeasures().ToList();
            var configurePerformanceMeasuresUrl = string.Empty;
            if (new PerformanceMeasureManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession))
            {
                configurePerformanceMeasuresUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Manage());
            }
            var viewData = new EditPerformanceMeasureExpectedViewData(performanceMeasures, true, configurePerformanceMeasuresUrl);
            return RazorPartialView<EditPerformanceMeasureExpected, EditPerformanceMeasureExpectedViewData, EditPerformanceMeasureExpectedViewModel>(viewData, viewModel);

        }
    }
}