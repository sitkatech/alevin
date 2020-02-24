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
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Views.ReportCenter;

namespace ProjectFirma.Web.Views.ExcelUpload
{
    /// <summary>
    /// An exception generated when a cell value is bad
    /// </summary>
    public class BudgetTransferBadCellException : SitkaDisplayErrorException
    {
        public string ColumnName;
        public int RowIndex;
        public string CellValue;

        public BudgetTransferBadCellException(string columnName, int rowIndex, string cellValue, string errorMessage, Exception innerException) : base(string.Format("{0} - Cell {1}{2} - Cell Value \"{3}\"", errorMessage, columnName, rowIndex + 1, cellValue), innerException)
        {
            ColumnName = columnName;
            CellValue = cellValue;
            RowIndex = rowIndex;
        }
    }

   
    public class BudgetTransferBulk
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
        public readonly decimal Obligation;
        public readonly decimal GoodsReceipt;
        public readonly decimal Invoiced;
        public readonly decimal Disbersed;
        public readonly decimal UnexpendedBalance;

        //public BudgetTransferBulk(AccountSpecifier sourceFund,
        //                          AccountSpecifier destinationFund,
        //                          AccountSpecifier sourceProject,
        //                          AccountSpecifier destinationProject,
        //                          decimal amount,
        //                          string shortDescription,
        //                          string rationale,
        //                          string bpaComments)
        //{
        //    SourceFund = sourceFund;
        //    DestinationFund = destinationFund;
        //    SourceProject = sourceProject;
        //    DestinationProject = destinationProject;
        //    Amount = amount;
        //    ShortDescription = shortDescription;
        //    Rationale = rationale;
        //    BpaComments = bpaComments;
        //    BpaCommentsSet = true;
        //}

        public BudgetTransferBulk(KeyValuePair<int, DataRow> keyValuePair)
        {
            var rowIndex = keyValuePair.Key;
            var dr = keyValuePair.Value;

            // Column A - Business Area Key
            string businessAreaKey;
            try
            {
                businessAreaKey = string.IsNullOrWhiteSpace(dr["A"].ToString()) ? null : dr["A"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("A", rowIndex, dr["A"].ToString(), "Problem parsing Source Business area - Key", e);
            }

            BusinessAreaKey = businessAreaKey;

            // Column B - FA Budget Activity Key
            string faBudgetActivityKey;
            try
            {
                faBudgetActivityKey = string.IsNullOrWhiteSpace(dr["B"].ToString()) ? null : dr["B"].ToString();
            }
            
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("B", rowIndex, dr["B"].ToString(), "Problem parsing FA Budget Activity Key", e);
            }

            FaBudgetActivityKey = faBudgetActivityKey;

            // Column C - Functional Area Text
            string functionalAreaText;
            try
            {
                functionalAreaText = string.IsNullOrWhiteSpace(dr["C"].ToString()) ? null : dr["C"].ToString();
            }

            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("C", rowIndex, dr["C"].ToString(), "Problem parsing Functional Area Text", e);
            }

            FunctionalAreaText = functionalAreaText;

            // Column D - Obligation Number Key
            string obligationNumberKey;
            try
            {
                obligationNumberKey = string.IsNullOrWhiteSpace(dr["D"].ToString()) ? null : dr["D"].ToString();
            }

            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("D", rowIndex, dr["D"].ToString(), "Problem parsing Obligation Number Key", e);
            }

            ObligationNumberKey = obligationNumberKey;

            // Column E - Obligation Item Key
            string obligationItemKey;
            try
            {
                obligationItemKey = string.IsNullOrWhiteSpace(dr["E"].ToString()) ? null : dr["E"].ToString();
            }

            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("E", rowIndex, dr["E"].ToString(), "Problem parsing Obligation Item Key", e);
            }

            ObligationItemKey = obligationItemKey;

            // Column F - Fund Key
            string fundKey;
            try
            {
                fundKey = string.IsNullOrWhiteSpace(dr["F"].ToString()) ? null : dr["F"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("F", rowIndex, dr["F"].ToString(), "Problem parsing Fund Key", e);
            }

            FundKey = fundKey;

            // Column G - Funded Program Key (Not Compunded)
            string fundedProgramKey;
            try
            {
                fundedProgramKey = string.IsNullOrWhiteSpace(dr["G"].ToString()) ? null : dr["G"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("G", rowIndex, dr["G"].ToString(), "Problem parsing Funded Program Key", e);
            }

            // Column H - WBS Element Key
            string wbsElementKey;
            try
            {
                wbsElementKey = string.IsNullOrWhiteSpace(dr["H"].ToString()) ? null : dr["H"].ToString();
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("H", rowIndex, dr["H"].ToString(), "Problem parsing WBS Element Key", e);
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
                throw new BudgetTransferBadCellException("I", rowIndex, dr["I"].ToString(), "Problem parsing WBS Element Text", e);
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
                throw new BudgetTransferBadCellException("J", rowIndex, dr["J"].ToString(), "Problem parsing Budget Object Class Key", e);
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
                throw new BudgetTransferBadCellException("K", rowIndex, dr["K"].ToString(), "Problem parsing Vendor Key", e);
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
                throw new BudgetTransferBadCellException("L", rowIndex, dr["L"].ToString(), "Problem parsing Vendor Text", e);
            }

            VendorText = vendorText;

            // Column M - Obligation
            try
            {
               
                Obligation = decimal.Parse(dr["M"].ToString());
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("M", rowIndex, dr["M"].ToString(), "Problem parsing Obligation", e);
            }

            // Column N - Goods Receipt
            try
            {

                GoodsReceipt = decimal.Parse(dr["N"].ToString());
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("N", rowIndex, dr["N"].ToString(), "Problem parsing Goods Receipt", e);
            }

            // Column O - Invoiced
            try
            {
                Invoiced = decimal.Parse(dr["O"].ToString());
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("O", rowIndex, dr["O"].ToString(), "Problem parsing Invoiced", e);
            }

            // Column P - Disbursed
            try
            {
                Disbersed = decimal.Parse(dr["P"].ToString());
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("P", rowIndex, dr["P"].ToString(), "Problem parsing Disbursed", e);
            }

            // Column Q - Unexpended Balance
            try
            {
                UnexpendedBalance = decimal.Parse(dr["Q"].ToString());
            }
            catch (Exception e)
            {
                throw new BudgetTransferBadCellException("Q", rowIndex, dr["Q"].ToString(), "Problem parsing Unexpended Balance", e);
            }
            
        }



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
