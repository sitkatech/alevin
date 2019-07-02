//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PacificNorthActivityList]
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
        public static PacificNorthActivityList GetPacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, int pacificNorthActivityListID)
        {
            var pacificNorthActivityList = pacificNorthActivityLists.SingleOrDefault(x => x.PacificNorthActivityListID == pacificNorthActivityListID);
            Check.RequireNotNullThrowNotFound(pacificNorthActivityList, "PacificNorthActivityList", pacificNorthActivityListID);
            return pacificNorthActivityList;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, List<int> pacificNorthActivityListIDList)
        {
            if(pacificNorthActivityListIDList.Any())
            {
                pacificNorthActivityLists.Where(x => pacificNorthActivityListIDList.Contains(x.PacificNorthActivityListID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, ICollection<PacificNorthActivityList> pacificNorthActivityListsToDelete)
        {
            if(pacificNorthActivityListsToDelete.Any())
            {
                var pacificNorthActivityListIDList = pacificNorthActivityListsToDelete.Select(x => x.PacificNorthActivityListID).ToList();
                pacificNorthActivityLists.Where(x => pacificNorthActivityListIDList.Contains(x.PacificNorthActivityListID)).Delete();
            }
        }

        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, int pacificNorthActivityListID)
        {
            DeletePacificNorthActivityList(pacificNorthActivityLists, new List<int> { pacificNorthActivityListID });
        }

        public static void DeletePacificNorthActivityList(this IQueryable<PacificNorthActivityList> pacificNorthActivityLists, PacificNorthActivityList pacificNorthActivityListToDelete)
        {
            DeletePacificNorthActivityList(pacificNorthActivityLists, new List<PacificNorthActivityList> { pacificNorthActivityListToDelete });
        }
    }
}