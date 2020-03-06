//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[PacificNorthActivityStatus]
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
        public static PacificNorthActivityStatus GetPacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, int reclamationPacificNorthActivityStatusID)
        {
            var pacificNorthActivityStatus = pacificNorthActivityStatuses.SingleOrDefault(x => x.ReclamationPacificNorthActivityStatusID == reclamationPacificNorthActivityStatusID);
            Check.RequireNotNullThrowNotFound(pacificNorthActivityStatus, "PacificNorthActivityStatus", reclamationPacificNorthActivityStatusID);
            return pacificNorthActivityStatus;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, List<int> reclamationPacificNorthActivityStatusIDList)
        {
            if(reclamationPacificNorthActivityStatusIDList.Any())
            {
                pacificNorthActivityStatuses.Where(x => reclamationPacificNorthActivityStatusIDList.Contains(x.ReclamationPacificNorthActivityStatusID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, ICollection<PacificNorthActivityStatus> pacificNorthActivityStatusesToDelete)
        {
            if(pacificNorthActivityStatusesToDelete.Any())
            {
                var reclamationPacificNorthActivityStatusIDList = pacificNorthActivityStatusesToDelete.Select(x => x.ReclamationPacificNorthActivityStatusID).ToList();
                pacificNorthActivityStatuses.Where(x => reclamationPacificNorthActivityStatusIDList.Contains(x.ReclamationPacificNorthActivityStatusID)).Delete();
            }
        }

        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, int reclamationPacificNorthActivityStatusID)
        {
            DeletePacificNorthActivityStatus(pacificNorthActivityStatuses, new List<int> { reclamationPacificNorthActivityStatusID });
        }

        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, PacificNorthActivityStatus pacificNorthActivityStatusToDelete)
        {
            DeletePacificNorthActivityStatus(pacificNorthActivityStatuses, new List<PacificNorthActivityStatus> { pacificNorthActivityStatusToDelete });
        }
    }
}