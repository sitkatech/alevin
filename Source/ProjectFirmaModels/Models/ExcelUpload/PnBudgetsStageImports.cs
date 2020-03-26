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
    public class PnBudgetsStageImports : List<PnBudgetsStageImport>
    {
        public const string SheetName = "Analysis 1";
        /// <summary>
        /// If there is only a single worksheet in a file, try to use it, no matter what it is named
        /// </summary>
        public const bool UseExistingSheetNameIfSingleSheetFound = true;

        public static PnBudgetsStageImports LoadFromXlsFile(DataTable dataTable)
        {
            EnsureWorksheetHasCorrectShape(dataTable);

            // Create index-to-row dictionary. This is generally discouraged, but we don't have any other way to get the exact cell address, which 
            // can save the user a great deal of time during debugging.
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
                if (PnBudgetsStageImport.RowIsBlank(kvp.Value))
                {
                    indexesToRemove.Add(kvp.Key);
                }
            }

            // Remove entries that we need to discard
            foreach (var i in indexesToRemove)
            {
                indexToRowDict.Remove(i);
            }

            // Turn all valid rows into PnBudgetsStageImports
            return new PnBudgetsStageImports(indexToRowDict.Select(kvp => new PnBudgetsStageImport(kvp)));
        }

        public PnBudgetsStageImports(IEnumerable<PnBudgetsStageImport> collection) : base(collection)
        {
        }

        private static void EnsureWorksheetHasCorrectShape(DataTable dataTable)
        {
            var columnNames = PnBudgets_GetBudgetColumnLetterToColumnNameDictionary();

            var dataRow = dataTable.Rows[0];
            var expectedColumns = columnNames.Values.ToList();
            var actualColumns = dataTable.Columns.Cast<DataColumn>().Select(c => (string)dataRow[c]).ToList();

            var missingColumns = expectedColumns.Except(actualColumns).ToList();
            Check.RequireThrowUserDisplayable(!missingColumns.Any(),
                                              string.Format("Expected columns [{0}]\n\nBut got columns [{1}].\n\nThese columns were missing: [{2}]", string.Join(", ", expectedColumns),
                                                            string.Join(", ", actualColumns), string.Join(", ", missingColumns)));
        }

        /*
         * Excel column names:
         *
         * Funded Program
         * Fund Type
         * Fund
         * Funds Center
         * Fiscal year/period
         * Commitment item
         * FI doc:doc.number
         * Recoveries
         * Committed But Not Obligated
         * Total Obligations
         * Total Expenditures
         * Undelivered Orders
         */

        public const string FundedProgram = "Funded Program";
        public const string FundType = "Fund Type";
        public const string Fund = "Fund";
        public const string FundsCenter = "Funds Center";
        public const string FiscalYearPeriod = "Fiscal year/period";
        public const string CommitmentItem = "Commitment item";
        public const string FiDocNumber = "FI doc:doc.number";
        public const string Recoveries = "Recoveries";
        public const string CommittedButNotObligated = "Committed But Not Obligated";
        public const string TotalObligations = "Total Obligations";
        public const string TotalExpenditures = "Total Expenditures";
        public const string UndeliveredOrders = "Undelivered Orders";

        public static Dictionary<string, string> PnBudgets_GetBudgetColumnLetterToColumnNameDictionary()
        {
            return new Dictionary<string, string>
            {
                {"A", FundedProgram},
                {"B", FundType},
                {"C", Fund},
                {"D", FundsCenter},
                {"E", FiscalYearPeriod},
                {"F", CommitmentItem},
                {"G", FiDocNumber},
                {"H", Recoveries},
                {"I", CommittedButNotObligated},
                {"J", TotalObligations},
                {"K", TotalExpenditures},
                {"L", UndeliveredOrders},
            };
        }

        public static Dictionary<string, string> PnBudgets_GetBudgetColumnNameToColumnLetterDictionary()
        {
            var forwardDict = PnBudgets_GetBudgetColumnLetterToColumnNameDictionary();
            var reverseDict = forwardDict.ToDictionary(g => g.Value, g => g.Key);
            return reverseDict;
        }

    }
}
