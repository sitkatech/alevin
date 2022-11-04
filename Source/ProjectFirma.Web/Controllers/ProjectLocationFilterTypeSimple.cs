﻿/*-----------------------------------------------------------------------
<copyright file="ProjectLocationFilterTypeSimple.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectLocationFilterTypeSimple
    {
        public string DisplayName { get; set; }
        public string ProjectLocationFilterTypeNameWithIdentifier { get; set; }
        public string ProjectLocationFilterTypeName { get; set; }
        public int DisplayGroup { get; set; }
        public int SortOrder { get; set; }

        public ProjectLocationFilterTypeSimple(ProjectLocationFilterType projectLocationFilterType)
        {
            DisplayName = projectLocationFilterType.GetDisplayName();
            ProjectLocationFilterTypeName = projectLocationFilterType.ProjectLocationFilterTypeName;
            ProjectLocationFilterTypeNameWithIdentifier =
                projectLocationFilterType.ProjectLocationFilterTypeNameWithIdentifier;
            DisplayGroup = projectLocationFilterType.DisplayGroup;
            SortOrder = projectLocationFilterType.SortOrder;
        }

        public ProjectLocationFilterTypeSimple(ProjectLocationFilterType projectLocationFilterType, string displayName)
        {
            DisplayName = displayName;
            ProjectLocationFilterTypeName = projectLocationFilterType.ProjectLocationFilterTypeName;
            ProjectLocationFilterTypeNameWithIdentifier =
                projectLocationFilterType.ProjectLocationFilterTypeNameWithIdentifier;
            DisplayGroup = projectLocationFilterType.DisplayGroup;
            SortOrder = projectLocationFilterType.SortOrder;
        }

        public ProjectLocationFilterTypeSimple(ProjectLocationFilterType projectLocationFilterType, int sortOrder)
        {

            DisplayName = projectLocationFilterType.GetDisplayName();
            ProjectLocationFilterTypeName = projectLocationFilterType.ProjectLocationFilterTypeName;
            ProjectLocationFilterTypeNameWithIdentifier =
                projectLocationFilterType.ProjectLocationFilterTypeNameWithIdentifier;
            DisplayGroup = projectLocationFilterType.DisplayGroup;
            SortOrder = sortOrder;
        }
    }
}