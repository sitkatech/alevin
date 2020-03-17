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

            // Column A - PO Number - Key
            PONumberKey = TryParseStringColumn(dr, rowIndex, "A", "PO Number - Key");

            // Column B - Purch Ord Line Itm - Key
            PurchOrdLineItmKey = TryParseStringColumn(dr, rowIndex, "B", "Purch Ord Line Itm - Key");

            // Column C - Reference - Key
            ReferenceKey = TryParseStringColumn(dr, rowIndex, "C", "Reference - Key");

            // Column D - Vendor - Key
            VendorKey = TryParseStringColumn(dr, rowIndex, "D", "Vendor - Key");

            // Column E - Vendor - Text
            VendorText = TryParseStringColumn(dr, rowIndex, "E", "Vendor - Text");
            
            // Column F - Fund - Key
            FundKey = TryParseStringColumn(dr, rowIndex, "F", "Fund - Key");

            // Column G - Funded Program - Key
            FundedProgramKey = TryParseStringColumn(dr, rowIndex, "G", "Funded Program - Key");

            // Column H - Wbs Element - Key
            WbsElementKey = TryParseStringColumn(dr, rowIndex, "H", "Wbs Element - Key");

            // Column I - Wbs Element - Text
            WbsElementText = TryParseStringColumn(dr, rowIndex, "I", "Wbs Element - Text");

            // Column J - Budget Object Class - Key
            BudgetObjectClassKey = TryParseStringColumn(dr, rowIndex, "J", "Budget Object Class - Key");

            // Column K - DebitAmount
            DebitAmount = TryParseDoubleColumn(dr, rowIndex, "K", "DebitAmount");

            // Column L - CreditAmount
            CreditAmount = TryParseDoubleColumn(dr, rowIndex, "L", "CreditAmount");

            // Column M - DebitCreditTotal
            DebitCreditTotal = TryParseDoubleColumn(dr, rowIndex, "M", "DebitCreditTotal");
        }

        private static double? TryParseDoubleColumn(DataRow dr, int rowIndex, string columnName, string displayString)
        {
            double? debitAmount;
            try
            {
                var isNullOrWhitespace = string.IsNullOrWhiteSpace(dr[columnName].ToString());
                if (isNullOrWhitespace)
                {
                    debitAmount = null;
                }
                else
                {
                    debitAmount = double.Parse(dr[columnName].ToString());
                }
            }
            catch (Exception e)
            {
                throw new ExcelImportBadCellException(columnName, rowIndex, dr[columnName].ToString(),
                    $"Problem parsing {displayString}", e);
            }

            return debitAmount;
        }

        private static string TryParseStringColumn(DataRow dr, int rowIndex, string columnName, string textOfSource)
        {
            string vendorText;
            try
            {
                vendorText = string.IsNullOrWhiteSpace(dr[columnName].ToString()) ? null : dr[columnName].ToString();
            }
            catch (Exception e)
            {
                throw new ExcelImportBadCellException(columnName, rowIndex, dr[columnName].ToString(),
                    $"Problem parsing Source {textOfSource}", e);
            }

            return vendorText;
        }

        /// <summary>
        /// Are all relevant colummns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        {
            var columnsToCheck = new List<String> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[(string) col].ToString()));
            return allColumnsBlank;
        }
    }
}