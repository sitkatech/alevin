using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
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

    public static class ProjectStatusModelExtensions
    {
        public static string GetDeleteUrl(this ProjectStatus projectStatus)
        {
            return SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(c => c.Delete(projectStatus.ProjectStatusID));
        }

        public static string GetEditUrl(this ProjectStatus projectStatus)
        {
            return SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(c => c.Edit(projectStatus.ProjectStatusID));
        }
    }
}