//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Subproject]
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
        public static Subproject GetSubproject(this IQueryable<Subproject> subprojects, int subprojectID)
        {
            var subproject = subprojects.SingleOrDefault(x => x.SubprojectID == subprojectID);
            Check.RequireNotNullThrowNotFound(subproject, "Subproject", subprojectID);
            return subproject;
        }

    }
}