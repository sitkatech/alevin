//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationPacificNorthActivityStatus]
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
        public static ReclamationPacificNorthActivityStatus GetReclamationPacificNorthActivityStatus(this IQueryable<ReclamationPacificNorthActivityStatus> reclamationPacificNorthActivityStatuses, int reclamationPacificNorthActivityStatusID)
        {
            var reclamationPacificNorthActivityStatus = reclamationPacificNorthActivityStatuses.SingleOrDefault(x => x.ReclamationPacificNorthActivityStatusID == reclamationPacificNorthActivityStatusID);
            Check.RequireNotNullThrowNotFound(reclamationPacificNorthActivityStatus, "ReclamationPacificNorthActivityStatus", reclamationPacificNorthActivityStatusID);
            return reclamationPacificNorthActivityStatus;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationPacificNorthActivityStatus(this IQueryable<ReclamationPacificNorthActivityStatus> reclamationPacificNorthActivityStatuses, List<int> reclamationPacificNorthActivityStatusIDList)
        {
            if(reclamationPacificNorthActivityStatusIDList.Any())
            {
                reclamationPacificNorthActivityStatuses.Where(x => reclamationPacificNorthActivityStatusIDList.Contains(x.ReclamationPacificNorthActivityStatusID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationPacificNorthActivityStatus(this IQueryable<ReclamationPacificNorthActivityStatus> reclamationPacificNorthActivityStatuses, ICollection<ReclamationPacificNorthActivityStatus> reclamationPacificNorthActivityStatusesToDelete)
        {
            if(reclamationPacificNorthActivityStatusesToDelete.Any())
            {
                var reclamationPacificNorthActivityStatusIDList = reclamationPacificNorthActivityStatusesToDelete.Select(x => x.ReclamationPacificNorthActivityStatusID).ToList();
                reclamationPacificNorthActivityStatuses.Where(x => reclamationPacificNorthActivityStatusIDList.Contains(x.ReclamationPacificNorthActivityStatusID)).Delete();
            }
        }

        public static void DeleteReclamationPacificNorthActivityStatus(this IQueryable<ReclamationPacificNorthActivityStatus> reclamationPacificNorthActivityStatuses, int reclamationPacificNorthActivityStatusID)
        {
            DeleteReclamationPacificNorthActivityStatus(reclamationPacificNorthActivityStatuses, new List<int> { reclamationPacificNorthActivityStatusID });
        }

        public static void DeleteReclamationPacificNorthActivityStatus(this IQueryable<ReclamationPacificNorthActivityStatus> reclamationPacificNorthActivityStatuses, ReclamationPacificNorthActivityStatus reclamationPacificNorthActivityStatusToDelete)
        {
            DeleteReclamationPacificNorthActivityStatus(reclamationPacificNorthActivityStatuses, new List<ReclamationPacificNorthActivityStatus> { reclamationPacificNorthActivityStatusToDelete });
        }
    }
}