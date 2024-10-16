﻿/*-----------------------------------------------------------------------
<copyright file="InvoiceStageImports.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirmaModels.Models.ExcelUpload
{
    public class FbmsInvoiceStageImports : List<FbmsInvoiceStageImport>
    {
        public const string SheetName = "AP-Genl";
        /// <summary>
        /// If there is only a single worksheet in a file, try to use it, no matter what it is named
        /// </summary>
        public const bool UseExistingSheetNameIfSingleSheetFound = true;

        public static FbmsInvoiceStageImports LoadFromXlsFile(DataTable dataTable)
        {
            EnsureWorksheetHasCorrectShape(dataTable);

            // Create index-to-row dictionary. This is generally discouraged, but we don't have any other way to get the exact cell address, which 
            // can save the user a great deal of time.
            int rowNumber = 0;
            var indexToRowDict = new Dictionary<int, DataRow>();
            foreach (DataRow curDataRow in dataTable.Rows)
            {
                indexToRowDict.Add(rowNumber++, curDataRow);
            }

            // Skip the first row (remove it)
            var indexesToRemove = new List<int> { 0 };

            // Remove any blank rows
            foreach (var kvp in indexToRowDict)
            {
                if (FbmsInvoiceStageImport.RowIsBlank(kvp.Value))
                {
                    indexesToRemove.Add(kvp.Key);
                }
            }

            // Remove entries that we need to discard
            foreach (var i in indexesToRemove)
            {
                indexToRowDict.Remove(i);
            }

            // Turn all valid rows into BudgetTransferBulks
            return new FbmsInvoiceStageImports(indexToRowDict.Select(kvp => new FbmsInvoiceStageImport(kvp)));
        }

        public FbmsInvoiceStageImports(IEnumerable<FbmsInvoiceStageImport> collection) : base(collection)
        {
        }

        private static void EnsureWorksheetHasCorrectShape(DataTable dataTable)
        {
            var columnNames = FbmsInvoice_GetInvoiceColumnLetterToColumnNameDictionary();

            var dataRow = dataTable.Rows[0];
            var expectedColumns = columnNames.Values.ToList();
            var actualColumns = dataTable.Columns.Cast<DataColumn>().Select(c => (string)dataRow[c]).ToList();

            var missingColumns = expectedColumns.Except(actualColumns).ToList();
            Check.RequireThrowUserDisplayable(!missingColumns.Any(),
                                              string.Format("Expected columns [{0}]\n\nBut got columns [{1}].\n\nThese columns were missing: [{2}]", string.Join(", ", expectedColumns),
                                                            string.Join(", ", actualColumns), string.Join(", ", missingColumns)));

            // taking this out for now - we don't think we want it to be tolerant  of oddball formats. We'd want to know when things change.
            // -- SLG 3/16/20 

            //foreach (var dataColumn in dataTable.Columns.Cast<DataColumn>())
            //{
            //    var currentString = (string) dataRow[dataColumn];
            //    // Remove unexpected columns?
            //    if (!expectedColumns.Any(x => string.Equals(currentString, x)))
            //    {
            //        dataTable.Columns.Remove(dataColumn);
            //    }
            //}



        }

        public const string PurchaseOrderNumberKey = "PO Number - Key";
        public const string PurchaseOrderLineItemKey = "Purch Ord Line Itm - Key";
        public const string ReferenceKey = "Reference - Key";
        public const string VendorKey = "Vendor - Key";
        public const string VendorText = "Vendor - Text";
        public const string FundKey = "Fund - Key";
        public const string FundedProgramKey = "Funded Program - Key";
        public const string WbsElementKey = "WBS Element - Key";
        public const string WbsElementText = "WBS Element - Text";
        public const string BudgetObjectClassKey = "Budget Object Class - Key";
        public const string DebitAmount = "Debit Amount";
        public const string CreditAmount = "Credit Amount";
        public const string DebitCreditTotal = "Debit/Credit Total";
        public const string CreatedOnKey = "Created on - Key";
        public const string PostingDateKey = "Posting date - Key";

        public static Dictionary<string, string> FbmsInvoice_GetInvoiceColumnLetterToColumnNameDictionary()
        {
            return new Dictionary<string, string>
            {
                {"B", PurchaseOrderNumberKey},
                {"C", PurchaseOrderLineItemKey},
                {"D", ReferenceKey},
                {"E", VendorKey},
                {"F", VendorText},
                {"G", FundKey},
                {"H", FundedProgramKey},
                {"I", WbsElementKey},
                {"J", WbsElementText},
                {"K", BudgetObjectClassKey},
                {"L", DebitAmount},
                {"M", CreditAmount},
                {"N", DebitCreditTotal},
                {"O", CreatedOnKey },
                {"P", PostingDateKey }
            };
        }

        public static Dictionary<string, string> FbmsInvoice_GetInvoiceColumnNameToColumnLetterDictionary()
        {
            var forwardDict = FbmsInvoice_GetInvoiceColumnLetterToColumnNameDictionary();
            var reverseDict = forwardDict.ToDictionary(g => g.Value, g => g.Key);
            return reverseDict;
        }

    }
}
