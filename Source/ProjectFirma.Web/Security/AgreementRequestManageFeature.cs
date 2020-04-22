using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage {0}", FieldDefinitionEnum.ObligationRequest)]
    public class ObligationRequestManageFeature : FirmaAdminFeature
    {
        public override bool HasPermissionByPerson(Person person)
        {
            return base.HasPermissionByPerson(person);
        }
    }
}