/*-----------------------------------------------------------------------
<copyright file="ObligationItemInvoiceGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Web;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.Obligation
{
    // formerly known as "ObligationItemInvoiceGridSpec"
    public class ContractualInvoiceGridSpec : GridSpec<WbsElementObligationItemBudget>
    {
        public ContractualInvoiceGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "Contractual Invoice";
            ObjectNamePlural = "Contractual Invoices";
            SaveFiltersInCookie = true;

            Add("Obligation Number Key", ci => UrlTemplate.MakeHrefString(ci.ObligationItem.ObligationNumber.GetDetailUrl(), ci.ObligationItem.ObligationNumber.ObligationNumberKey), 150, AgGridColumnFilterType.Text);
            Add("Obligation Item Key", ci => UrlTemplate.MakeHrefString(ci.ObligationItem.GetDetailUrl(), ci.ObligationItem.ObligationItemKey), 80, AgGridColumnFilterType.Numeric);
            Add("Vendor", ci => ci.ObligationItem.Vendor.GetDisplayNameAsUrl(), 200, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Cost Authority", ci => ci.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, AgGridColumnFilterType.Html);
            Add("Budget Object Code", ci => MakeBudgetObjectCodeHrefString(ci.BudgetObjectCode), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Budget Object Code FBMS Year", ci => GetBudgetObjectCodeFmsYearAsString(ci.BudgetObjectCode), 100, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), ci => UrlTemplate.MakeHrefString(ci.FundingSource.GetDetailUrl(), ci.FundingSource.FundingSourceName), 100, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Unexpended Balance", ci => ci.UnexpendedBalance, 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
            Add("Posting Date", ob => ob.PostingDatePerSplKey, 80, AgGridColumnFormatType.Date);

            


        }

        private const string UnknownString = "(Unknown)";

        private static string GetBudgetObjectCodeFmsYearAsString(ProjectFirmaModels.Models.BudgetObjectCode budgetObjectCode)
        {
            if (budgetObjectCode == null)
            {
                return UnknownString;
            }
            return budgetObjectCode.FbmsYear.ToString();
        }

        private static HtmlString MakeBudgetObjectCodeHrefString(ProjectFirmaModels.Models.BudgetObjectCode budgetObjectCode)
        {
            if (budgetObjectCode == null)
            {
                // We don't know what Budget Code to assign for this in the Publishing Processing, so we have to punt here.
                return new HtmlString(UnknownString);
            }
            return UrlTemplate.MakeHrefString(budgetObjectCode.GetDetailUrl(), budgetObjectCode.GetDisplayName());
        }
    }
}