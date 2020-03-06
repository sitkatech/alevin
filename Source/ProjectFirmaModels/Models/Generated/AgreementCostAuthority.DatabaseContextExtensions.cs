//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementCostAuthority]
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
        public static AgreementCostAuthority GetAgreementCostAuthority(this IQueryable<AgreementCostAuthority> agreementCostAuthorities, int agreementCostAuthorityID)
        {
            var agreementCostAuthority = agreementCostAuthorities.SingleOrDefault(x => x.AgreementCostAuthorityID == agreementCostAuthorityID);
            Check.RequireNotNullThrowNotFound(agreementCostAuthority, "AgreementCostAuthority", agreementCostAuthorityID);
            return agreementCostAuthority;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementCostAuthority(this IQueryable<AgreementCostAuthority> agreementCostAuthorities, List<int> agreementCostAuthorityIDList)
        {
            if(agreementCostAuthorityIDList.Any())
            {
                agreementCostAuthorities.Where(x => agreementCostAuthorityIDList.Contains(x.AgreementCostAuthorityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementCostAuthority(this IQueryable<AgreementCostAuthority> agreementCostAuthorities, ICollection<AgreementCostAuthority> agreementCostAuthoritiesToDelete)
        {
            if(agreementCostAuthoritiesToDelete.Any())
            {
                var agreementCostAuthorityIDList = agreementCostAuthoritiesToDelete.Select(x => x.AgreementCostAuthorityID).ToList();
                agreementCostAuthorities.Where(x => agreementCostAuthorityIDList.Contains(x.AgreementCostAuthorityID)).Delete();
            }
        }

        public static void DeleteAgreementCostAuthority(this IQueryable<AgreementCostAuthority> agreementCostAuthorities, int agreementCostAuthorityID)
        {
            DeleteAgreementCostAuthority(agreementCostAuthorities, new List<int> { agreementCostAuthorityID });
        }

        public static void DeleteAgreementCostAuthority(this IQueryable<AgreementCostAuthority> agreementCostAuthorities, AgreementCostAuthority agreementCostAuthorityToDelete)
        {
            DeleteAgreementCostAuthority(agreementCostAuthorities, new List<AgreementCostAuthority> { agreementCostAuthorityToDelete });
        }
    }
}