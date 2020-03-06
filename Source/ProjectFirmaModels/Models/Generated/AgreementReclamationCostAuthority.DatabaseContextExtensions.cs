//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementReclamationCostAuthority]
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
        public static AgreementReclamationCostAuthority GetAgreementReclamationCostAuthority(this IQueryable<AgreementReclamationCostAuthority> agreementReclamationCostAuthorities, int reclamationAgreementReclamationCostAuthorityID)
        {
            var agreementReclamationCostAuthority = agreementReclamationCostAuthorities.SingleOrDefault(x => x.ReclamationAgreementReclamationCostAuthorityID == reclamationAgreementReclamationCostAuthorityID);
            Check.RequireNotNullThrowNotFound(agreementReclamationCostAuthority, "AgreementReclamationCostAuthority", reclamationAgreementReclamationCostAuthorityID);
            return agreementReclamationCostAuthority;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementReclamationCostAuthority(this IQueryable<AgreementReclamationCostAuthority> agreementReclamationCostAuthorities, List<int> reclamationAgreementReclamationCostAuthorityIDList)
        {
            if(reclamationAgreementReclamationCostAuthorityIDList.Any())
            {
                agreementReclamationCostAuthorities.Where(x => reclamationAgreementReclamationCostAuthorityIDList.Contains(x.ReclamationAgreementReclamationCostAuthorityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementReclamationCostAuthority(this IQueryable<AgreementReclamationCostAuthority> agreementReclamationCostAuthorities, ICollection<AgreementReclamationCostAuthority> agreementReclamationCostAuthoritiesToDelete)
        {
            if(agreementReclamationCostAuthoritiesToDelete.Any())
            {
                var reclamationAgreementReclamationCostAuthorityIDList = agreementReclamationCostAuthoritiesToDelete.Select(x => x.ReclamationAgreementReclamationCostAuthorityID).ToList();
                agreementReclamationCostAuthorities.Where(x => reclamationAgreementReclamationCostAuthorityIDList.Contains(x.ReclamationAgreementReclamationCostAuthorityID)).Delete();
            }
        }

        public static void DeleteAgreementReclamationCostAuthority(this IQueryable<AgreementReclamationCostAuthority> agreementReclamationCostAuthorities, int reclamationAgreementReclamationCostAuthorityID)
        {
            DeleteAgreementReclamationCostAuthority(agreementReclamationCostAuthorities, new List<int> { reclamationAgreementReclamationCostAuthorityID });
        }

        public static void DeleteAgreementReclamationCostAuthority(this IQueryable<AgreementReclamationCostAuthority> agreementReclamationCostAuthorities, AgreementReclamationCostAuthority agreementReclamationCostAuthorityToDelete)
        {
            DeleteAgreementReclamationCostAuthority(agreementReclamationCostAuthorities, new List<AgreementReclamationCostAuthority> { agreementReclamationCostAuthorityToDelete });
        }
    }
}