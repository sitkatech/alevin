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


}
 