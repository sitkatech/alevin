using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

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

            // The order of objects doesn't matter, so long as we do them all - there is no nesting hierarchy
            // in the DHTMLXTreeGrid JSON format, it's driven entirely by keying.
            //
            // But since we have to do some order, we'll do the groups, then the leaves.
            foreach (var currentBudgetObjectCodeGroup in budgetObjectCodeGroups)
            {
                budgetObjectsToSerialize.Add(new BudgetObjectCodeGroupTreeGridBudgetObjectCodeGroupJson(currentBudgetObjectCodeGroup));
            }

            // We want to group the BOCs by name, so we can limit the duplicate output somewhat.
            var bocNamesToBocDictionary = GetBocToYearsDictionary(budgetObjectCodes);
            foreach (var currentBocDictEntry in bocNamesToBocDictionary)
            {
                // We take the one from the latest year as the one whose details we display.
                // This isn't perfect but seems most likely to be what the user expects to see for the prototype of this BOC.
                var currentBoc = currentBocDictEntry.Value.OrderBy(boc => boc.FbmsYear).Last();

                // Make an individual link for each FBMS Year variant, so the user can drill down to the details if they want to.
                string relevantYearsAsListOfHtmlLinks = MakeBocConjoinedLinkString(currentBocDictEntry);
                budgetObjectsToSerialize.Add(new BudgetObjectCodeGroupTreeGridBudgetObjectCodeLeafJson(currentBoc, relevantYearsAsListOfHtmlLinks));
            }

            string resultingJson = LtInfo.Common.JsonTools.SerializeObject(budgetObjectsToSerialize);
            return resultingJson;
        }

        public static Dictionary<string, List<ProjectFirmaModels.Models.BudgetObjectCode>> 
                            GetBocToYearsDictionary(List<ProjectFirmaModels.Models.BudgetObjectCode> budgetObjectCodes)
        {
            // Build a list of Possible BOC name prefixes to the specific BOC records.
            var bocNameToBocRecords = budgetObjectCodes.GroupBy(boc => boc.BudgetObjectCodeName).ToDictionary(g => g.Key, g => g.ToList());
            return bocNameToBocRecords;
        }

        public static String MakeBocConjoinedLinkString(KeyValuePair<string, List<ProjectFirmaModels.Models.BudgetObjectCode>> currentBocDictEntry)
        {
            List<HtmlString> htmlLinks = currentBocDictEntry.Value
                .Select(boc => UrlTemplate.MakeHrefString(boc.GetDetailUrl(), boc.FbmsYear.ToString())).ToList();
            return String.Join(", ", htmlLinks);
        }
    }
}