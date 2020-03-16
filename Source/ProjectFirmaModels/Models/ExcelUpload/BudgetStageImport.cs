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
using LtInfo.Common;
using ProjectFirmaModels.Models.ExcelUpload;


namespace ProjectFirmaModels.Models
{
    /// <summary>
    /// An exception generated when a cell value is bad
    /// </summary>
    public class BudgetStageImportBadCellException : SitkaDisplayErrorException
    {
        public string ColumnName;
        public int RowIndex;
        public string CellValue;

        public BudgetStageImportBadCellException(string columnName, int rowIndex, string cellValue, string errorMessage, Exception innerException) : base(string.Format("{0} - Cell {1}{2} - Cell Value \"{3}\"", errorMessage, columnName, rowIndex + 1, cellValue), innerException)
        {
            ColumnName = columnName;
            CellValue = cellValue;
            RowIndex = rowIndex;
        }
    }

   
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

            /*
             *
             *
             *
             */

            // Are you there tom?


            //var columnNames =  BudgetStageImports.GetBudgetColumnLetterToColumnNameDictionary();
            var columnNameToLetterDict = BudgetStageImports.GetBudgetColumnNameToColumnLetterDictionary();

            // Column A - Business Area Key
            //string businessAreaKey;
            //var businessAreaKeyColumnLetterName = columnNameToLetterDict[BudgetStageImports.BusinessAreaKey];
            //try
            //{
            //    businessAreaKey = string.IsNullOrWhiteSpace(dr[businessAreaKeyColumnLetterName].ToString()) ? null : dr[businessAreaKeyColumnLetterName].ToString();
            //}
            //catch (Exception e)
            //{
            //    throw new BudgetStageImportBadCellException(businessAreaKeyColumnLetterName, rowIndex, dr[businessAreaKeyColumnLetterName].ToString(), $"Problem parsing Source {BudgetStageImports.BusinessAreaKey}", e);
            //}

            //BusinessAreaKey = businessAreaKey;








