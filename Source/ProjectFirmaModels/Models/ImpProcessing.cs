using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ImpProcessing
    {
        public static ImpProcessing GetLatestImportProcessingForGivenType(DatabaseEntities databaseEntities, ImpProcessingTableType impProcessingTableType)
        {
            var latestImportProcessingForPnBudget = databaseEntities.ImpProcessings.
                Where(ip => ip.ImpProcessingTableTypeID == impProcessingTableType.ImpProcessingTableTypeID).
                ToList().OrderBy(ip => ip.UploadDate).
                LastOrDefault();
            return latestImportProcessingForPnBudget;
        }

    }
}