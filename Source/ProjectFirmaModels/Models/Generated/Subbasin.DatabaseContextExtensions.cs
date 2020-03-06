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
        public static Subbasin GetSubbasin(this IQueryable<Subbasin> subbasins, int subbasinID)
        {
            var subbasin = subbasins.SingleOrDefault(x => x.SubbasinID == subbasinID);
            Check.RequireNotNullThrowNotFound(subbasin, "Subbasin", subbasinID);
            return subbasin;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, List<int> subbasinIDList)
        {
            if(subbasinIDList.Any())
            {
                subbasins.Where(x => subbasinIDList.Contains(x.SubbasinID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, ICollection<Subbasin> subbasinsToDelete)
        {
            if(subbasinsToDelete.Any())
            {
                var subbasinIDList = subbasinsToDelete.Select(x => x.SubbasinID).ToList();
                subbasins.Where(x => subbasinIDList.Contains(x.SubbasinID)).Delete();
            }
        }

        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, int subbasinID)
        {
            DeleteSubbasin(subbasins, new List<int> { subbasinID });
        }

        public static void DeleteSubbasin(this IQueryable<Subbasin> subbasins, Subbasin subbasinToDelete)
        {
            DeleteSubbasin(subbasins, new List<Subbasin> { subbasinToDelete });
        }
    }
}