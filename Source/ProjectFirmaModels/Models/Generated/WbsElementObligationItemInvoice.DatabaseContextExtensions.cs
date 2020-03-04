//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElementObligationItemInvoice]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static WbsElementObligationItemInvoice GetWbsElementObligationItemInvoice(this IQueryable<WbsElementObligationItemInvoice> wbsElementObligationItemInvoices, int wbsElementObligationItemInvoiceID)
        {
            var wbsElementObligationItemInvoice = wbsElementObligationItemInvoices.SingleOrDefault(x => x.WbsElementObligationItemInvoiceID == wbsElementObligationItemInvoiceID);
            Check.RequireNotNullThrowNotFound(wbsElementObligationItemInvoice, "WbsElementObligationItemInvoice", wbsElementObligationItemInvoiceID);
            return wbsElementObligationItemInvoice;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWbsElementObligationItemInvoice(this IQueryable<WbsElementObligationItemInvoice> wbsElementObligationItemInvoices, List<int> wbsElementObligationItemInvoiceIDList)
        {
            if(wbsElementObligationItemInvoiceIDList.Any())
            {
                wbsElementObligationItemInvoices.Where(x => wbsElementObligationItemInvoiceIDList.Contains(x.WbsElementObligationItemInvoiceID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWbsElementObligationItemInvoice(this IQueryable<WbsElementObligationItemInvoice> wbsElementObligationItemInvoices, ICollection<WbsElementObligationItemInvoice> wbsElementObligationItemInvoicesToDelete)
        {
            if(wbsElementObligationItemInvoicesToDelete.Any())
            {
                var wbsElementObligationItemInvoiceIDList = wbsElementObligationItemInvoicesToDelete.Select(x => x.WbsElementObligationItemInvoiceID).ToList();
                wbsElementObligationItemInvoices.Where(x => wbsElementObligationItemInvoiceIDList.Contains(x.WbsElementObligationItemInvoiceID)).Delete();
            }
        }

        public static void DeleteWbsElementObligationItemInvoice(this IQueryable<WbsElementObligationItemInvoice> wbsElementObligationItemInvoices, int wbsElementObligationItemInvoiceID)
        {
            DeleteWbsElementObligationItemInvoice(wbsElementObligationItemInvoices, new List<int> { wbsElementObligationItemInvoiceID });
        }

        public static void DeleteWbsElementObligationItemInvoice(this IQueryable<WbsElementObligationItemInvoice> wbsElementObligationItemInvoices, WbsElementObligationItemInvoice wbsElementObligationItemInvoiceToDelete)
        {
            DeleteWbsElementObligationItemInvoice(wbsElementObligationItemInvoices, new List<WbsElementObligationItemInvoice> { wbsElementObligationItemInvoiceToDelete });
        }
    }
}