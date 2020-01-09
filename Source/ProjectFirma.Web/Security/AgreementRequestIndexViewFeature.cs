using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Has a ProjectFirma role")]
    public class AgreementRequestIndexViewFeature : FirmaFeature
    {
        public AgreementRequestIndexViewFeature()
            : base(new List<Role> { Role.SitkaAdmin})
        {
        }
    }
}