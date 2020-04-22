using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class ObligationRequestIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData AgrementRequestIndexViewPageContentViewData { get; }
        public ObligationRequestGridSpec ObligationRequestGridSpec { get; }
        public string ObligationRequestGridName { get; }
        public string ObligationRequestGridDataUrl { get; }
        public string EditSortOrderUrl { get; }
        public bool HasAgreementManagePermissions { get; }
        public string NewUrl { get; }

        public bool DisplayActionButtons { get; }

        public ObligationRequestIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetObligationRequestNamePluralized();
            NewUrl = "NO_URL_FOR_THIS_PROBABLY_WILL_NEVER_BE_ONE";
            HasAgreementManagePermissions = new ObligationRequestManageFeature().HasPermissionByFirmaSession(currentFirmaSession);

            ObligationRequestGridSpec = new ObligationRequestGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = MultiTenantHelpers.GetObligationRequestName(),
                ObjectNamePlural = MultiTenantHelpers.GetObligationRequestNamePluralized(),
                SaveFiltersInCookie = true
            };

            ObligationRequestGridName = $"ObligationRequestsGrid";
            ObligationRequestGridDataUrl = SitkaRoute<ObligationRequestController>.BuildUrlFromExpression(c => c.ObligationRequestGridJsonData());

            AgrementRequestIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);

            DisplayActionButtons = true;
        }
    }
}



