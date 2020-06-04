//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectClassification]
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
        public static ProjectClassification GetProjectClassification(this IQueryable<ProjectClassification> projectClassifications, int projectClassificationID)
        {
            var projectClassification = projectClassifications.SingleOrDefault(x => x.ProjectClassificationID == projectClassificationID);
            Check.RequireNotNullThrowNotFound(projectClassification, "ProjectClassification", projectClassificationID);
            return projectClassification;
        }

    }
}