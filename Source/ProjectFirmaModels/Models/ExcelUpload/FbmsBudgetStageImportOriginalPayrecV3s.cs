﻿/*-----------------------------------------------------------------------
<copyright file="BudgetStageImports.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
    // ReSharper disable once InconsistentNaming
    public class FbmsBudgetStageImportOriginalPayrecV3s : List<FbmsBudgetStageImportOriginalPayrecV3>
    {
        public const string FbmsOriginalPayRecV3SheetName = "PayRec-v3";
        /// <summary>
        /// If there is only a single worksheet in a file, try to use it, no matter what it is named
        /// </summary>
        public const bool UseExistingSheetNameIfSingleSheetFound = true;

        public static FbmsBudgetStageImportOriginalPayrecV3s LoadFromXlsFile(DataTable dataTable)
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
                if (FbmsBudgetStageImportOriginalPayrecV3.RowIsBlank(kvp.Value))
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
            return new FbmsBudgetStageImportOriginalPayrecV3s(indexToRowDict.Select(kvp => new FbmsBudgetStageImportOriginalPayrecV3(kvp)));
        }

        public FbmsBudgetStageImportOriginalPayrecV3s(IEnumerable<FbmsBudgetStageImportOriginalPayrecV3> collection) : base(collection)
        {
        }

        private static void EnsureWorksheetHasCorrectShape(DataTable dataTable)
        {
            var columnNames = GetBudgetColumnLetterToColumnNameDictionary();

            var dataRow = dataTable.Rows[0];
            var expectedColumns = columnNames.Values.ToList();
            var actualColumns = dataTable.Columns.Cast<DataColumn>().Select(c => (string)dataRow[c]).ToList();

            var missingColumns = expectedColumns.Except(actualColumns).ToList();
            Check.RequireThrowUserDisplayable(!missingColumns.Any(),
                                              string.Format("Expected columns [{0}]\n\nBut got columns [{1}].\n\nThese columns were missing: [{2}]", string.Join(", ", expectedColumns),
                                                            string.Join(", ", actualColumns), string.Join(", ", missingColumns)));
           
        }


        public const string BusinessAreaKey = "Business area - Key";
        public const string FaBudgetActivityKey = "FA Budget Activity - Key";
        public const string FunctionalAreaText = "Functional area - Text";
        public const string ObligationNumberKey = "Obligation Number - Key";
        public const string ObligationItemKey = "Obligation Item - Key";
        public const string FundKey = "Fund - Key";
        public const string FundedProgramKey = "Funded Program - Key (Not Compounded)";
        public const string WbsElementKey = "WBS Element - Key";
        public const string WbsElementText = "WBS Element - Text";
        public const string BudgetObjectClassKey = "Budget Object Class - Key";
        public const string VendorKey = "Vendor - Key";
        public const string VendorText = "Vendor - Text";
        public const string Obligation = "Obligation";
        public const string GoodsReceipt = "Goods Receipt";
        public const string Invoiced = "Invoiced";
        public const string Disbursed = "Disbursed";
        public const string CreatedOnKey = "Created on - Key";
        public const string DateOfUpdateKey = "Date of Update - Key";
        public const string PostingDateKey = "Posting date - Key";
        public const string PostingDatePerSplKey = "Posting Date (Per SPL) - Key";
        public const string DocumentDateOfBlKey = "Document Date of BL - Key";

        public static Dictionary<string, string> GetBudgetColumnLetterToColumnNameDictionary()
        {
            return new Dictionary<string, string>
            {
                {"B", BusinessAreaKey},
                {"C", FaBudgetActivityKey},
                {"D", FunctionalAreaText},
                {"E", ObligationNumberKey},
                {"F", ObligationItemKey},
                {"G", FundKey},
                {"H", FundedProgramKey},
                {"I", WbsElementKey},
                {"J", WbsElementText},
                {"K", BudgetObjectClassKey},
                {"L", VendorKey},
                {"M", VendorText },
                {"N", Obligation },
                {"O", GoodsReceipt },
                {"P", Invoiced },
                {"Q", Disbursed },
                {"R", CreatedOnKey },
                {"S", DateOfUpdateKey },
                {"T", PostingDateKey },
                {"U", PostingDatePerSplKey },
                {"V", DocumentDateOfBlKey }
            };
        }

        public static Dictionary<string, string> GetBudgetColumnNameToColumnLetterDictionary()
        {
            var forwardDict = GetBudgetColumnLetterToColumnNameDictionary();
            var reverseDict = forwardDict.ToDictionary(g => g.Value, g => g.Key);
            return reverseDict;
        }

    }
}