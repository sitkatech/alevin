using ProjectFirma.Web.Security.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View {0}", FieldDefinitionEnum.AgreementRequest)]
    public class AgreementRequestViewFeature : AnonymousUnclassifiedFeature
    {
    }
}