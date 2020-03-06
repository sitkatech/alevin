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
        public static PacificNorthActivityStatus GetPacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, int pacificNorthActivityStatusID)
        {
            var pacificNorthActivityStatus = pacificNorthActivityStatuses.SingleOrDefault(x => x.PacificNorthActivityStatusID == pacificNorthActivityStatusID);
            Check.RequireNotNullThrowNotFound(pacificNorthActivityStatus, "PacificNorthActivityStatus", pacificNorthActivityStatusID);
            return pacificNorthActivityStatus;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, List<int> pacificNorthActivityStatusIDList)
        {
            if(pacificNorthActivityStatusIDList.Any())
            {
                pacificNorthActivityStatuses.Where(x => pacificNorthActivityStatusIDList.Contains(x.PacificNorthActivityStatusID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, ICollection<PacificNorthActivityStatus> pacificNorthActivityStatusesToDelete)
        {
            if(pacificNorthActivityStatusesToDelete.Any())
            {
                var pacificNorthActivityStatusIDList = pacificNorthActivityStatusesToDelete.Select(x => x.PacificNorthActivityStatusID).ToList();
                pacificNorthActivityStatuses.Where(x => pacificNorthActivityStatusIDList.Contains(x.PacificNorthActivityStatusID)).Delete();
            }
        }

        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, int pacificNorthActivityStatusID)
        {
            DeletePacificNorthActivityStatus(pacificNorthActivityStatuses, new List<int> { pacificNorthActivityStatusID });
        }

        public static void DeletePacificNorthActivityStatus(this IQueryable<PacificNorthActivityStatus> pacificNorthActivityStatuses, PacificNorthActivityStatus pacificNorthActivityStatusToDelete)
        {
            DeletePacificNorthActivityStatus(pacificNorthActivityStatuses, new List<PacificNorthActivityStatus> { pacificNorthActivityStatusToDelete });
        }
    }
}