using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeIndexViewData : FirmaViewData
    {
        // Conventional Grid
        public BudgetObjectCodeGridSpec BudgetObjectCodeGridSpec { get; }
        public string BudgetObjectCodeGridName { get; }
        public string BudgetObjectCodeGridDataUrl { get; }

        // Groovy new TreeGrid
        public string BudgetObjectCodeGridTreeDataUrl { get; }

        public BudgetObjectCodeIndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Budget Object Codes";

            BudgetObjectCodeGridSpec = new BudgetObjectCodeGridSpec(currentFirmaSession);

            BudgetObjectCodeGridName = "BudgetObjectCodesGrid";
            BudgetObjectCodeGridDataUrl = SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(c => c.BudgetObjectCodeGridJsonData());
            BudgetObjectCodeGridTreeDataUrl = SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(c => c.BudgetObjectCodeTreeGridJsonDataV2());
        }
    }
}



