//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionItem]
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
        public static ActionItem GetActionItem(this IQueryable<ActionItem> actionItems, int actionItemID)
        {
            var actionItem = actionItems.SingleOrDefault(x => x.ActionItemID == actionItemID);
            Check.RequireNotNullThrowNotFound(actionItem, "ActionItem", actionItemID);
            return actionItem;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteActionItem(this IQueryable<ActionItem> actionItems, List<int> actionItemIDList)
        {
            if(actionItemIDList.Any())
            {
                actionItems.Where(x => actionItemIDList.Contains(x.ActionItemID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteActionItem(this IQueryable<ActionItem> actionItems, ICollection<ActionItem> actionItemsToDelete)
        {
            if(actionItemsToDelete.Any())
            {
                var actionItemIDList = actionItemsToDelete.Select(x => x.ActionItemID).ToList();
                actionItems.Where(x => actionItemIDList.Contains(x.ActionItemID)).Delete();
            }
        }

        public static void DeleteActionItem(this IQueryable<ActionItem> actionItems, int actionItemID)
        {
            DeleteActionItem(actionItems, new List<int> { actionItemID });
        }

        public static void DeleteActionItem(this IQueryable<ActionItem> actionItems, ActionItem actionItemToDelete)
        {
            DeleteActionItem(actionItems, new List<ActionItem> { actionItemToDelete });
        }
    }
}