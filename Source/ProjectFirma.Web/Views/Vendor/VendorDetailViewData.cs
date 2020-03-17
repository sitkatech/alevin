/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Obligation;

namespace ProjectFirma.Web.Views.Vendor
{
    public class VendorDetailViewData : FirmaViewData
    {
        public readonly ProjectFirmaModels.Models.Vendor Vendor;
        public readonly string VendorIndexUrl;

        public ObligationItemInvoiceGridSpec ObligationItemInvoiceGridSpec { get; }
        public string ObligationItemInvoiceGridName { get; }
        public string ObligationItemInvoiceGridDataUrl { get; }

        public ObligationItemBudgetGridSpec ObligationItemBudgetGridSpec { get; }
        public string ObligationItemBudgetGridName { get; }
        public string ObligationItemBudgetGridDataUrl { get; }


        public VendorDetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Vendor vendor) : base(currentFirmaSession)
        {
            Vendor = vendor;
            PageTitle = vendor.GetDisplayName();
            EntityName = $"{FieldDefinitionEnum.Vendor.ToType().GetFieldDefinitionLabel()}";
            VendorIndexUrl = SitkaRoute<VendorController>.BuildUrlFromExpression(c => c.Index());

            ObligationItemInvoiceGridName = "obligationItemInvoices";
            ObligationItemInvoiceGridSpec = new ObligationItemInvoiceGridSpec(currentFirmaSession);
            ObligationItemInvoiceGridDataUrl = SitkaRoute<VendorController>.BuildUrlFromExpression(oc => oc.VendorObligationItemInvoiceGridJsonData(vendor));

            ObligationItemBudgetGridName = "obligationItemBudgets";
            ObligationItemBudgetGridSpec = new ObligationItemBudgetGridSpec(currentFirmaSession);
            ObligationItemBudgetGridDataUrl = SitkaRoute<VendorController>.BuildUrlFromExpression(oc => oc.VendorObligationItemBudgetGridJsonData(vendor));
        }
    }
}
