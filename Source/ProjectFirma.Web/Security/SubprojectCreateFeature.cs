using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Create Subprojects")]
    public class SubprojectCreateFeature : FirmaFeature
    {
        public SubprojectCreateFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward }) { }

    }
}