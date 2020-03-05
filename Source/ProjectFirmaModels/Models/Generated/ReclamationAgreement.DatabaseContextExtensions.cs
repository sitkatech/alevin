//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationAgreement]
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
        public static ReclamationAgreement GetReclamationAgreement(this IQueryable<ReclamationAgreement> reclamationAgreements, int reclamationAgreementID)
        {
            var reclamationAgreement = reclamationAgreements.SingleOrDefault(x => x.ReclamationAgreementID == reclamationAgreementID);
            Check.RequireNotNullThrowNotFound(reclamationAgreement, "ReclamationAgreement", reclamationAgreementID);
            return reclamationAgreement;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationAgreement(this IQueryable<ReclamationAgreement> reclamationAgreements, List<int> reclamationAgreementIDList)
        {
            if(reclamationAgreementIDList.Any())
            {
                reclamationAgreements.Where(x => reclamationAgreementIDList.Contains(x.ReclamationAgreementID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationAgreement(this IQueryable<ReclamationAgreement> reclamationAgreements, ICollection<ReclamationAgreement> reclamationAgreementsToDelete)
        {
            if(reclamationAgreementsToDelete.Any())
            {
                var reclamationAgreementIDList = reclamationAgreementsToDelete.Select(x => x.ReclamationAgreementID).ToList();
                reclamationAgreements.Where(x => reclamationAgreementIDList.Contains(x.ReclamationAgreementID)).Delete();
            }
        }

        public static void DeleteReclamationAgreement(this IQueryable<ReclamationAgreement> reclamationAgreements, int reclamationAgreementID)
        {
            DeleteReclamationAgreement(reclamationAgreements, new List<int> { reclamationAgreementID });
        }

        public static void DeleteReclamationAgreement(this IQueryable<ReclamationAgreement> reclamationAgreements, ReclamationAgreement reclamationAgreementToDelete)
        {
            DeleteReclamationAgreement(reclamationAgreements, new List<ReclamationAgreement> { reclamationAgreementToDelete });
        }
    }
}