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
        public static CostAuthorityAgreementRequest GetCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, int reclamationCostAuthorityAgreementRequestID)
        {
            var costAuthorityAgreementRequest = costAuthorityAgreementRequests.SingleOrDefault(x => x.ReclamationCostAuthorityAgreementRequestID == reclamationCostAuthorityAgreementRequestID);
            Check.RequireNotNullThrowNotFound(costAuthorityAgreementRequest, "CostAuthorityAgreementRequest", reclamationCostAuthorityAgreementRequestID);
            return costAuthorityAgreementRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, List<int> reclamationCostAuthorityAgreementRequestIDList)
        {
            if(reclamationCostAuthorityAgreementRequestIDList.Any())
            {
                costAuthorityAgreementRequests.Where(x => reclamationCostAuthorityAgreementRequestIDList.Contains(x.ReclamationCostAuthorityAgreementRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, ICollection<CostAuthorityAgreementRequest> costAuthorityAgreementRequestsToDelete)
        {
            if(costAuthorityAgreementRequestsToDelete.Any())
            {
                var reclamationCostAuthorityAgreementRequestIDList = costAuthorityAgreementRequestsToDelete.Select(x => x.ReclamationCostAuthorityAgreementRequestID).ToList();
                costAuthorityAgreementRequests.Where(x => reclamationCostAuthorityAgreementRequestIDList.Contains(x.ReclamationCostAuthorityAgreementRequestID)).Delete();
            }
        }

        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, int reclamationCostAuthorityAgreementRequestID)
        {
            DeleteCostAuthorityAgreementRequest(costAuthorityAgreementRequests, new List<int> { reclamationCostAuthorityAgreementRequestID });
        }

        public static void DeleteCostAuthorityAgreementRequest(this IQueryable<CostAuthorityAgreementRequest> costAuthorityAgreementRequests, CostAuthorityAgreementRequest costAuthorityAgreementRequestToDelete)
        {
            DeleteCostAuthorityAgreementRequest(costAuthorityAgreementRequests, new List<CostAuthorityAgreementRequest> { costAuthorityAgreementRequestToDelete });
        }
    }
}