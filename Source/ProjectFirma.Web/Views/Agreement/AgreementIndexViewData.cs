using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ObligationRequest;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData AgrementIndexViewPageContentViewData { get; }
        public AgreementGridSpec AgreementGridSpec { get; }
        public string AgreementGridName { get; }
        public string AgreementGridDataUrl { get; }
        public string EditSortOrderUrl { get; }
        public bool HasAgreementManagePermissions { get; }
        public string NewUrl { get; }

        public AgreementIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetAgreementNamePluralized();

            HasAgreementManagePermissions = new AgreementManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            AgreementGridSpec = new AgreementGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = MultiTenantHelpers.GetAgreementName(),
                ObjectNamePlural = MultiTenantHelpers.GetAgreementNamePluralized(),
                SaveFiltersInCookie = true
            };

            AgreementGridName = "AgreementsGrid";
            AgreementGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.AgreementGridJsonData());
            AgrementIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);

            //AgreementGridSpec.CustomExcelDownloadLinkText = $"Download with {FieldDefinitionEnum.AgreementSubcategory.ToType().GetFieldDefinitionLabelPluralized()}";
            //AgreementGridSpec.CustomExcelDownloadUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());

        }
    }
}



