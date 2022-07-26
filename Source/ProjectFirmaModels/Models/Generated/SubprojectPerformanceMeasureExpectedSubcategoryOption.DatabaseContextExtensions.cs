//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]
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
        public static SubprojectPerformanceMeasureExpectedSubcategoryOption GetSubprojectPerformanceMeasureExpectedSubcategoryOption(this IQueryable<SubprojectPerformanceMeasureExpectedSubcategoryOption> subprojectPerformanceMeasureExpectedSubcategoryOptions, int subprojectPerformanceMeasureExpectedSubcategoryOptionID)
        {
            var subprojectPerformanceMeasureExpectedSubcategoryOption = subprojectPerformanceMeasureExpectedSubcategoryOptions.SingleOrDefault(x => x.SubprojectPerformanceMeasureExpectedSubcategoryOptionID == subprojectPerformanceMeasureExpectedSubcategoryOptionID);
            Check.RequireNotNullThrowNotFound(subprojectPerformanceMeasureExpectedSubcategoryOption, "SubprojectPerformanceMeasureExpectedSubcategoryOption", subprojectPerformanceMeasureExpectedSubcategoryOptionID);
            return subprojectPerformanceMeasureExpectedSubcategoryOption;
        }

    }
}