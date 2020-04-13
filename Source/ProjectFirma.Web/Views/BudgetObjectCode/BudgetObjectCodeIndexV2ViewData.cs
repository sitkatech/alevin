using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeIndexV2ViewData : FirmaViewData
    {
        public BudgetObjectCodeTreeGridSpecV2 BudgetObjectCodeGridSpec { get; }
        public string BudgetObjectCodeGridName { get; }
        public string BudgetObjectCodeGridDataUrl { get; }
        public string NewUrl { get; }

        public BudgetObjectCodeIndexV2ViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Budget Object Codes V2";

            BudgetObjectCodeGridSpec = new BudgetObjectCodeTreeGridSpecV2(currentFirmaSession);

            //NewUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.New());
            NewUrl = "NO_URL_FOR_THIS_PROBABLY_WILL_NEVER_BE_ONE";

            BudgetObjectCodeGridName = "BudgetObjectCodesGrid";
            BudgetObjectCodeGridDataUrl = SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(c => c.BudgetObjectCodeGridJsonData());
            //BudgetObjectCodeIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



