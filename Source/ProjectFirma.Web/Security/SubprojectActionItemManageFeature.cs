using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add and Edit Subproject Action Items")]
    public class SubprojectActionItemManageFeature : FirmaFeature
    {
        public SubprojectActionItemManageFeature() : base(new List<Role> { Role.ESAAdmin, Role.Admin, Role.ProjectSteward })
        {
        }

    }
}