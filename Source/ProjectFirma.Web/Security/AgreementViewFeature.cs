using ProjectFirma.Web.Security.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View {0}", FieldDefinitionEnum.Agreement)]
    public class AgreementViewFeature : AnonymousUnclassifiedFeature
    {
    }
}