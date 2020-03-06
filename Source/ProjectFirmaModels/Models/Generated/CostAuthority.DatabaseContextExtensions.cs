//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthority]
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
        public static CostAuthority GetCostAuthority(this IQueryable<CostAuthority> costAuthorities, int reclamationCostAuthorityID)
        {
            var costAuthority = costAuthorities.SingleOrDefault(x => x.ReclamationCostAuthorityID == reclamationCostAuthorityID);
            Check.RequireNotNullThrowNotFound(costAuthority, "CostAuthority", reclamationCostAuthorityID);
            return costAuthority;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, List<int> reclamationCostAuthorityIDList)
        {
            if(reclamationCostAuthorityIDList.Any())
            {
                costAuthorities.Where(x => reclamationCostAuthorityIDList.Contains(x.ReclamationCostAuthorityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, ICollection<CostAuthority> costAuthoritiesToDelete)
        {
            if(costAuthoritiesToDelete.Any())
            {
                var reclamationCostAuthorityIDList = costAuthoritiesToDelete.Select(x => x.ReclamationCostAuthorityID).ToList();
                costAuthorities.Where(x => reclamationCostAuthorityIDList.Contains(x.ReclamationCostAuthorityID)).Delete();
            }
        }

        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, int reclamationCostAuthorityID)
        {
            DeleteCostAuthority(costAuthorities, new List<int> { reclamationCostAuthorityID });
        }

        public static void DeleteCostAuthority(this IQueryable<CostAuthority> costAuthorities, CostAuthority costAuthorityToDelete)
        {
            DeleteCostAuthority(costAuthorities, new List<CostAuthority> { costAuthorityToDelete });
        }
    }
}