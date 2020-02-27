namespace ProjectFirmaModels.Models
{
    public partial class StageImpPayRecV3 : IAuditableEntity
    {
        public StageImpPayRecV3(BudgetStageImport budgetStageImport)
        {

            this.BusinessAreaKey = budgetStageImport.BusinessAreaKey;
            this.FABudgetActivityKey = budgetStageImport.FaBudgetActivityKey;
            this.FunctionalAreaText = budgetStageImport.FunctionalAreaText;
            this.ObligationNumberKey = budgetStageImport.ObligationNumberKey;
            this.ObligationItemKey = budgetStageImport.ObligationItemKey;
            this.FundKey = budgetStageImport.FundKey;
            this.FundedProgramKeyNotCompounded = budgetStageImport.FundedProgramKeyNotCompounded;
            this.WBSElementKey = budgetStageImport.WbsElementKey;
            this.WBSElementText = budgetStageImport.WbsElementText;
            this.BudgetObjectClassKey = budgetStageImport.BudgetObjectClassKey;
            this.VendorKey = budgetStageImport.VendorKey;
            this.VendorText = budgetStageImport.VendorText;
            this.Obligation = budgetStageImport.Obligation;
            this.GoodsReceipt = budgetStageImport.GoodsReceipt?.ToString();
            this.Invoiced = budgetStageImport.Invoiced;
            this.Disbursed = budgetStageImport.Disbersed;
            this.UnexpendedBalance = budgetStageImport.UnexpendedBalance;
        }

        public string GetAuditDescriptionString()
        {
            return this.StageImpPayRecV3ID.ToString();
        }
    }
}