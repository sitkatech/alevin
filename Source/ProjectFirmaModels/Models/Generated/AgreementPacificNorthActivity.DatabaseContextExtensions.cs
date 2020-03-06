//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[AgreementPacificNorthActivity]
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
        public static AgreementPacificNorthActivity GetAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, int reclamationAgreementPacificNorthActivityID)
        {
            var agreementPacificNorthActivity = agreementPacificNorthActivities.SingleOrDefault(x => x.ReclamationAgreementPacificNorthActivityID == reclamationAgreementPacificNorthActivityID);
            Check.RequireNotNullThrowNotFound(agreementPacificNorthActivity, "AgreementPacificNorthActivity", reclamationAgreementPacificNorthActivityID);
            return agreementPacificNorthActivity;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, List<int> reclamationAgreementPacificNorthActivityIDList)
        {
            if(reclamationAgreementPacificNorthActivityIDList.Any())
            {
                agreementPacificNorthActivities.Where(x => reclamationAgreementPacificNorthActivityIDList.Contains(x.ReclamationAgreementPacificNorthActivityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, ICollection<AgreementPacificNorthActivity> agreementPacificNorthActivitiesToDelete)
        {
            if(agreementPacificNorthActivitiesToDelete.Any())
            {
                var reclamationAgreementPacificNorthActivityIDList = agreementPacificNorthActivitiesToDelete.Select(x => x.ReclamationAgreementPacificNorthActivityID).ToList();
                agreementPacificNorthActivities.Where(x => reclamationAgreementPacificNorthActivityIDList.Contains(x.ReclamationAgreementPacificNorthActivityID)).Delete();
            }
        }

        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, int reclamationAgreementPacificNorthActivityID)
        {
            DeleteAgreementPacificNorthActivity(agreementPacificNorthActivities, new List<int> { reclamationAgreementPacificNorthActivityID });
        }

        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, AgreementPacificNorthActivity agreementPacificNorthActivityToDelete)
        {
            DeleteAgreementPacificNorthActivity(agreementPacificNorthActivities, new List<AgreementPacificNorthActivity> { agreementPacificNorthActivityToDelete });
        }
    }
}