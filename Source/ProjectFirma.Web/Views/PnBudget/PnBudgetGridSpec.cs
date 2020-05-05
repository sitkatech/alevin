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
            Add("Fund Type", pnb => pnb.PnBudgetFundType.PnBudgetFundTypeDisplayName, 125, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Funding Source", pnb => pnb.FundingSource.FundingSourceName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Funds Center", pnb => pnb.FundsCenter, 100, DhtmlxGridColumnFilterType.Text);
            Add("Fiscal Quarter", pnb => pnb.FiscalQuarter.FiscalQuarterDisplayName, 125, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Fiscal Year", pnb => pnb.FiscalYear.ToString(), 50, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Commitment Item", pnb => pnb.CommitmentItem.CommitmentItemName, 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("FIDoc Number", pnb => pnb.FIDocNumber, 75, DhtmlxGridColumnFilterType.Text);
            Add("Recoveries", pnb => pnb.Recoveries.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Committed But Not Obligated", pnb => pnb.CommittedButNotObligated.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Total Obligations", pnb => pnb.TotalObligations.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Total Expenditures", pnb => pnb.TotalExpenditures.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Undelivered Orders", pnb => pnb.UndeliveredOrders.ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            
        }
    }
}