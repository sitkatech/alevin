/*-----------------------------------------------------------------------
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
    public class FbmsBudgetStageImportPayrecV3UnexpendedBalances : List<FbmsBudgetStageImportPayrecV3UnexpendedBalance>
    {
        public const string FbmsUnexpendedPayrecV3SheetName = "Analysis 1 - PayRec v3 BW_SS...";
        /// <summary>
        /// If there is only a single worksheet in a file, try to use it, no matter what it is named
        /// </summary>
        public const bool UseExistingSheetNameIfSingleSheetFound = true;

        public static FbmsBudgetStageImportPayrecV3UnexpendedBalances LoadFromXlsFile(DataTable dataTable)
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
            List<FbmsBudgetStageImportPayrecV3UnexpendedBalance> fbmsBudgetStageImportPayrecV3UnexpendedBalances = indexToRowDict.Select(kvp => new FbmsBudgetStageImportPayrecV3UnexpendedBalance(kvp)).ToList();
            return new FbmsBudgetStageImportPayrecV3UnexpendedBalances(fbmsBudgetStageImportPayrecV3UnexpendedBalances);
        }

        public FbmsBudgetStageImportPayrecV3UnexpendedBalances(IEnumerable<FbmsBudgetStageImportPayrecV3UnexpendedBalance> collection) : base(collection)
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


        public const string BusinessAreaKey = "Business area";
        public const string FaBudgetActivityKey = "FA Budget Activity";
        public const string FunctionalAreaText = "Functional area";
        public const string ObligationNumberKey = "Obligation Number";
        public const string ObligationItemKey = "Obligation Item";
        public const string FundKey = "Fund";
        public const string FundedProgramKey = "Funded Program";
        public const string WbsElementKey = "WBS Element";
        public const string WbsElementText = "WBS Description";
        public const string BudgetObjectClassKey = "Budget Object Class";
        public const string VendorKey = "Vendor";
        public const string VendorText = "Vendor Name";
        public const string PostingDatePerSplKey = "Posting Date (Per SPL)";
        public const string UnexpendedBalanceValue = "Unexpended Balance";

        public static Dictionary<string, string> GetBudgetColumnLetterToColumnNameDictionary()
        {
            return new Dictionary<string, string>
            {
                {"A", BusinessAreaKey},
                {"B", FaBudgetActivityKey},
                {"C", FunctionalAreaText},
                {"D", ObligationNumberKey},
                {"E", ObligationItemKey},
                {"F", FundKey},
                {"G", FundedProgramKey},
                {"H", WbsElementKey},
                {"I", WbsElementText},
                {"J", BudgetObjectClassKey},
                {"K", VendorKey},
                {"L", VendorText },
                {"M", PostingDatePerSplKey },
                {"N", UnexpendedBalanceValue }
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
