namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeGroupTreeGridBudgetObjectCodeLeafJson
    {
        // Our names need to match what dhtmxl GridTree expects
        // ReSharper disable InconsistentNaming

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