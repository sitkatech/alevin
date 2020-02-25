namespace ProjectFirmaModels.Models
{
    public partial class StageImpPayRecV3 : IAuditableEntity
    {
        public StageImpPayRecV3(BudgetTransferBulk budgetTransferBulk)
        {

            this.BusinessAreaKey = budgetTransferBulk.BusinessAreaKey;
            this.FABudgetActivityKey = budgetTransferBulk.FaBudgetActivityKey;
            this.FunctionalAreaText = budgetTransferBulk.FunctionalAreaText;
            this.ObligationNumberKey = budgetTransferBulk.ObligationNumberKey;
            this.ObligationItemKey = budgetTransferBulk.ObligationItemKey;
            this.FundKey = budgetTransferBulk.FundKey;
            this.FundedProgramKeyNotCompounded = budgetTransferBulk.FundedProgramKeyNotCompounded;
            this.WBSElementKey = budgetTransferBulk.WbsElementKey;
            this.WBSElementText = budgetTransferBulk.WbsElementText;
            this.BudgetObjectClassKey = budgetTransferBulk.BudgetObjectClassKey;
            this.VendorKey = budgetTransferBulk.VendorKey;
            this.VendorText = budgetTransferBulk.VendorText;
            this.Obligation = budgetTransferBulk.Obligation;
            this.GoodsReceipt = budgetTransferBulk.GoodsReceipt?.ToString();
            this.Invoiced = budgetTransferBulk.Invoiced;
            this.Disbursed = budgetTransferBulk.Disbersed;
            this.UnexpendedBalance = budgetTransferBulk.UnexpendedBalance;
        }

        public string GetAuditDescriptionString()
        {
            return this.StageImpPayRecV3ID.ToString();
        }
    }
}