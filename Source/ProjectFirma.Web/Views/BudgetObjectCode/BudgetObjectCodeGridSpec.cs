﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeGridSpec : GridSpec<ProjectFirmaModels.Models.BudgetObjectCode>
    {
        public BudgetObjectCodeGridSpec(FirmaSession currentFirmaSession)
        {
            // These are reclamation-specific, so don't need Tenant customization.
            ObjectNameSingular = "Budget Object Code";
            ObjectNamePlural = "Budget Object Codes";
            SaveFiltersInCookie = true;

            Add("Budget Object Code", boc => UrlTemplate.MakeHrefString(boc.GetDetailUrl(), boc.GetDisplayName()), 100, DhtmlxGridColumnFilterType.Html);
            Add("Budget Object Code Description" , boc => boc.BudgetObjectCodeItemDescription, 300, DhtmlxGridColumnFilterType.Text);
            Add("Budget Object Code Definition", boc => boc.BudgetObjectCodeDefinition, 300, DhtmlxGridColumnFilterType.Text);
            Add("Parent BOC Group", boc =>   boc.BudgetObjectCodeGroup.GetDisplayName(), 150, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("FBMS Year", boc => boc.FbmsYear.ToString(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Expired or Deleted", boc => boc.IsExpiredOrDeleted.ToYesNo(), 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CostType.ToType().ToGridHeaderString(), x => x.GetEffectiveCostType().CostTypeName,
                80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Reportable 1099", boc => boc.Reportable1099?.ToString(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Explanation 1099", boc => boc.Explanation1099?.ToString(), 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
            
            // This is the right idea, but it is painfully slow. We'll need a proc I think.-- SLG 3/23/2020
            //Add("Obligation Item Budgets", boc => GetWbsElementObligationItemBudgetsCount(boc).ToString(), 300, DhtmlxGridColumnFilterType.Numeric);
            //Add("Obligation Item Invoices", boc => boc.WbsElementObligationItemInvoices.Count.ToString(), 300, DhtmlxGridColumnFilterType.Numeric);

            // Is this performant? Nope, it also dogs. We'd definitely need a proc to do this.
            //Add("Has Obligation Item Budgets", boc => boc.WbsElementObligationItemBudgets.Any().ToString(), 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
            //Add("Has Obligation Item Invoices", boc => boc.WbsElementObligationItemInvoices.Any().ToString(), 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }

        private static int GetWbsElementObligationItemBudgetsCount(ProjectFirmaModels.Models.BudgetObjectCode boc)
        {
            var bocWbsElementObligationItemBudgets = boc.WbsElementObligationItemBudgets.ToList();
            return bocWbsElementObligationItemBudgets.Count;
        }
    }
}