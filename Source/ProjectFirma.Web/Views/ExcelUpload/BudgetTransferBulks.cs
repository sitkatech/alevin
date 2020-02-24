/*-----------------------------------------------------------------------
<copyright file="ImportGdbFile.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class BudgetTransferBulks : List<BudgetTransferBulk>
    {
        public const string SheetName = "MainSheet";
        /// <summary>
        /// If there is only a single worksheet in a file, try to use it, no matter what it is named
        /// </summary>
        public const bool UseExistingSheetNameIfSingleSheetFound = true;

        public static BudgetTransferBulks LoadFromXlsFile(DataTable dataTable)
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
                if (BudgetTransferBulk.RowIsBlank(kvp.Value))
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
            return new BudgetTransferBulks(indexToRowDict.Select(kvp => new BudgetTransferBulk(kvp)));
        }

        public BudgetTransferBulks(IEnumerable<BudgetTransferBulk> collection) : base(collection)
        {
        }

        private static void EnsureWorksheetHasCorrectShape(DataTable dataTable)
        {
            var columnNames = new Dictionary<string, string>
                              {
                                  {"A", "Business area - Key"},
                                  {"B", "FA Budget Activity - Key"},
                                  {"C", "Functional area - Text"},
                                  {"D", "Obligation Number - Key"},
                                  {"E", "Obligation Item - Key"},
                                  {"F", "Fund - Key"},
                                  {"G", "Funded Program - Key (Not Compounded)"},
                                  {"H", "WBS Element - Key"},
                                  {"I", "WBS Element - Text"},
                                  {"J", "Budget Object Class - Key"},
                                  {"K", "Vendor - Key"},
                                  {"L", "Vendor - Text" },
                                  {"M", "Obligation" },
                                  {"N", "Goods Receipt" },
                                  {"O", "Invoiced" },
                                  {"P", "Disbursed" },
                                  {"Q", "Unexpended Balance" }
                                  
                              };

            var dataRow = dataTable.Rows[0];
            var expectedColumns = columnNames.Values.ToList();
            var actualColumns = dataTable.Columns.Cast<DataColumn>().Select(c => (string)dataRow[c]).ToList();

            var missingColumns = expectedColumns.Except(actualColumns).ToList();
            Check.RequireThrowUserDisplayable(!missingColumns.Any(),
                                              string.Format("Expected columns [{0}]\n\nBut got columns [{1}].\n\nThese columns were missing: [{2}]", string.Join(", ", expectedColumns),
                                                            string.Join(", ", actualColumns), string.Join(", ", missingColumns)));
            var anyNegativeAmounts = dataTable.Rows.Cast<DataRow>().Skip(1).Any(dr =>
            {
                var currentValue = dr["I"].ToString();

                // Ignore whitespace silently
                if (String.IsNullOrWhiteSpace(currentValue))
                {
                    return false;
                }

                // TODO: Try block here with exceptions

                // Otherwise, try to parse as integer
                return decimal.Parse(dr["I"].ToString()) < 0;
            });
            Check.RequireThrowUserDisplayable(!anyNegativeAmounts,
                                              string.Format("Amounts can not be negative"));
        }

    }
}
