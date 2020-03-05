//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationPacificNorthActivityList]
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
        public static ReclamationPacificNorthActivityList GetReclamationPacificNorthActivityList(this IQueryable<ReclamationPacificNorthActivityList> reclamationPacificNorthActivityLists, int reclamationPacificNorthActivityListID)
        {
            var reclamationPacificNorthActivityList = reclamationPacificNorthActivityLists.SingleOrDefault(x => x.ReclamationPacificNorthActivityListID == reclamationPacificNorthActivityListID);
            Check.RequireNotNullThrowNotFound(reclamationPacificNorthActivityList, "ReclamationPacificNorthActivityList", reclamationPacificNorthActivityListID);
            return reclamationPacificNorthActivityList;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationPacificNorthActivityList(this IQueryable<ReclamationPacificNorthActivityList> reclamationPacificNorthActivityLists, List<int> reclamationPacificNorthActivityListIDList)
        {
            if(reclamationPacificNorthActivityListIDList.Any())
            {
                reclamationPacificNorthActivityLists.Where(x => reclamationPacificNorthActivityListIDList.Contains(x.ReclamationPacificNorthActivityListID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationPacificNorthActivityList(this IQueryable<ReclamationPacificNorthActivityList> reclamationPacificNorthActivityLists, ICollection<ReclamationPacificNorthActivityList> reclamationPacificNorthActivityListsToDelete)
        {
            if(reclamationPacificNorthActivityListsToDelete.Any())
            {
                var reclamationPacificNorthActivityListIDList = reclamationPacificNorthActivityListsToDelete.Select(x => x.ReclamationPacificNorthActivityListID).ToList();
                reclamationPacificNorthActivityLists.Where(x => reclamationPacificNorthActivityListIDList.Contains(x.ReclamationPacificNorthActivityListID)).Delete();
            }
        }

        public static void DeleteReclamationPacificNorthActivityList(this IQueryable<ReclamationPacificNorthActivityList> reclamationPacificNorthActivityLists, int reclamationPacificNorthActivityListID)
        {
            DeleteReclamationPacificNorthActivityList(reclamationPacificNorthActivityLists, new List<int> { reclamationPacificNorthActivityListID });
        }

        public static void DeleteReclamationPacificNorthActivityList(this IQueryable<ReclamationPacificNorthActivityList> reclamationPacificNorthActivityLists, ReclamationPacificNorthActivityList reclamationPacificNorthActivityListToDelete)
        {
            DeleteReclamationPacificNorthActivityList(reclamationPacificNorthActivityLists, new List<ReclamationPacificNorthActivityList> { reclamationPacificNorthActivityListToDelete });
        }
    }
}