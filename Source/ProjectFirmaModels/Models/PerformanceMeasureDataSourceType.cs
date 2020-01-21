using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public abstract partial class PerformanceMeasureDataSourceType
    {
        public virtual List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(PerformanceMeasure performanceMeasure, List<Project> projects)
        {
            List<PerformanceMeasureActual> performanceMeasureActualsFiltered;
            if (projects == null || !projects.Any())
            {
                performanceMeasureActualsFiltered = performanceMeasure.PerformanceMeasureActuals.ToList();
            }
            else
            {
                var projectIDs = projects.Select(x => x.ProjectID).ToList();
                performanceMeasureActualsFiltered =
                    performanceMeasure.PerformanceMeasureActuals.Where(x => projectIDs.Contains(x.Project.ProjectID)).ToList();
            }
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActualsFiltered);
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ToList();
        }


        public virtual List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasureValues(PerformanceMeasure performanceMeasure, List<ProjectUpdateBatch> projectUpdateBatches)
        {
            List<PerformanceMeasureActualUpdate> performanceMeasureActualsFiltered;
            if (projectUpdateBatches == null || !projectUpdateBatches.Any())
            {
                performanceMeasureActualsFiltered = performanceMeasure.PerformanceMeasureActualUpdates.ToList();
            }
            else
            {
                var projectUpdateBatchIDs = projectUpdateBatches.Select(x => x.ProjectUpdateBatchID).ToList();
                performanceMeasureActualsFiltered = performanceMeasure.PerformanceMeasureActualUpdates.Where(x => projectUpdateBatchIDs.Contains(x.ProjectUpdateBatchID)).ToList();
            }
            var performanceMeasureReportedValues = PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActualsFiltered);
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ToList();
        }


    }
}
