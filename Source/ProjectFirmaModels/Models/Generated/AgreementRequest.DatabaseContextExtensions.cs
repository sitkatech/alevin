//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementRequest]
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
        public static AgreementRequest GetAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, int agreementRequestID)
        {
            var agreementRequest = agreementRequests.SingleOrDefault(x => x.AgreementRequestID == agreementRequestID);
            Check.RequireNotNullThrowNotFound(agreementRequest, "AgreementRequest", agreementRequestID);
            return agreementRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, List<int> agreementRequestIDList)
        {
            if(agreementRequestIDList.Any())
            {
                agreementRequests.Where(x => agreementRequestIDList.Contains(x.AgreementRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, ICollection<AgreementRequest> agreementRequestsToDelete)
        {
            if(agreementRequestsToDelete.Any())
            {
                var agreementRequestIDList = agreementRequestsToDelete.Select(x => x.AgreementRequestID).ToList();
                agreementRequests.Where(x => agreementRequestIDList.Contains(x.AgreementRequestID)).Delete();
            }
        }

        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, int agreementRequestID)
        {
            DeleteAgreementRequest(agreementRequests, new List<int> { agreementRequestID });
        }

        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, AgreementRequest agreementRequestToDelete)
        {
            DeleteAgreementRequest(agreementRequests, new List<AgreementRequest> { agreementRequestToDelete });
        }
    }
}