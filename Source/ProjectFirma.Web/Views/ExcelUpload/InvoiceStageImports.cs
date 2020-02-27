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
using MoreLinq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    public class InvoiceStageImports : List<InvoiceStageImport>
    {
        public const string SheetName = "AP-Genl";
        /// <summary>
        /// If there is only a single worksheet in a file, try to use it, no matter what it is named
        /// </summary>
        public const bool UseExistingSheetNameIfSingleSheetFound = true;

        public static InvoiceStageImports LoadFromXlsFile(DataTable dataTable)
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
                if (InvoiceStageImport.RowIsBlank(kvp.Value))
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
            return new InvoiceStageImports(indexToRowDict.Select(kvp => new InvoiceStageImport(kvp)));
        }

        public InvoiceStageImports(IEnumerable<InvoiceStageImport> collection) : base(collection)
        {
        }

        private static void EnsureWorksheetHasCorrectShape(DataTable dataTable)
        {
            var columnNames = new Dictionary<string, string>
                              {
                                  {"A", "PO Number - Key"},
                                  {"B", "Purch Ord Line Itm - Key"},
                                  {"C", "Reference - Key"},
                                  {"D", "Vendor - Key"},
                                  {"E", "Vendor - Text"},
                                  {"F", "Fund - Key"},
                                  {"G", "Funded Program - Key"},
                                  {"H", "WBS Element - Key"},
                                  {"I", "WBS Element - Text"},
                                  {"J", "Budget Object Class - Key"},
                                  {"K", "Debit Amount"},
                                  {"L", "Credit Amount" },
                                  {"M", "Debit/Credit Total" }

                                  
                              };

            var dataRow = dataTable.Rows[0];
            var expectedColumns = columnNames.Values.ToList();
            var actualColumns = dataTable.Columns.Cast<DataColumn>().Select(c => (string)dataRow[c]).ToList();

            var missingColumns = expectedColumns.Except(actualColumns).ToList();
            Check.RequireThrowUserDisplayable(!missingColumns.Any(),
                                              string.Format("Expected columns [{0}]\n\nBut got columns [{1}].\n\nThese columns were missing: [{2}]", string.Join(", ", expectedColumns),
                                                            string.Join(", ", actualColumns), string.Join(", ", missingColumns)));

            foreach (var dataColumn in dataTable.Columns.Cast<DataColumn>())
            {
                var currentString = (string) dataRow[dataColumn];
                if (!expectedColumns.Any(x => string.Equals(currentString, x)))
                {
                    dataTable.Columns.Remove(dataColumn);
                }
            }

           
           
        }

    }
}
