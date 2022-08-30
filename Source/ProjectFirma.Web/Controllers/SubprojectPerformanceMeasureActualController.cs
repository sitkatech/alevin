/*-----------------------------------------------------------------------
<copyright file="SubprojectPerformanceMeasureActualController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureActual;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectPerformanceMeasureActualController : FirmaBaseController
    {

        [HttpGet]
        [PerformanceMeasureActualFromSubprojectManageFeature]
        public PartialViewResult EditPerformanceMeasureActualsForSubproject(SubprojectPrimaryKey subprojectPrimaryKey)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            var expectedPerformanceMeasures = subproject.SubprojectPerformanceMeasureExpecteds;
            var reportedPerformanceMeasures = subproject.SubprojectPerformanceMeasureActuals;
            var performanceMeasureActualSimples = new List<PerformanceMeasureActualSimple>();

            if (reportedPerformanceMeasures.Any())
            {
                performanceMeasureActualSimples =
                    subproject.SubprojectPerformanceMeasureActuals.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder).ThenBy(x => x.PerformanceMeasure.GetDisplayName())
                        .ThenByDescending(x => x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear)
                        .Select(x => new PerformanceMeasureActualSimple(x))
                        .ToList();
            }


            var viewModel = new EditPerformanceMeasureActualsViewModel(performanceMeasureActualSimples,
                "",
                new List<ProjectExemptReportingYearSimple>()
                );
            return ViewEditPerformanceMeasureActuals(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureActualFromSubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureActualsForSubproject(SubprojectPrimaryKey subprojectPrimaryKey, EditPerformanceMeasureActualsViewModel viewModel)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPerformanceMeasureActuals(viewModel);
            }
            var currentPerformanceMeasureActuals = subproject.SubprojectPerformanceMeasureActuals.ToList();
            return UpdatePerformanceMeasureActuals(viewModel, currentPerformanceMeasureActuals, subproject);
        }

        private static ActionResult UpdatePerformanceMeasureActuals(EditPerformanceMeasureActualsViewModel viewModel,
            List<SubprojectPerformanceMeasureActual> currentPerformanceMeasureActuals,
            Subproject subproject)
        {
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActuals.Load();
            var allPerformanceMeasureActuals = HttpRequestStorage.DatabaseEntities.AllSubprojectPerformanceMeasureActuals.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureActualSubcategoryOptions.Load();
            var allPerformanceMeasureActualSubcategoryOptions = HttpRequestStorage.DatabaseEntities.AllSubprojectPerformanceMeasureActualSubcategoryOptions.Local;
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.Load();
            var allPerformanceMeasureReportingPeriods = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Local;
            viewModel.UpdateModel(currentPerformanceMeasureActuals, allPerformanceMeasureActuals, allPerformanceMeasureActualSubcategoryOptions, subproject, allPerformanceMeasureReportingPeriods);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPerformanceMeasureActuals(EditPerformanceMeasureActualsViewModel viewModel)
        {
            var performanceMeasures = PerformanceMeasureModelExtensions.GetReportablePerformanceMeasures().ToList();
            var showExemptYears = false;//Exempt years does not apply to subprojects
            var viewData = new EditPerformanceMeasureActualsViewData(performanceMeasures, showExemptYears);
            return RazorPartialView<EditPerformanceMeasureActuals, EditPerformanceMeasureActualsViewData, EditPerformanceMeasureActualsViewModel>(viewData, viewModel);
        }
    }
}
