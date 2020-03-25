using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FundModelExtensions
    {
        public static readonly UrlTemplate<int> FundDetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<FundController>.BuildUrlFromExpression(fc => fc.FundDetail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Fund fund)
        {
            return FundDetailUrlTemplate.ParameterReplace(fund.PrimaryKey);
        }
    }
}