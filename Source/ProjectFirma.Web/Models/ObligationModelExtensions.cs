using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ObligationModelExtensions
    {
        public static readonly UrlTemplate<string> ObligationDetailUrlTemplate = new UrlTemplate<string>(SitkaRoute<ObligationController>.BuildUrlFromExpression(t => t.ObligationDetail(UrlTemplate.Parameter1String)));
        public static string GetDetailUrl(this ObligationNumber obligation)
        {
            return ObligationDetailUrlTemplate.ParameterReplace(obligation.ObligationNumberKey);
        }
    }
}