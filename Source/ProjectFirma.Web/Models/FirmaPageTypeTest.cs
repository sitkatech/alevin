using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class FirmaPageTypeTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CheckForUncreatedFirmaPageForFirmaPageType()
        {
            var allFirmaPages = HttpRequestStorage.DatabaseEntities.AllFirmaPages.ToList();
            var allFirmaPageTypes = HttpRequestStorage.DatabaseEntities.FirmaPageTypes.ToList();
            var allTenants = Tenant.All;
            string missingPageTypes = string.Empty;

            // Only check Reclamation in the Reclamation Client Branch.
            List<Tenant> tenantsToCheck = allTenants.Where(t => t.TenantID == 12).ToList();
            foreach (var tenant in tenantsToCheck)
            {
                List<int> allFirmaPageTypeIDPresentInFirmaPages = allFirmaPages.Where(fp => fp.TenantID == tenant.TenantID).Select(fp => fp.FirmaPageTypeID).Distinct().ToList();
                foreach (var firmaPageType in allFirmaPageTypes)
                {
                    var pageTypeIsPresent = allFirmaPageTypeIDPresentInFirmaPages.Contains(firmaPageType.FirmaPageTypeID);
                    if (!pageTypeIsPresent)
                    {
                        missingPageTypes += $"Could Not find FirmaPage for FirmaPageType '{firmaPageType.FirmaPageTypeName}'({firmaPageType.FirmaPageTypeID}) in FirmaPages for Tenant {tenant.TenantName}({tenant.TenantID})\n\r";
                    }

                }
            }
            Approvals.Verify(missingPageTypes);
        }
    }
}