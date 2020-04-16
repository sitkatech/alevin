using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeGroupTreeGridBudgetObjectCodeGroupJson
    {
        // Our names need to match what dhtmxl GridTree expects
        // ReSharper disable InconsistentNaming

        // ID of Budget Object Code Group 
        public int id;

        // Optional parent ID of Parent Budget Object Code Group
        public int? parent;

        // BudgetObjectCodeGroupPrefix
        public string boc_or_bocg_id;
        // BudgetObjectCodeGroupName
        public string name_or_description;
        // BudgetObjectCodeGroupDefinition
        public string definition;

        public BudgetObjectCodeGroupTreeGridBudgetObjectCodeGroupJson(BudgetObjectCodeGroup budgetObjectCodeGroup)
        {
            this.parent = budgetObjectCodeGroup.ParentBudgetObjectCodeGroupID;
            this.id = budgetObjectCodeGroup.BudgetObjectCodeGroupID;
            this.boc_or_bocg_id = budgetObjectCodeGroup.BudgetObjectCodeGroupPrefix;
            this.name_or_description = budgetObjectCodeGroup.BudgetObjectCodeGroupName;
            this.definition = budgetObjectCodeGroup.BudgetObjectCodeGroupDefinition;
        }
    }
}