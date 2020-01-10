using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ReclamationAgreementRequestModelExtensions
    {
        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t => t.AgreementRequestDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this ReclamationAgreementRequest agreementRequest)
        {
            return DetailUrlTemplate.ParameterReplace(agreementRequest.PrimaryKey);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this ReclamationAgreementRequest agreementRequest)
        {
            return EditUrlTemplate.ParameterReplace(agreementRequest.PrimaryKey);
        }


        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(t => t.Delete(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this ReclamationAgreementRequest agreementRequest)
        {
            return DeleteUrlTemplate.ParameterReplace(agreementRequest.PrimaryKey);
        }

    }
}