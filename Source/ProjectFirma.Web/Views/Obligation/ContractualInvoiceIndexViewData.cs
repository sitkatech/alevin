using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    public class ContractualInvoiceIndexViewData : FirmaViewData
    {
        public ContractualInvoiceGridSpec ContractualInvoiceGridSpec { get; }
        public string ContractualInvoiceGridName { get; }
        public string ContractualInvoiceGridDataUrl { get; }

        public ContractualInvoiceIndexViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {
            PageTitle = "Contractual Invoices";

            ContractualInvoiceGridSpec = new ContractualInvoiceGridSpec(currentFirmaSession);
            ContractualInvoiceGridName = "contractualInvoiceGrid";
            ContractualInvoiceGridDataUrl = SitkaRoute<ObligationController>.BuildUrlFromExpression(c => c.ContractualObligationIndexGridJsonData());
        }
    }
}



