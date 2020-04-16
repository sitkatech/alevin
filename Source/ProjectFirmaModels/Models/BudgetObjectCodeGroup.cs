namespace ProjectFirmaModels.Models
{
    public partial class BudgetObjectCodeGroup
    {
        public string GetDisplayName() => $"{this.BudgetObjectCodeGroupPrefix} - {this.BudgetObjectCodeGroupName}";
    }
}