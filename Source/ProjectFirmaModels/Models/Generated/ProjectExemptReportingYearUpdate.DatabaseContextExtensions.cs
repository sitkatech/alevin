//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExemptReportingYearUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExemptReportingYearUpdate GetProjectExemptReportingYearUpdate(this IQueryable<ProjectExemptReportingYearUpdate> projectExemptReportingYearUpdates, int projectExemptReportingYearUpdateID)
        {
            var projectExemptReportingYearUpdate = projectExemptReportingYearUpdates.SingleOrDefault(x => x.ProjectExemptReportingYearUpdateID == projectExemptReportingYearUpdateID);
            Check.RequireNotNullThrowNotFound(projectExemptReportingYearUpdate, "ProjectExemptReportingYearUpdate", projectExemptReportingYearUpdateID);
            return projectExemptReportingYearUpdate;
        }

    }
}