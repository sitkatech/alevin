using LtInfo.Common.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static class ProjectNoFundingSourceIdentifiedUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectNoFundingSourceIdentifiedUpdates = project.ProjectNoFundingSourceIdentifieds.Select(x => 
                new ProjectNoFundingSourceIdentifiedUpdate(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), projectUpdateBatch.ProjectUpdateBatchID, x.CalendarYear.HasValue ? x.CalendarYear.Value : (int?)null, x.NoFundingSourceIdentifiedYet, x.CostTypeID)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;

            var projectNoFundingSourceIdentifiedsFromProjectUpdate = projectUpdateBatch
                .ProjectNoFundingSourceIdentifiedUpdates
                .Select(x => new ProjectNoFundingSourceIdentified(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), project.ProjectID, x.CalendarYear, x.NoFundingSourceIdentifiedYet, x.CostTypeID)).ToList();
            project.ProjectNoFundingSourceIdentifieds.Merge(projectNoFundingSourceIdentifiedsFromProjectUpdate,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.CostTypeID == y.CostTypeID,
                (x, y) =>
                {
                    x.NoFundingSourceIdentifiedYet = y.NoFundingSourceIdentifiedYet;
                }, databaseEntities);
        }
    }
}