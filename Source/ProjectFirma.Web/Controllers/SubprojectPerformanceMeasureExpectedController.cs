/*-----------------------------------------------------------------------
<copyright file="SubprojectPerformanceMeasureExpectedController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
            return ViewEditPerformanceMeasureExpecteds(viewModel);
        }

        [HttpPost]
        [SubprojectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureExpectedsForSubproject(SubprojectPrimaryKey subprojectPrimaryKey, EditPerformanceMeasureExpectedViewModel viewModel)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPerformanceMeasureExpecteds(viewModel);
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

        private PartialViewResult ViewEditPerformanceMeasureExpecteds(EditPerformanceMeasureExpectedViewModel viewModel)
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