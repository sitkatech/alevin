//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[PacificNorthActivityType]
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
        public static PacificNorthActivityType GetPacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, int pacificNorthActivityTypeID)
        {
            var pacificNorthActivityType = pacificNorthActivityTypes.SingleOrDefault(x => x.PacificNorthActivityTypeID == pacificNorthActivityTypeID);
            Check.RequireNotNullThrowNotFound(pacificNorthActivityType, "PacificNorthActivityType", pacificNorthActivityTypeID);
            return pacificNorthActivityType;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, List<int> pacificNorthActivityTypeIDList)
        {
            if(pacificNorthActivityTypeIDList.Any())
            {
                pacificNorthActivityTypes.Where(x => pacificNorthActivityTypeIDList.Contains(x.PacificNorthActivityTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, ICollection<PacificNorthActivityType> pacificNorthActivityTypesToDelete)
        {
            if(pacificNorthActivityTypesToDelete.Any())
            {
                var pacificNorthActivityTypeIDList = pacificNorthActivityTypesToDelete.Select(x => x.PacificNorthActivityTypeID).ToList();
                pacificNorthActivityTypes.Where(x => pacificNorthActivityTypeIDList.Contains(x.PacificNorthActivityTypeID)).Delete();
            }
        }

        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, int pacificNorthActivityTypeID)
        {
            DeletePacificNorthActivityType(pacificNorthActivityTypes, new List<int> { pacificNorthActivityTypeID });
        }

        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, PacificNorthActivityType pacificNorthActivityTypeToDelete)
        {
            DeletePacificNorthActivityType(pacificNorthActivityTypes, new List<PacificNorthActivityType> { pacificNorthActivityTypeToDelete });
        }
    }
}