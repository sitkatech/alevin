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
        public static AgreementRequest GetAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, int reclamationAgreementRequestID)
        {
            var agreementRequest = agreementRequests.SingleOrDefault(x => x.ReclamationAgreementRequestID == reclamationAgreementRequestID);
            Check.RequireNotNullThrowNotFound(agreementRequest, "AgreementRequest", reclamationAgreementRequestID);
            return agreementRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, List<int> reclamationAgreementRequestIDList)
        {
            if(reclamationAgreementRequestIDList.Any())
            {
                agreementRequests.Where(x => reclamationAgreementRequestIDList.Contains(x.ReclamationAgreementRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, ICollection<AgreementRequest> agreementRequestsToDelete)
        {
            if(agreementRequestsToDelete.Any())
            {
                var reclamationAgreementRequestIDList = agreementRequestsToDelete.Select(x => x.ReclamationAgreementRequestID).ToList();
                agreementRequests.Where(x => reclamationAgreementRequestIDList.Contains(x.ReclamationAgreementRequestID)).Delete();
            }
        }

        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, int reclamationAgreementRequestID)
        {
            DeleteAgreementRequest(agreementRequests, new List<int> { reclamationAgreementRequestID });
        }

        public static void DeleteAgreementRequest(this IQueryable<AgreementRequest> agreementRequests, AgreementRequest agreementRequestToDelete)
        {
            DeleteAgreementRequest(agreementRequests, new List<AgreementRequest> { agreementRequestToDelete });
        }
    }
}