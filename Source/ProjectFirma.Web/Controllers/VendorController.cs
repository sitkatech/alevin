/*-----------------------------------------------------------------------
<copyright file="OrganizationController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Models;
using ProjectFirma.Web.Views.Vendor;

namespace ProjectFirma.Web.Controllers
{
    public class VendorController : FirmaBaseController
    {
        [VendorViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.VendorList.GetFirmaPage();
            var gridDataUrl = SitkaRoute<VendorController>.BuildUrlFromExpression(x => x.VendorIndexGridJsonData());
            var viewData = new VendorIndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl);

            return RazorView<VendorIndex, VendorIndexViewData>(viewData);
        }

        [VendorViewFeature]
        public GridJsonNetJObjectResult<Vendor> VendorIndexGridJsonData()
        {
            var gridSpec = new VendorIndexGridSpec(CurrentFirmaSession);
            List<Vendor> vendors = HttpRequestStorage.DatabaseEntities.Vendors.ToList();
            List<Vendor> orderedVendors = vendors.OrderBy(v => v.VendorText).ToList();

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Vendor>(orderedVendors, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [VendorViewFeature]
        public ViewResult Detail(VendorPrimaryKey vendorPrimaryKey)
        {
            var vendor = vendorPrimaryKey.EntityObject;
            var viewData = new VendorDetailViewData(CurrentFirmaSession, vendor);
            return RazorView<VendorDetail, VendorDetailViewData>(viewData);
        }

    }
}
