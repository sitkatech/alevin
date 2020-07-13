using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ObligationItemModelExtensions
    {
        public static readonly UrlTemplate<int> ObligationItemDetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<ObligationItemController>.BuildUrlFromExpression(t => t.ObligationItemDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this ObligationItem obligationItem)
        {
            return ObligationItemDetailUrlTemplate.ParameterReplace(obligationItem.ObligationItemID);
        }

        public static List<WbsElementObligationItemInvoice> GetWbsElementObligationItemInvoicesSorted(this ICollection<ObligationItem> obligationItems)
        {
            return obligationItems.SelectMany(x => x.WbsElementObligationItemInvoices).OrderBy(wbsoib => wbsoib.PostingDateKey).ToList();
        }

        public static List<WbsElementObligationItemBudget> GetWbsElementObligationItemBudgetsSorted(this ICollection<ObligationItem> obligationItems)
        {
            return obligationItems.SelectMany(x => x.WbsElementObligationItemBudgets).OrderBy(wbsoib => wbsoib.PostingDatePerSplKey).ToList();
        }

        public static List<WbsElementObligationItemBudget> GetWbsElementObligationItemBudgetsSorted(this ObligationItem obligationItem)
        {
            return GetWbsElementObligationItemBudgetsSorted(new List<ObligationItem>{obligationItem});
        }
    }
}