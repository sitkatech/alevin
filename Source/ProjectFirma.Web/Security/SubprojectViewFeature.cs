﻿/*-----------------------------------------------------------------------
<copyright file="SubprojectViewFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Subproject")]
    public class SubprojectViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        public SubprojectViewFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward, Role.Normal })
        {

        }
        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            if (contextModelObject.IsRejected() || contextModelObject.IsProposal() || contextModelObject.IsPendingProject())
            {
                return new ProjectCreateFeature().HasPermission(firmaSession, contextModelObject);
            }
            else
            {
                var hasPermissionByPerson = HasPermissionByFirmaSession(firmaSession);
                if (!hasPermissionByPerson)
                {
                    return new PermissionCheckResult($"You do not have permission to view {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
                }

                var projectIsEditableByUser = new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(firmaSession, contextModelObject).HasPermission || contextModelObject.IsMyProject(firmaSession);
                if (projectIsEditableByUser)
                {
                    return new PermissionCheckResult();
                }

                return new PermissionCheckResult($"You do not have permission to view {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()} for this {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
            }
        }
        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            throw new System.NotImplementedException();
        }

    }
}
