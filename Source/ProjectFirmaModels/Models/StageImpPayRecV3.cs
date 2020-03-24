using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirmaModels.Models
{
    public partial class StageImpPayRecV3 : IAuditableEntity
    {
        public StageImpPayRecV3(FbmsBudgetStageImport fbmsBudgetStageImport)
        {
            this.BusinessAreaKey = fbmsBudgetStageImport.BusinessAreaKey;
            this.FABudgetActivityKey = fbmsBudgetStageImport.FaBudgetActivityKey;
            this.FunctionalAreaText = fbmsBudgetStageImport.FunctionalAreaText;
            this.ObligationNumberKey = fbmsBudgetStageImport.ObligationNumberKey;
            this.ObligationItemKey = fbmsBudgetStageImport.ObligationItemKey;
            this.FundKey = fbmsBudgetStageImport.FundKey;
            this.FundedProgramKeyNotCompounded = fbmsBudgetStageImport.FundedProgramKeyNotCompounded;
            this.WBSElementKey = fbmsBudgetStageImport.WbsElementKey;
            this.WBSElementText = fbmsBudgetStageImport.WbsElementText;
            this.BudgetObjectClassKey = fbmsBudgetStageImport.BudgetObjectClassKey;
            this.VendorKey = fbmsBudgetStageImport.VendorKey;
            this.VendorText = fbmsBudgetStageImport.VendorText;
            this.Obligation = fbmsBudgetStageImport.Obligation;
            this.GoodsReceipt = fbmsBudgetStageImport.GoodsReceipt;
            this.Invoiced = fbmsBudgetStageImport.Invoiced;
            this.Disbursed = fbmsBudgetStageImport.Disbursed;
            // 3/17/2020 TK - This column is currently not included in our latest excel.
            //this.UnexpendedBalance = budgetStageImport.UnexpendedBalance;

            this.CreatedOnKey = fbmsBudgetStageImport.CreatedOnKey;
            this.DateOfUpdateKey = fbmsBudgetStageImport.DateOfUpdateKey;
            this.PostingDateKey = fbmsBudgetStageImport.PostingDateKey;
            this.PostingDatePerSplKey = fbmsBudgetStageImport.PostingDatePerSplKey;
            this.DocumentDateOfBlKey = fbmsBudgetStageImport.DocumentDateOfBlKey;
        }

public string GetAuditDescriptionString()
{
return this.StageImpPayRecV3ID.ToString();
}
}
}
 