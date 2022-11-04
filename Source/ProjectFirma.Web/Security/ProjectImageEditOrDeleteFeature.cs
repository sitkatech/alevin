﻿/*-----------------------------------------------------------------------
<copyright file="ProjectImageEditOrDeleteFeature.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit/Delete {0} Image", FieldDefinitionEnum.Project)]
    public class ProjectImageEditOrDeleteFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectImage>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectImage> _firmaFeatureWithContextImpl;

        public ProjectImageEditOrDeleteFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectImage>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, ProjectImage contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, ProjectImage contextModelObject)
        {

            var hasPermissionByFirmaSession = HasPermissionByFirmaSession(firmaSession);
            if (!hasPermissionByFirmaSession)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.Project.GetDisplayName()}");
            }

            bool isProposal = contextModelObject.Project.IsProposal();
            bool isPending = contextModelObject.Project.IsPendingProject();

            if (isProposal || isPending)
            {
                return new ProjectCreateFeature().HasPermission(firmaSession, contextModelObject.Project);
            }

            return new ProjectEditAsAdminFeature().HasPermission(firmaSession, contextModelObject.Project);
        }
    }
}
