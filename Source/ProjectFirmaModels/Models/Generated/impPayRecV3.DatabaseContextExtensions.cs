//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[impPayRecV3]
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
        public static impPayRecV3 GetimpPayRecV3(this IQueryable<impPayRecV3> impPayRecV3s, int impPayRecV3ID)
        {
            var impPayRecV3 = impPayRecV3s.SingleOrDefault(x => x.impPayRecV3ID == impPayRecV3ID);
            Check.RequireNotNullThrowNotFound(impPayRecV3, "impPayRecV3", impPayRecV3ID);
            return impPayRecV3;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteimpPayRecV3(this IQueryable<impPayRecV3> impPayRecV3s, List<int> impPayRecV3IDList)
        {
            if(impPayRecV3IDList.Any())
            {
                impPayRecV3s.Where(x => impPayRecV3IDList.Contains(x.impPayRecV3ID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteimpPayRecV3(this IQueryable<impPayRecV3> impPayRecV3s, ICollection<impPayRecV3> impPayRecV3sToDelete)
        {
            if(impPayRecV3sToDelete.Any())
            {
                var impPayRecV3IDList = impPayRecV3sToDelete.Select(x => x.impPayRecV3ID).ToList();
                impPayRecV3s.Where(x => impPayRecV3IDList.Contains(x.impPayRecV3ID)).Delete();
            }
        }

        public static void DeleteimpPayRecV3(this IQueryable<impPayRecV3> impPayRecV3s, int impPayRecV3ID)
        {
            DeleteimpPayRecV3(impPayRecV3s, new List<int> { impPayRecV3ID });
        }

        public static void DeleteimpPayRecV3(this IQueryable<impPayRecV3> impPayRecV3s, impPayRecV3 impPayRecV3ToDelete)
        {
            DeleteimpPayRecV3(impPayRecV3s, new List<impPayRecV3> { impPayRecV3ToDelete });
        }
    }
}