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
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceAllContract
{
    public class ProjectRunningBalanceAllContractViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceAllContractRecord> ProjectRunningBalanceAllContractRecords { get; set; }


        public ProjectRunningBalanceAllContractViewData(List<ProjectRunningBalanceAllContractRecord> projectRunningBalanceAllContractRecords)
        {
            ProjectRunningBalanceAllContractRecords = projectRunningBalanceAllContractRecords.OrderBy(x => x.Date).ToList();
        }
    }

    public class ProjectRunningBalanceAllContractRecord
    {
        public FiscalQuarter FiscalQuarter { get; set; }
        public int FiscalYear { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Dummy data - eventually coming from user entered data in UI
        /// </summary>
        public double Commitments { get; set; }
        public double Obligations { get; set; }
        public double Expenditures { get; set; }
        public double UnexpendedBalance { get; set; }

        public ProjectFirmaModels.Models.CostAuthority CostAuthority { get; set; }
        public ProjectFirmaModels.Models.BudgetObjectCode BudgetObjectCode { get; set; }

        /*
        /// <summary>
        /// Constructor for building a Project Running Balance Record for a budget projection
        /// </summary>
        /// <param name="projectedBudget"></param>
        /// <param name="dateOfProjectedBudget"></param>
        public ProjectRunningBalanceAllContractRecord(double projectedBudget, DateTime dateOfProjectedBudget)
        {
            ProjectedBudget = projectedBudget;
            Date = dateOfProjectedBudget;
            ObligationItemBudgetObligation = 0;
            ObligationItemInvoiceDebit = 0;
        }
        */

        public ProjectRunningBalanceAllContractRecord(WbsElementPnBudget wbsElementPnBudget)
        {
            this.FiscalQuarter = wbsElementPnBudget.FiscalQuarter;
            this.FiscalYear = wbsElementPnBudget.FiscalYear;
            // WARNING - This date will be wrong until we resolve FQ/FY/CY issues! Need to unify FiscalQuarter ideas from PF & Reclamation.
            this.Date = this.FiscalQuarter.GetCompleteStartDateUsingCalendarYear(wbsElementPnBudget.FiscalYear);

            this.Commitments = wbsElementPnBudget.CommittedButNotObligated ?? 0;
            this.Obligations = wbsElementPnBudget.TotalObligations ?? 0;
            this.Expenditures = wbsElementPnBudget.TotalExpenditures ?? 0;
            // I believe this is the mapping; Dorothy seems to be telling me it is. -- SLG 5/21/2020
            this.UnexpendedBalance = wbsElementPnBudget.UndeliveredOrders ?? 0;

            this.CostAuthority = wbsElementPnBudget.CostAuthority;
            this.BudgetObjectCode = wbsElementPnBudget.BudgetObjectCode;
        }

        public static List<ProjectRunningBalanceAllContractRecord> GetProjectRunningBalanceAllContractRecordsForProject_RouteOne(ProjectFirmaModels.Models.Project project)
        {
            var relevantCostAuthorities = project.CostAuthorityProjects.Select(cap => cap.CostAuthority).ToList();
            var relevantPns = relevantCostAuthorities.SelectMany(ca => ca.WbsElementPnBudgets).ToList();
            return relevantPns.Select(pn => new ProjectRunningBalanceAllContractRecord(pn)).ToList();
        }

        public static List<ProjectRunningBalanceAllContractRecord> GetProjectRunningBalanceAllContractRecordsForProject_RouteTwo(ProjectFirmaModels.Models.Project project)
        {
            var relevantFundingSources = project.ProjectFundingSourceBudgets.Select(pfsb => pfsb.FundingSource).ToList();
            var relevantPns = relevantFundingSources.SelectMany(ca => ca.WbsElementPnBudgets).ToList();
            return relevantPns.Select(pn => new ProjectRunningBalanceAllContractRecord(pn)).ToList();
        }

    }
}
