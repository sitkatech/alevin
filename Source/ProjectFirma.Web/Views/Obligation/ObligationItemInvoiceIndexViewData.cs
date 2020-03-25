using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationItemInvoiceIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData ObligationIndexViewPageContentViewData { get; }
        public ObligationItemInvoiceGridSpec ObligationItemInvoiceGridSpec { get; }
        public string ObligationItemInvoiceGridName { get; }
        public string ObligationItemInvoiceGridDataUrl { get; }

        //public ObligationItemInvoiceIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        public ObligationItemInvoiceIndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Obligation Item Invoices";

            ObligationItemInvoiceGridSpec = new ObligationItemInvoiceGridSpec(currentFirmaSession);



            ObligationItemInvoiceGridName = "obligationItemInvoiceGrid";
            ObligationItemInvoiceGridDataUrl = SitkaRoute<ObligationController>.BuildUrlFromExpression(c => c.ObligationItemInvoiceIndexGridJsonData());
            //ObligationIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



