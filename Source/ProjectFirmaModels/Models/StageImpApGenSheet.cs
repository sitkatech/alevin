namespace ProjectFirmaModels.Models
{
    public partial class StageImpApGenSheet : IAuditableEntity
    {

        public StageImpApGenSheet(InvoiceStageImport invoiceStageImport)
        {

            this.PONumberKey = invoiceStageImport.PONumberKey;
            this.PurchOrdLineItmKey = invoiceStageImport.PurchOrdLineItmKey;
            this.ReferenceKey = invoiceStageImport.ReferenceKey;
            this.VendorKey = invoiceStageImport.VendorKey;
            this.VendorText = invoiceStageImport.VendorText;
            this.FundKey = invoiceStageImport.FundKey;
            this.FundedProgramKey = invoiceStageImport.FundedProgramKey;
            this.WBSElementKey = invoiceStageImport.WbsElementKey;
            this.WBSElementText = invoiceStageImport.WbsElementText;
            this.BudgetObjectClassKey = invoiceStageImport.BudgetObjectClassKey;
            this.DebitAmount = invoiceStageImport.DebitAmount;
            this.CreditAmount = invoiceStageImport.CreditAmount;
            this.DebitCreditTotal = invoiceStageImport.DebitCreditTotal;
        }

        public string GetAuditDescriptionString()
        {
            return this.StageImpApGenSheetID.ToString();
        }
    }
}