//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityAgreementRequest]
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
        public static CostAuthorityAgreementRequest GetCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, int costAuthorityAgreementRequestID)
        {
            var costAuthorityAgreementRequest = costAuthorityAgreementRequests.SingleOrDefault(x => x.CostAuthorityAgreementRequestID == costAuthorityAgreementRequestID);
            Check.RequireNotNullThrowNotFound(costAuthorityAgreementRequest, "CostAuthorityAgreementRequest", costAuthorityAgreementRequestID);
            return costAuthorityAgreementRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, List<int> costAuthorityAgreementRequestIDList)
        {
            if(costAuthorityAgreementRequestIDList.Any())
            {
                costAuthorityAgreementRequests.Where(x => costAuthorityAgreementRequestIDList.Contains(x.CostAuthorityAgreementRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, ICollection<CostAuthorityAgreementRequest> costAuthorityAgreementRequestsToDelete)
        {
            if(costAuthorityAgreementRequestsToDelete.Any())
            {
                var costAuthorityAgreementRequestIDList = costAuthorityAgreementRequestsToDelete.Select(x => x.CostAuthorityAgreementRequestID).ToList();
                costAuthorityAgreementRequests.Where(x => costAuthorityAgreementRequestIDList.Contains(x.CostAuthorityAgreementRequestID)).Delete();
            }
        }

        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, int costAuthorityAgreementRequestID)
        {
            DeleteCostAuthorityAgreementRequest(costAuthorityAgreementRequests, new List<int> { costAuthorityAgreementRequestID });
        }

        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, CostAuthorityAgreementRequest costAuthorityAgreementRequestToDelete)
        {
            DeleteCostAuthorityAgreementRequest(costAuthorityAgreementRequests, new List<CostAuthorityAgreementRequest> { costAuthorityAgreementRequestToDelete });
        }
    }
}