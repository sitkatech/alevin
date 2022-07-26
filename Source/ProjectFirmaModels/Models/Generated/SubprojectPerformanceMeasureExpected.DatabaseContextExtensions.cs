//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureExpected]
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
        public static SubprojectPerformanceMeasureExpected GetSubprojectPerformanceMeasureExpected(this IQueryable<SubprojectPerformanceMeasureExpected> subprojectPerformanceMeasureExpecteds, int subprojectPerformanceMeasureExpectedID)
        {
            var subprojectPerformanceMeasureExpected = subprojectPerformanceMeasureExpecteds.SingleOrDefault(x => x.SubprojectPerformanceMeasureExpectedID == subprojectPerformanceMeasureExpectedID);
            Check.RequireNotNullThrowNotFound(subprojectPerformanceMeasureExpected, "SubprojectPerformanceMeasureExpected", subprojectPerformanceMeasureExpectedID);
            return subprojectPerformanceMeasureExpected;
        }

    }
}