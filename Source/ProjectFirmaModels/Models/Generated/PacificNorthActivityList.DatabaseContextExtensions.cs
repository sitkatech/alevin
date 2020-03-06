//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[PacificNorthActivityList]
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
        public static PacificNorthActivityList GetPacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, int reclamationPacificNorthActivityListID)
        {
            var pacificNorthActivityList = pacificNorthActivityLists.SingleOrDefault(x => x.ReclamationPacificNorthActivityListID == reclamationPacificNorthActivityListID);
            Check.RequireNotNullThrowNotFound(pacificNorthActivityList, "PacificNorthActivityList", reclamationPacificNorthActivityListID);
            return pacificNorthActivityList;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, List<int> reclamationPacificNorthActivityListIDList)
        {
            if(reclamationPacificNorthActivityListIDList.Any())
            {
                pacificNorthActivityLists.Where(x => reclamationPacificNorthActivityListIDList.Contains(x.ReclamationPacificNorthActivityListID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, ICollection<PacificNorthActivityList> pacificNorthActivityListsToDelete)
        {
            if(pacificNorthActivityListsToDelete.Any())
            {
                var reclamationPacificNorthActivityListIDList = pacificNorthActivityListsToDelete.Select(x => x.ReclamationPacificNorthActivityListID).ToList();
                pacificNorthActivityLists.Where(x => reclamationPacificNorthActivityListIDList.Contains(x.ReclamationPacificNorthActivityListID)).Delete();
            }
        }

        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, int reclamationPacificNorthActivityListID)
        {
            DeletePacificNorthActivityList(pacificNorthActivityLists, new List<int> { reclamationPacificNorthActivityListID });
        }

        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, PacificNorthActivityList pacificNorthActivityListToDelete)
        {
            DeletePacificNorthActivityList(pacificNorthActivityLists, new List<PacificNorthActivityList> { pacificNorthActivityListToDelete });
        }
    }
}