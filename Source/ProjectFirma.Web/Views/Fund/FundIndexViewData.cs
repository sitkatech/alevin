using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Fund
{
    public class FundIndexViewData : FirmaViewData
    {
        //public ViewPageContentViewData FundIndexViewPageContentViewData { get; }
        public FundGridSpec FundGridSpec { get; }
        public string FundGridName { get; }
        public string FundGridDataUrl { get; }
        public string NewUrl { get; }

        public FundIndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Funds";

            FundGridSpec = new FundGridSpec(currentFirmaSession);

            //NewUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.New());
            NewUrl = "NO_URL_FOR_THIS_PROBABLY_WILL_NEVER_BE_ONE";

            FundGridName = "FundsGrid";
            FundGridDataUrl = SitkaRoute<FundController>.BuildUrlFromExpression(c => c.FundGridJsonData());
            //FundIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



