﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualFromProjectManageFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    [SecurityFeatureDescription("Edit {0} Actual Value From Subproject", FieldDefinitionEnum.PerformanceMeasure)]
    public class PerformanceMeasureActualFromSubprojectManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Subproject>
    {
        private readonly FirmaFeatureWithContextImpl<Subproject> _firmaFeatureWithContextImpl;

        public PerformanceMeasureActualFromSubprojectManageFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Subproject>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(FirmaSession firmaSession, Subproject contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Subproject contextModelObject)
        {
            if (contextModelObject.SubprojectStage == ProjectStage.PlanningDesign)
            {
                return new PermissionCheckResult(
                    $"Reported {FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized()} are not relevant for subprojects in the Planning/Design stage.");
            }
            return new PermissionCheckResult();
        }
    }
}
