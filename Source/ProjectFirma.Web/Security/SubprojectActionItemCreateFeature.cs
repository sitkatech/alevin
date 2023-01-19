using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Create Subproject Action Items")]
    public class SubprojectActionItemCreateFeature : FirmaFeature
    {
        public SubprojectActionItemCreateFeature() : base(new List<Role> { Role.ESAAdmin, Role.Admin, Role.ProjectSteward })
        {
        }

    }
}