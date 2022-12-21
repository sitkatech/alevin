using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class Subproject : IAuditableEntity
    {
        public string GetDisplayName() => SubprojectName;
        public string GetAuditDescriptionString()
        {
            return $"Subproject: {SubprojectID}, ProjectID: {ProjectID}";
        }
        public bool IsProposal()
        {
            return SubprojectStage == ProjectStage.Proposal;
        }

        public ProjectStatus GetCurrentSubprojectStatus()
        {
            return SubprojectProjectStatuses.OrderBy(x => x.SubprojectProjectStatusUpdateDate).ThenBy(x => x.SubprojectProjectStatusID).LastOrDefault()?.ProjectStatus;
        }
    }
}