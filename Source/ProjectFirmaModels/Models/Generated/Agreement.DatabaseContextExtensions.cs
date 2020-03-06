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
        public static Agreement GetAgreement(this IQueryable<Agreement> agreements, int agreementID)
        {
            var agreement = agreements.SingleOrDefault(x => x.AgreementID == agreementID);
            Check.RequireNotNullThrowNotFound(agreement, "Agreement", agreementID);
            return agreement;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreement(this IQueryable<Agreement> agreements, List<int> agreementIDList)
        {
            if(agreementIDList.Any())
            {
                agreements.Where(x => agreementIDList.Contains(x.AgreementID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreement(this IQueryable<Agreement> agreements, ICollection<Agreement> agreementsToDelete)
        {
            if(agreementsToDelete.Any())
            {
                var agreementIDList = agreementsToDelete.Select(x => x.AgreementID).ToList();
                agreements.Where(x => agreementIDList.Contains(x.AgreementID)).Delete();
            }
        }

        public static void DeleteAgreement(this IQueryable<Agreement> agreements, int agreementID)
        {
            DeleteAgreement(agreements, new List<int> { agreementID });
        }

        public static void DeleteAgreement(this IQueryable<Agreement> agreements, Agreement agreementToDelete)
        {
            DeleteAgreement(agreements, new List<Agreement> { agreementToDelete });
        }
    }
}