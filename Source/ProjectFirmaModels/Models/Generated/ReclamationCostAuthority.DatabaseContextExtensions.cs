//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationCostAuthority]
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
        public static ReclamationCostAuthority GetReclamationCostAuthority(this IQueryable<ReclamationCostAuthority> reclamationCostAuthorities, int reclamationCostAuthorityID)
        {
            var reclamationCostAuthority = reclamationCostAuthorities.SingleOrDefault(x => x.ReclamationCostAuthorityID == reclamationCostAuthorityID);
            Check.RequireNotNullThrowNotFound(reclamationCostAuthority, "ReclamationCostAuthority", reclamationCostAuthorityID);
            return reclamationCostAuthority;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationCostAuthority(this IQueryable<ReclamationCostAuthority> reclamationCostAuthorities, List<int> reclamationCostAuthorityIDList)
        {
            if(reclamationCostAuthorityIDList.Any())
            {
                reclamationCostAuthorities.Where(x => reclamationCostAuthorityIDList.Contains(x.ReclamationCostAuthorityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationCostAuthority(this IQueryable<ReclamationCostAuthority> reclamationCostAuthorities, ICollection<ReclamationCostAuthority> reclamationCostAuthoritiesToDelete)
        {
            if(reclamationCostAuthoritiesToDelete.Any())
            {
                var reclamationCostAuthorityIDList = reclamationCostAuthoritiesToDelete.Select(x => x.ReclamationCostAuthorityID).ToList();
                reclamationCostAuthorities.Where(x => reclamationCostAuthorityIDList.Contains(x.ReclamationCostAuthorityID)).Delete();
            }
        }

        public static void DeleteReclamationCostAuthority(this IQueryable<ReclamationCostAuthority> reclamationCostAuthorities, int reclamationCostAuthorityID)
        {
            DeleteReclamationCostAuthority(reclamationCostAuthorities, new List<int> { reclamationCostAuthorityID });
        }

        public static void DeleteReclamationCostAuthority(this IQueryable<ReclamationCostAuthority> reclamationCostAuthorities, ReclamationCostAuthority reclamationCostAuthorityToDelete)
        {
            DeleteReclamationCostAuthority(reclamationCostAuthorities, new List<ReclamationCostAuthority> { reclamationCostAuthorityToDelete });
        }
    }
}