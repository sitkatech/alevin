//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationAgreementRequest]
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
        public static ReclamationAgreementRequest GetReclamationAgreementRequest(this IQueryable<ReclamationAgreementRequest> reclamationAgreementRequests, int reclamationAgreementRequestID)
        {
            var reclamationAgreementRequest = reclamationAgreementRequests.SingleOrDefault(x => x.ReclamationAgreementRequestID == reclamationAgreementRequestID);
            Check.RequireNotNullThrowNotFound(reclamationAgreementRequest, "ReclamationAgreementRequest", reclamationAgreementRequestID);
            return reclamationAgreementRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationAgreementRequest(this IQueryable<ReclamationAgreementRequest> reclamationAgreementRequests, List<int> reclamationAgreementRequestIDList)
        {
            if(reclamationAgreementRequestIDList.Any())
            {
                reclamationAgreementRequests.Where(x => reclamationAgreementRequestIDList.Contains(x.ReclamationAgreementRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationAgreementRequest(this IQueryable<ReclamationAgreementRequest> reclamationAgreementRequests, ICollection<ReclamationAgreementRequest> reclamationAgreementRequestsToDelete)
        {
            if(reclamationAgreementRequestsToDelete.Any())
            {
                var reclamationAgreementRequestIDList = reclamationAgreementRequestsToDelete.Select(x => x.ReclamationAgreementRequestID).ToList();
                reclamationAgreementRequests.Where(x => reclamationAgreementRequestIDList.Contains(x.ReclamationAgreementRequestID)).Delete();
            }
        }

        public static void DeleteReclamationAgreementRequest(this IQueryable<ReclamationAgreementRequest> reclamationAgreementRequests, int reclamationAgreementRequestID)
        {
            DeleteReclamationAgreementRequest(reclamationAgreementRequests, new List<int> { reclamationAgreementRequestID });
        }

        public static void DeleteReclamationAgreementRequest(this IQueryable<ReclamationAgreementRequest> reclamationAgreementRequests, ReclamationAgreementRequest reclamationAgreementRequestToDelete)
        {
            DeleteReclamationAgreementRequest(reclamationAgreementRequests, new List<ReclamationAgreementRequest> { reclamationAgreementRequestToDelete });
        }
    }
}