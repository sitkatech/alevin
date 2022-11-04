﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureChartViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureChartViewData : FirmaUserControlViewData
    {
        private const int DefaultHeight = 350;
        public readonly ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure;
        public readonly bool HyperlinkPerformanceMeasureName;
        public readonly List<GoogleChartJson> GoogleChartJsons;
        public readonly bool CanManagePerformanceMeasures;
        public readonly bool ShowLastUpdatedDate;
        public readonly string ChartTitle;
        public double? ChartTotal { get; }
        public string ChartTotalFormatted { get; }

        public readonly ViewGoogleChartViewData ViewGoogleChartViewData;

        public PerformanceMeasureChartViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
                                               int height,
                                               FirmaSession currentFirmaSession,
                                               bool showLastUpdatedDate,
                                               bool fromPerformanceMeasureDetailPage,
                                               List<ProjectFirmaModels.Models.Project> projects,
                                               string chartUniqueName,
                                               ProjectFirmaModels.Models.GeospatialArea geospatialArea)
        {
            PerformanceMeasure = performanceMeasure;
            HyperlinkPerformanceMeasureName = !fromPerformanceMeasureDetailPage;

            GoogleChartJsons = performanceMeasure.GetGoogleChartJsonDictionary(geospatialArea, projects, chartUniqueName);

            var performanceMeasureActuals = PerformanceMeasure.PerformanceMeasureActuals.Where(x => projects.Contains(x.Project)).ToList();
            ChartTotal = performanceMeasureActuals.Any() ? performanceMeasureActuals.Sum(x => x.ActualValue) : (double?) null;
            ChartTotalFormatted = PerformanceMeasure.MeasurementUnitType.DisplayValue(ChartTotal);

            var currentPersonHasManagePermission = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            CanManagePerformanceMeasures = currentPersonHasManagePermission && fromPerformanceMeasureDetailPage;

            ShowLastUpdatedDate = showLastUpdatedDate;
            ChartTitle = performanceMeasure.GetDisplayName();
            ViewGoogleChartViewData = new ViewGoogleChartViewData(GoogleChartJsons,
                ChartTitle,
                height,
                null,
                chartUniqueName,
                CanManagePerformanceMeasures,
                SitkaRoute<GoogleChartController>.BuildUrlFromExpression(c => c.DownloadPerformanceMeasureChartData()),
                true,
                true,
                performanceMeasure,
                HyperlinkPerformanceMeasureName);
        }

        public PerformanceMeasureChartViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession, bool showLastUpdatedDate, List<ProjectFirmaModels.Models.Project> projects) : this(
            performanceMeasure,
            DefaultHeight,
            currentFirmaSession,
            showLastUpdatedDate,
            false, 
            projects,
            performanceMeasure.GetJavascriptSafeChartUniqueName(),
            null)
        {
        }

        public PerformanceMeasureChartViewData(ProjectFirmaModels.Models.GeospatialArea geospatialArea, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession, bool showLastUpdatedDate, List<ProjectFirmaModels.Models.Project> projects) : this(
            performanceMeasure,
            DefaultHeight,
            currentFirmaSession,
            showLastUpdatedDate,
            false,
            projects,
            performanceMeasure.GetJavascriptSafeChartUniqueName(),
            geospatialArea)
        {
        }


        public PerformanceMeasureChartViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            FirmaSession currentFirmaSession, bool showLastUpdatedDate, List<ProjectFirmaModels.Models.Project> projects,
            string chartUniqueName) : this(
            performanceMeasure,
            DefaultHeight,
            currentFirmaSession,
            showLastUpdatedDate,
            false,
            projects,
            chartUniqueName,
            null)
        {
        }

        public PerformanceMeasureChartViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, FirmaSession currentFirmaSession, bool showLastUpdatedDate, bool showConfigureOption, List<ProjectFirmaModels.Models.Project> projects) : this(
            performanceMeasure,
            DefaultHeight,
            currentFirmaSession,
            showLastUpdatedDate,
            showConfigureOption, 
            projects,
            performanceMeasure.GetJavascriptSafeChartUniqueName(),
            null)
        {
        }


    }
}
