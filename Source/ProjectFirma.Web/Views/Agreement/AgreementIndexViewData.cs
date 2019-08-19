using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementIndexViewData : FirmaViewData
    {
        public AgreementGridSpec AgreementGridSpec { get; }
        public string AgreementGridName { get; }
        public string AgreementGridDataUrl { get; }
        public string EditSortOrderUrl { get; }
        public bool HasAgreementManagePermissions { get; }
        public string NewUrl { get; }

        public AgreementIndexViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetAgreementNamePluralized();

            HasAgreementManagePermissions = new AgreementManageFeature().HasPermissionByPerson(currentPerson);
            AgreementGridSpec = new AgreementGridSpec(currentPerson)
            {
                ObjectNameSingular = MultiTenantHelpers.GetAgreementName(),
                ObjectNamePlural = MultiTenantHelpers.GetAgreementNamePluralized(),
                SaveFiltersInCookie = true
            };

            //NewUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.New());
            NewUrl = "NO_URL_FOR_THIS_PROBABLY_WILL_NEVER_BE_ONE";

            //AgreementGridSpec.CustomExcelDownloadLinkText = $"Download with {FieldDefinitionEnum.AgreementSubcategory.ToType().GetFieldDefinitionLabelPluralized()}";
            //AgreementGridSpec.CustomExcelDownloadUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());

            AgreementGridName = "AgreementsGrid";
            AgreementGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.AgreementGridJsonData());
            // Is this needed??
            //EditSortOrderUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(x => x.EditSortOrder());
        }
    }
}



