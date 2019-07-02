//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostAuthority]
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
        public static CostAuthority GetCostAuthority(this IQueryable<CostAuthority> costAuthorities, int costAuthorityID)
        {
            var costAuthority = costAuthorities.SingleOrDefault(x => x.CostAuthorityID == costAuthorityID);
            Check.RequireNotNullThrowNotFound(costAuthority, "CostAuthority", costAuthorityID);
            return costAuthority;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, List<int> costAuthorityIDList)
        {
            if(costAuthorityIDList.Any())
            {
                costAuthorities.Where(x => costAuthorityIDList.Contains(x.CostAuthorityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, ICollection<CostAuthority> costAuthoritiesToDelete)
        {
            if(costAuthoritiesToDelete.Any())
            {
                var costAuthorityIDList = costAuthoritiesToDelete.Select(x => x.CostAuthorityID).ToList();
                costAuthorities.Where(x => costAuthorityIDList.Contains(x.CostAuthorityID)).Delete();
            }
        }

        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, int costAuthorityID)
        {
            DeleteCostAuthority(costAuthorities, new List<int> { costAuthorityID });
        }

        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, CostAuthority costAuthorityToDelete)
        {
            DeleteCostAuthority(costAuthorities, new List<CostAuthority> { costAuthorityToDelete });
        }
    }
}