//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Basin]
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
        public static Basin GetBasin(this IQueryable<Basin> basins, int reclamationBasinID)
        {
            var basin = basins.SingleOrDefault(x => x.ReclamationBasinID == reclamationBasinID);
            Check.RequireNotNullThrowNotFound(basin, "Basin", reclamationBasinID);
            return basin;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteBasin(this IQueryable<Basin> basins, List<int> reclamationBasinIDList)
        {
            if(reclamationBasinIDList.Any())
            {
                basins.Where(x => reclamationBasinIDList.Contains(x.ReclamationBasinID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteBasin(this IQueryable<Basin> basins, ICollection<Basin> basinsToDelete)
        {
            if(basinsToDelete.Any())
            {
                var reclamationBasinIDList = basinsToDelete.Select(x => x.ReclamationBasinID).ToList();
                basins.Where(x => reclamationBasinIDList.Contains(x.ReclamationBasinID)).Delete();
            }
        }

        public static void DeleteBasin(this IQueryable<Basin> basins, int reclamationBasinID)
        {
            DeleteBasin(basins, new List<int> { reclamationBasinID });
        }

        public static void DeleteBasin(this IQueryable<Basin> basins, Basin basinToDelete)
        {
            DeleteBasin(basins, new List<Basin> { basinToDelete });
        }
    }
}