using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class CostAuthorityObligationRequestModelExtensions
    {
        

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(t => t.DeleteCostAuthority(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this CostAuthorityObligationRequest costAuthorityObligationRequest)
        {
            return DeleteUrlTemplate.ParameterReplace(costAuthorityObligationRequest.PrimaryKey);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(t => t.EditCostAuthorityObligationRequest(UrlTemplate.Parameter1Int)));

        public static string GetEditUrl(this CostAuthorityObligationRequest costAuthorityObligationRequest)
        {
            return EditUrlTemplate.ParameterReplace(costAuthorityObligationRequest.PrimaryKey);
        }
    }
}