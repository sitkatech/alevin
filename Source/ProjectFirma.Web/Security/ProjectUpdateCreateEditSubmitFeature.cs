﻿/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateManageFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Create, Edit, and Submit {0} Updates", FieldDefinitionEnum.Project)]
    public class ProjectUpdateCreateEditSubmitFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureForProject _firmaFeatureWithContextImpl;

        public ProjectUpdateCreateEditSubmitFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureForProject(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            var hasPermissionByFirmaSession = HasPermissionByFirmaSession(firmaSession);
            if (!hasPermissionByFirmaSession)
            {
                return new PermissionCheckResult($"You don't have permission to Edit {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()}");
            }

            if (contextModelObject.IsProposal())
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()} cannot be updated through the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update process.");
            }

            if (!contextModelObject.IsUpdatableViaProjectUpdateProcess())
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.GetDisplayName()} is not updateable via the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update process");
            }

            bool hasUpdateAdminPermission = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(firmaSession, contextModelObject).HasPermission;
            bool isUsersProject = contextModelObject.IsMyProject(firmaSession);

            var projectIsEditableByUser = hasUpdateAdminPermission || isUsersProject;

            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {contextModelObject.ProjectID} is not editable by you.");
            }

            return new PermissionCheckResult();
        }
    }
}
