using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
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

            Add(FieldDefinitionEnum.PnBudget.ToType().ToGridHeaderString(), pnb => pnb.WbsElementPnBudgetID.ToString(), 100, AgGridColumnFilterType.Text);
            Add("Cost Authority", pnb => pnb.CostAuthority?.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, AgGridColumnFilterType.Html);
            Add("Fund Type", pnb => pnb.PnBudgetFundType.PnBudgetFundTypeDisplayName, 125, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), pnb => UrlTemplate.MakeHrefString(pnb.FundingSource.GetDetailUrl(), pnb.FundingSource.GetDisplayName()), 320, AgGridColumnFilterType.Html);
            Add("Funds Center", pnb => pnb.FundsCenter, 100, AgGridColumnFilterType.Text);
            Add("Fiscal Quarter", pnb => pnb.FiscalQuarter.FiscalQuarterDisplayName, 125, AgGridColumnFilterType.SelectFilterStrict);
            Add("Fiscal Year", pnb => pnb.FiscalYear.ToString(), 50, AgGridColumnFilterType.SelectFilterStrict);
            Add("Budget Object Code", pnb => UrlTemplate.MakeHrefString(pnb.BudgetObjectCode?.GetDetailUrl(), pnb.BudgetObjectCode?.GetDisplayName()), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Budget Object Code FBMS Year", pnb => pnb.BudgetObjectCode?.FbmsYear.ToString(), 100, AgGridColumnFilterType.SelectFilterStrict);
            Add("FIDoc Number", pnb => pnb.FIDocNumber, 75, AgGridColumnFilterType.Text);
            Add("Recoveries", pnb => pnb.Recoveries.ToStringCurrency(), 100, AgGridColumnFilterType.Numeric);
            Add("Committed But Not Obligated", pnb => pnb.CommittedButNotObligated.ToStringCurrency(), 100, AgGridColumnFilterType.Numeric);
            Add("Total Obligations", pnb => pnb.TotalObligations.ToStringCurrency(), 100, AgGridColumnFilterType.Numeric);
            Add("Total Expenditures", pnb => pnb.TotalExpenditures.ToStringCurrency(), 100, AgGridColumnFilterType.Numeric);
            Add("Undelivered Orders", pnb => pnb.UndeliveredOrders.ToStringCurrency(), 100, AgGridColumnFilterType.Numeric);
            
        }
    }
}