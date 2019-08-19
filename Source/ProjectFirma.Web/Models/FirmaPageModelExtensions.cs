using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FirmaPageModelExtensions
    {
        public static FirmaPageType ToType(this FirmaPageTypeEnum psInfoPageTypeEnum)
        {
            return ToType((int)psInfoPageTypeEnum);
        }

        public static FirmaPageType ToType(int fieldDefinitionID)
        {
            return HttpRequestStorage.DatabaseEntities.FirmaPageTypes.SingleOrDefault(x => x.FirmaPageTypeID == fieldDefinitionID);
        }

        public static FirmaPage GetFirmaPage(this FirmaPageType firmaPageType)
        {
            var firmaPage = firmaPageType.FirmaPages.SingleOrDefault(x => x.TenantID == HttpRequestStorage.Tenant.TenantID);
            if (firmaPage == null)
            {
                firmaPage = new FirmaPage(firmaPageType.FirmaPageTypeID);
                firmaPage.FirmaPageType = HttpRequestStorage.DatabaseEntities.FirmaPageTypes.GetFirmaPageType(firmaPageType.FirmaPageTypeID);
                firmaPage.FirmaPageContent = $"[No FirmaPage defined yet for FirmaPageType {firmaPageType.FirmaPageTypeDisplayName} for Tenant {HttpRequestStorage.Tenant.TenantName} (TenantID: {HttpRequestStorage.Tenant.TenantID})]";
                // Can we get this without crashing?
                var blah = firmaPage.FirmaPageType.FirmaPageTypeDisplayName;
            }
            return firmaPage;
        }

        public static FirmaPage GetFirmaPage(this FirmaPageTypeEnum firmaPageTypeEnum)
        {
            return  GetFirmaPage(firmaPageTypeEnum.ToType());
        }
    }
}