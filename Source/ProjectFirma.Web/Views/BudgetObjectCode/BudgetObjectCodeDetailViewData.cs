/*-----------------------------------------------------------------------
<copyright file="BudgetObjectCodeDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.BudgetObjectCode
{
    public class BudgetObjectCodeDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.BudgetObjectCode BudgetObjectCode { get; }
        public string BudgetObjectCodeIndexUrl { get; }

        public ObligationItemInvoiceGridSpec ObligationItemInvoiceGridSpec { get; }
        public string ObligationItemInvoiceGridName { get; }
        public string ObligationItemInvoiceGridDataUrl { get; }

        public ObligationItemBudgetGridSpec ObligationItemBudgetGridSpec { get; }
        public string ObligationItemBudgetGridName { get; }
        public string ObligationItemBudgetGridDataUrl { get; }

        public BudgetObjectCodeDetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.BudgetObjectCode budgetObjectCode) : base(currentFirmaSession)
        {
            PageTitle = $"Budget Object Code: {budgetObjectCode.GetDisplayName()}";
            EntityName = "Budget Object Code Detail";

            BudgetObjectCode = budgetObjectCode;
            BudgetObjectCodeIndexUrl = SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(c => c.BudgetObjectCodeIndex());

            ObligationItemInvoiceGridName = "budgetObjectCodeItemInvoices";
            ObligationItemInvoiceGridSpec = new ObligationItemInvoiceGridSpec(currentFirmaSession);
            ObligationItemInvoiceGridDataUrl = SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(fc => fc.ObligationItemInvoiceGridOnBudgetObjectCodeDetailJsonData(budgetObjectCode));

            ObligationItemBudgetGridName = "budgetObjectCodeItemBudgets";
            ObligationItemBudgetGridSpec = new ObligationItemBudgetGridSpec(currentFirmaSession);
            ObligationItemBudgetGridDataUrl = SitkaRoute<BudgetObjectCodeController>.BuildUrlFromExpression(fc => fc.ObligationItemBudgetGridOnBudgetObjectCodeDetailJsonData(budgetObjectCode));
        }
    }
}
