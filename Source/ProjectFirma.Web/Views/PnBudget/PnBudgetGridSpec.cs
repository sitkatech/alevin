using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PnBudget
{
    public class PnBudgetGridSpec : GridSpec<WbsElementPnBudget>
    {
        public PnBudgetGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "PnBudget";
            ObjectNamePlural = "PnBudgets";
            SaveFiltersInCookie = true;

            // ObligationNumber as link
            //Add(FieldDefinitionEnum.PnBudget.ToType().ToGridHeaderString(), ob => UrlTemplate.MakeHrefString(ob?.GetDetailUrl(), ob?.ObligationNumberKey), 100, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.PnBudget.ToType().ToGridHeaderString(), pnb => pnb.WbsElementPnBudgetID.ToString(), 100, DhtmlxGridColumnFilterType.Text);
            // Agreement
            //Add(FieldDefinitionEnum.Agreement.ToType().ToGridHeaderStringPlural(), ra => UrlTemplate.MakeHrefString(ra.ReclamationAgreement?.GetDetailUrl(), ra.ReclamationAgreement?.GetDisplayName()), 300, DhtmlxGridColumnFilterType.Html);
        }
    }
}