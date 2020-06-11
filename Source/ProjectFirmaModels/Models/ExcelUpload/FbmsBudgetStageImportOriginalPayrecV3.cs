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
    public class FbmsBudgetStageImportOriginalPayrecV3
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

        public readonly DateTime? CreatedOnKey;
        public readonly DateTime? DateOfUpdateKey;
        public readonly DateTime? PostingDateKey;
        public readonly DateTime? PostingDatePerSplKey;
        public readonly DateTime? DocumentDateOfBlKey;

        public FbmsBudgetStageImportOriginalPayrecV3(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;
            var columnNameToLetterDict = FbmsBudgetStageImportOriginalPayrecV3s.GetBudgetColumnNameToColumnLetterDictionary();
 
            // Column - Business Area Key
            BusinessAreaKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.BusinessAreaKey);

            // Column - FA Budget Activity Key
            FaBudgetActivityKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.FaBudgetActivityKey);

            // Column - Functional Area Text
            FunctionalAreaText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.FunctionalAreaText);

            // Column - Obligation Number Key
            ObligationNumberKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.ObligationNumberKey);

            // Column - Obligation Item Key
            ObligationItemKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.ObligationItemKey);

            // Column - Fund Key
            FundKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.FundKey);

            // Column - Funded Program Key (Not Compunded)
            FundedProgramKeyNotCompounded = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.FundedProgramKey);

            // Column - WBS Element Key
            WbsElementKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.WbsElementKey);

            // Column - WBS Element Text
            WbsElementText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.WbsElementText);

            // Column - Budget Object Class Key
            BudgetObjectClassKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.BudgetObjectClassKey);

            // Column - Vendor Key
            VendorKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.VendorKey);

            // Column - Vendor Key
            VendorText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.VendorText);

            // Column - Obligation
            Obligation = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.Obligation);

            // Column - Goods Receipt
            GoodsReceipt = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.GoodsReceipt);

            // Column - Invoiced
            Invoiced = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.Invoiced);

            // Column - Disbursed
            Disbursed = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.Disbursed);

            // Column - Created on - Key
            CreatedOnKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.CreatedOnKey, ExcelColumnHelper.ExcelDateTimeCellType.StringWithDateTime);

            // Column - Date of Update - Key
            DateOfUpdateKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.DateOfUpdateKey, ExcelColumnHelper.ExcelDateTimeCellType.StringWithDateTime);

            // Column - Posting date - Key
            PostingDateKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.PostingDateKey, ExcelColumnHelper.ExcelDateTimeCellType.StringWithDateTime);

            // Column - Posting Date (Per SPL) - Key
            PostingDatePerSplKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.PostingDatePerSplKey, ExcelColumnHelper.ExcelDateTimeCellType.StringWithDateTime);

            // Column - Document Date of BL - Key
            DocumentDateOfBlKey = ExcelColumnHelper.GetDateTimeDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, FbmsBudgetStageImportOriginalPayrecV3s.DocumentDateOfBlKey, ExcelColumnHelper.ExcelDateTimeCellType.StringWithDateTime);
        }
        

        /// <summary>
        /// Are all relevant columns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        { 
            var columnsToCheck = FbmsBudgetStageImportOriginalPayrecV3s.GetBudgetColumnLetterToColumnNameDictionary().Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[col].ToString()));
            return allColumnsBlank;
        }


        
    }
}
