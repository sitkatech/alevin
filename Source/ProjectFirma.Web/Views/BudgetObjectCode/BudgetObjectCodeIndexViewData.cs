using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeIndexViewData : FirmaViewData
    {
        //public ViewPageContentViewData BudgetObjectCodeIndexViewPageContentViewData { get; }
        public BudgetObjectCodeGridSpec BudgetObjectCodeGridSpec { get; }
        public string BudgetObjectCodeGridName { get; }
        public string BudgetObjectCodeGridDataUrl { get; }
        public string NewUrl { get; }

        public BudgetObjectCodeIndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Budget Object Codes";

            BudgetObjectCodeGridSpec = new BudgetObjectCodeGridSpec(currentFirmaSession);

            //NewUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.New());
            NewUrl = "NO_URL_FOR_THIS_PROBABLY_WILL_NEVER_BE_ONE";

            BudgetObjectCodeGridName = "BudgetObjectCodesGrid";
            BudgetObjectCodeGridDataUrl = SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(c => c.BudgetObjectCodeGridJsonData());
            //BudgetObjectCodeIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



