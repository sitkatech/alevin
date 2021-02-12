﻿using LtInfo.Common.GeoJson;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.ProjectFinder;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Controllers
{

    public class ProjectFinderController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        [HttpGet]
        public ViewResult Organization(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;

            var organizationHasOptedIn = organization.MatchmakerOptIn ?? false;

            var projectFinderGridSpec = new ProjectFinderGridSpec(CurrentFirmaSession);
            var projectMatchmakerScoresForOrganization = organizationHasOptedIn ? new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization) : new List<PartnerOrganizationMatchMakerScore>();
            var projectsToShow = projectMatchmakerScoresForOrganization.Select(x => x.Project).Where(x => x.ProjectStage.ShouldIncludeInMatchmaker()).ToList();


            var filterValues = ResultsController.GetDefaultFilterValuesForFilterType(ProjectMapCustomization.DefaultLocationFilterType.ToEnum, true);

            var initialCustomization = new ProjectMapCustomization(ProjectMapCustomization.DefaultLocationFilterType, filterValues, ProjectColorByType.ProjectStage);
            var projectLocationsLayerGeoJson =
                new LayerGeoJson($"{FieldDefinitionEnum.ProjectLocation.ToType().GetFieldDefinitionLabel()}",
                    projectsToShow.MappedPointsToGeoJsonFeatureCollection(false, true, true), "blue", 1,
                    LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
            var projectLocationsMapInitJson = new ProjectLocationsMapInitJson(projectLocationsLayerGeoJson, initialCustomization, "ProjectLocationsMap", false);
            // Add Organization Type boundaries according to configuration
            projectLocationsMapInitJson.Layers.AddRange(HttpRequestStorage.DatabaseEntities.Organizations.GetConfiguredBoundaryLayersGeoJson());

            var profileCompletionDictionary = organization.GetMatchmakerOrganizationProfileCompletionDictionary();
            DisplayMatchMakerToastMessagesIfAny(organization, projectMatchmakerScoresForOrganization, profileCompletionDictionary, organizationHasOptedIn);

            var matchMakerAreaOfInterestGeoJson = GetMatchMakerAreaOfInterestGeoJson(organization);

            var viewData = new ProjectFinderOrganizationViewData(CurrentFirmaSession, organization, projectMatchmakerScoresForOrganization, projectFinderGridSpec, projectLocationsMapInitJson, matchMakerAreaOfInterestGeoJson);
            return RazorView<ProjectFinderOrganization, ProjectFinderOrganizationViewData>(viewData);
        }

        private static LayerGeoJson GetMatchMakerAreaOfInterestGeoJson(Organization organization)
        {
            LayerGeoJson layer = null;

            // organization boundary layer
            if (organization.UseOrganizationBoundaryForMatchmaker && organization.OrganizationBoundary != null)
            {
                var organizationBoundaryToFeatureCollection = organization.OrganizationBoundaryToFeatureCollection();
                organizationBoundaryToFeatureCollection.Features.ForEach(x => x.Properties.Add("Hover Name", FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel()));
                layer = new LayerGeoJson("Organization Boundary",
                    organizationBoundaryToFeatureCollection, ProjectFirmaModels.Models.Organization.OrganizationAreaOfInterestMapLayerColor, 1,
                    LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
            }

            // custom areas of interest
            if (!organization.UseOrganizationBoundaryForMatchmaker &&
                organization.MatchMakerAreaOfInterestLocations.Any())
            {
                var areaOfInterestLayerGeoJsonFeatureCollection = DbGeometryToGeoJsonHelper.FeatureCollectionFromDbGeometry(organization.MatchMakerAreaOfInterestLocations.Select(x => x.MatchMakerAreaOfInterestLocationGeometry), "Area Of Interest", "User Set");
                areaOfInterestLayerGeoJsonFeatureCollection.Features.ForEach(x => x.Properties.Add("Hover Name", FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel()));
                layer = new LayerGeoJson($"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.AreaOfInterest.ToType().GetFieldDefinitionLabel()} Geometries", areaOfInterestLayerGeoJsonFeatureCollection, ProjectFirmaModels.Models.Organization.OrganizationAreaOfInterestMapLayerColor, 1, LayerInitialVisibility.LayerInitialVisibilityEnum.Show);
            }

            return layer;
        }

        private void DisplayMatchMakerToastMessagesIfAny(Organization organization,
            List<PartnerOrganizationMatchMakerScore> projectMatchmakerScoresForOrganization,
            Dictionary<MatchmakerSubScoreTypeEnum, bool> profileCompletionDictionary,
            bool organizationHasOptedIn)
        {

            var linkToOrgProfile = SitkaRoute<OrganizationController>.BuildLinkFromExpression(
                x => x.Detail(organization.OrganizationID, OrganizationDetailViewData.OrganizationDetailTab.Profile),
                $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} Profile");

            if (!organizationHasOptedIn)
            {
                SetErrorForDisplay($"The {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} ({organization.OrganizationName}) has not opted in to the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Matchmaker service. The {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} ({(organization.PrimaryContactPerson?.GetFullNameFirstLast() ?? $"no {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}")}) will need to fill out the {linkToOrgProfile} as completely as possible and Opt-In to the service.");
                return;
            }

            // When Org profile is not filled out at all (no matches are possible)
            if (!profileCompletionDictionary.Values.Any(x => x))
            {
                SetErrorForDisplay($"The profile for your {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} ({organization.OrganizationName}) is empty, so it’s not possible to identify {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches. The {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} ({(organization.PrimaryContactPerson?.GetFullNameFirstLast() ?? $"no {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}")}) will need to fill out the {linkToOrgProfile} as completely as possible before using the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Finder");
                return;
            }

            // When Org profile is partially filled out and there are no matches
            if (profileCompletionDictionary.Values.Any(x => x == false) && !projectMatchmakerScoresForOrganization.Any())
            {
                SetWarningForDisplay($"0 {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches found. The {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} ({(organization.PrimaryContactPerson?.GetFullNameFirstLast() ?? $"no {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}")}) should fill out the {linkToOrgProfile} as completely as possible to increase the potential for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches.");
                return;
            }


            // When Org profile is partially filled out and matches exist
            if (profileCompletionDictionary.Values.Any(x => x == false) && projectMatchmakerScoresForOrganization.Any())
            {
                SetWarningForDisplay($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} can only be found for {profileCompletionDictionary.Values.Count(x => x)} out of {profileCompletionDictionary.Values.Count} match categories. The {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} ({(organization.PrimaryContactPerson?.GetFullNameFirstLast() ?? $"no {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}")}) should fill out their {linkToOrgProfile} to access more potential {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches!");
                return;
            }

            // When Org profile is completely filled out and there are no matches
            if (profileCompletionDictionary.Values.All(x => x != false) && !projectMatchmakerScoresForOrganization.Any())
            {
                SetWarningForDisplay($"No matches just yet! To increase potential matches, the {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} ({(organization.PrimaryContactPerson?.GetFullNameFirstLast() ?? $"no {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}")}) should add more detail where possible to their {linkToOrgProfile}.");
            }

        }


        // All projects that match with the organization
        [AnonymousUnclassifiedFeature]
        public GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore> ProjectFinderGridFullJsonData(OrganizationPrimaryKey organizationPrimaryKey)
        {
            var organization = organizationPrimaryKey.EntityObject;
            var organizationHasOptedIn = organization.MatchmakerOptIn ?? false;
            var gridSpec = new ProjectFinderGridSpec(CurrentFirmaSession);
            var projectMatchmakerScoresForOrganization = organizationHasOptedIn ? new ProjectOrganizationMatchmaker().GetPartnerOrganizationMatchMakerScoresForParticularOrganization(CurrentFirmaSession, organization) : new List<PartnerOrganizationMatchMakerScore>();
            var projectMatchmakerScoresExcludingInvalidStages = projectMatchmakerScoresForOrganization.Where(x => x.Project.ProjectStage.ShouldIncludeInMatchmaker()).ToList();

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<PartnerOrganizationMatchMakerScore>(projectMatchmakerScoresExcludingInvalidStages, gridSpec, x => x.Project.PrimaryKey);
            return gridJsonNetJObjectResult;
        }
       
    }

}