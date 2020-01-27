using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectProjectStatusModelExtensions
    {
        public static string GetDropdownDisplayName(this ProjectProjectStatus projectProjectStatus)
        {
            return $"{projectProjectStatus.ProjectProjectStatusCreateDate:MM/dd/yyyy} - {projectProjectStatus.ProjectProjectStatusCreatePerson.GetFullNameFirstLast()} - {projectProjectStatus.ProjectStatus.ProjectStatusDisplayName}";
        }
    }
}