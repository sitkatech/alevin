//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[tmpFishProject1]
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
        public static tmpFishProject1 GettmpFishProject1(this IQueryable<tmpFishProject1> tmpFishProject1s, int tmpFishProject1ID)
        {
            var tmpFishProject1 = tmpFishProject1s.SingleOrDefault(x => x.tmpFishProject1ID == tmpFishProject1ID);
            Check.RequireNotNullThrowNotFound(tmpFishProject1, "tmpFishProject1", tmpFishProject1ID);
            return tmpFishProject1;
        }

        // Delete using an IDList (Firma style)
        public static void DeletetmpFishProject1(this IQueryable<tmpFishProject1> tmpFishProject1s, List<int> tmpFishProject1IDList)
        {
            if(tmpFishProject1IDList.Any())
            {
                tmpFishProject1s.Where(x => tmpFishProject1IDList.Contains(x.tmpFishProject1ID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletetmpFishProject1(this IQueryable<tmpFishProject1> tmpFishProject1s, ICollection<tmpFishProject1> tmpFishProject1sToDelete)
        {
            if(tmpFishProject1sToDelete.Any())
            {
                var tmpFishProject1IDList = tmpFishProject1sToDelete.Select(x => x.tmpFishProject1ID).ToList();
                tmpFishProject1s.Where(x => tmpFishProject1IDList.Contains(x.tmpFishProject1ID)).Delete();
            }
        }

        public static void DeletetmpFishProject1(this IQueryable<tmpFishProject1> tmpFishProject1s, int tmpFishProject1ID)
        {
            DeletetmpFishProject1(tmpFishProject1s, new List<int> { tmpFishProject1ID });
        }

        public static void DeletetmpFishProject1(this IQueryable<tmpFishProject1> tmpFishProject1s, tmpFishProject1 tmpFishProject1ToDelete)
        {
            DeletetmpFishProject1(tmpFishProject1s, new List<tmpFishProject1> { tmpFishProject1ToDelete });
        }
    }
}