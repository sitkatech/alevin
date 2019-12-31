//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject2Dissolve]
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
        public static tmpFishProject2Dissolve GettmpFishProject2Dissolve(this IQueryable<tmpFishProject2Dissolve> tmpFishProject2Dissolves, int tmpFishProject2DissolveID)
        {
            var tmpFishProject2Dissolve = tmpFishProject2Dissolves.SingleOrDefault(x => x.tmpFishProject2DissolveID == tmpFishProject2DissolveID);
            Check.RequireNotNullThrowNotFound(tmpFishProject2Dissolve, "tmpFishProject2Dissolve", tmpFishProject2DissolveID);
            return tmpFishProject2Dissolve;
        }

        // Delete using an IDList (Firma style)
        public static void DeletetmpFishProject2Dissolve(this IQueryable<tmpFishProject2Dissolve> tmpFishProject2Dissolves, List<int> tmpFishProject2DissolveIDList)
        {
            if(tmpFishProject2DissolveIDList.Any())
            {
                tmpFishProject2Dissolves.Where(x => tmpFishProject2DissolveIDList.Contains(x.tmpFishProject2DissolveID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletetmpFishProject2Dissolve(this IQueryable<tmpFishProject2Dissolve> tmpFishProject2Dissolves, ICollection<tmpFishProject2Dissolve> tmpFishProject2DissolvesToDelete)
        {
            if(tmpFishProject2DissolvesToDelete.Any())
            {
                var tmpFishProject2DissolveIDList = tmpFishProject2DissolvesToDelete.Select(x => x.tmpFishProject2DissolveID).ToList();
                tmpFishProject2Dissolves.Where(x => tmpFishProject2DissolveIDList.Contains(x.tmpFishProject2DissolveID)).Delete();
            }
        }

        public static void DeletetmpFishProject2Dissolve(this IQueryable<tmpFishProject2Dissolve> tmpFishProject2Dissolves, int tmpFishProject2DissolveID)
        {
            DeletetmpFishProject2Dissolve(tmpFishProject2Dissolves, new List<int> { tmpFishProject2DissolveID });
        }

        public static void DeletetmpFishProject2Dissolve(this IQueryable<tmpFishProject2Dissolve> tmpFishProject2Dissolves, tmpFishProject2Dissolve tmpFishProject2DissolveToDelete)
        {
            DeletetmpFishProject2Dissolve(tmpFishProject2Dissolves, new List<tmpFishProject2Dissolve> { tmpFishProject2DissolveToDelete });
        }
    }
}