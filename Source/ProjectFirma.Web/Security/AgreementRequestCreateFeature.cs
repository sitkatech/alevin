using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Has a ProjectFirma role")]
    public class AgreementRequestCreateFeature : FirmaFeature
    {
        public AgreementRequestCreateFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }
    }
}