//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpPayrecV3]
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
        public static ImpPayrecV3 GetImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, int impPayrecV3ID)
        {
            var impPayrecV3 = impPayrecV3s.SingleOrDefault(x => x.ImpPayrecV3ID == impPayrecV3ID);
            Check.RequireNotNullThrowNotFound(impPayrecV3, "ImpPayrecV3", impPayrecV3ID);
            return impPayrecV3;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, List<int> impPayrecV3IDList)
        {
            if(impPayrecV3IDList.Any())
            {
                impPayrecV3s.Where(x => impPayrecV3IDList.Contains(x.ImpPayrecV3ID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, ICollection<ImpPayrecV3> impPayrecV3sToDelete)
        {
            if(impPayrecV3sToDelete.Any())
            {
                var impPayrecV3IDList = impPayrecV3sToDelete.Select(x => x.ImpPayrecV3ID).ToList();
                impPayrecV3s.Where(x => impPayrecV3IDList.Contains(x.ImpPayrecV3ID)).Delete();
            }
        }

        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, int impPayrecV3ID)
        {
            DeleteImpPayrecV3(impPayrecV3s, new List<int> { impPayrecV3ID });
        }

        public static void DeleteImpPayrecV3(this IQueryable<ImpPayrecV3> impPayrecV3s, ImpPayrecV3 impPayrecV3ToDelete)
        {
            DeleteImpPayrecV3(impPayrecV3s, new List<ImpPayrecV3> { impPayrecV3ToDelete });
        }
    }
}