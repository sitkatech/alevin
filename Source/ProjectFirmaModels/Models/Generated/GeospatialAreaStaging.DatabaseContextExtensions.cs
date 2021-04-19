//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[GeospatialAreaStaging]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static GeospatialAreaStaging GetGeospatialAreaStaging(this IQueryable<GeospatialAreaStaging> geospatialAreaStagings, int geospatialAreaStagingID)
        {
            var geospatialAreaStaging = geospatialAreaStagings.SingleOrDefault(x => x.GeospatialAreaStagingID == geospatialAreaStagingID);
            Check.RequireNotNullThrowNotFound(geospatialAreaStaging, "GeospatialAreaStaging", geospatialAreaStagingID);
            return geospatialAreaStaging;
        }

    }
}