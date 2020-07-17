using System;
using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirmaModels.Models
{
    public partial class StageImpUnexpendedBalancePayRecV3 : IAuditableEntity
    {
        public StageImpUnexpendedBalancePayRecV3(FbmsBudgetStageImportPayrecV3UnexpendedBalance fbmsBudgetStageImportPayrecV3UnexpendedBalance)
        {
            this.BusinessArea = fbmsBudgetStageImportPayrecV3UnexpendedBalance.BusinessArea;
            this.FABudgetActivity = fbmsBudgetStageImportPayrecV3UnexpendedBalance.FABudgetActivity;
            this.FunctionalArea = fbmsBudgetStageImportPayrecV3UnexpendedBalance.FunctionalArea;
            this.ObligationNumber = fbmsBudgetStageImportPayrecV3UnexpendedBalance.ObligationNumber;
            this.ObligationItem = fbmsBudgetStageImportPayrecV3UnexpendedBalance.ObligationItem;
            this.Fund = fbmsBudgetStageImportPayrecV3UnexpendedBalance.Fund;
            //this.FundedProgram = fbmsBudgetStageImportPayrecV3UnexpendedBalance.FundedProgram;
            this.WBSElement = fbmsBudgetStageImportPayrecV3UnexpendedBalance.WbsElement;
            this.WBSElementDescription = fbmsBudgetStageImportPayrecV3UnexpendedBalance.WbsElementDescription;
            this.BudgetObjectClass = fbmsBudgetStageImportPayrecV3UnexpendedBalance.BudgetObjectClass;
            this.Vendor = fbmsBudgetStageImportPayrecV3UnexpendedBalance.Vendor;
            this.VendorName = fbmsBudgetStageImportPayrecV3UnexpendedBalance.VendorName;
            this.PostingDatePerSpl = fbmsBudgetStageImportPayrecV3UnexpendedBalance.PostingDatePerSpl;
            this.UnexpendedBalance = fbmsBudgetStageImportPayrecV3UnexpendedBalance.UnexpendedBalance;
        }

        public string GetAuditDescriptionString()
        {
            return StageImpUnexpendedBalancePayRecV3ID.ToString();
        }
    }



    // This is obsolete we think, but it's also not being gen'd currently, and I haven't looked into why deeply enough -- SLG 6/11/2020
    /*
    public partial class StageImpOriginalPayRecV3 : IAuditableEntity
    {
        public StageImpOriginalPayRecV3(FbmsBudgetStageImportOriginalPayrecV3 fbmsBudgetStageImportOriginalPayrecV3)
        {
            BusinessAreaKey = fbmsBudgetStageImportOriginalPayrecV3.BusinessAreaKey;
            FABudgetActivityKey = fbmsBudgetStageImportOriginalPayrecV3.FaBudgetActivityKey;
            FunctionalAreaText = fbmsBudgetStageImportOriginalPayrecV3.FunctionalAreaText;
            ObligationNumberKey = fbmsBudgetStageImportOriginalPayrecV3.ObligationNumberKey;
            ObligationItemKey = fbmsBudgetStageImportOriginalPayrecV3.ObligationItemKey;
            FundKey = fbmsBudgetStageImportOriginalPayrecV3.FundKey;
            FundedProgramKeyNotCompounded = fbmsBudgetStageImportOriginalPayrecV3.FundedProgramKeyNotCompounded;
            WBSElementKey = fbmsBudgetStageImportOriginalPayrecV3.WbsElementKey;
            WBSElementText = fbmsBudgetStageImportOriginalPayrecV3.WbsElementText;
            BudgetObjectClassKey = fbmsBudgetStageImportOriginalPayrecV3.BudgetObjectClassKey;
            VendorKey = fbmsBudgetStageImportOriginalPayrecV3.VendorKey;
            VendorText = fbmsBudgetStageImportOriginalPayrecV3.VendorText;
            Obligation = fbmsBudgetStageImportOriginalPayrecV3.Obligation;
            GoodsReceipt = fbmsBudgetStageImportOriginalPayrecV3.GoodsReceipt;
            Invoiced = fbmsBudgetStageImportOriginalPayrecV3.Invoiced;
            Disbursed = fbmsBudgetStageImportOriginalPayrecV3.Disbursed;
            // 3/17/2020 TK - This column is currently not included in our latest excel.
            //this.UnexpendedBalance = budgetStageImport.UnexpendedBalance;

            CreatedOnKey = fbmsBudgetStageImportOriginalPayrecV3.CreatedOnKey;
            DateOfUpdateKey = fbmsBudgetStageImportOriginalPayrecV3.DateOfUpdateKey;
            PostingDateKey = fbmsBudgetStageImportOriginalPayrecV3.PostingDateKey;
            PostingDatePerSplKey = fbmsBudgetStageImportOriginalPayrecV3.PostingDatePerSplKey;
            DocumentDateOfBlKey = fbmsBudgetStageImportOriginalPayrecV3.DocumentDateOfBlKey;
        }

        public string GetAuditDescriptionString()
        {
            return StageImpPayRecV3ID.ToString();
        }
    }
    */
}
 