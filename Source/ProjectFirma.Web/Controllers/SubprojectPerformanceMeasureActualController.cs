﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.PerformanceMeasureActual;
using ProjectFirma.Web.Views.Shared.SortOrder;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Controllers
{
    public class SubprojectPerformanceMeasureActualController : FirmaBaseController
    {

        private void PrePopulateReportedPerformanceMeasures(Subproject subproject, ICollection<SubprojectPerformanceMeasureExpected> expectedPerformanceMeasures,
            List<PerformanceMeasureActualSimple> performanceMeasureActualSimples)
        {
            var sortedExpectedPerformanceMeasures =  expectedPerformanceMeasures.OrderBy(pam => pam.PerformanceMeasure.PerformanceMeasureSortOrder)
                .ThenBy(x => x.PerformanceMeasure.GetDisplayName()).ToList();
            var yearRange = subproject.GetProjectUpdateImplementationStartToCompletionYearRange();
            var reportingPeriods = HttpRequestStorage.DatabaseEntities.PerformanceMeasureReportingPeriods.ToList();
            var performanceMeasureActualIDToUse = -1;
            foreach (var calendarYear in yearRange)
            {
                var reportingPeriod =
                    reportingPeriods.SingleOrDefault(x => x.PerformanceMeasureReportingPeriodCalendarYear == calendarYear);
                if (reportingPeriod == null)
                {
                    var newPerformanceMeasureReportingPeriod =
                        new PerformanceMeasureReportingPeriod(calendarYear, calendarYear.ToString());
                    HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureReportingPeriods.Add(
                        newPerformanceMeasureReportingPeriod);
                    HttpRequestStorage.DatabaseEntities.SaveChanges(CurrentFirmaSession);
                }

                foreach (var sortedExpectedPerformanceMeasure in sortedExpectedPerformanceMeasures)
                {
                    var performanceMeasureActual = new PerformanceMeasureActualSimple(sortedExpectedPerformanceMeasure,
                        calendarYear, performanceMeasureActualIDToUse);
                    performanceMeasureActualSimples.Add(performanceMeasureActual);
                    performanceMeasureActualIDToUse--;
                }
            }
        }

        [HttpGet]
        [PerformanceMeasureActualFromProjectManageFeature]
        public PartialViewResult EditPerformanceMeasureActualsForProject(SubprojectPrimaryKey subprojectPrimaryKey)
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
            else
            {
                PrePopulateReportedPerformanceMeasures(subproject, expectedPerformanceMeasures, performanceMeasureActualSimples);
            }


            //var projectExemptReportingYears = subproject.GetPerformanceMeasuresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList();
            //var currentExemptedYears = projectExemptReportingYears.Select(x => x.CalendarYear).ToList();
            //var endYear = DateTime.Now.Year;
            //var startYear = subproject.ImplementationStartYear ?? endYear;
            //var possibleYearsToExempt = FirmaDateUtilities.GetRangeOfYears(startYear, endYear).OrderBy(x => x).ToList();
            //projectExemptReportingYears.AddRange(
            //    possibleYearsToExempt.Where(x => !currentExemptedYears.Contains(x)).Select((x, index) => new ProjectExemptReportingYearSimple(-(index + 1), subproject.SubprojectID, x)));

            var viewModel = new EditPerformanceMeasureActualsViewModel(performanceMeasureActualSimples//,
                //subproject.PerformanceMeasureActualYearsExemptionExplanation,
                //projectExemptReportingYears.OrderBy(x => x.CalendarYear).ToList()
                );
            return ViewEditPerformanceMeasureActuals(subproject, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureActualFromProjectManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureActualsForProject(SubprojectPrimaryKey subprojectPrimaryKey, EditPerformanceMeasureActualsViewModel viewModel)
        {
            var subproject = subprojectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPerformanceMeasureActuals(subproject, viewModel);
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

        private PartialViewResult ViewEditPerformanceMeasureActuals(Subproject subproject, EditPerformanceMeasureActualsViewModel viewModel)
        {
            var performanceMeasures = PerformanceMeasureModelExtensions.GetReportablePerformanceMeasures().ToList().SortByOrderThenName().ToList();
            //var showExemptYears = subproject.GetPerformanceMeasuresExemptReportingYears().Any() ||
                                  //ModelState.Values.SelectMany(x => x.Errors)
                                  //    .Any(
                                  //        x =>
                                  //            x.ErrorMessage == FirmaValidationMessages.ExplanationNotNecessaryForProjectExemptYears ||
                                  //            x.ErrorMessage == FirmaValidationMessages.ExplanationNecessaryForProjectExemptYears ||
                                  //            x.ErrorMessage == FirmaValidationMessages.ExplanationForProjectExemptYearsExceedsMax(Project.FieldLengths.PerformanceMeasureActualYearsExemptionExplanation) ||
                                  //            x.ErrorMessage == FirmaValidationMessages.PerformanceMeasureOrExemptYearsRequired);
            var viewData = new EditPerformanceMeasureActualsViewData(performanceMeasures, false);
            return RazorPartialView<EditPerformanceMeasureActuals, EditPerformanceMeasureActualsViewData, EditPerformanceMeasureActualsViewModel>(viewData, viewModel);
        }
    }
}