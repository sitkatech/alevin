
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Subproject
{
    public class SubprojectDisplayViewData : FirmaUserControlViewData
    {
        public ProjectFirmaModels.Models.Project Project { get; set; }
        public SubprojectGridSpec SubprojectGridSpec { get; }
        public string SubprojectGridName { get; }
        public string SubprojectGridDataUrl { get; }
        
        
        public SubprojectDisplayViewData(ProjectFirmaModels.Models.Project project, SubprojectGridSpec subprojectGridSpec, string subprojectGridName, string subprojectGridDataUrl)
        {
            Project = project;
            SubprojectGridSpec = subprojectGridSpec;
            SubprojectGridName = subprojectGridName;
            SubprojectGridDataUrl = subprojectGridDataUrl;
        }
    }
}