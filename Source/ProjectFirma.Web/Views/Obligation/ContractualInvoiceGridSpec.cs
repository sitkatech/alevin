/*-----------------------------------------------------------------------
<copyright file="ObligationItemInvoiceGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using LtInfo.Common.DhtmlWrappers;
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

            Add("Obligation Number Key", ci => UrlTemplate.MakeHrefString(ci.ObligationItem.ObligationNumber.GetDetailUrl(), ci.ObligationItem.ObligationNumber.ObligationNumberKey), 150, DhtmlxGridColumnFilterType.Text);
            Add("Obligation Item Key", ci => UrlTemplate.MakeHrefString(ci.ObligationItem.GetDetailUrl(), ci.ObligationItem.ObligationItemKey), 80, DhtmlxGridColumnFilterType.Numeric);
            Add("Vendor", ci => ci.ObligationItem.Vendor.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Cost Authority", ci => ci.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, DhtmlxGridColumnFilterType.Html);
            Add("Budget Object Code", ci => MakeBudgetObjectCodeHrefString(ci.BudgetObjectCode), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Budget Object Code FBMS Year", ci => GetBudgetObjectCodeFmsYearAsString(ci.BudgetObjectCode), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderString(), ci => UrlTemplate.MakeHrefString(ci.FundingSource.GetDetailUrl(), ci.FundingSource.FundingSourceName), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Unexpended Balance", ci => ci.UnexpendedBalance, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Posting Date", ob => ob.PostingDatePerSplKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
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