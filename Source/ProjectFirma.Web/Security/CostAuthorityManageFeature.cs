using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Cost Authorities")]
    public class CostAuthorityManageFeature : FirmaAdminFeature
    {
        public override bool HasPermissionByPerson(Person person)
        {
            return base.HasPermissionByPerson(person);
        }
    }
}