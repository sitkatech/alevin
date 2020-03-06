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
        public static PacificNorthActivityType GetPacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, int reclamationPacificNorthActivityTypeID)
        {
            var pacificNorthActivityType = pacificNorthActivityTypes.SingleOrDefault(x => x.ReclamationPacificNorthActivityTypeID == reclamationPacificNorthActivityTypeID);
            Check.RequireNotNullThrowNotFound(pacificNorthActivityType, "PacificNorthActivityType", reclamationPacificNorthActivityTypeID);
            return pacificNorthActivityType;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, List<int> reclamationPacificNorthActivityTypeIDList)
        {
            if(reclamationPacificNorthActivityTypeIDList.Any())
            {
                pacificNorthActivityTypes.Where(x => reclamationPacificNorthActivityTypeIDList.Contains(x.ReclamationPacificNorthActivityTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, ICollection<PacificNorthActivityType> pacificNorthActivityTypesToDelete)
        {
            if(pacificNorthActivityTypesToDelete.Any())
            {
                var reclamationPacificNorthActivityTypeIDList = pacificNorthActivityTypesToDelete.Select(x => x.ReclamationPacificNorthActivityTypeID).ToList();
                pacificNorthActivityTypes.Where(x => reclamationPacificNorthActivityTypeIDList.Contains(x.ReclamationPacificNorthActivityTypeID)).Delete();
            }
        }

        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, int reclamationPacificNorthActivityTypeID)
        {
            DeletePacificNorthActivityType(pacificNorthActivityTypes, new List<int> { reclamationPacificNorthActivityTypeID });
        }

        public static void DeletePacificNorthActivityType(this IQueryable<PacificNorthActivityType> pacificNorthActivityTypes, PacificNorthActivityType pacificNorthActivityTypeToDelete)
        {
            DeletePacificNorthActivityType(pacificNorthActivityTypes, new List<PacificNorthActivityType> { pacificNorthActivityTypeToDelete });
        }
    }
}