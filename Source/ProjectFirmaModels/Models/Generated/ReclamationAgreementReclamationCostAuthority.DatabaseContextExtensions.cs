//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementReclamationCostAuthority]
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
        public static ReclamationAgreementReclamationCostAuthority GetReclamationAgreementReclamationCostAuthority(this IQueryable<ReclamationAgreementReclamationCostAuthority> reclamationAgreementReclamationCostAuthorities, int reclamationAgreementReclamationCostAuthorityID)
        {
            var reclamationAgreementReclamationCostAuthority = reclamationAgreementReclamationCostAuthorities.SingleOrDefault(x => x.ReclamationAgreementReclamationCostAuthorityID == reclamationAgreementReclamationCostAuthorityID);
            Check.RequireNotNullThrowNotFound(reclamationAgreementReclamationCostAuthority, "ReclamationAgreementReclamationCostAuthority", reclamationAgreementReclamationCostAuthorityID);
            return reclamationAgreementReclamationCostAuthority;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationAgreementReclamationCostAuthority(this IQueryable<ReclamationAgreementReclamationCostAuthority> reclamationAgreementReclamationCostAuthorities, List<int> reclamationAgreementReclamationCostAuthorityIDList)
        {
            if(reclamationAgreementReclamationCostAuthorityIDList.Any())
            {
                reclamationAgreementReclamationCostAuthorities.Where(x => reclamationAgreementReclamationCostAuthorityIDList.Contains(x.ReclamationAgreementReclamationCostAuthorityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationAgreementReclamationCostAuthority(this IQueryable<ReclamationAgreementReclamationCostAuthority> reclamationAgreementReclamationCostAuthorities, ICollection<ReclamationAgreementReclamationCostAuthority> reclamationAgreementReclamationCostAuthoritiesToDelete)
        {
            if(reclamationAgreementReclamationCostAuthoritiesToDelete.Any())
            {
                var reclamationAgreementReclamationCostAuthorityIDList = reclamationAgreementReclamationCostAuthoritiesToDelete.Select(x => x.ReclamationAgreementReclamationCostAuthorityID).ToList();
                reclamationAgreementReclamationCostAuthorities.Where(x => reclamationAgreementReclamationCostAuthorityIDList.Contains(x.ReclamationAgreementReclamationCostAuthorityID)).Delete();
            }
        }

        public static void DeleteReclamationAgreementReclamationCostAuthority(this IQueryable<ReclamationAgreementReclamationCostAuthority> reclamationAgreementReclamationCostAuthorities, int reclamationAgreementReclamationCostAuthorityID)
        {
            DeleteReclamationAgreementReclamationCostAuthority(reclamationAgreementReclamationCostAuthorities, new List<int> { reclamationAgreementReclamationCostAuthorityID });
        }

        public static void DeleteReclamationAgreementReclamationCostAuthority(this IQueryable<ReclamationAgreementReclamationCostAuthority> reclamationAgreementReclamationCostAuthorities, ReclamationAgreementReclamationCostAuthority reclamationAgreementReclamationCostAuthorityToDelete)
        {
            DeleteReclamationAgreementReclamationCostAuthority(reclamationAgreementReclamationCostAuthorities, new List<ReclamationAgreementReclamationCostAuthority> { reclamationAgreementReclamationCostAuthorityToDelete });
        }
    }
}