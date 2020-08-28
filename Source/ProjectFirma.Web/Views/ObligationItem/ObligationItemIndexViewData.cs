using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationItem
{
    public class ObligationItemIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData ObligationItemIndexViewPageContentViewData { get; }
        public ObligationItemGridSpec ObligationItemGridSpec { get; }
        public string ObligationItemGridName { get; }
        public string ObligationItemGridDataUrl { get; }
        public string NewUrl { get; }

        public ObligationItemIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "Obligation Items";

            ObligationItemGridSpec = new ObligationItemGridSpec(currentFirmaSession);

            ObligationItemGridName = "ObligationItemsGrid";
            ObligationItemGridDataUrl = SitkaRoute<ObligationItemController>.BuildUrlFromExpression(c => c.ObligationItemGridJsonData());
            
            ObligationItemIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



