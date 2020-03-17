using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjectFirmaModels.Models.ExcelUpload
{
    public class InvoiceStageImport
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


        public InvoiceStageImport(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;
            var columnNameToLetterDict = InvoiceStageImports.GetInvoiceColumnNameToColumnLetterDictionary();

            // Column A - PO Number - Key
            PONumberKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.PurchaseOrderNumberKey);

            // Column B - Purch Ord Line Itm - Key
            PurchOrdLineItmKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.PurchaseOrderLineItemKey);

            // Column C - Reference - Key
            ReferenceKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.ReferenceKey);

            // Column D - Vendor - Key
            VendorKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.VendorKey);

            // Column E - Vendor - Text
            VendorText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.VendorText);
            
            // Column F - Fund - Key
            FundKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.FundKey);

            // Column G - Funded Program - Key
            FundedProgramKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.FundedProgramKey);

            // Column H - Wbs Element - Key
            WbsElementKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.WbsElementKey);

            // Column I - Wbs Element - Text
            WbsElementText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.WbsElementText);

            // Column J - Budget Object Class - Key
            BudgetObjectClassKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.BudgetObjectClassKey);

            // Column K - DebitAmount
            DebitAmount = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.DebitAmount);

            // Column L - CreditAmount
            CreditAmount = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.CreditAmount);

            // Column M - DebitCreditTotal
            DebitCreditTotal = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict,
                InvoiceStageImports.DebitCreditTotal);
        }

        /// <summary>
        /// Are all relevant columns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        {
            var columnsToCheck = InvoiceStageImports.GetInvoiceColumnLetterToColumnNameDictionary().Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[(string) col].ToString()));
            return allColumnsBlank;
        }
    }
}