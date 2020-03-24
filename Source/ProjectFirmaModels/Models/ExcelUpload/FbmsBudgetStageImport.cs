/*-----------------------------------------------------------------------
<copyright file="BudgetStageImport.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirmaModels.Models.ExcelUpload
{
    public class FbmsBudgetStageImport
    {
        public readonly string BusinessAreaKey;
        public readonly string FaBudgetActivityKey;
        public readonly string FunctionalAreaText;
        public readonly string ObligationNumberKey;
        public readonly string ObligationItemKey;
        public readonly string FundKey;
        public readonly string FundedProgramKeyNotCompounded;
        public readonly string WbsElementKey;
        public readonly string WbsElementText;
        public readonly string BudgetObjectClassKey;
        public readonly string VendorKey;
        public readonly string VendorText;
        public readonly double? Obligation;
        public readonly double? GoodsReceipt;
        public readonly double? Invoiced;
        public readonly double? Disbursed;
        public readonly double? UnexpendedBalance;

        public readonly DateTime? CreatedOnKey;
        public readonly DateTime? DateOfUpdateKey;
        public readonly DateTime? PostingDateKey;
        public readonly DateTime? PostingDatePerSplKey;
        public readonly DateTime? DocumentDateOfBlKey;

        public FbmsBudgetStageImport(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;
            var columnNameToLetterDict = FbmsBudgetStageImports.GetBudgetColumnNameToColumnLetterDictionary();
 
            // Column - Business Area Key
            BusinessAreaKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.BusinessAreaKey);

            // Column - FA Budget Activity Key
            FaBudgetActivityKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.FaBudgetActivityKey);

            // Column - Functional Area Text
            FunctionalAreaText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.FunctionalAreaText);

            // Column - Obligation Number Key
            ObligationNumberKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.ObligationNumberKey);

            // Column - Obligation Item Key
            ObligationItemKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.ObligationItemKey);

            // Column - Fund Key
            FundKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.FundKey);

            // Column - Funded Program Key (Not Compunded)
            FundedProgramKeyNotCompounded = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.FundedProgramKey);

            // Column - WBS Element Key
            WbsElementKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.WbsElementKey);

            // Column - WBS Element Text
            WbsElementText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.WbsElementText);

            // Column - Budget Object Class Key
            BudgetObjectClassKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.BudgetObjectClassKey);

            // Column - Vendor Key
            VendorKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.VendorKey);

            // Column - Vendor Key
            VendorText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.VendorText);

            // Column - Obligation
            Obligation = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.Obligation);

            // Column - Goods Receipt
            GoodsReceipt = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.GoodsReceipt);

            // Column - Invoiced
            Invoiced = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.Invoiced);

            // Column - Disbursed
            Disbursed = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.Disbursed);

            // Column - Created on - Key
            CreatedOnKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.CreatedOnKey);

            // Column - Date of Update - Key
            DateOfUpdateKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.DateOfUpdateKey);

            // Column - Posting date - Key
            PostingDateKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.PostingDateKey);

            // Column - Posting Date (Per SPL) - Key
            PostingDatePerSplKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.PostingDatePerSplKey);

            // Column - Document Date of BL - Key
            DocumentDateOfBlKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImports.DocumentDateOfBlKey);
        }
        

        /// <summary>
        /// Are all relevant columns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        { 
            var columnsToCheck = FbmsBudgetStageImports.GetBudgetColumnLetterToColumnNameDictionary().Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[col].ToString()));
            return allColumnsBlank;
        }


        
    }
}
