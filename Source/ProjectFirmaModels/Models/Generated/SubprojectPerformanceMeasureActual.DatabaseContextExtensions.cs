//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureActual]
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
        public static SubprojectPerformanceMeasureActual GetSubprojectPerformanceMeasureActual(this IQueryable<SubprojectPerformanceMeasureActual> subprojectPerformanceMeasureActuals, int subprojectPerformanceMeasureActualID)
        {
            var subprojectPerformanceMeasureActual = subprojectPerformanceMeasureActuals.SingleOrDefault(x => x.SubprojectPerformanceMeasureActualID == subprojectPerformanceMeasureActualID);
            Check.RequireNotNullThrowNotFound(subprojectPerformanceMeasureActual, "SubprojectPerformanceMeasureActual", subprojectPerformanceMeasureActualID);
            return subprojectPerformanceMeasureActual;
        }

    }
}