            // Column A - Business Area Key
            BusinessAreaKey = GetDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.BusinessAreaKey);

            // Column B - FA Budget Activity Key
            FaBudgetActivityKey = GetDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.FaBudgetActivityKey);

            // Column C - Functional Area Text
            FunctionalAreaText = GetDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.FunctionalAreaText);

            // Column D - Obligation Number Key
            ObligationNumberKey = GetDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.ObligationNumberKey);

            // Column E - Obligation Item Key
            ObligationItemKey = GetDataValueForColumnName(dr, rowIndex, columnNameToLetterDict, BudgetStageImports.ObligationItemKey);

            // Column F - Fund Key
            FundKey = GetDataValueForColumnName(dr, rowIndex, BudgetStageImports.BusinessAreaKey, columnNameToLetterDict[BudgetStageImports.FundKey]);

            // Column G - Funded Program Key (Not Compunded)
            string fundedProgramKey;
            try
            {
                fundedProgramKey = string.IsNullOrWhiteSpace(dr["G"].ToString()) ? null : dr["G"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("G", rowIndex, dr["G"].ToString(), "Problem parsing Funded Program Key", e);
            }

            FundedProgramKeyNotCompounded = fundedProgramKey;

            // Column H - WBS Element Key
            string wbsElementKey;
            try
            {
                wbsElementKey = string.IsNullOrWhiteSpace(dr["H"].ToString()) ? null : dr["H"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("H", rowIndex, dr["H"].ToString(), "Problem parsing WBS Element Key", e);
            }

            WbsElementKey = wbsElementKey;

            // Column I - WBS Element Text
            string wbsElementText;
            try
            {
                wbsElementText = string.IsNullOrWhiteSpace(dr["I"].ToString()) ? null : dr["I"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("I", rowIndex, dr["I"].ToString(), "Problem parsing WBS Element Text", e);
            }

            WbsElementText = wbsElementText;

            // Column J - Budget Object Class Key
            string budgetObjectClassKey;
            try
            {
                budgetObjectClassKey = string.IsNullOrWhiteSpace(dr["J"].ToString()) ? null : dr["J"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("J", rowIndex, dr["J"].ToString(), "Problem parsing Budget Object Class Key", e);
            }

            BudgetObjectClassKey = budgetObjectClassKey;

            // Column K - Vendor Key
            string vendorKey;
            try
            {
                vendorKey = string.IsNullOrWhiteSpace(dr["K"].ToString()) ? null : dr["K"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("K", rowIndex, dr["K"].ToString(), "Problem parsing Vendor Key", e);
            }

            VendorKey = vendorKey;

            // Column L - Vendor Key
            string vendorText;
            try
            {
                vendorText = string.IsNullOrWhiteSpace(dr["L"].ToString()) ? null : dr["L"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("L", rowIndex, dr["L"].ToString(), "Problem parsing Vendor Text", e);
            }

            VendorText = vendorText;

            // Column M - Obligation
            try
            {
                var isNullOrWhitespace = string.IsNullOrWhiteSpace(dr["M"].ToString());
                if (isNullOrWhitespace)
                {
                    Obligation = null;
                }
                else
                {
                    Obligation = double.Parse(dr["M"].ToString());
                }
                
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("M", rowIndex, dr["M"].ToString(), "Problem parsing Obligation", e);
            }

            // Column N - Goods Receipt
            try
            {
                var isNullOrEmpty = string.IsNullOrWhiteSpace(dr["N"].ToString());
                if (isNullOrEmpty)
                {
                    GoodsReceipt = null;
                }
                else
                {
                    GoodsReceipt = double.Parse(dr["N"].ToString());
                }

                
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("N", rowIndex, dr["N"].ToString(), "Problem parsing Goods Receipt", e);
            }

            // Column O - Invoiced
            try
            {
                var isNullOrWhitespace = string.IsNullOrWhiteSpace(dr["O"].ToString());
                if (isNullOrWhitespace)
                {
                    Invoiced = null;
                }
                else
                {
                    Invoiced = double.Parse(dr["O"].ToString());
                }
                
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("O", rowIndex, dr["O"].ToString(), "Problem parsing Invoiced", e);
            }

            // Column P - Disbursed
            try
            {
                var isNullOrWhitespace = string.IsNullOrWhiteSpace(dr["P"].ToString());
                if (isNullOrWhitespace)
                {
                    Disbersed = null;
                }
                else
                {
                    Disbersed = double.Parse(dr["P"].ToString());
                }
                
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("P", rowIndex, dr["P"].ToString(), "Problem parsing Disbursed", e);
            }

            // Column Q - Unexpended Balance
            try
            {
                var isNullOrWhitespace = string.IsNullOrWhiteSpace(dr["Q"].ToString());
                if (isNullOrWhitespace)
                {
                    UnexpendedBalance = null;
                }
                else
                {
                    UnexpendedBalance = double.Parse(dr["Q"].ToString());
                }
                
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException("Q", rowIndex, dr["Q"].ToString(), "Problem parsing Unexpended Balance", e);
            }
            
        }

        private string GetDataValueForColumnName(DataRow dr, int rowIndex, Dictionary<string, string> columnNameToLetterDict, string humanReadableNameOfColumn)
        {
            string columnKeyLetterName = columnNameToLetterDict[humanReadableNameOfColumn];

            string dataValue;
            try
            {
                dataValue = string.IsNullOrWhiteSpace(dr[columnKeyLetterName].ToString())
                    ? null
                    : dr[columnKeyLetterName].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetStageImportBadCellException(columnKeyLetterName, rowIndex,
                    dr[columnKeyLetterName].ToString(),
                    $"Problem parsing Source {humanReadableNameOfColumn}", e);
            }

            return dataValue;
        }

        //private static string GetDataValueForColumnName(DataRow dr, int rowIndex, string columnNameKey,)
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
        //        throw new BudgetStageImportBadCellException(columnKeyLetterName, rowIndex,
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
            var columnsToCheck = new List<String> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L","M", "N", "O", "P", "Q" };
            var allColumnsBlank = columnsToCheck.All(col => String.IsNullOrWhiteSpace(dr[col].ToString()));
            return allColumnsBlank;
        }


        
    }
}
