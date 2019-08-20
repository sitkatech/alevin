using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.CostAuthority
{
    public class CostAuthorityIndexViewData : FirmaViewData
    {
        public ViewPageContentViewData AgrementIndexViewPageContentViewData { get; }
        public CostAuthorityGridSpec CostAuthorityGridSpec { get; }
        public string CostAuthorityGridName { get; }
        public string CostAuthorityGridDataUrl { get; }
        public string EditSortOrderUrl { get; }
        public bool HasCostAuthorityManagePermissions { get; }
        public string NewUrl { get; }

        public CostAuthorityIndexViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = MultiTenantHelpers.GetCostAuthorityNamePluralized();

            HasCostAuthorityManagePermissions = new CostAuthorityManageFeature().HasPermissionByPerson(currentPerson);
            CostAuthorityGridSpec = new CostAuthorityGridSpec(currentPerson)
            {
                ObjectNameSingular = MultiTenantHelpers.GetCostAuthorityName(),
                ObjectNamePlural = MultiTenantHelpers.GetCostAuthorityNamePluralized(),
                SaveFiltersInCookie = true
            };

            //NewUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(c => c.New());
            NewUrl = "NO_URL_FOR_THIS_PROBABLY_WILL_NEVER_BE_ONE";

            //CostAuthorityGridSpec.CustomExcelDownloadLinkText = $"Download with {FieldDefinitionEnum.CostAuthoritySubcategory.ToType().GetFieldDefinitionLabelPluralized()}";
            //CostAuthorityGridSpec.CustomExcelDownloadUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());

            CostAuthorityGridName = "CostAuthoritysGrid";
            CostAuthorityGridDataUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(c => c.CostAuthorityGridJsonData());
            // Is this needed??
            //EditSortOrderUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(x => x.EditSortOrder());
            AgrementIndexViewPageContentViewData = new ViewPageContentViewData(firmaPage, true);
        }
    }
}



