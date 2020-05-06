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

            Add(FieldDefinitionEnum.PnBudget.ToType().ToGridHeaderString(), pnb => pnb.WbsElementPnBudgetID.ToString(), 100, DhtmlxGridColumnFilterType.Text);
            Add("Cost Authority", pnb => pnb.CostAuthority?.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, DhtmlxGridColumnFilterType.Html);
            Add("Fund Type", pnb => pnb.PnBudgetFundType.PnBudgetFundTypeDisplayName, 125, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), pnb => UrlTemplate.MakeHrefString(pnb.FundingSource.GetDetailUrl(), pnb.FundingSource.GetDisplayName()), 320, DhtmlxGridColumnFilterType.Html);
            Add("Funds Center", pnb => pnb.FundsCenter, 100, DhtmlxGridColumnFilterType.Text);
            Add("Fiscal Quarter", pnb => pnb.FiscalQuarter.FiscalQuarterDisplayName, 125, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Fiscal Year", pnb => pnb.FiscalYear.ToString(), 50, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Budget Object Code", pnb => UrlTemplate.MakeHrefString(pnb.BudgetObjectCode?.GetDetailUrl(), pnb.BudgetObjectCode?.GetDisplayName()), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Budget Object Code FBMS Year", pnb => pnb.BudgetObjectCode?.FbmsYear.ToString(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("FIDoc Number", pnb => pnb.FIDocNumber, 75, DhtmlxGridColumnFilterType.Text);
            Add("Recoveries", pnb => pnb.Recoveries.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Committed But Not Obligated", pnb => pnb.CommittedButNotObligated.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Total Obligations", pnb => pnb.TotalObligations.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Total Expenditures", pnb => pnb.TotalExpenditures.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Undelivered Orders", pnb => pnb.UndeliveredOrders.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            
        }
    }
}