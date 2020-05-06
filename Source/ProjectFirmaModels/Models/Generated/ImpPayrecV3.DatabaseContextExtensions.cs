//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpPayrecV3]
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
        public static ImpPayrecV3 GetImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, int impPayRecV3ID)
        {
            var impPayrecV3 = impPayrecV3s.SingleOrDefault(x => x.impPayRecV3ID == impPayRecV3ID);
            Check.RequireNotNullThrowNotFound(impPayrecV3, "ImpPayrecV3", impPayRecV3ID);
            return impPayrecV3;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, List<int> impPayRecV3IDList)
        {
            if(impPayRecV3IDList.Any())
            {
                impPayrecV3s.Where(x => impPayRecV3IDList.Contains(x.impPayRecV3ID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, ICollection<ImpPayrecV3> impPayrecV3sToDelete)
        {
            if(impPayrecV3sToDelete.Any())
            {
                var impPayRecV3IDList = impPayrecV3sToDelete.Select(x => x.impPayRecV3ID).ToList();
                impPayrecV3s.Where(x => impPayRecV3IDList.Contains(x.impPayRecV3ID)).Delete();
            }
        }

        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, int impPayRecV3ID)
        {
            DeleteImpPayrecV3(impPayrecV3s, new List<int> { impPayRecV3ID });
        }

        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, ImpPayrecV3 impPayrecV3ToDelete)
        {
            DeleteImpPayrecV3(impPayrecV3s, new List<ImpPayrecV3> { impPayrecV3ToDelete });
        }
    }
}