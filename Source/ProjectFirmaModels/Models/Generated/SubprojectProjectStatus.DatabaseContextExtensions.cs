//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectProjectStatus]
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
        public static SubprojectProjectStatus GetSubprojectProjectStatus(this IQueryable<SubprojectProjectStatus> subprojectProjectStatuses, int subprojectProjectStatusID)
        {
            var subprojectProjectStatus = subprojectProjectStatuses.SingleOrDefault(x => x.SubprojectProjectStatusID == subprojectProjectStatusID);
            Check.RequireNotNullThrowNotFound(subprojectProjectStatus, "SubprojectProjectStatus", subprojectProjectStatusID);
            return subprojectProjectStatus;
        }

    }
}