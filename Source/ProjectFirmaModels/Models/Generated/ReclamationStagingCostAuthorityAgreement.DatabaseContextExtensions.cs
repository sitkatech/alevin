//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingCostAuthorityAgreement]
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
        public static ReclamationStagingCostAuthorityAgreement GetReclamationStagingCostAuthorityAgreement(this IQueryable<ReclamationStagingCostAuthorityAgreement> reclamationStagingCostAuthorityAgreements, int reclamationStagingCostAuthorityAgreementID)
        {
            var reclamationStagingCostAuthorityAgreement = reclamationStagingCostAuthorityAgreements.SingleOrDefault(x => x.ReclamationStagingCostAuthorityAgreementID == reclamationStagingCostAuthorityAgreementID);
            Check.RequireNotNullThrowNotFound(reclamationStagingCostAuthorityAgreement, "ReclamationStagingCostAuthorityAgreement", reclamationStagingCostAuthorityAgreementID);
            return reclamationStagingCostAuthorityAgreement;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingCostAuthorityAgreement(this IQueryable<ReclamationStagingCostAuthorityAgreement> reclamationStagingCostAuthorityAgreements, List<int> reclamationStagingCostAuthorityAgreementIDList)
        {
            if(reclamationStagingCostAuthorityAgreementIDList.Any())
            {
                reclamationStagingCostAuthorityAgreements.Where(x => reclamationStagingCostAuthorityAgreementIDList.Contains(x.ReclamationStagingCostAuthorityAgreementID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingCostAuthorityAgreement(this IQueryable<ReclamationStagingCostAuthorityAgreement> reclamationStagingCostAuthorityAgreements, ICollection<ReclamationStagingCostAuthorityAgreement> reclamationStagingCostAuthorityAgreementsToDelete)
        {
            if(reclamationStagingCostAuthorityAgreementsToDelete.Any())
            {
                var reclamationStagingCostAuthorityAgreementIDList = reclamationStagingCostAuthorityAgreementsToDelete.Select(x => x.ReclamationStagingCostAuthorityAgreementID).ToList();
                reclamationStagingCostAuthorityAgreements.Where(x => reclamationStagingCostAuthorityAgreementIDList.Contains(x.ReclamationStagingCostAuthorityAgreementID)).Delete();
            }
        }

        public static void DeleteReclamationStagingCostAuthorityAgreement(this IQueryable<ReclamationStagingCostAuthorityAgreement> reclamationStagingCostAuthorityAgreements, int reclamationStagingCostAuthorityAgreementID)
        {
            DeleteReclamationStagingCostAuthorityAgreement(reclamationStagingCostAuthorityAgreements, new List<int> { reclamationStagingCostAuthorityAgreementID });
        }

        public static void DeleteReclamationStagingCostAuthorityAgreement(this IQueryable<ReclamationStagingCostAuthorityAgreement> reclamationStagingCostAuthorityAgreements, ReclamationStagingCostAuthorityAgreement reclamationStagingCostAuthorityAgreementToDelete)
        {
            DeleteReclamationStagingCostAuthorityAgreement(reclamationStagingCostAuthorityAgreements, new List<ReclamationStagingCostAuthorityAgreement> { reclamationStagingCostAuthorityAgreementToDelete });
        }
    }
}