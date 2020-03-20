//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[BudgetObjectCode]
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
        public static BudgetObjectCode GetBudgetObjectCode(this IQueryable<BudgetObjectCode> budgetObjectCodes, int budgetObjectCodeID)
        {
            var budgetObjectCode = budgetObjectCodes.SingleOrDefault(x => x.BudgetObjectCodeID == budgetObjectCodeID);
            Check.RequireNotNullThrowNotFound(budgetObjectCode, "BudgetObjectCode", budgetObjectCodeID);
            return budgetObjectCode;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteBudgetObjectCode(this IQueryable<BudgetObjectCode> budgetObjectCodes, List<int> budgetObjectCodeIDList)
        {
            if(budgetObjectCodeIDList.Any())
            {
                budgetObjectCodes.Where(x => budgetObjectCodeIDList.Contains(x.BudgetObjectCodeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteBudgetObjectCode(this IQueryable<BudgetObjectCode> budgetObjectCodes, ICollection<BudgetObjectCode> budgetObjectCodesToDelete)
        {
            if(budgetObjectCodesToDelete.Any())
            {
                var budgetObjectCodeIDList = budgetObjectCodesToDelete.Select(x => x.BudgetObjectCodeID).ToList();
                budgetObjectCodes.Where(x => budgetObjectCodeIDList.Contains(x.BudgetObjectCodeID)).Delete();
            }
        }

        public static void DeleteBudgetObjectCode(this IQueryable<BudgetObjectCode> budgetObjectCodes, int budgetObjectCodeID)
        {
            DeleteBudgetObjectCode(budgetObjectCodes, new List<int> { budgetObjectCodeID });
        }

        public static void DeleteBudgetObjectCode(this IQueryable<BudgetObjectCode> budgetObjectCodes, BudgetObjectCode budgetObjectCodeToDelete)
        {
            DeleteBudgetObjectCode(budgetObjectCodes, new List<BudgetObjectCode> { budgetObjectCodeToDelete });
        }
    }
}