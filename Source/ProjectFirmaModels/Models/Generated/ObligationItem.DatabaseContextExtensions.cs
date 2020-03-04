//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ObligationItem]
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
        public static ObligationItem GetObligationItem(this IQueryable<ObligationItem> obligationItems, int obligationItemID)
        {
            var obligationItem = obligationItems.SingleOrDefault(x => x.ObligationItemID == obligationItemID);
            Check.RequireNotNullThrowNotFound(obligationItem, "ObligationItem", obligationItemID);
            return obligationItem;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteObligationItem(this IQueryable<ObligationItem> obligationItems, List<int> obligationItemIDList)
        {
            if(obligationItemIDList.Any())
            {
                obligationItems.Where(x => obligationItemIDList.Contains(x.ObligationItemID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteObligationItem(this IQueryable<ObligationItem> obligationItems, ICollection<ObligationItem> obligationItemsToDelete)
        {
            if(obligationItemsToDelete.Any())
            {
                var obligationItemIDList = obligationItemsToDelete.Select(x => x.ObligationItemID).ToList();
                obligationItems.Where(x => obligationItemIDList.Contains(x.ObligationItemID)).Delete();
            }
        }

        public static void DeleteObligationItem(this IQueryable<ObligationItem> obligationItems, int obligationItemID)
        {
            DeleteObligationItem(obligationItems, new List<int> { obligationItemID });
        }

        public static void DeleteObligationItem(this IQueryable<ObligationItem> obligationItems, ObligationItem obligationItemToDelete)
        {
            DeleteObligationItem(obligationItems, new List<ObligationItem> { obligationItemToDelete });
        }
    }
}