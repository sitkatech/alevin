//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationCostAuthorityAgreementRequest]
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
        public static ReclamationCostAuthorityAgreementRequest GetReclamationCostAuthorityAgreementRequest(this IQueryable<ReclamationCostAuthorityAgreementRequest> reclamationCostAuthorityAgreementRequests, int reclamationCostAuthorityAgreementRequestID)
        {
            var reclamationCostAuthorityAgreementRequest = reclamationCostAuthorityAgreementRequests.SingleOrDefault(x => x.ReclamationCostAuthorityAgreementRequestID == reclamationCostAuthorityAgreementRequestID);
            Check.RequireNotNullThrowNotFound(reclamationCostAuthorityAgreementRequest, "ReclamationCostAuthorityAgreementRequest", reclamationCostAuthorityAgreementRequestID);
            return reclamationCostAuthorityAgreementRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationCostAuthorityAgreementRequest(this IQueryable<ReclamationCostAuthorityAgreementRequest> reclamationCostAuthorityAgreementRequests, List<int> reclamationCostAuthorityAgreementRequestIDList)
        {
            if(reclamationCostAuthorityAgreementRequestIDList.Any())
            {
                reclamationCostAuthorityAgreementRequests.Where(x => reclamationCostAuthorityAgreementRequestIDList.Contains(x.ReclamationCostAuthorityAgreementRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationCostAuthorityAgreementRequest(this IQueryable<ReclamationCostAuthorityAgreementRequest> reclamationCostAuthorityAgreementRequests, ICollection<ReclamationCostAuthorityAgreementRequest> reclamationCostAuthorityAgreementRequestsToDelete)
        {
            if(reclamationCostAuthorityAgreementRequestsToDelete.Any())
            {
                var reclamationCostAuthorityAgreementRequestIDList = reclamationCostAuthorityAgreementRequestsToDelete.Select(x => x.ReclamationCostAuthorityAgreementRequestID).ToList();
                reclamationCostAuthorityAgreementRequests.Where(x => reclamationCostAuthorityAgreementRequestIDList.Contains(x.ReclamationCostAuthorityAgreementRequestID)).Delete();
            }
        }

        public static void DeleteReclamationCostAuthorityAgreementRequest(this IQueryable<ReclamationCostAuthorityAgreementRequest> reclamationCostAuthorityAgreementRequests, int reclamationCostAuthorityAgreementRequestID)
        {
            DeleteReclamationCostAuthorityAgreementRequest(reclamationCostAuthorityAgreementRequests, new List<int> { reclamationCostAuthorityAgreementRequestID });
        }

        public static void DeleteReclamationCostAuthorityAgreementRequest(this IQueryable<ReclamationCostAuthorityAgreementRequest> reclamationCostAuthorityAgreementRequests, ReclamationCostAuthorityAgreementRequest reclamationCostAuthorityAgreementRequestToDelete)
        {
            DeleteReclamationCostAuthorityAgreementRequest(reclamationCostAuthorityAgreementRequests, new List<ReclamationCostAuthorityAgreementRequest> { reclamationCostAuthorityAgreementRequestToDelete });
        }
    }
}