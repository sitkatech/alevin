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

using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationItemInvoiceGridSpec : GridSpec<WbsElementObligationItemInvoice>
    {
        public ObligationItemInvoiceGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "Obligation Item Invoice";
            ObjectNamePlural = "Obligation Item Invoices";
            SaveFiltersInCookie = true;

            Add("Obligation Number Key", obi => UrlTemplate.MakeHrefString(obi.ObligationItem.ObligationNumber.GetDetailUrl(), obi.ObligationItem.ObligationNumber.ObligationNumberKey), 150, DhtmlxGridColumnFilterType.Text);
            Add("Obligation Item Key", obi => obi.ObligationItem.ObligationItemKey, 80, DhtmlxGridColumnFilterType.Numeric);
            Add("Vendor", ob => ob.ObligationItem.Vendor.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            //Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderStringPlural(), obi => obi.WbsElement.WbsElementKey, 150, DhtmlxGridColumnFilterType.Text);
            Add("Cost Authority", ob => ob.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, DhtmlxGridColumnFilterType.Html);
            Add("Budget Object Code", ob => ob.BudgetObjectCode.BudgetObjectCodeName, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Fund Name", ob => ob.Fund.ReclamationFundNumber, 100, DhtmlxGridColumnFilterType.SelectFilterStrict);

            Add("Debit Amount", obi => obi.DebitAmount, 100, DhtmlxGridColumnFormatType.Currency);
            Add("Credit Amount", obi => obi.CreditAmount, 100, DhtmlxGridColumnFormatType.Currency);
            Add("Debit/Credit Total", obi => obi.DebitCreditTotal, 100, DhtmlxGridColumnFormatType.Currency);
            Add("Created On Date", ob => ob.CreatedOnKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
            Add("Posting Date", ob => ob.PostingDateKey.ToStringDate(), 80, DhtmlxGridColumnFilterType.FormattedNumeric);
        }
    }
}