using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReclamationCostAuthorityAgreementRequestModelExtensions
    {
        

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t => t.DeleteCostAuthority(UrlTemplate.Parameter1Int)));

        public static string GetDeleteUrl(this ReclamationCostAuthorityAgreementRequest reclamationCostAuthorityAgreementRequest)
        {
            return DeleteUrlTemplate.ParameterReplace(reclamationCostAuthorityAgreementRequest.PrimaryKey);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(
            SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t => t.EditCostAuthorityAgreementRequest(UrlTemplate.Parameter1Int)));

        public static string GetEditUrl(this ReclamationCostAuthorityAgreementRequest reclamationCostAuthorityAgreementRequest)
        {
            return EditUrlTemplate.ParameterReplace(reclamationCostAuthorityAgreementRequest.PrimaryKey);
        }
    }
}