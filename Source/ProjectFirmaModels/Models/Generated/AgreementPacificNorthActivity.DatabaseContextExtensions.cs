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
        public static AgreementPacificNorthActivity GetAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, int agreementPacificNorthActivityID)
        {
            var agreementPacificNorthActivity = agreementPacificNorthActivities.SingleOrDefault(x => x.AgreementPacificNorthActivityID == agreementPacificNorthActivityID);
            Check.RequireNotNullThrowNotFound(agreementPacificNorthActivity, "AgreementPacificNorthActivity", agreementPacificNorthActivityID);
            return agreementPacificNorthActivity;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, List<int> agreementPacificNorthActivityIDList)
        {
            if(agreementPacificNorthActivityIDList.Any())
            {
                agreementPacificNorthActivities.Where(x => agreementPacificNorthActivityIDList.Contains(x.AgreementPacificNorthActivityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, ICollection<AgreementPacificNorthActivity> agreementPacificNorthActivitiesToDelete)
        {
            if(agreementPacificNorthActivitiesToDelete.Any())
            {
                var agreementPacificNorthActivityIDList = agreementPacificNorthActivitiesToDelete.Select(x => x.AgreementPacificNorthActivityID).ToList();
                agreementPacificNorthActivities.Where(x => agreementPacificNorthActivityIDList.Contains(x.AgreementPacificNorthActivityID)).Delete();
            }
        }

        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, int agreementPacificNorthActivityID)
        {
            DeleteAgreementPacificNorthActivity(agreementPacificNorthActivities, new List<int> { agreementPacificNorthActivityID });
        }

        public static void DeleteAgreementPacificNorthActivity(this IQueryable<AgreementPacificNorthActivity> agreementPacificNorthActivities, AgreementPacificNorthActivity agreementPacificNorthActivityToDelete)
        {
            DeleteAgreementPacificNorthActivity(agreementPacificNorthActivities, new List<AgreementPacificNorthActivity> { agreementPacificNorthActivityToDelete });
        }
    }
}