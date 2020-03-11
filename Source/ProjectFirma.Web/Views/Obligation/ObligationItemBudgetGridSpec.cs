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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Obligation
{
    public class ObligationItemBudgetGridSpec : GridSpec<WbsElementObligationItemBudget>
    {
        public ObligationItemBudgetGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "Obligation Item Invoice";
            ObjectNamePlural = "Obligation Item Invoices";
            SaveFiltersInCookie = true;

            Add("Obligation Number Key", ob => UrlTemplate.MakeHrefString(ob.ObligationItem.ObligationNumber.GetDetailUrl(), ob.ObligationItem.ObligationNumber.ObligationNumberKey), 150, DhtmlxGridColumnFilterType.Text);
            Add("Obligation Item Key", ob => ob.ObligationItem.ObligationItemKey, 80, DhtmlxGridColumnFilterType.Numeric);
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderStringPlural(), ob => ob.WbsElement.WbsElementKey, 150, DhtmlxGridColumnFilterType.Text);

            Add("Obligation", ob => ob.Obligation, 100, DhtmlxGridColumnFormatType.Currency);
            Add("Goods Receipt", ob => ob.GoodsReceipt, 100, DhtmlxGridColumnFilterType.Text);
            Add("Invoiced", ob => ob.Invoiced, 100, DhtmlxGridColumnFormatType.Currency);
            Add("Disbursed", ob => ob.Disbursed, 100, DhtmlxGridColumnFormatType.Currency);
            Add("Unexpended Balance", ob => ob.UnexpendedBalance, 100, DhtmlxGridColumnFormatType.Currency);

            Add("Cost Authority", ob => ob.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 150, DhtmlxGridColumnFilterType.Html);
        }
    }
}