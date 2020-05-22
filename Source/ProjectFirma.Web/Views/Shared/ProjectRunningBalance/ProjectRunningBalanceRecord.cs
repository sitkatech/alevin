using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalance
{
    public class ProjectRunningBalanceRecord
    {
        /// <summary>
        /// Posting Date from Obligation Item Budget/Invoice
        /// or Date from ProjectedBudget
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Dummy data - eventually coming from user entered data in UI
        /// </summary>
        public double ProjectedBudget { get; set; }
        public double ObligationItemBudgetObligation { get; set; }
        public double ObligationItemInvoiceDebit { get; set; }

        /// <summary>
        /// Constructor for building a Project Running Balance Record for a budget projection
        /// </summary>
        /// <param name="projectedBudget"></param>
        /// <param name="dateOfProjectedBudget"></param>
        public ProjectRunningBalanceRecord(double projectedBudget, DateTime dateOfProjectedBudget)
        {
            ProjectedBudget = projectedBudget;
            Date = dateOfProjectedBudget;
            ObligationItemBudgetObligation = 0;
            ObligationItemInvoiceDebit = 0;
        }

        public ProjectRunningBalanceRecord(WbsElementObligationItemBudget obligationItemBudget)
        {
            ProjectedBudget = 0;
            Date = obligationItemBudget.PostingDateKey ?? DateTime.MinValue;
            ObligationItemBudgetObligation = obligationItemBudget.Obligation ?? 0;
            ObligationItemInvoiceDebit = 0;
        }

        public ProjectRunningBalanceRecord(WbsElementObligationItemInvoice obligationItemInvoice)
        {
            ProjectedBudget = 0;
            Date = obligationItemInvoice.PostingDateKey ?? DateTime.MinValue;
            ObligationItemBudgetObligation = 0;
            ObligationItemInvoiceDebit = obligationItemInvoice.DebitAmount ?? 0;
        }

    }
}