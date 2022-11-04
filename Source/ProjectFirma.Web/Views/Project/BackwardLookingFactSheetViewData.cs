﻿/*-----------------------------------------------------------------------
<copyright file="FactSheetViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.SortOrder;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;


namespace ProjectFirma.Web.Views.Project
{
    public class BackwardLookingFactSheetViewData : ProjectViewData
    {
        public string EstimatedTotalCost { get; }
        public string NoFundingSourceIdentified { get; }
        public string ProjectedFunding { get; }
        public List<IGrouping<ProjectFirmaModels.Models.PerformanceMeasure, PerformanceMeasureReportedValue>> PerformanceMeasureReportedValues { get; }
        public List<IGrouping<ProjectFirmaModels.Models.PerformanceMeasure, PerformanceMeasureExpected>> PerformanceMeasureExpectedValues { get; }
        public bool ShowExpectedPerformanceMeasures { get; }
        public List<GooglePieChartSlice> ExpenditureGooglePieChartSlices { get; }
        public string ChartID { get; }
        public ProjectFirmaModels.Models.ProjectImage KeyPhoto { get; }
        public List<IGrouping<ProjectImageTiming, ProjectFirmaModels.Models.ProjectImage>> ProjectImagesExceptKeyPhotoGroupedByTiming { get; }
        public int ProjectImagesPerTimingGroup { get; }
        public List<string> ChartColorRange { get; }
        public List<ProjectFirmaModels.Models.Classification> Classifications { get; }
        public ProjectLocationSummaryMapInitJson ProjectLocationSummaryMapInitJson { get; }
        public GoogleChartJson GoogleChartJson { get; }
        public int CalculatedChartHeight { get; }
        public bool WithCustomAttributes { get; }

        public string TaxonomyColor { get; }
        public string TaxonomyLeafName { get; }
        public string TaxonomyBranchName { get; }

        public string TaxonomyLeafDisplayName { get; }
        public Person PrimaryContactPerson { get; }
        public ViewPageContentViewData CustomFactSheetPageTextViewData { get; }
        public List<TechnicalAssistanceParameter> TechnicalAssistanceParameters { get; }
        public List<ProjectFirmaModels.Models.TechnicalAssistanceRequest> TechnicalAssistanceRequests { get; }
        public List<ProjectCustomAttribute> ViewableProjectCustomAttributes { get; }
        public List<ProjectFirmaModels.Models.ProjectCustomAttributeType> ViewableProjectCustomAttributeTypes { get; }
        public DateTime LastUpdated { get; }
        public ProjectController.FactSheetPdfEnum FactSheetPdfEnum { get; }
        public bool ProjectLocationIsProvided { get; }

        public BackwardLookingFactSheetViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project,
            ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson,
            GoogleChartJson projectFactSheetGoogleChart,
            List<GooglePieChartSlice> expenditureGooglePieChartSlices, List<string> chartColorRange,
            ProjectFirmaModels.Models.FirmaPage firmaPageFactSheet,
            List<TechnicalAssistanceParameter> technicalAssistanceParameters,
            bool withCustomAttributes,
            ProjectController.FactSheetPdfEnum factSheetPdfEnum) : base(currentFirmaSession, project)
        {
            PageTitle = project.GetDisplayName();
            BreadCrumbTitle = "Fact Sheet";

            EstimatedTotalCost = Project.GetEstimatedTotalRegardlessOfFundingType().HasValue ? Project.GetEstimatedTotalRegardlessOfFundingType().ToStringCurrency() : "";
            NoFundingSourceIdentified = project.GetNoFundingSourceIdentifiedAmount() != null ? Project.GetNoFundingSourceIdentifiedAmount().ToStringCurrency() : "";
            ProjectedFunding = Project.GetProjectedFunding().ToStringCurrency();

            PerformanceMeasureReportedValues =
                project.GetPerformanceMeasureReportedValues().GroupBy(x => x.PerformanceMeasure).OrderBy(x => x.Key.PerformanceMeasureSortOrder).ThenBy(x => x.Key.PerformanceMeasureDisplayName).ToList();
            PerformanceMeasureExpectedValues = project.PerformanceMeasureExpecteds.GroupBy(x => x.PerformanceMeasure, new HavePrimaryKeyComparer<ProjectFirmaModels.Models.PerformanceMeasure>())
                .OrderBy(x => x.Key.PerformanceMeasureSortOrder).ThenBy(x => x.Key.PerformanceMeasureDisplayName).ToList();

            ShowExpectedPerformanceMeasures =
                MultiTenantHelpers.GetTenantAttributeFromCache().ShowExpectedPerformanceMeasuresOnFactSheet &&
                (project.ProjectStage == ProjectStage.Implementation || project.ProjectStage == ProjectStage.PostImplementation) && !PerformanceMeasureReportedValues.Any();

            ChartID = $"fundingChartForProject{project.ProjectID}";
            KeyPhoto = project.GetKeyPhoto();
            ProjectImagesExceptKeyPhotoGroupedByTiming =
                project.ProjectImages.Where(x => !x.IsKeyPhoto && x.ProjectImageTiming != ProjectImageTiming.Unknown && !x.ExcludeFromFactSheet)
                    .GroupBy(x => x.ProjectImageTiming)
                    .OrderBy(x => x.Key.SortOrder)
                    .ToList();
            ProjectImagesPerTimingGroup = ProjectImagesExceptKeyPhotoGroupedByTiming.Count == 1 ? 6 : 2;
            Classifications = project.ProjectClassifications.Select(x => x.Classification).ToList().SortByOrderThenName().ToList();

            ProjectLocationSummaryMapInitJson = projectLocationSummaryMapInitJson;
            GoogleChartJson = projectFactSheetGoogleChart;

            ExpenditureGooglePieChartSlices = expenditureGooglePieChartSlices;
            ChartColorRange = chartColorRange;
            //Dynamically resize chart based on how much space the legend requires
            CalculatedChartHeight = 350 - ExpenditureGooglePieChartSlices.Count * 19;

            if (project.GetTaxonomyLeaf() == null)
            {
                TaxonomyColor = "blue";
            }
            else
            {
                switch (MultiTenantHelpers.GetTaxonomyLevel().ToEnum)
                {
                    case TaxonomyLevelEnum.Leaf:
                        TaxonomyColor = project.GetTaxonomyLeaf().ThemeColor;
                        break;
                    case TaxonomyLevelEnum.Branch:
                        TaxonomyColor = project.GetTaxonomyLeaf().TaxonomyBranch.ThemeColor;
                        break;
                    case TaxonomyLevelEnum.Trunk:
                        TaxonomyColor = project.GetTaxonomyLeaf().TaxonomyBranch.TaxonomyTrunk.ThemeColor;
                        break;
                }
            }
            TaxonomyLeafName = project.GetTaxonomyLeaf() == null ? $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Taxonomy Not Set" : project.GetTaxonomyLeaf().GetDisplayName();
            TaxonomyBranchName = project.GetTaxonomyLeaf() == null ? $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Taxonomy Not Set" : project.GetTaxonomyLeaf().TaxonomyBranch.GetDisplayName();
            TaxonomyLeafDisplayName = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel();
            PrimaryContactPerson = project.GetPrimaryContact();
            CustomFactSheetPageTextViewData = new ViewPageContentViewData(firmaPageFactSheet, false);
            TechnicalAssistanceParameters = technicalAssistanceParameters;
            TechnicalAssistanceRequests = project.TechnicalAssistanceRequests.ToList();

            ViewableProjectCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.ToList().Where(x => x.HasViewPermission(currentFirmaSession) && x.IsViewableOnFactSheet).ToList();
            ViewableProjectCustomAttributes = project.ProjectCustomAttributes.Where(x => x.ProjectCustomAttributeType.HasViewPermission(currentFirmaSession) && ViewableProjectCustomAttributeTypes.Contains(x.ProjectCustomAttributeType)).ToList();
            
            WithCustomAttributes = withCustomAttributes;
            LastUpdated = project.LastUpdatedDate;
            FactSheetPdfEnum = factSheetPdfEnum;

            ProjectLocationIsProvided = project.ProjectLocationPoint != null || project.ProjectLocations.Any();
        }
    }
}
