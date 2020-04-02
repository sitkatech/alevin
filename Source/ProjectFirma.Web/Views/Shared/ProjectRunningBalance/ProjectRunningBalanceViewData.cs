/*-----------------------------------------------------------------------
<copyright file="ProjectRunningBalanceViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalance
{
    public class ProjectRunningBalanceViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceRecord> ProjectRunningBalanceRecords { get; set; }


        public ProjectRunningBalanceViewData(List<ProjectRunningBalanceRecord> projectRunningBalanceRecords)
        {
            ProjectRunningBalanceRecords = projectRunningBalanceRecords.OrderBy(x => x.Date).ToList();
        }
    }

    public class ProjectRunningBalanceRecord
    {
        /// <summary>
        /// Posting Date from Obligation Item Budget/Invoice
        /// or Date from TotalProjectedBudget
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Dummy data - eventually coming from user entered data in UI
        /// </summary>
        public double TotalProjectedBudget { get; set; }
        public double ObligationItemBudgetObligation { get; set; }
        public double ObligationItemInvoiceDebit { get; set; }
        public double ProjectionMinusObligation => TotalProjectedBudget - ObligationItemBudgetObligation;
        public double ObligationMinusDebit => ObligationItemBudgetObligation - ObligationItemInvoiceDebit;

        public ProjectRunningBalanceRecord()
        {
            TotalProjectedBudget = 1000000;
        }

        public ProjectRunningBalanceRecord(WbsElementObligationItemBudget obligationItemBudget) : this()
        {
            Date = obligationItemBudget.PostingDateKey ?? DateTime.MinValue;
            ObligationItemBudgetObligation = obligationItemBudget.Obligation ?? 0;
            ObligationItemInvoiceDebit = 0;
        }

        public ProjectRunningBalanceRecord(WbsElementObligationItemInvoice obligationItemInvoice) : this()
        {
            Date = obligationItemInvoice.PostingDateKey ?? DateTime.MinValue;
            ObligationItemBudgetObligation = 0;
            ObligationItemInvoiceDebit = obligationItemInvoice.DebitAmount ?? 0;
        }

    }
}
