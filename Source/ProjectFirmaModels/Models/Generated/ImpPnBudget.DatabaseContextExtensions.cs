//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpPnBudget]
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
        public static ImpPnBudget GetImpPnBudget(this IQueryable<ImpPnBudget> impPnBudgets, int impPnBudgetID)
        {
            var impPnBudget = impPnBudgets.SingleOrDefault(x => x.ImpPnBudgetID == impPnBudgetID);
            Check.RequireNotNullThrowNotFound(impPnBudget, "ImpPnBudget", impPnBudgetID);
            return impPnBudget;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteImpPnBudget(this IQueryable<ImpPnBudget> impPnBudgets, List<int> impPnBudgetIDList)
        {
            if(impPnBudgetIDList.Any())
            {
                impPnBudgets.Where(x => impPnBudgetIDList.Contains(x.ImpPnBudgetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteImpPnBudget(this IQueryable<ImpPnBudget> impPnBudgets, ICollection<ImpPnBudget> impPnBudgetsToDelete)
        {
            if(impPnBudgetsToDelete.Any())
            {
                var impPnBudgetIDList = impPnBudgetsToDelete.Select(x => x.ImpPnBudgetID).ToList();
                impPnBudgets.Where(x => impPnBudgetIDList.Contains(x.ImpPnBudgetID)).Delete();
            }
        }

        public static void DeleteImpPnBudget(this IQueryable<ImpPnBudget> impPnBudgets, int impPnBudgetID)
        {
            DeleteImpPnBudget(impPnBudgets, new List<int> { impPnBudgetID });
        }

        public static void DeleteImpPnBudget(this IQueryable<ImpPnBudget> impPnBudgets, ImpPnBudget impPnBudgetToDelete)
        {
            DeleteImpPnBudget(impPnBudgets, new List<ImpPnBudget> { impPnBudgetToDelete });
        }
    }
}