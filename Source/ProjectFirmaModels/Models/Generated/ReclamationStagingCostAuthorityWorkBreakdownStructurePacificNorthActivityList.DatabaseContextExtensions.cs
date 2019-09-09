//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList]
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
        public static ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList GetReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists, int reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID)
        {
            var reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList = reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists.SingleOrDefault(x => x.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID == reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID);
            Check.RequireNotNullThrowNotFound(reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList, "ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList", reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID);
            return reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists, List<int> reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListIDList)
        {
            if(reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListIDList.Any())
            {
                reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists.Where(x => reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListIDList.Contains(x.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists, ICollection<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsToDelete)
        {
            if(reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsToDelete.Any())
            {
                var reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListIDList = reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsToDelete.Select(x => x.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID).ToList();
                reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists.Where(x => reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListIDList.Contains(x.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID)).Delete();
            }
        }

        public static void DeleteReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists, int reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID)
        {
            DeleteReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists, new List<int> { reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID });
        }

        public static void DeleteReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists, ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListToDelete)
        {
            DeleteReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList(reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityLists, new List<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList> { reclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListToDelete });
        }
    }
}