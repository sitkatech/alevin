﻿/*-----------------------------------------------------------------------
<copyright file="CustomPageManageFeature.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Custom Page Content")]
    public class CustomPageViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<CustomPage>
    {
        private readonly FirmaFeatureWithContextImpl<CustomPage> _firmaFeatureWithContextImpl;

        public CustomPageViewFeature()
            : base(new List<Role>())
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<CustomPage>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, CustomPage contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, CustomPage contextModelObject)
        {
            var viewTypeRoles = contextModelObject.CustomPageRoles;
            var isVisible = firmaSession.IsAnonymousUser() && viewTypeRoles.Any(x => x.Role == null) ||
                            !firmaSession.IsAnonymousUser() && viewTypeRoles.Select(x => x.Role).Contains(firmaSession.Role) ||
                            viewTypeRoles.Any() && new FirmaAdminFeature().HasPermissionByFirmaSession(firmaSession) ||
                            new SitkaAdminFeature().HasPermissionByFirmaSession(firmaSession);
            if (isVisible)
            {
                return new PermissionCheckResult();
            }

            return new PermissionCheckResult("Does not have custom page view privileges");
        }
    }
}
