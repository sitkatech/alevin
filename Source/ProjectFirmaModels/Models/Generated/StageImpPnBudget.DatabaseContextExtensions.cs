//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Staging].[StageImpPnBudget]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static StageImpPnBudget GetStageImpPnBudget(this IQueryable<StageImpPnBudget> stageImpPnBudgets, int stageImpPnBudgetID)
        {
            var stageImpPnBudget = stageImpPnBudgets.SingleOrDefault(x => x.StageImpPnBudgetID == stageImpPnBudgetID);
            Check.RequireNotNullThrowNotFound(stageImpPnBudget, "StageImpPnBudget", stageImpPnBudgetID);
            return stageImpPnBudget;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteStageImpPnBudget(this IQueryable<StageImpPnBudget> stageImpPnBudgets, List<int> stageImpPnBudgetIDList)
        {
            if(stageImpPnBudgetIDList.Any())
            {
                stageImpPnBudgets.Where(x => stageImpPnBudgetIDList.Contains(x.StageImpPnBudgetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteStageImpPnBudget(this IQueryable<StageImpPnBudget> stageImpPnBudgets, ICollection<StageImpPnBudget> stageImpPnBudgetsToDelete)
        {
            if(stageImpPnBudgetsToDelete.Any())
            {
                var stageImpPnBudgetIDList = stageImpPnBudgetsToDelete.Select(x => x.StageImpPnBudgetID).ToList();
                stageImpPnBudgets.Where(x => stageImpPnBudgetIDList.Contains(x.StageImpPnBudgetID)).Delete();
            }
        }

        public static void DeleteStageImpPnBudget(this IQueryable<StageImpPnBudget> stageImpPnBudgets, int stageImpPnBudgetID)
        {
            DeleteStageImpPnBudget(stageImpPnBudgets, new List<int> { stageImpPnBudgetID });
        }

        public static void DeleteStageImpPnBudget(this IQueryable<StageImpPnBudget> stageImpPnBudgets, StageImpPnBudget stageImpPnBudgetToDelete)
        {
            DeleteStageImpPnBudget(stageImpPnBudgets, new List<StageImpPnBudget> { stageImpPnBudgetToDelete });
        }
    }
}