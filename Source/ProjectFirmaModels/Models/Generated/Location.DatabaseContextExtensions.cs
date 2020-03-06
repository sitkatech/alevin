//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Location]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Location GetLocation(this IQueryable<Location> locations, int locationID)
        {
            var location = locations.SingleOrDefault(x => x.LocationID == locationID);
            Check.RequireNotNullThrowNotFound(location, "Location", locationID);
            return location;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteLocation(this IQueryable<Location> locations, List<int> locationIDList)
        {
            if(locationIDList.Any())
            {
                locations.Where(x => locationIDList.Contains(x.LocationID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteLocation(this IQueryable<Location> locations, ICollection<Location> locationsToDelete)
        {
            if(locationsToDelete.Any())
            {
                var locationIDList = locationsToDelete.Select(x => x.LocationID).ToList();
                locations.Where(x => locationIDList.Contains(x.LocationID)).Delete();
            }
        }

        public static void DeleteLocation(this IQueryable<Location> locations, int locationID)
        {
            DeleteLocation(locations, new List<int> { locationID });
        }

        public static void DeleteLocation(this IQueryable<Location> locations, Location locationToDelete)
        {
            DeleteLocation(locations, new List<Location> { locationToDelete });
        }
    }
}