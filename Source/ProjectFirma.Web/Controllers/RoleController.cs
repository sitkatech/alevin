﻿/*-----------------------------------------------------------------------
<copyright file="RoleController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Web.Mvc;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Role;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Controllers
{
    public class RoleController : FirmaBaseController
    {
        [UserAdminFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentFirmaSession);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [UserAdminFeature]
        public GridJsonNetJObjectResult<IRole> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var roleSummaries = GetRoleSummaryData();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<IRole>(roleSummaries, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [UserAdminFeature]
        public GridJsonNetJObjectResult<Person> PersonWithRoleGridJsonData(int roleID)
        {
            var role = Role.AllLookupDictionary[roleID];
            var gridSpec = new PersonWithRoleGridSpec();
            var peopleWithRole = HttpRequestStorage.DatabaseEntities.People.Where(x => x.IsActive && x.RoleID == role.RoleID).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Person>(peopleWithRole, gridSpec);
            return gridJsonNetJObjectResult;
        }

        public static List<IRole> GetRoleSummaryData()
        {
            var roles = new List<IRole> {new AnonymousRole()};
            roles.AddRange(Role.All);
            return roles.OrderBy(x => x.RoleDisplayName).ToList();
        }

        [UserAdminFeature]
        public ViewResult Anonymous()
        {
            var role = new AnonymousRole();
            return ViewDetail(role, role.GetFeaturePermissions(typeof(AnonymousUnclassifiedFeature)), role.RoleDisplayName);
        }

        [UserAdminFeature]
        public ViewResult Detail(int roleID)
        {
            var role = Role.AllLookupDictionary[roleID];
            var featurePermissions = role.GetFeaturePermissions(typeof(FirmaFeature));
            featurePermissions.AddRange(role.GetFeaturePermissions(typeof(FirmaFeatureWithContext)));
            return ViewDetail(role, featurePermissions, role.GetRoleDisplayName());
        }

        private ViewResult ViewDetail(IRole role, List<FeaturePermission> featurePermissions, string roleName)
        {
            var viewData = new DetailViewData(CurrentFirmaSession, role, featurePermissions, roleName);
            return RazorView<Detail, DetailViewData>(viewData);
        }
    }
}
