namespace ProjectFirmaModels.Models
{
    public partial class SubprojectProjectStatus : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var projectStatusProjectStatusDisplayName = ProjectStatus != null ? ProjectStatus.ProjectStatusDisplayName : "NO PROJECT STATUS FOUND";
            var subprojectID = SubprojectID.ToString();
            return $"Subproject Status Update: Project Status - {projectStatusProjectStatusDisplayName}, SubprojectID - {subprojectID}";
        }
    }
}