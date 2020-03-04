//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementObligationItemBudget]
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
        public static WbsElementObligationItemBudget GetWbsElementObligationItemBudget(this IQueryable<WbsElementObligationItemBudget> wbsElementObligationItemBudgets, int wbsElementObligationItemBudgetID)
        {
            var wbsElementObligationItemBudget = wbsElementObligationItemBudgets.SingleOrDefault(x => x.WbsElementObligationItemBudgetID == wbsElementObligationItemBudgetID);
            Check.RequireNotNullThrowNotFound(wbsElementObligationItemBudget, "WbsElementObligationItemBudget", wbsElementObligationItemBudgetID);
            return wbsElementObligationItemBudget;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWbsElementObligationItemBudget(this IQueryable<WbsElementObligationItemBudget> wbsElementObligationItemBudgets, List<int> wbsElementObligationItemBudgetIDList)
        {
            if(wbsElementObligationItemBudgetIDList.Any())
            {
                wbsElementObligationItemBudgets.Where(x => wbsElementObligationItemBudgetIDList.Contains(x.WbsElementObligationItemBudgetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWbsElementObligationItemBudget(this IQueryable<WbsElementObligationItemBudget> wbsElementObligationItemBudgets, ICollection<WbsElementObligationItemBudget> wbsElementObligationItemBudgetsToDelete)
        {
            if(wbsElementObligationItemBudgetsToDelete.Any())
            {
                var wbsElementObligationItemBudgetIDList = wbsElementObligationItemBudgetsToDelete.Select(x => x.WbsElementObligationItemBudgetID).ToList();
                wbsElementObligationItemBudgets.Where(x => wbsElementObligationItemBudgetIDList.Contains(x.WbsElementObligationItemBudgetID)).Delete();
            }
        }

        public static void DeleteWbsElementObligationItemBudget(this IQueryable<WbsElementObligationItemBudget> wbsElementObligationItemBudgets, int wbsElementObligationItemBudgetID)
        {
            DeleteWbsElementObligationItemBudget(wbsElementObligationItemBudgets, new List<int> { wbsElementObligationItemBudgetID });
        }

        public static void DeleteWbsElementObligationItemBudget(this IQueryable<WbsElementObligationItemBudget> wbsElementObligationItemBudgets, WbsElementObligationItemBudget wbsElementObligationItemBudgetToDelete)
        {
            DeleteWbsElementObligationItemBudget(wbsElementObligationItemBudgets, new List<WbsElementObligationItemBudget> { wbsElementObligationItemBudgetToDelete });
        }
    }
}