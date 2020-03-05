//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationAgreementPacificNorthActivity]
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
        public static ReclamationAgreementPacificNorthActivity GetReclamationAgreementPacificNorthActivity(this IQueryable<ReclamationAgreementPacificNorthActivity> reclamationAgreementPacificNorthActivities, int reclamationAgreementPacificNorthActivityID)
        {
            var reclamationAgreementPacificNorthActivity = reclamationAgreementPacificNorthActivities.SingleOrDefault(x => x.ReclamationAgreementPacificNorthActivityID == reclamationAgreementPacificNorthActivityID);
            Check.RequireNotNullThrowNotFound(reclamationAgreementPacificNorthActivity, "ReclamationAgreementPacificNorthActivity", reclamationAgreementPacificNorthActivityID);
            return reclamationAgreementPacificNorthActivity;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationAgreementPacificNorthActivity(this IQueryable<ReclamationAgreementPacificNorthActivity> reclamationAgreementPacificNorthActivities, List<int> reclamationAgreementPacificNorthActivityIDList)
        {
            if(reclamationAgreementPacificNorthActivityIDList.Any())
            {
                reclamationAgreementPacificNorthActivities.Where(x => reclamationAgreementPacificNorthActivityIDList.Contains(x.ReclamationAgreementPacificNorthActivityID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationAgreementPacificNorthActivity(this IQueryable<ReclamationAgreementPacificNorthActivity> reclamationAgreementPacificNorthActivities, ICollection<ReclamationAgreementPacificNorthActivity> reclamationAgreementPacificNorthActivitiesToDelete)
        {
            if(reclamationAgreementPacificNorthActivitiesToDelete.Any())
            {
                var reclamationAgreementPacificNorthActivityIDList = reclamationAgreementPacificNorthActivitiesToDelete.Select(x => x.ReclamationAgreementPacificNorthActivityID).ToList();
                reclamationAgreementPacificNorthActivities.Where(x => reclamationAgreementPacificNorthActivityIDList.Contains(x.ReclamationAgreementPacificNorthActivityID)).Delete();
            }
        }

        public static void DeleteReclamationAgreementPacificNorthActivity(this IQueryable<ReclamationAgreementPacificNorthActivity> reclamationAgreementPacificNorthActivities, int reclamationAgreementPacificNorthActivityID)
        {
            DeleteReclamationAgreementPacificNorthActivity(reclamationAgreementPacificNorthActivities, new List<int> { reclamationAgreementPacificNorthActivityID });
        }

        public static void DeleteReclamationAgreementPacificNorthActivity(this IQueryable<ReclamationAgreementPacificNorthActivity> reclamationAgreementPacificNorthActivities, ReclamationAgreementPacificNorthActivity reclamationAgreementPacificNorthActivityToDelete)
        {
            DeleteReclamationAgreementPacificNorthActivity(reclamationAgreementPacificNorthActivities, new List<ReclamationAgreementPacificNorthActivity> { reclamationAgreementPacificNorthActivityToDelete });
        }
    }
}