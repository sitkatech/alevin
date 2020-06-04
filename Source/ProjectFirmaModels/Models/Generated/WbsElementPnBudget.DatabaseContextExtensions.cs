//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementPnBudget]
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
        public static WbsElementPnBudget GetWbsElementPnBudget(this IQueryable<WbsElementPnBudget> wbsElementPnBudgets, int wbsElementPnBudgetID)
        {
            var wbsElementPnBudget = wbsElementPnBudgets.SingleOrDefault(x => x.WbsElementPnBudgetID == wbsElementPnBudgetID);
            Check.RequireNotNullThrowNotFound(wbsElementPnBudget, "WbsElementPnBudget", wbsElementPnBudgetID);
            return wbsElementPnBudget;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWbsElementPnBudget(this IQueryable<WbsElementPnBudget> wbsElementPnBudgets, List<int> wbsElementPnBudgetIDList)
        {
            if(wbsElementPnBudgetIDList.Any())
            {
                wbsElementPnBudgets.Where(x => wbsElementPnBudgetIDList.Contains(x.WbsElementPnBudgetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWbsElementPnBudget(this IQueryable<WbsElementPnBudget> wbsElementPnBudgets, ICollection<WbsElementPnBudget> wbsElementPnBudgetsToDelete)
        {
            if(wbsElementPnBudgetsToDelete.Any())
            {
                var wbsElementPnBudgetIDList = wbsElementPnBudgetsToDelete.Select(x => x.WbsElementPnBudgetID).ToList();
                wbsElementPnBudgets.Where(x => wbsElementPnBudgetIDList.Contains(x.WbsElementPnBudgetID)).Delete();
            }
        }

        public static void DeleteWbsElementPnBudget(this IQueryable<WbsElementPnBudget> wbsElementPnBudgets, int wbsElementPnBudgetID)
        {
            DeleteWbsElementPnBudget(wbsElementPnBudgets, new List<int> { wbsElementPnBudgetID });
        }

        public static void DeleteWbsElementPnBudget(this IQueryable<WbsElementPnBudget> wbsElementPnBudgets, WbsElementPnBudget wbsElementPnBudgetToDelete)
        {
            DeleteWbsElementPnBudget(wbsElementPnBudgets, new List<WbsElementPnBudget> { wbsElementPnBudgetToDelete });
        }
    }
}