using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    // Does this whole thing need to be scrapped?
    public class ObligationItemInvoiceIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData ObligationIndexViewPageContentViewData { get; }
        public ContractualInvoiceGridSpec ContractualInvoiceGridSpec { get; }
        public string ObligationItemInvoiceGridName { get; }
        public string ObligationItemInvoiceGridDataUrl { get; }

        public ObligationItemInvoiceIndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Obligation Item Invoices";

            ContractualInvoiceGridSpec = new ContractualInvoiceGridSpec(currentFirmaSession);


            /*
            ObligationItemInvoiceGridName = "obligationItemInvoiceGrid";
            ObligationItemInvoiceGridDataUrl = SitkaRoute<ObligationController>.BuildUrlFromExpression(c => c.ObligationItemInvoiceIndexGridJsonData());
            //ObligationIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
            */
        }
    }
}



