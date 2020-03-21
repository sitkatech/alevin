/*-----------------------------------------------------------------------
<copyright file="FundDetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.DhtmlWrappers;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Obligation;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Fund
{
    public class FundDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Fund Fund { get; }
        public string FundIndexUrl { get; }

        public ObligationItemInvoiceGridSpec ObligationItemInvoiceGridSpec { get; }
        public string ObligationItemInvoiceGridName { get; }
        public string ObligationItemInvoiceGridDataUrl { get; }

        public ObligationItemBudgetGridSpec ObligationItemBudgetGridSpec { get; }
        public string ObligationItemBudgetGridName { get; }
        public string ObligationItemBudgetGridDataUrl { get; }

        public FundDetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Fund fund) : base(currentFirmaSession)
        {
            PageTitle = $"Fund Number: {fund.ReclamationFundNumber}";
            EntityName = "Fund Detail";
            
            Fund = fund;
            FundIndexUrl = SitkaRoute<FundController>.BuildUrlFromExpression(c => c.FundIndex());

            ObligationItemInvoiceGridName = "fundItemInvoices";
            ObligationItemInvoiceGridSpec = new ObligationItemInvoiceGridSpec(currentFirmaSession);
            ObligationItemInvoiceGridDataUrl = SitkaRoute<FundController>.BuildUrlFromExpression(fc => fc.ObligationItemInvoiceGridOnFundDetailJsonData(fund));
             
            ObligationItemBudgetGridName = "fundItemBudgets";
            ObligationItemBudgetGridSpec = new ObligationItemBudgetGridSpec(currentFirmaSession);
            ObligationItemBudgetGridDataUrl = SitkaRoute<FundController>.BuildUrlFromExpression(fc => fc.ObligationItemBudgetGridOnFundDetailJsonData(fund));
        }


    }
}
