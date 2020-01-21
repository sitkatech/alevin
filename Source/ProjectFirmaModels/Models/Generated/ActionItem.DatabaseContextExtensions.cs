//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionItem]
using System.Collections.Generic;
using System.Linq;
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

    }
}