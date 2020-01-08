using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public class AgreementRequestIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData AgrementRequestIndexViewPageContentViewData { get; }
        public AgreementRequestGridSpec AgreementRequestGridSpec { get; }
        public string AgreementRequestGridName { get; }
        public string AgreementRequestGridDataUrl { get; }
        public string EditSortOrderUrl { get; }
        public bool HasAgreementManagePermissions { get; }
        public string NewUrl { get; }

        public AgreementRequestIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetAgreementRequestNamePluralized();

            HasAgreementManagePermissions = new AgreementRequestManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            AgreementRequestGridSpec = new AgreementRequestGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = MultiTenantHelpers.GetAgreementRequestName(),
                ObjectNamePlural = MultiTenantHelpers.GetAgreementRequestNamePluralized(),
                SaveFiltersInCookie = true
            };

            NewUrl = "NO_URL_FOR_THIS_PROBABLY_WILL_NEVER_BE_ONE";

            AgreementRequestGridName = $"AgreementRequestsGrid";
            AgreementRequestGridDataUrl = SitkaRoute<AgreementRequestController>.BuildUrlFromExpression(c => c.AgreementGridJsonData());
            AgrementRequestIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



