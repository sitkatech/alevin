//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Subbasin]
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
        public static Subbasin GetSubbasin(this IQueryable<Subbasin> subbasins, int reclamationSubbasinID)
        {
            var subbasin = subbasins.SingleOrDefault(x => x.ReclamationSubbasinID == reclamationSubbasinID);
            Check.RequireNotNullThrowNotFound(subbasin, "Subbasin", reclamationSubbasinID);
            return subbasin;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, List<int> reclamationSubbasinIDList)
        {
            if(reclamationSubbasinIDList.Any())
            {
                subbasins.Where(x => reclamationSubbasinIDList.Contains(x.ReclamationSubbasinID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, ICollection<Subbasin> subbasinsToDelete)
        {
            if(subbasinsToDelete.Any())
            {
                var reclamationSubbasinIDList = subbasinsToDelete.Select(x => x.ReclamationSubbasinID).ToList();
                subbasins.Where(x => reclamationSubbasinIDList.Contains(x.ReclamationSubbasinID)).Delete();
            }
        }

        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, int reclamationSubbasinID)
        {
            DeleteSubbasin(subbasins, new List<int> { reclamationSubbasinID });
        }

        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, Subbasin subbasinToDelete)
        {
            DeleteSubbasin(subbasins, new List<Subbasin> { subbasinToDelete });
        }
    }
}