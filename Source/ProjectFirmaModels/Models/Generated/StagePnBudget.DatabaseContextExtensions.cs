//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Staging].[StagePnBudget]
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
        public static StagePnBudget GetStagePnBudget(this IQueryable<StagePnBudget> stagePnBudgets, int stagePnBudgetID)
        {
            var stagePnBudget = stagePnBudgets.SingleOrDefault(x => x.StagePnBudgetID == stagePnBudgetID);
            Check.RequireNotNullThrowNotFound(stagePnBudget, "StagePnBudget", stagePnBudgetID);
            return stagePnBudget;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteStagePnBudget(this IQueryable<StagePnBudget> stagePnBudgets, List<int> stagePnBudgetIDList)
        {
            if(stagePnBudgetIDList.Any())
            {
                stagePnBudgets.Where(x => stagePnBudgetIDList.Contains(x.StagePnBudgetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteStagePnBudget(this IQueryable<StagePnBudget> stagePnBudgets, ICollection<StagePnBudget> stagePnBudgetsToDelete)
        {
            if(stagePnBudgetsToDelete.Any())
            {
                var stagePnBudgetIDList = stagePnBudgetsToDelete.Select(x => x.StagePnBudgetID).ToList();
                stagePnBudgets.Where(x => stagePnBudgetIDList.Contains(x.StagePnBudgetID)).Delete();
            }
        }

        public static void DeleteStagePnBudget(this IQueryable<StagePnBudget> stagePnBudgets, int stagePnBudgetID)
        {
            DeleteStagePnBudget(stagePnBudgets, new List<int> { stagePnBudgetID });
        }

        public static void DeleteStagePnBudget(this IQueryable<StagePnBudget> stagePnBudgets, StagePnBudget stagePnBudgetToDelete)
        {
            DeleteStagePnBudget(stagePnBudgets, new List<StagePnBudget> { stagePnBudgetToDelete });
        }
    }
}