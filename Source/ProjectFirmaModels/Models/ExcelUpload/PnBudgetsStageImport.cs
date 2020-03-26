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

    public class PnBudgetsStageImport
    {
        public readonly string FundedProgram;
        public readonly string FundType;
        public readonly string Fund;
        public readonly string FundsCenter;
        public readonly string FiscalYearPeriod;
        public readonly string CommitmentItem;
        public readonly string FiDocNumber;
        public readonly double? Recoveries;
        public readonly double? CommittedButNotObligated;
        public readonly double? TotalObligations;
        public readonly double? TotalExpenditures;
        public readonly double? UndeliveredOrders;

        public PnBudgetsStageImport(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;
            var columnNameToLetterDict = PnBudgetsStageImports.PnBudgets_GetBudgetColumnNameToColumnLetterDictionary();

            FundedProgram = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.FundedProgram);
            FundType = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.FundType);
            Fund = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.Fund);
            FundsCenter = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.FundsCenter);
            FiscalYearPeriod = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.FiscalYearPeriod);
            CommitmentItem = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.CommitmentItem);
            FiDocNumber = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.FiDocNumber);
            Recoveries = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.Recoveries);
            CommittedButNotObligated = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.CommittedButNotObligated);
            TotalObligations = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.TotalObligations);
            TotalExpenditures = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.TotalExpenditures);
            UndeliveredOrders = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, PnBudgetsStageImports.UndeliveredOrders);
        }

        /// <summary>
        /// Are all relevant columns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        { 
            var columnsToCheck = PnBudgetsStageImports.PnBudgets_GetBudgetColumnLetterToColumnNameDictionary().Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[col].ToString()));
            return allColumnsBlank;
        }

    }
}
