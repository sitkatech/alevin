//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ObligationRequest]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ObligationRequest GetObligationRequest(this IQueryable<ObligationRequest> obligationRequests, int obligationRequestID)
        {
            var obligationRequest = obligationRequests.SingleOrDefault(x => x.ObligationRequestID == obligationRequestID);
            Check.RequireNotNullThrowNotFound(obligationRequest, "ObligationRequest", obligationRequestID);
            return obligationRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteObligationRequest(this IQueryable<ObligationRequest> obligationRequests, List<int> obligationRequestIDList)
        {
            if(obligationRequestIDList.Any())
            {
                obligationRequests.Where(x => obligationRequestIDList.Contains(x.ObligationRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteObligationRequest(this IQueryable<ObligationRequest> obligationRequests, ICollection<ObligationRequest> obligationRequestsToDelete)
        {
            if(obligationRequestsToDelete.Any())
            {
                var obligationRequestIDList = obligationRequestsToDelete.Select(x => x.ObligationRequestID).ToList();
                obligationRequests.Where(x => obligationRequestIDList.Contains(x.ObligationRequestID)).Delete();
            }
        }

        public static void DeleteObligationRequest(this IQueryable<ObligationRequest> obligationRequests, int obligationRequestID)
        {
            DeleteObligationRequest(obligationRequests, new List<int> { obligationRequestID });
        }

        public static void DeleteObligationRequest(this IQueryable<ObligationRequest> obligationRequests, ObligationRequest obligationRequestToDelete)
        {
            DeleteObligationRequest(obligationRequests, new List<ObligationRequest> { obligationRequestToDelete });
        }
    }
}