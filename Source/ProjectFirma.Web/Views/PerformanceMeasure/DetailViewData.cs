﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.BootstrapWrappers;
using ProjectFirma.Web.Views.GeospatialAreaPerformanceMeasureTarget;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class DetailViewData : FirmaViewData
    {
        public enum PerformanceMeasureDetailTab
        {
            Overview,
            ReportingGuidance
        }

        public ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure { get; }
        public PerformanceMeasureChartViewData PerformanceMeasureChartViewData { get; }
        public EntityNotesViewData EntityNotesViewData { get; }

        public bool UserHasPerformanceMeasureOverviewManagePermissions { get; }
        public bool IsAdmin { get; }

        public string EditPerformanceMeasureUrl { get; }
        public string EditSubcategoriesAndOptionsUrl { get; }
        public bool CanEditAdditionalInformation { get; }
        public string EditAdditionalInformationUrl { get; }
        public string EditCriticalDefinitionsUrl { get; }
        public string EditProjectReportingUrl { get; }

        public string IndexUrl { get; }

        public string EditTaxonomyTiersUrl { get; }
        public bool UserHasTaxonomyTierPerformanceMeasureManagePermissions { get; }
        public PerformanceMeasureReportedValuesGridSpec PerformanceMeasureReportedValuesGridSpec { get; }
        public string PerformanceMeasureReportedValuesGridName { get; }
        public string PerformanceMeasureReportedValuesGridDataUrl { get; }
        public PerformanceMeasureExpectedGridSpec PerformanceMeasureExpectedGridSpec { get; }
        public string PerformanceMeasureExpectedsGridName { get; }
        public string PerformanceMeasureExpectedsGridDataUrl { get; }

        public bool ShowGeoSpatialAreaPanel { get; }
        public bool CanAddGeospatialArea { get; }

        public string TaxonomyTierDisplayName { get; }

        public RelatedTaxonomyTiersViewData RelatedTaxonomyTiersViewData { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPerformanceMeasureType { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPerformanceMeasureSubcategory { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPerformanceMeasureSubcategoryOption { get; }
        public string EditPerformanceMeasureTargetUrl { get; set; }
        public GeospatialAreaPerformanceMeasureTargetGridSpec GeospatialAreaPerformanceMeasureTargetGridSpec { get; }
        public string GeospatialAreaPerformanceMeasureTargetGridName { get; }
        public string GeospatialAreaPerformanceMeasureTargetGridDataUrl { get;  }
        public string AddGeospatialAreaPerformanceMeasureTargetDialogTitle { get; }
        public string AddGeospatialAreaPerformanceMeasureTargetText { get; }
        public string AddGeospatialAreaPerformanceMeasureTargetUrl { get; }

        public ViewPageContentViewData ExpectedAccomplishmentsTextViewData { get; }
        public ViewPageContentViewData ReportedAccomplishmentsTextViewData { get; }
        public ViewPageContentViewData TargetsTabIntoTextViewData { get; }

        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }
        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }

        public PerformanceMeasureDetailTab ActiveTab { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            PerformanceMeasureChartViewData performanceMeasureChartViewData,
            EntityNotesViewData entityNotesViewData,
            bool userHasPerformanceMeasureManagePermissions, bool isAdmin,
            ProjectFirmaModels.Models.FirmaPage expectedAccomplishmentsFirmaPage,
            ProjectFirmaModels.Models.FirmaPage reportedAccomplishmentsFirmaPage,
            ProjectFirmaModels.Models.FirmaPage targetsTabIntroFirmaPage,
            ProjectLocationsMapViewData projectLocationsMapViewData, ProjectLocationsMapInitJson projectLocationsMapInitJson,
            PerformanceMeasureDetailTab activeTab) : base(currentFirmaSession)
        {
            PageTitle = performanceMeasure.PerformanceMeasureDisplayName;
            EntityName = "PerformanceMeasure Detail";

            PerformanceMeasure = performanceMeasure;
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;
            EntityNotesViewData = entityNotesViewData;
            UserHasPerformanceMeasureOverviewManagePermissions = userHasPerformanceMeasureManagePermissions;
            IsAdmin = isAdmin;

            EditPerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Edit(performanceMeasure));
            EditSubcategoriesAndOptionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditSubcategoriesAndOptions(performanceMeasure));

            var performanceMeasuresExternallySourced = HttpRequestStorage.Tenant.ArePerformanceMeasuresExternallySourced;
            CanEditAdditionalInformation = !performanceMeasuresExternallySourced;
            EditAdditionalInformationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.AdditionalInformation));
            EditCriticalDefinitionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions));
            EditProjectReportingUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting));

            IndexUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Index());
            var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            TaxonomyTierDisplayName = associatePerformanceMeasureTaxonomyLevel.GetFieldDefinition().GetFieldDefinitionLabel();
            UserHasTaxonomyTierPerformanceMeasureManagePermissions = new TaxonomyTierPerformanceMeasureManageFeature().HasPermission(currentFirmaSession).HasPermission;
            EditTaxonomyTiersUrl = SitkaRoute<TaxonomyTierPerformanceMeasureController>.BuildUrlFromExpression(c => c.Edit(performanceMeasure));
            RelatedTaxonomyTiersViewData = new RelatedTaxonomyTiersViewData(performanceMeasure, associatePerformanceMeasureTaxonomyLevel, true);

            // Hide GeoSpatialArea panel on tenants where performance measures are externally sourced
            ShowGeoSpatialAreaPanel = !performanceMeasuresExternallySourced;
            CanAddGeospatialArea = new GeospatialAreaPerformanceMeasureTargetManageFeature().HasPermissionByFirmaSession(currentFirmaSession);

            PerformanceMeasureReportedValuesGridSpec = new PerformanceMeasureReportedValuesGridSpec(performanceMeasure)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.ReportedValue.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.ReportedValue.ToType().GetFieldDefinitionLabelPluralized()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureReportedValuesGridName = "performanceMeasuresReportedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureReportedValuesGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureReportedValuesGridJsonData(performanceMeasure));

            PerformanceMeasureExpectedGridSpec = new PerformanceMeasureExpectedGridSpec(performanceMeasure)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.ExpectedValue.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.ExpectedValue.ToType().GetFieldDefinitionLabelPluralized()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureExpectedsGridName = "performanceMeasuresExpectedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureExpectedsGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureExpectedsGridJsonData(performanceMeasure));

            GeospatialAreaPerformanceMeasureTargetGridSpec = new GeospatialAreaPerformanceMeasureTargetGridSpec(currentFirmaSession, performanceMeasure)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabel()} Target for {performanceMeasure.GetDisplayName()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabel()} Targets for {performanceMeasure.GetDisplayName()}",
                SaveFiltersInCookie = true
            };

            GeospatialAreaPerformanceMeasureTargetGridName = "geospatialAreaPerformanceMeasuresTargetsGrid";
            GeospatialAreaPerformanceMeasureTargetGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.GeospatialAreaPerformanceMeasureTargetsGridJsonData(performanceMeasure));
            AddGeospatialAreaPerformanceMeasureTargetDialogTitle = $"Add {FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabelPluralized()} to {performanceMeasure.GetDisplayName()}";
            AddGeospatialAreaPerformanceMeasureTargetText = $"{BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus")} Add {FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabel()}";
            AddGeospatialAreaPerformanceMeasureTargetUrl = SitkaRoute<GeospatialAreaPerformanceMeasureTargetController>.BuildUrlFromExpression(x => x.AddGeospatialAreaToPerformanceMeasure(performanceMeasure));

            EditPerformanceMeasureTargetUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(pmc => pmc.EditPerformanceMeasureReportedValues(performanceMeasure));

            FieldDefinitionForPerformanceMeasure = FieldDefinitionEnum.PerformanceMeasure.ToType();
            FieldDefinitionForPerformanceMeasureType = FieldDefinitionEnum.PerformanceMeasureType.ToType();
            FieldDefinitionForPerformanceMeasureSubcategory = FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType();
            FieldDefinitionForPerformanceMeasureSubcategoryOption = FieldDefinitionEnum.PerformanceMeasureSubcategoryOption.ToType();
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();

            ExpectedAccomplishmentsTextViewData = new ViewPageContentViewData(expectedAccomplishmentsFirmaPage, IsAdmin);
            ReportedAccomplishmentsTextViewData = new ViewPageContentViewData(reportedAccomplishmentsFirmaPage, IsAdmin);
            TargetsTabIntoTextViewData = new ViewPageContentViewData(targetsTabIntroFirmaPage, IsAdmin);

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;

            ActiveTab = activeTab;
        }

    }
}
