using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    // Should this just be an "ObligationRequestViewFeature" instead? Why specifically for index? -- SLG 07/24/2020
    [SecurityFeatureDescription("Has a ProjectFirma role")]
    public class ObligationRequestIndexViewFeature : FirmaFeature
    {
        public ObligationRequestIndexViewFeature()
            : base(new List<Role> { Role.ESAAdmin, Role.Admin})
        {
        }
    }
}