using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public static class BudgetObjectCodeJsonBuilder
    {
        // Return JSON type?
        public static string GetBudgetObjectGroupHierarchyAsJson()
        {
            var budgetObjectCodeGroups = HttpRequestStorage.DatabaseEntities.BudgetObjectCodeGroups.ToList();
            var budgetObjectCodes = HttpRequestStorage.DatabaseEntities.BudgetObjectCodes.ToList();

            List<object> budgetObjectsToSerialize = new List<object>();

            // We think the order of objects doesn't matter, so long as we do them all.
            // But since we have to do some order, we'll do the groups, then the leaves.
            foreach (var currentBudgetObjectCodeGroup in budgetObjectCodeGroups)
            {
                budgetObjectsToSerialize.Add(new BudgetObjectCodeGroupTreeGridBudgetObjectCodeGroupJson(currentBudgetObjectCodeGroup));
            }

            foreach (var currentBudgetObjectCode in budgetObjectCodes)
            {
                budgetObjectsToSerialize.Add(new BudgetObjectCodeGroupTreeGridBudgetObjectCodeLeafJson(currentBudgetObjectCode));
            }

            string resultingJson = LtInfo.Common.JsonTools.SerializeObject(budgetObjectsToSerialize);
            return resultingJson;
        }
    }
}