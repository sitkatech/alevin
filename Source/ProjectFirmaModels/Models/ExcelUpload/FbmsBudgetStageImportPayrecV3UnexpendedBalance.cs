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
    public class FbmsBudgetStageImportPayrecV3UnexpendedBalance
    {
        public readonly string BusinessArea;
        public readonly string FABudgetActivity;
        public readonly string FunctionalArea;
        public readonly string ObligationNumber;
        public readonly string ObligationItem;
        public readonly string Fund;
        public readonly string FundedProgram;
        public readonly string WbsElement;
        public readonly string WbsElementDescription;
        public readonly string BudgetObjectClass;
        public readonly string Vendor;
        public readonly string VendorName;
        public readonly DateTime? PostingDatePerSpl;
        public readonly double? UnexpendedBalance;

        public FbmsBudgetStageImportPayrecV3UnexpendedBalance(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;
            var columnNameToLetterDict = FbmsBudgetStageImportPayrecV3UnexpendedBalances.GetBudgetColumnNameToColumnLetterDictionary();
 
            // Column - Business Area Key
            BusinessArea = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.BusinessAreaKey);

            // Column - FA Budget Activity Key
            FABudgetActivity = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.FaBudgetActivityKey);

            // Column - Functional Area Text
            FunctionalArea = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.FunctionalAreaText);

            // Column - Obligation Number Key
            ObligationNumber = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.ObligationNumberKey);

            // Column - Obligation Item Key
            ObligationItem = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.ObligationItemKey);

            // Column - Fund Key
            Fund = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.FundKey);

            // Column - Funded Program Key (Not Compounded)
            FundedProgram = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.FundedProgramKey);

            // Column - WBS Element Key
            WbsElement = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.WbsElementKey);

            // Column - WBS Element Text
            WbsElementDescription = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.WbsElementText);

            // Column - Budget Object Class Key
            BudgetObjectClass = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.BudgetObjectClassKey);

            // Column - Vendor Key
            Vendor = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.VendorKey);

            // Column - Vendor Key
            VendorName = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.VendorText);

            // Column - Posting Date (Per SPL) - Key
            PostingDatePerSpl = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.PostingDatePerSplKey, ExcelColumnHelper.ExcelDateTimeCellType.SerialDateTimeValue);

            // Column - Unexpended Balance
            UnexpendedBalance = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportPayrecV3UnexpendedBalances.UnexpendedBalanceValue);
        }
        

        /// <summary>
        /// Are all relevant columns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        { 
            var columnsToCheck = FbmsBudgetStageImportPayrecV3UnexpendedBalances.GetBudgetColumnLetterToColumnNameDictionary().Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[col].ToString()));
            return allColumnsBlank;
        }

    }
}
