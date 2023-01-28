//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectActionItem]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SubprojectActionItem GetSubprojectActionItem(this IQueryable<SubprojectActionItem> subprojectActionItems, int subprojectActionItemID)
        {
            var subprojectActionItem = subprojectActionItems.SingleOrDefault(x => x.SubprojectActionItemID == subprojectActionItemID);
            Check.RequireNotNullThrowNotFound(subprojectActionItem, "SubprojectActionItem", subprojectActionItemID);
            return subprojectActionItem;
        }

    }
}