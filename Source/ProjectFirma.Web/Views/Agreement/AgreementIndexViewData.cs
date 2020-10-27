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
        public ViewPageContentViewData AgreementIndexViewPageContentViewData { get; }
        public AgreementGridSpec AgreementGridSpec { get; }
        public string AgreementGridName { get; }
        public string AgreementGridDataUrl { get; }
        public string EditSortOrderUrl { get; }
        public bool HasAgreementManagePermissions { get; }
        public string NewAgreementUrl { get; }


        public bool DisplayActionButtons { get; }

        public AgreementIndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetAgreementNamePluralized();

            HasAgreementManagePermissions = new AgreementManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            DisplayActionButtons = HasAgreementManagePermissions;

            AgreementGridSpec = new AgreementGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = MultiTenantHelpers.GetAgreementName(),
                ObjectNamePlural = MultiTenantHelpers.GetAgreementNamePluralized(),
                SaveFiltersInCookie = true
            };

            AgreementGridName = "AgreementsGrid";
            AgreementGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.AgreementGridJsonData());
            AgreementIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);

            // FIX; not agreement yet!
            NewAgreementUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.New());

            //AgreementGridSpec.CustomExcelDownloadLinkText = $"Download with {FieldDefinitionEnum.AgreementSubcategory.ToType().GetFieldDefinitionLabelPluralized()}";
            //AgreementGridSpec.CustomExcelDownloadUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());
        }
    }
}



