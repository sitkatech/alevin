using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View {0}", FieldDefinitionEnum.PnBudget)]
    public class PnBudgetViewFeature : FirmaAdminFeature
    {
    }
}