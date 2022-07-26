//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]
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
        public static SubprojectPerformanceMeasureActualSubcategoryOption GetSubprojectPerformanceMeasureActualSubcategoryOption(this IQueryable<SubprojectPerformanceMeasureActualSubcategoryOption> subprojectPerformanceMeasureActualSubcategoryOptions, int subprojectPerformanceMeasureActualSubcategoryOptionID)
        {
            var subprojectPerformanceMeasureActualSubcategoryOption = subprojectPerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.SubprojectPerformanceMeasureActualSubcategoryOptionID == subprojectPerformanceMeasureActualSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(subprojectPerformanceMeasureActualSubcategoryOption, "SubprojectPerformanceMeasureActualSubcategoryOption", subprojectPerformanceMeasureActualSubcategoryOptionID);
            return subprojectPerformanceMeasureActualSubcategoryOption;
        }

    }
}