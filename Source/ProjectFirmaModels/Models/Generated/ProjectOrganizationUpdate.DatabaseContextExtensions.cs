//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectOrganizationUpdate]
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
        public static ProjectOrganizationUpdate GetProjectOrganizationUpdate(this IQueryable<ProjectOrganizationUpdate> projectOrganizationUpdates, int projectOrganizationUpdateID)
        {
            var projectOrganizationUpdate = projectOrganizationUpdates.SingleOrDefault(x => x.ProjectOrganizationUpdateID == projectOrganizationUpdateID);
            Check.RequireNotNullThrowNotFound(projectOrganizationUpdate, "ProjectOrganizationUpdate", projectOrganizationUpdateID);
            return projectOrganizationUpdate;
        }

    }
}