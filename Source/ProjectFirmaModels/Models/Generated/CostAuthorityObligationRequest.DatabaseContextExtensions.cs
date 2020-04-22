//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityObligationRequest]
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
        public static CostAuthorityObligationRequest GetCostAuthorityObligationRequest(this IQueryable<CostAuthorityObligationRequest> costAuthorityObligationRequests, int costAuthorityObligationRequestID)
        {
            var costAuthorityObligationRequest = costAuthorityObligationRequests.SingleOrDefault(x => x.CostAuthorityObligationRequestID == costAuthorityObligationRequestID);
            Check.RequireNotNullThrowNotFound(costAuthorityObligationRequest, "CostAuthorityObligationRequest", costAuthorityObligationRequestID);
            return costAuthorityObligationRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityObligationRequest(this IQueryable<CostAuthorityObligationRequest> costAuthorityObligationRequests, List<int> costAuthorityObligationRequestIDList)
        {
            if(costAuthorityObligationRequestIDList.Any())
            {
                costAuthorityObligationRequests.Where(x => costAuthorityObligationRequestIDList.Contains(x.CostAuthorityObligationRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityObligationRequest(this IQueryable<CostAuthorityObligationRequest> costAuthorityObligationRequests, ICollection<CostAuthorityObligationRequest> costAuthorityObligationRequestsToDelete)
        {
            if(costAuthorityObligationRequestsToDelete.Any())
            {
                var costAuthorityObligationRequestIDList = costAuthorityObligationRequestsToDelete.Select(x => x.CostAuthorityObligationRequestID).ToList();
                costAuthorityObligationRequests.Where(x => costAuthorityObligationRequestIDList.Contains(x.CostAuthorityObligationRequestID)).Delete();
            }
        }

        public static void DeleteCostAuthorityObligationRequest(this IQueryable<CostAuthorityObligationRequest> costAuthorityObligationRequests, int costAuthorityObligationRequestID)
        {
            DeleteCostAuthorityObligationRequest(costAuthorityObligationRequests, new List<int> { costAuthorityObligationRequestID });
        }

        public static void DeleteCostAuthorityObligationRequest(this IQueryable<CostAuthorityObligationRequest> costAuthorityObligationRequests, CostAuthorityObligationRequest costAuthorityObligationRequestToDelete)
        {
            DeleteCostAuthorityObligationRequest(costAuthorityObligationRequests, new List<CostAuthorityObligationRequest> { costAuthorityObligationRequestToDelete });
        }
    }
}