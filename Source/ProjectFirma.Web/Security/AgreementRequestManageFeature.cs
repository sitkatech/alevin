using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage {0}", FieldDefinitionEnum.AgreementRequest)]
    public class AgreementRequestManageFeature : FirmaAdminFeature
    {
        public override bool HasPermissionByPerson(Person person)
        {
            return base.HasPermissionByPerson(person);
        }
    }
}