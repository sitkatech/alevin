﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectNoFundingSourceIdentifiedUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates = project.ProjectNoFundingSourceIdentifieds.Select(x => 
                new ProjectNoFundingSourceIdentifiedUpdate(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), projectUpdateBatch.ProjectUpdateBatchID, x.CalendarYear.Value, x.NoFundingSourceIdentifiedYet)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            IList<ProjectNoFundingSourceIdentified> allProjectNoFundingSourceIdentifieds)
        {
            var project = projectUpdateBatch.Project;

            var projectNoFundingSourceIdentifiedsFromProjectUpdate = projectUpdateBatch
                .ProjectNoFundingSourceIdentifiedUpdates
                .Select(x => new ProjectNoFundingSourceIdentified(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), project.ProjectID, x.CalendarYear, x.NoFundingSourceIdentifiedYet)).ToList();
            project.ProjectNoFundingSourceIdentifieds.Merge(projectNoFundingSourceIdentifiedsFromProjectUpdate,
                allProjectNoFundingSourceIdentifieds,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear,
                (x, y) =>
                {
                    x.NoFundingSourceIdentifiedYet = y.NoFundingSourceIdentifiedYet;
                }, HttpRequestStorage.DatabaseEntities);
        }
    }
}