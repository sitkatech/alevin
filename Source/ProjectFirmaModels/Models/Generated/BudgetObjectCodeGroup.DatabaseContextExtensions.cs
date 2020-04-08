//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[BudgetObjectCodeGroup]
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
        public static BudgetObjectCodeGroup GetBudgetObjectCodeGroup(this IQueryable<BudgetObjectCodeGroup> budgetObjectCodeGroups, int budgetObjectCodeGroupID)
        {
            var budgetObjectCodeGroup = budgetObjectCodeGroups.SingleOrDefault(x => x.BudgetObjectCodeGroupID == budgetObjectCodeGroupID);
            Check.RequireNotNullThrowNotFound(budgetObjectCodeGroup, "BudgetObjectCodeGroup", budgetObjectCodeGroupID);
            return budgetObjectCodeGroup;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteBudgetObjectCodeGroup(this IQueryable<BudgetObjectCodeGroup> budgetObjectCodeGroups, List<int> budgetObjectCodeGroupIDList)
        {
            if(budgetObjectCodeGroupIDList.Any())
            {
                budgetObjectCodeGroups.Where(x => budgetObjectCodeGroupIDList.Contains(x.BudgetObjectCodeGroupID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteBudgetObjectCodeGroup(this IQueryable<BudgetObjectCodeGroup> budgetObjectCodeGroups, ICollection<BudgetObjectCodeGroup> budgetObjectCodeGroupsToDelete)
        {
            if(budgetObjectCodeGroupsToDelete.Any())
            {
                var budgetObjectCodeGroupIDList = budgetObjectCodeGroupsToDelete.Select(x => x.BudgetObjectCodeGroupID).ToList();
                budgetObjectCodeGroups.Where(x => budgetObjectCodeGroupIDList.Contains(x.BudgetObjectCodeGroupID)).Delete();
            }
        }

        public static void DeleteBudgetObjectCodeGroup(this IQueryable<BudgetObjectCodeGroup> budgetObjectCodeGroups, int budgetObjectCodeGroupID)
        {
            DeleteBudgetObjectCodeGroup(budgetObjectCodeGroups, new List<int> { budgetObjectCodeGroupID });
        }

        public static void DeleteBudgetObjectCodeGroup(this IQueryable<BudgetObjectCodeGroup> budgetObjectCodeGroups, BudgetObjectCodeGroup budgetObjectCodeGroupToDelete)
        {
            DeleteBudgetObjectCodeGroup(budgetObjectCodeGroups, new List<BudgetObjectCodeGroup> { budgetObjectCodeGroupToDelete });
        }
    }
}