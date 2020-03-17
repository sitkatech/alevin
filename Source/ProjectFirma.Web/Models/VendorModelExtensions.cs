/*-----------------------------------------------------------------------
<copyright file="VendorModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class VendorModelExtensions
    {
        public static string GetDisplayName(this Vendor vendor)
        {
            if (vendor == null)
            {
                return null;
            }
            return $"{vendor.VendorText}";
        }

        public static HtmlString GetDisplayNameAsUrl(this Vendor Vendor)
        {
            return Vendor != null ? UrlTemplate.MakeHrefString(Vendor.GetDetailUrl(), Vendor.GetDisplayName()) : new HtmlString(null);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<VendorController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Vendor vendor)
        {
            return vendor == null ? "" : SummaryUrlTemplate.ParameterReplace(vendor.VendorID);
        }
    }
}
