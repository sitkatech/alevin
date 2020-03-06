//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Agreement]
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
        public static Agreement GetAgreement(this IQueryable<Agreement> agreements, int reclamationAgreementID)
        {
            var agreement = agreements.SingleOrDefault(x => x.ReclamationAgreementID == reclamationAgreementID);
            Check.RequireNotNullThrowNotFound(agreement, "Agreement", reclamationAgreementID);
            return agreement;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreement(this IQueryable<Agreement> agreements, List<int> reclamationAgreementIDList)
        {
            if(reclamationAgreementIDList.Any())
            {
                agreements.Where(x => reclamationAgreementIDList.Contains(x.ReclamationAgreementID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreement(this IQueryable<Agreement> agreements, ICollection<Agreement> agreementsToDelete)
        {
            if(agreementsToDelete.Any())
            {
                var reclamationAgreementIDList = agreementsToDelete.Select(x => x.ReclamationAgreementID).ToList();
                agreements.Where(x => reclamationAgreementIDList.Contains(x.ReclamationAgreementID)).Delete();
            }
        }

        public static void DeleteAgreement(this IQueryable<Agreement> agreements, int reclamationAgreementID)
        {
            DeleteAgreement(agreements, new List<int> { reclamationAgreementID });
        }

        public static void DeleteAgreement(this IQueryable<Agreement> agreements, Agreement agreementToDelete)
        {
            DeleteAgreement(agreements, new List<Agreement> { agreementToDelete });
        }
    }
}