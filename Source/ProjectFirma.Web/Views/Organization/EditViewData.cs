﻿/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> OrganizationTypes;
        public readonly IEnumerable<SelectListItem> PossiblePrimaryContactPeople;
        public readonly bool IsInKeystone;
        public readonly string RequestOrganizationChangeUrl;
        public readonly bool IsSitkaAdmin;
        public readonly bool UserHasAdminPermissions;
        public readonly Guid? OrganizationGuid;
        public readonly string SyncWithKeystoneUrl;

        public EditViewData(IEnumerable<SelectListItem> organizationTypes, IEnumerable<SelectListItem> possiblePrimaryContactPeople, bool isInKeystone, string requestOrganizationChangeUrl, bool isSitkaAdmin, bool userHasAdminPermissions, Guid? organizationGuid)
        {
            OrganizationTypes = organizationTypes;
            PossiblePrimaryContactPeople = possiblePrimaryContactPeople;
            IsInKeystone = isInKeystone;
            RequestOrganizationChangeUrl = requestOrganizationChangeUrl;
            IsSitkaAdmin = isSitkaAdmin;
            UserHasAdminPermissions = userHasAdminPermissions;
            OrganizationGuid = organizationGuid;
            SyncWithKeystoneUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.SyncWithKeystone(UrlTemplate.Parameter1String));
        }
    }
}
