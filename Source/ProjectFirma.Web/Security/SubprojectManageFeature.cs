using ProjectFirmaModels.Models;
using System.Collections.Generic;


namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Subproject")]
    public class SubprojectManageFeature : FirmaFeature
    {
        public SubprojectManageFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward }) { }
    }
}
