/*-----------------------------------------------------------------------
<copyright file="BasicProjectInfoGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class BasicProjectInfoGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {

        public BasicProjectInfoGridSpec(FirmaSession currentFirmaSession, bool allowTaggingFunctionality)
        {
            BasicProjectInfoGridSpec_Impl(currentFirmaSession, allowTaggingFunctionality, null, null);
        }

        public BasicProjectInfoGridSpec(FirmaSession currentFirmaSession, bool allowTaggingFunctionality, ProjectFirmaModels.Models.CostAuthority costAuthorityWorkBreakdownStructure)
        {
            BasicProjectInfoGridSpec_Impl(currentFirmaSession, allowTaggingFunctionality, costAuthorityWorkBreakdownStructure, null);
        }

        public BasicProjectInfoGridSpec(FirmaSession currentFirmaSession, bool allowTaggingFunctionality, ProjectFirmaModels.Models.Agreement agreement)
        {
            BasicProjectInfoGridSpec_Impl(currentFirmaSession, allowTaggingFunctionality, null, agreement);
        }

        private void BasicProjectInfoGridSpec_Impl(FirmaSession currentFirmaSession, 
                                                   bool allowTaggingFunctionality,
                                                   ProjectFirmaModels.Models.CostAuthority costAuthorityWorkBreakdownStructure,
                                                   ProjectFirmaModels.Models.Agreement agreement)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (userHasTagManagePermissions && allowTaggingFunctionality)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(
                    SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)),
                    $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                    $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            Add("Fact Sheer",
                x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaAgGridHtmlHelpers.FactSheetIcon.ToString()), 30,
                AgGridColumnFilterType.None);
            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => new HtmlLinkObject(x.ProjectName,x.GetDetailUrl()).ToJsonObjectForAgGrid() , 300, AgGridColumnFilterType.HtmlLinkJson);
            if (costAuthorityWorkBreakdownStructure != null)
            {
                Add($"Is {costAuthorityWorkBreakdownStructure.GetDisplayName()} Primary or Secondary CAWBS for this project?",
                    x => x.CostAuthorityProjects.Any(rcap =>
                        rcap.IsPrimaryProjectCawbs && rcap.CostAuthorityID ==
                        costAuthorityWorkBreakdownStructure.CostAuthorityID)
                        ? "Primary"
                        : "Secondary", 70, AgGridColumnFilterType.SelectFilterStrict);
            }

            if (agreement != null)
            {
                Add(FieldDefinitionEnum.PrimaryCostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString(), x => x.CostAuthorityProjects.SingleOrDefault(rcap => rcap.IsPrimaryProjectCawbs)?.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 120, AgGridColumnFilterType.Html);

                Add(FieldDefinitionEnum.SecondaryCostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderStringPlural(), x => GetSecondaryCostAuthorityAsCommaDelimitedList(x), 200, AgGridColumnFilterType.Text);
            }

            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetShortNameAsUrlForAgGrid(), 150,
                    AgGridColumnFilterType.HtmlLinkJson);
            }

            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(),
                x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90,
                AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => x.GetPlanningDesignStartYear(),
                90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => x.GetImplementationStartYear(),
                115, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => x.GetCompletionYear(), 90,
                AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingType.ToType().ToGridHeaderString(),
                x => x.FundingType?.FundingTypeDisplayName ?? string.Empty, 300, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(),
                x => x.GetEstimatedTotalRegardlessOfFundingType(), 110, AgGridColumnFormatType.Currency,
                AgGridColumnAggregationType.Total);

            Add(FieldDefinitionEnum.ProjectedFunding.ToType().ToGridHeaderString(), x => x.GetProjectedFunding(), 100,
                AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(),
                x => x.GetNoFundingSourceIdentifiedAmount(), 110, AgGridColumnFormatType.Currency,
                AgGridColumnAggregationType.Total);
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinksForAgGrid(geospatialAreaType), 350, AgGridColumnFilterType.HtmlLinkListJson);
            }

            Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 300);
            if (userHasTagManagePermissions)
            {
                Add("Tags", x => x.ProjectTags.Select(pt => pt.Tag).ToList().GetDisplayNamesAsUrlListForAgGrid(), 100, AgGridColumnFilterType.HtmlLinkListJson);    
            }
        }

        private static HtmlString GetSecondaryCostAuthorityAsCommaDelimitedList(ProjectFirmaModels.Models.Project project)
        {
            var costAuthorities = project.CostAuthorityProjects.Where(cap => !cap.IsPrimaryProjectCawbs).Select(x => x.CostAuthority);
            var costAuthorityWorkBreakdownStructures = costAuthorities.Select(rca => rca.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure()).ToList();
            return new HtmlString(string.Join(", ", costAuthorityWorkBreakdownStructures));
        }
    }
}
