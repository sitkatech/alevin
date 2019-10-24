//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject2PopulationDissolve]
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
        public static tmpFishProject2PopulationDissolve GettmpFishProject2PopulationDissolve(this IQueryable<tmpFishProject2PopulationDissolve> tmpFishProject2PopulationDissolves, int tmpFishProject2PopulationDissolveID)
        {
            var tmpFishProject2PopulationDissolve = tmpFishProject2PopulationDissolves.SingleOrDefault(x => x.tmpFishProject2PopulationDissolveID == tmpFishProject2PopulationDissolveID);
            Check.RequireNotNullThrowNotFound(tmpFishProject2PopulationDissolve, "tmpFishProject2PopulationDissolve", tmpFishProject2PopulationDissolveID);
            return tmpFishProject2PopulationDissolve;
        }

        // Delete using an IDList (Firma style)
        public static void DeletetmpFishProject2PopulationDissolve(this IQueryable<tmpFishProject2PopulationDissolve> tmpFishProject2PopulationDissolves, List<int> tmpFishProject2PopulationDissolveIDList)
        {
            if(tmpFishProject2PopulationDissolveIDList.Any())
            {
                tmpFishProject2PopulationDissolves.Where(x => tmpFishProject2PopulationDissolveIDList.Contains(x.tmpFishProject2PopulationDissolveID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletetmpFishProject2PopulationDissolve(this IQueryable<tmpFishProject2PopulationDissolve> tmpFishProject2PopulationDissolves, ICollection<tmpFishProject2PopulationDissolve> tmpFishProject2PopulationDissolvesToDelete)
        {
            if(tmpFishProject2PopulationDissolvesToDelete.Any())
            {
                var tmpFishProject2PopulationDissolveIDList = tmpFishProject2PopulationDissolvesToDelete.Select(x => x.tmpFishProject2PopulationDissolveID).ToList();
                tmpFishProject2PopulationDissolves.Where(x => tmpFishProject2PopulationDissolveIDList.Contains(x.tmpFishProject2PopulationDissolveID)).Delete();
            }
        }

        public static void DeletetmpFishProject2PopulationDissolve(this IQueryable<tmpFishProject2PopulationDissolve> tmpFishProject2PopulationDissolves, int tmpFishProject2PopulationDissolveID)
        {
            DeletetmpFishProject2PopulationDissolve(tmpFishProject2PopulationDissolves, new List<int> { tmpFishProject2PopulationDissolveID });
        }

        public static void DeletetmpFishProject2PopulationDissolve(this IQueryable<tmpFishProject2PopulationDissolve> tmpFishProject2PopulationDissolves, tmpFishProject2PopulationDissolve tmpFishProject2PopulationDissolveToDelete)
        {
            DeletetmpFishProject2PopulationDissolve(tmpFishProject2PopulationDissolves, new List<tmpFishProject2PopulationDissolve> { tmpFishProject2PopulationDissolveToDelete });
        }
    }
}