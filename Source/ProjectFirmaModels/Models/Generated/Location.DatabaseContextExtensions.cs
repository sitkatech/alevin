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
        public static Location GetLocation(this IQueryable<Location> locations, int reclamationLocationID)
        {
            var location = locations.SingleOrDefault(x => x.ReclamationLocationID == reclamationLocationID);
            Check.RequireNotNullThrowNotFound(location, "Location", reclamationLocationID);
            return location;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteLocation(this IQueryable<Location> locations, List<int> reclamationLocationIDList)
        {
            if(reclamationLocationIDList.Any())
            {
                locations.Where(x => reclamationLocationIDList.Contains(x.ReclamationLocationID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteLocation(this IQueryable<Location> locations, ICollection<Location> locationsToDelete)
        {
            if(locationsToDelete.Any())
            {
                var reclamationLocationIDList = locationsToDelete.Select(x => x.ReclamationLocationID).ToList();
                locations.Where(x => reclamationLocationIDList.Contains(x.ReclamationLocationID)).Delete();
            }
        }

        public static void DeleteLocation(this IQueryable<Location> locations, int reclamationLocationID)
        {
            DeleteLocation(locations, new List<int> { reclamationLocationID });
        }

        public static void DeleteLocation(this IQueryable<Location> locations, Location locationToDelete)
        {
            DeleteLocation(locations, new List<Location> { locationToDelete });
        }
    }
}