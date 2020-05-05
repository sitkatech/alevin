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
            Add("Cost Authority", pnb => pnb.CostAuthority?.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, DhtmlxGridColumnFilterType.Html);
            Add("Fund Type", pnb => pnb.PnBudgetFundType.PnBudgetFundTypeDisplayName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}