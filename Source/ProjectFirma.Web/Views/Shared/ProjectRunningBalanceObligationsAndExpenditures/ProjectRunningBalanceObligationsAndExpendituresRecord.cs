/*-----------------------------------------------------------------------
<copyright file="ProjectRunningBalanceViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{

    public class ProjectRunningBalanceObligationsAndExpendituresRecord
    {
        public FiscalQuarter FiscalQuarter { get; set; }
        public int FiscalYear { get; set; }
        public int FiscalMonthPeriod { get; set; }

        public int CalendarYear { get; set; }
        public int CalendarMonthNumber { get; set; }
        //public DateTime Date { get; set; }

        /// <summary>
        /// Dummy data - eventually coming from user entered data in UI
        /// </summary>
        public double Commitments { get; set; }
        public double Obligations { get; set; }
        public double Expenditures { get; set; }
        public double UndeliveredOrders { get; set; }

        public ProjectFirmaModels.Models.CostAuthority CostAuthority { get; set; }
        public ProjectFirmaModels.Models.BudgetObjectCode BudgetObjectCode { get; set; }

        public ProjectFirmaModels.Models.FundingSource FundingSource { get; set; }

        public ProjectRunningBalanceObligationsAndExpendituresRecord(WbsElementPnBudget wbsElementPnBudget)
        {
            this.FiscalQuarter = wbsElementPnBudget.FiscalQuarter;
            this.FiscalYear = wbsElementPnBudget.FiscalYear;
            this.FiscalMonthPeriod = wbsElementPnBudget.FiscalMonthPeriod;

            this.Commitments = wbsElementPnBudget.CommittedButNotObligated ?? 0;
            this.Obligations = wbsElementPnBudget.TotalObligations ?? 0;
            this.Expenditures = wbsElementPnBudget.TotalExpenditures ?? 0;
            // Dorothy originally seemed to be telling me this was actually "Unexpended Balances", but that does not appear to be true.
            // -- SLG 5/29/2020
            this.UndeliveredOrders = wbsElementPnBudget.UndeliveredOrders ?? 0;

            this.CostAuthority = wbsElementPnBudget.CostAuthority;
            this.BudgetObjectCode = wbsElementPnBudget.BudgetObjectCode;
            this.FundingSource = wbsElementPnBudget.FundingSource;
            this.CalendarYear = wbsElementPnBudget.CalendarYear;
            this.CalendarMonthNumber = wbsElementPnBudget.CalendarMonthNumber;

            //this.Date = DateTime.Parse($"{wbsElementPnBudget.CalendarYear}{wbsElementPnBudget.CalendarMonthNumber:00}01");
        }

        public static List<ProjectRunningBalanceObligationsAndExpendituresRecord> GetProjectRunningBalanceObligationsAndExpendituresRecordsForProject(ProjectFirmaModels.Models.Project project)
        {
            var relevantCostAuthorities = project.CostAuthorityProjects.Select(cap => cap.CostAuthority).ToList();
            var relevantPns = relevantCostAuthorities.SelectMany(ca => ca.WbsElementPnBudgets).ToList();
            return relevantPns.Select(pn => new ProjectRunningBalanceObligationsAndExpendituresRecord(pn)).ToList();
        }

    }
}
