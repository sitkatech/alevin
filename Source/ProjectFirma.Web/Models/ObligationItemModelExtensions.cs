using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ObligationItemModelExtensions
    {
        public static List<WbsElementObligationItemInvoice> GetWbsElementObligationItemInvoicesSorted(this ICollection<ObligationItem> obligationItems)
        {
            return obligationItems.SelectMany(x => x.WbsElementObligationItemInvoices).OrderBy(wbsoib => wbsoib.PostingDateKey).ToList();
        }

        public static List<WbsElementObligationItemBudget> GetWbsElementObligationItemBudgetsSorted(this ICollection<ObligationItem> obligationItems)
        {
            return obligationItems.SelectMany(x => x.WbsElementObligationItemBudgets).OrderBy(wbsoib => wbsoib.PostingDateKey).ToList();
        }
    }
}