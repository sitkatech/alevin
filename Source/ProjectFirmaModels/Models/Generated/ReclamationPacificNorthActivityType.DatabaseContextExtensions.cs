//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationPacificNorthActivityType]
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
        public static ReclamationPacificNorthActivityType GetReclamationPacificNorthActivityType(this IQueryable<ReclamationPacificNorthActivityType> reclamationPacificNorthActivityTypes, int reclamationPacificNorthActivityTypeID)
        {
            var reclamationPacificNorthActivityType = reclamationPacificNorthActivityTypes.SingleOrDefault(x => x.ReclamationPacificNorthActivityTypeID == reclamationPacificNorthActivityTypeID);
            Check.RequireNotNullThrowNotFound(reclamationPacificNorthActivityType, "ReclamationPacificNorthActivityType", reclamationPacificNorthActivityTypeID);
            return reclamationPacificNorthActivityType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationPacificNorthActivityType(this IQueryable<ReclamationPacificNorthActivityType> reclamationPacificNorthActivityTypes, List<int> reclamationPacificNorthActivityTypeIDList)
        {
            if(reclamationPacificNorthActivityTypeIDList.Any())
            {
                reclamationPacificNorthActivityTypes.Where(x => reclamationPacificNorthActivityTypeIDList.Contains(x.ReclamationPacificNorthActivityTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationPacificNorthActivityType(this IQueryable<ReclamationPacificNorthActivityType> reclamationPacificNorthActivityTypes, ICollection<ReclamationPacificNorthActivityType> reclamationPacificNorthActivityTypesToDelete)
        {
            if(reclamationPacificNorthActivityTypesToDelete.Any())
            {
                var reclamationPacificNorthActivityTypeIDList = reclamationPacificNorthActivityTypesToDelete.Select(x => x.ReclamationPacificNorthActivityTypeID).ToList();
                reclamationPacificNorthActivityTypes.Where(x => reclamationPacificNorthActivityTypeIDList.Contains(x.ReclamationPacificNorthActivityTypeID)).Delete();
            }
        }

        public static void DeleteReclamationPacificNorthActivityType(this IQueryable<ReclamationPacificNorthActivityType> reclamationPacificNorthActivityTypes, int reclamationPacificNorthActivityTypeID)
        {
            DeleteReclamationPacificNorthActivityType(reclamationPacificNorthActivityTypes, new List<int> { reclamationPacificNorthActivityTypeID });
        }

        public static void DeleteReclamationPacificNorthActivityType(this IQueryable<ReclamationPacificNorthActivityType> reclamationPacificNorthActivityTypes, ReclamationPacificNorthActivityType reclamationPacificNorthActivityTypeToDelete)
        {
            DeleteReclamationPacificNorthActivityType(reclamationPacificNorthActivityTypes, new List<ReclamationPacificNorthActivityType> { reclamationPacificNorthActivityTypeToDelete });
        }
    }
}