using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Has a ProjectFirma role")]
    public class ObligationRequestCreateFeature : FirmaFeature
    {
        public ObligationRequestCreateFeature()
            : base(new List<Role> { Role.ESAAdmin, Role.Admin })
        {
        }
    }
}