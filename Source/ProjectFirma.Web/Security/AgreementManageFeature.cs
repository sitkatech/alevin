using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Agreement")]
    public class AgreementManageFeature : FirmaAdminFeature
    {
        public override bool HasPermissionByPerson(Person person)
        {
            return base.HasPermissionByPerson(person);
        }
    }
}