using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Subproject Action Items under the context of a project")]
    public class SubprojectActionItemViewFeature : FirmaFeature
    {
        public SubprojectActionItemViewFeature() : base(new List<Role> { Role.ESAAdmin, Role.Admin, Role.ProjectSteward }) { }

    }
}
