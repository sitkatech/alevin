namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeGroupTreeGridBudgetObjectCodeLeafJson
    {
        /*

    { width: 260, id: "boc_or_bocg_id", header: [{ text: "Budget Object Code" }] },
    { width: 260, id: "name_or_description", type: "string", header: [{ text: "Name" }] },
    { width: 200, id: "definition", type: "string", header: [{ text: "Definition" }] },
    { width: 200, id: "fbms_year", type: "string", header: [{ text: "FBMS Year" }] },
    { width: 200, id: "reportable_1099", type: "string", header: [{ text: "Reportable 1099" }] },
    { width: 200, id: "explanation_1099", type: "string", header: [{ text: "Explanation 1099" }] }

*/
        // ID of Budget Object Code Group that is immediate parent.
        // field "id" is expected in BOCG group JSON objects
        public int parent;

        // These are the columns to be displayed

        // "Budget Object Code"
        public string boc_or_bocg_id;
        public string name_or_description;
        public string definition;
        public string fbms_year;
        public string reportable_1099;
        public string explanation_1099;

        public BudgetObjectCodeGroupTreeGridBudgetObjectCodeLeafJson(ProjectFirmaModels.Models.BudgetObjectCode budgetObjectCode)
        {
            this.parent = budgetObjectCode.BudgetObjectCodeGroupID;

            this.boc_or_bocg_id = budgetObjectCode.BudgetObjectCodeName;
            this.name_or_description = budgetObjectCode.BudgetObjectCodeItemDescription;
            this.definition = budgetObjectCode.BudgetObjectCodeDefinition;
            this.fbms_year = budgetObjectCode.FbmsYear.ToString();
            this.reportable_1099 = budgetObjectCode.Reportable1099.ToString();
            this.explanation_1099 = budgetObjectCode.Explanation1099;
        }
    }
}