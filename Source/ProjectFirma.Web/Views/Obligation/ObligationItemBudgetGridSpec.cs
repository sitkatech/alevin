/*-----------------------------------------------------------------------
<copyright file="ObligationItemBudgetGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationItemBudgetGridSpec : GridSpec<WbsElementObligationItemBudget>
    {
        public ObligationItemBudgetGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "Obligation Item Budget";
            ObjectNamePlural = "Obligation Item Budgets";
            SaveFiltersInCookie = true;

            Add("Obligation Number Key", ob => UrlTemplate.MakeHrefString(ob.ObligationItem.ObligationNumber.GetDetailUrl(), ob.ObligationItem.ObligationNumber.ObligationNumberKey), 150, DhtmlxGridColumnFilterType.Text);
            Add("Obligation Item Key", ob => ob.ObligationItem.ObligationItemKey, 80, DhtmlxGridColumnFilterType.Numeric);
            Add("Vendor", ob => ob.ObligationItem.Vendor.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Cost Authority", ob => ob.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, DhtmlxGridColumnFilterType.Html);
            Add("Budget Object Code", ob => UrlTemplate.MakeHrefString(ob.BudgetObjectCode.GetDetailUrl(), ob.BudgetObjectCode.GetDisplayName()), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Budget Object Code FBMS Year", ob => ob.BudgetObjectCode.FbmsYear.ToString(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Fund Number", ob => UrlTemplate.MakeHrefString(ob.Fund.GetDetailUrl(), ob.Fund.ReclamationFundNumber), 100, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            Add("Obligation", ob => ob.Obligation, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Goods Receipt", ob => ob.GoodsReceipt, 100, DhtmlxGridColumnFilterType.Text);
            Add("Invoiced", ob => ob.Invoiced, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Disbursed", ob => ob.Disbursed, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Unexpended Balance", ob => ob.UnexpendedBalance, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Created On Date", ob => ob.CreatedOnKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
            Add("Date Of Update", ob => ob.DateOfUpdateKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
            Add("Document Date of Bl", ob => ob.DocumentDateOfBlKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
            Add("Posting Date", ob => ob.PostingDateKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
            Add("Posting Date Per Spl", ob => ob.PostingDatePerSplKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
        }
    }
}