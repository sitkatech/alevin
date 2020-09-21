using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaTypeModelExtensions
    {
        public static string GetEditGeospatialAreasUrl(this GeospatialAreaType geospatialAreaType, Project project)
        {
            return SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(x =>
                x.EditProjectGeospatialAreas(project.ProjectID, geospatialAreaType.GeospatialAreaTypeID));
        }

        public static string MapServiceUrl(this GeospatialAreaType geospatialAreaType)
        {
            var geoServerNamespace = MultiTenantHelpers.GetTenantAttributeFromCache().GeoServerNamespace;
            return $"{FirmaWebConfiguration.GeoServerUrl}{geoServerNamespace}/wms";
        }

        public static HtmlString GetGeoJsonLinkHtmlString(this GeospatialAreaType geospatialAreaType)
        {
            var mapServiceUri = new UriBuilder(geospatialAreaType.MapServiceUrl());
            mapServiceUri.Path = mapServiceUri.Path.Replace("/wms", "/ows");

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["service"] = "WFS";
            queryString["version"] = "1.0.0";
            queryString["request"] = "GetFeature";
            queryString["typeName"] = geospatialAreaType.GeospatialAreaLayerName;
            queryString["outputFormat"] = "application/json";
            queryString["maxFeatures"] = "500";
            queryString["sortBy"] = "PrimaryKey";
            queryString["startIndex"] = "0";
            mapServiceUri.Query = queryString.ToString();

            return UrlTemplate.MakeHrefString(mapServiceUri.ToString(), mapServiceUri.ToString());
        }

        public static readonly UrlTemplate<int> EditMapLayerUrlTemplate = new UrlTemplate<int>(SitkaRoute<MapLayerController>.BuildUrlFromExpression(t => t.EditGeospatialAreaMapLayer(UrlTemplate.Parameter1Int)));
        public static string GetEditMapLayerUrl(this GeospatialAreaType geospatialAreaType)
        {
            return EditMapLayerUrlTemplate.ParameterReplace(geospatialAreaType.GeospatialAreaTypeID);
        }

        public static string GetEsuDpsPopulationStringForProjectInBiOpAnnualReportGrid(this GeospatialAreaType geospatialAreaType, Project project, bool returnRawHtmlUrlString)
        {
            var returnString = "";

            if (geospatialAreaType?.EsuDpsGeospatialAreaType != null)
            {
                var esuDpsGeospatialAreaType = geospatialAreaType.EsuDpsGeospatialAreaType;
                var projectGeospatialAreas = project.ProjectGeospatialAreas.Select(x => x.GeospatialArea).ToList();
                var projectGeospatialAreasWithinType = projectGeospatialAreas.Where(x => x.GeospatialAreaTypeID == esuDpsGeospatialAreaType.GeospatialAreaTypeID).ToList();

                returnString = String.Join(", ", projectGeospatialAreasWithinType.Select(x => returnRawHtmlUrlString ? x.GetDisplayNameAsUrl().ToString() : x.GetDisplayName()));

            }

            return returnString;
        }

        public static string GetMpgPopulationStringForProjectInBiOpAnnualReportGrid(this GeospatialAreaType geospatialAreaType, Project project, bool returnRawHtmlUrlString)
        {
            var returnString = "";

            if (geospatialAreaType?.MPGGeospatialAreaType != null)
            {
                var mpgGeospatialAreaType = geospatialAreaType.MPGGeospatialAreaType;
                var projectGeospatialAreas = project.ProjectGeospatialAreas.Select(x => x.GeospatialArea).ToList();
                var projectGeospatialAreasWithinType = projectGeospatialAreas.Where(x => x.GeospatialAreaTypeID == mpgGeospatialAreaType.GeospatialAreaTypeID).ToList();

                returnString = String.Join(", ", projectGeospatialAreasWithinType.Select(x => returnRawHtmlUrlString ? x.GetDisplayNameAsUrl().ToString() : x.GetDisplayName()));

            }

            return returnString;
        }

        public static string GetPopulationStringForProjectInBiOpAnnualReportGrid(this GeospatialAreaType geospatialAreaType, Project project, bool returnRawHtmlUrlString)
        {
            var returnString = "";

            if (geospatialAreaType?.PopulationGeospatialAreaType != null)
            {
                var populationGeospatialAreaType = geospatialAreaType.PopulationGeospatialAreaType;
                var projectGeospatialAreas = project.ProjectGeospatialAreas.Select(x => x.GeospatialArea).ToList();
                var projectGeospatialAreasWithinType = projectGeospatialAreas.Where(x => x.GeospatialAreaTypeID == populationGeospatialAreaType.GeospatialAreaTypeID).ToList();

                returnString = String.Join(", ", projectGeospatialAreasWithinType.Select(x => returnRawHtmlUrlString ? x.GetDisplayNameAsUrl().ToString() : x.GetDisplayName()));

            }

            return returnString;
        }

    }
}