//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostAuthorityAgreement]
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
        public static CostAuthorityAgreement GetCostAuthorityAgreement(this IQueryable<CostAuthorityAgreement> costAuthorityAgreements, int costAuthorityAgreementID)
        {
            var costAuthorityAgreement = costAuthorityAgreements.SingleOrDefault(x => x.CostAuthorityAgreementID == costAuthorityAgreementID);
            Check.RequireNotNullThrowNotFound(costAuthorityAgreement, "CostAuthorityAgreement", costAuthorityAgreementID);
            return costAuthorityAgreement;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityAgreement(this IQueryable<CostAuthorityAgreement> costAuthorityAgreements, List<int> costAuthorityAgreementIDList)
        {
            if(costAuthorityAgreementIDList.Any())
            {
                costAuthorityAgreements.Where(x => costAuthorityAgreementIDList.Contains(x.CostAuthorityAgreementID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityAgreement(this IQueryable<CostAuthorityAgreement> costAuthorityAgreements, ICollection<CostAuthorityAgreement> costAuthorityAgreementsToDelete)
        {
            if(costAuthorityAgreementsToDelete.Any())
            {
                var costAuthorityAgreementIDList = costAuthorityAgreementsToDelete.Select(x => x.CostAuthorityAgreementID).ToList();
                costAuthorityAgreements.Where(x => costAuthorityAgreementIDList.Contains(x.CostAuthorityAgreementID)).Delete();
            }
        }

        public static void DeleteCostAuthorityAgreement(this IQueryable<CostAuthorityAgreement> costAuthorityAgreements, int costAuthorityAgreementID)
        {
            DeleteCostAuthorityAgreement(costAuthorityAgreements, new List<int> { costAuthorityAgreementID });
        }

        public static void DeleteCostAuthorityAgreement(this IQueryable<CostAuthorityAgreement> costAuthorityAgreements, CostAuthorityAgreement costAuthorityAgreementToDelete)
        {
            DeleteCostAuthorityAgreement(costAuthorityAgreements, new List<CostAuthorityAgreement> { costAuthorityAgreementToDelete });
        }
    }
}