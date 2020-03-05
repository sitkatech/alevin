//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationLocation]
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
        public static ReclamationLocation GetReclamationLocation(this IQueryable<ReclamationLocation> reclamationLocations, int reclamationLocationID)
        {
            var reclamationLocation = reclamationLocations.SingleOrDefault(x => x.ReclamationLocationID == reclamationLocationID);
            Check.RequireNotNullThrowNotFound(reclamationLocation, "ReclamationLocation", reclamationLocationID);
            return reclamationLocation;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationLocation(this IQueryable<ReclamationLocation> reclamationLocations, List<int> reclamationLocationIDList)
        {
            if(reclamationLocationIDList.Any())
            {
                reclamationLocations.Where(x => reclamationLocationIDList.Contains(x.ReclamationLocationID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationLocation(this IQueryable<ReclamationLocation> reclamationLocations, ICollection<ReclamationLocation> reclamationLocationsToDelete)
        {
            if(reclamationLocationsToDelete.Any())
            {
                var reclamationLocationIDList = reclamationLocationsToDelete.Select(x => x.ReclamationLocationID).ToList();
                reclamationLocations.Where(x => reclamationLocationIDList.Contains(x.ReclamationLocationID)).Delete();
            }
        }

        public static void DeleteReclamationLocation(this IQueryable<ReclamationLocation> reclamationLocations, int reclamationLocationID)
        {
            DeleteReclamationLocation(reclamationLocations, new List<int> { reclamationLocationID });
        }

        public static void DeleteReclamationLocation(this IQueryable<ReclamationLocation> reclamationLocations, ReclamationLocation reclamationLocationToDelete)
        {
            DeleteReclamationLocation(reclamationLocations, new List<ReclamationLocation> { reclamationLocationToDelete });
        }
    }
}