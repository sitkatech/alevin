using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjectFirmaModels.Models.ExcelUpload
{
    public class FbmsInvoiceStageImport
    {
        public readonly string PONumberKey;
        public readonly string PurchOrdLineItmKey;
        public readonly string ReferenceKey;
        public readonly string VendorKey;
        public readonly string VendorText;
        public readonly string FundKey;
        public readonly string FundedProgramKey;
        public readonly string WbsElementKey;
        public readonly string WbsElementText;
        public readonly string BudgetObjectClassKey;
        public readonly double? DebitAmount;
        public readonly double? CreditAmount;
        public readonly double? DebitCreditTotal;
        public readonly DateTime? CreatedOnKey;
        public readonly DateTime? PostingDateKey;


        public FbmsInvoiceStageImport(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;
            var columnNameToLetterDict = FbmsInvoiceStageImports.GetInvoiceColumnNameToColumnLetterDictionary();

            // Column - PO Number - Key
            PONumberKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.PurchaseOrderNumberKey);

            // Column - Purch Ord Line Itm - Key
            PurchOrdLineItmKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.PurchaseOrderLineItemKey);

            // Column - Reference - Key
            ReferenceKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.ReferenceKey);

            // Column - Vendor - Key
            VendorKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.VendorKey);

            // Column - Vendor - Text
            VendorText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.VendorText);
            
            // Column - Fund - Key
            FundKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.FundKey);

            // Column - Funded Program - Key
            FundedProgramKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.FundedProgramKey);

            // Column - Wbs Element - Key
            WbsElementKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.WbsElementKey);

            // Column - Wbs Element - Text
            WbsElementText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.WbsElementText);

            // Column - Budget Object Class - Key
            BudgetObjectClassKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.BudgetObjectClassKey);

            // Column - DebitAmount
            DebitAmount = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.DebitAmount);

            // Column - CreditAmount
            CreditAmount = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.CreditAmount);

            // Column - DebitCreditTotal
            DebitCreditTotal = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.DebitCreditTotal);

            // Column - Created On - Key
            CreatedOnKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.CreatedOnKey);

            // Column - Posting Date Key
            PostingDateKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                FbmsInvoiceStageImports.PostingDateKey);
        }

        /// <summary>
        /// Are all relevant columns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        {
            var columnsToCheck = FbmsInvoiceStageImports.GetInvoiceColumnLetterToColumnNameDictionary().Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[(string) col].ToString()));
            return allColumnsBlank;
        }
    }
}