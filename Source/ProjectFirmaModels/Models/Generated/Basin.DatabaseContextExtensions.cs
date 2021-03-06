//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Basin]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Basin GetBasin(this IQueryable<Basin> basins, int basinID)
        {
            var basin = basins.SingleOrDefault(x => x.BasinID == basinID);
            Check.RequireNotNullThrowNotFound(basin, "Basin", basinID);
            return basin;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteBasin(this IQueryable<Basin> basins, List<int> basinIDList)
        {
            if(basinIDList.Any())
            {
                basins.Where(x => basinIDList.Contains(x.BasinID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteBasin(this IQueryable<Basin> basins, ICollection<Basin> basinsToDelete)
        {
            if(basinsToDelete.Any())
            {
                var basinIDList = basinsToDelete.Select(x => x.BasinID).ToList();
                basins.Where(x => basinIDList.Contains(x.BasinID)).Delete();
            }
        }

        public static void DeleteBasin(this IQueryable<Basin> basins, int basinID)
        {
            DeleteBasin(basins, new List<int> { basinID });
        }

        public static void DeleteBasin(this IQueryable<Basin> basins, Basin basinToDelete)
        {
            DeleteBasin(basins, new List<Basin> { basinToDelete });
        }
    }
}