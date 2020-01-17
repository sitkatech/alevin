﻿/*-----------------------------------------------------------------------
<copyright file="ProjectSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirmaModels.Models
{
    public class ProjectSimple
    {
        public int ProjectID { get; set; }
        public string DisplayName { get; set; }
        public int TaxonomyLeafID { get; set; }

        public ProjectSimple(Project project)
        {
            ProjectID = project.ProjectID;
            DisplayName = project.GetDisplayName();
            TaxonomyLeafID = project.TaxonomyLeafID;
        }

        public ProjectSimple(int projectID, string displayName)
        {
            ProjectID = projectID;
            DisplayName = displayName;
        }
    }
}
