//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostAuthorityWorkBreakdownStructurePacificNorthActivityList]
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
        public static CostAuthorityWorkBreakdownStructurePacificNorthActivityList GetCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<CostAuthorityWorkBreakdownStructurePacificNorthActivityList> costAuthorityWorkBreakdownStructurePacificNorthActivityLists, int costAuthorityWorkBreakdownStructurePacificNorthActivityListID)
        {
            var costAuthorityWorkBreakdownStructurePacificNorthActivityList = costAuthorityWorkBreakdownStructurePacificNorthActivityLists.SingleOrDefault(x => x.CostAuthorityWorkBreakdownStructurePacificNorthActivityListID == costAuthorityWorkBreakdownStructurePacificNorthActivityListID);
            Check.RequireNotNullThrowNotFound(costAuthorityWorkBreakdownStructurePacificNorthActivityList, "CostAuthorityWorkBreakdownStructurePacificNorthActivityList", costAuthorityWorkBreakdownStructurePacificNorthActivityListID);
            return costAuthorityWorkBreakdownStructurePacificNorthActivityList;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<CostAuthorityWorkBreakdownStructurePacificNorthActivityList> costAuthorityWorkBreakdownStructurePacificNorthActivityLists, List<int> costAuthorityWorkBreakdownStructurePacificNorthActivityListIDList)
        {
            if(costAuthorityWorkBreakdownStructurePacificNorthActivityListIDList.Any())
            {
                costAuthorityWorkBreakdownStructurePacificNorthActivityLists.Where(x => costAuthorityWorkBreakdownStructurePacificNorthActivityListIDList.Contains(x.CostAuthorityWorkBreakdownStructurePacificNorthActivityListID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<CostAuthorityWorkBreakdownStructurePacificNorthActivityList> costAuthorityWorkBreakdownStructurePacificNorthActivityLists, ICollection<CostAuthorityWorkBreakdownStructurePacificNorthActivityList> costAuthorityWorkBreakdownStructurePacificNorthActivityListsToDelete)
        {
            if(costAuthorityWorkBreakdownStructurePacificNorthActivityListsToDelete.Any())
            {
                var costAuthorityWorkBreakdownStructurePacificNorthActivityListIDList = costAuthorityWorkBreakdownStructurePacificNorthActivityListsToDelete.Select(x => x.CostAuthorityWorkBreakdownStructurePacificNorthActivityListID).ToList();
                costAuthorityWorkBreakdownStructurePacificNorthActivityLists.Where(x => costAuthorityWorkBreakdownStructurePacificNorthActivityListIDList.Contains(x.CostAuthorityWorkBreakdownStructurePacificNorthActivityListID)).Delete();
            }
        }

        public static void DeleteCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<CostAuthorityWorkBreakdownStructurePacificNorthActivityList> costAuthorityWorkBreakdownStructurePacificNorthActivityLists, int costAuthorityWorkBreakdownStructurePacificNorthActivityListID)
        {
            DeleteCostAuthorityWorkBreakdownStructurePacificNorthActivityList(costAuthorityWorkBreakdownStructurePacificNorthActivityLists, new List<int> { costAuthorityWorkBreakdownStructurePacificNorthActivityListID });
        }

        public static void DeleteCostAuthorityWorkBreakdownStructurePacificNorthActivityList(this IQueryable<CostAuthorityWorkBreakdownStructurePacificNorthActivityList> costAuthorityWorkBreakdownStructurePacificNorthActivityLists, CostAuthorityWorkBreakdownStructurePacificNorthActivityList costAuthorityWorkBreakdownStructurePacificNorthActivityListToDelete)
        {
            DeleteCostAuthorityWorkBreakdownStructurePacificNorthActivityList(costAuthorityWorkBreakdownStructurePacificNorthActivityLists, new List<CostAuthorityWorkBreakdownStructurePacificNorthActivityList> { costAuthorityWorkBreakdownStructurePacificNorthActivityListToDelete });
        }
    }
}