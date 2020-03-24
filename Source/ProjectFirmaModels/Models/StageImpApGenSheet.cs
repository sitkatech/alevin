using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirmaModels.Models
{
    public partial class StageImpApGenSheet : IAuditableEntity
    {

        public StageImpApGenSheet(FbmsInvoiceStageImport fbmsInvoiceStageImport)
        {

            this.PONumberKey = fbmsInvoiceStageImport.PONumberKey;
            this.PurchOrdLineItmKey = fbmsInvoiceStageImport.PurchOrdLineItmKey;
            this.ReferenceKey = fbmsInvoiceStageImport.ReferenceKey;
            this.VendorKey = fbmsInvoiceStageImport.VendorKey;
            this.VendorText = fbmsInvoiceStageImport.VendorText;
            this.FundKey = fbmsInvoiceStageImport.FundKey;
            this.FundedProgramKey = fbmsInvoiceStageImport.FundedProgramKey;
            this.WBSElementKey = fbmsInvoiceStageImport.WbsElementKey;
            this.WBSElementText = fbmsInvoiceStageImport.WbsElementText;
            this.BudgetObjectClassKey = fbmsInvoiceStageImport.BudgetObjectClassKey;
            this.DebitAmount = fbmsInvoiceStageImport.DebitAmount;
            this.CreditAmount = fbmsInvoiceStageImport.CreditAmount;
            this.DebitCreditTotal = fbmsInvoiceStageImport.DebitCreditTotal;
            this.CreatedOnKey = fbmsInvoiceStageImport.CreatedOnKey;
            this.PostingDateKey = fbmsInvoiceStageImport.PostingDateKey;
        }

        public string GetAuditDescriptionString()
        {
            return this.StageImpApGenSheetID.ToString();
        }
    }
}