using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData ObligationIndexViewPageContentViewData { get; }
        public ObligationGridSpec ObligationGridSpec { get; }
        public string ObligationGridName { get; }
        public string ObligationGridDataUrl { get; }
        public string NewUrl { get; }

        public ObligationIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "Obligations";

            ObligationGridSpec = new ObligationGridSpec(currentFirmaSession);

            ObligationGridName = "ObligationsGrid";
            ObligationGridDataUrl = SitkaRoute<ObligationController>.BuildUrlFromExpression(c => c.ObligationNumberGridJsonData());
            ObligationIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



