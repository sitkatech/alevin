//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubbasinLiason]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SubbasinLiason GetSubbasinLiason(this IQueryable<SubbasinLiason> subbasinLiasons, int subbasinLiasonID)
        {
            var subbasinLiason = subbasinLiasons.SingleOrDefault(x => x.SubbasinLiasonID == subbasinLiasonID);
            Check.RequireNotNullThrowNotFound(subbasinLiason, "SubbasinLiason", subbasinLiasonID);
            return subbasinLiason;
        }

    }
}