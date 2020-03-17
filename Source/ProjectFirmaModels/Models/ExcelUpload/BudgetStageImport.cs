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
    public class BudgetStageImport
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
        public readonly double? Disbersed;
        public readonly double? UnexpendedBalance;

        public BudgetStageImport(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;

            //var columnNames =  BudgetStageImports.GetBudgetColumnLetterToColumnNameDictionary();
            var columnNameToLetterDict = BudgetStageImports.GetBudgetColumnNameToColumnLetterDictionary();

 
            // Column A - Business Area Key
            BusinessAreaKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.BusinessAreaKey);

            // Column B - FA Budget Activity Key
            FaBudgetActivityKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.FaBudgetActivityKey);

            // Column C - Functional Area Text
            FunctionalAreaText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.FunctionalAreaText);

            // Column D - Obligation Number Key
            ObligationNumberKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.ObligationNumberKey);

            // Column E - Obligation Item Key
            ObligationItemKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.ObligationItemKey);

            // Column F - Fund Key
            FundKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.FundKey);

            // Column G - Funded Program Key (Not Compunded)
            FundedProgramKeyNotCompounded = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.FundedProgramKey);

            // Column H - WBS Element Key
            WbsElementKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.WbsElementKey);

            // Column I - WBS Element Text
            WbsElementText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.WbsElementText);

            // Column J - Budget Object Class Key
            BudgetObjectClassKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.BudgetObjectClassKey);

            // Column K - Vendor Key
            VendorKey = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.VendorKey);

            // Column L - Vendor Key
            VendorText = ExcelColumnHelper.GetStringDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.VendorText);

            // Column M - Obligation
            Obligation = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.Obligation);

            // Column N - Goods Receipt
            GoodsReceipt = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.GoodsReceipt);
            //try
            //{
            //    var isNullOrEmpty = string.IsNullOrWhiteSpace(dr["N"].ToString());
            //    if (isNullOrEmpty)
            //    {
            //        GoodsReceipt = null;
            //    }
            //    else
            //    {
            //        GoodsReceipt = double.Parse(dr["N"].ToString());
            //    }


            //}
            //catch (Exception e)
            //{
            //    throw new ExcelImportBadCellException("N", rowIndex, dr["N"].ToString(), "Problem parsing Goods Receipt", e);
            //}

            // Column O - Invoiced
            Invoiced = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.Invoiced);

            // Column P - Disbursed
            Disbersed = ExcelColumnHelper.GetDoubleDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.Disbursed);

            // Column Q - Unexpended Balance
            //try
            //{
            //    var isNullOrWhitespace = string.IsNullOrWhiteSpace(dr["Q"].ToString());
            //    if (isNullOrWhitespace)
            //    {
            //        UnexpendedBalance = null;
            //    }
            //    else
            //    {
            //        UnexpendedBalance = double.Parse(dr["Q"].ToString());
            //    }
                
            //}
            //catch (Exception e)
            //{
            //    throw new ExcelImportBadCellException("Q", rowIndex, dr["Q"].ToString(), "Problem parsing Unexpended Balance", e);
            //}
            
        }

        //private static string GetStringDataValueForColumnName(DataRow dr, int rowIndex, string columnNameKey,)
        //{
        //    string columnKeyLetterName = columnNameToLetterDict[BudgetStageImports.BusinessAreaKey]

        //    string dataValue;
        //    try
        //    {


        //        dataValue = string.IsNullOrWhiteSpace(dr[columnKeyLetterName].ToString())
        //            ? null
        //            : dr[columnKeyLetterName].ToString();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ExcelImportBadCellException(columnKeyLetterName, rowIndex,
        //            dr[columnKeyLetterName].ToString(),
        //            $"Problem parsing Source {columnNameKey}", e);
        //    }

        //    return dataValue;
        //}


        /// <summary>
        /// Are all relevant colummns in this row blank?
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static bool RowIsBlank(DataRow dr)
        { 
            var columnsToCheck = BudgetStageImports.GetBudgetColumnLetterToColumnNameDictionary().Keys.ToList();
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[col].ToString()));
            return allColumnsBlank;
        }


        
    }
}
