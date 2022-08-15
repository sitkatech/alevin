/*-----------------------------------------------------------------------
<copyright file="SubprojectBasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Shared.ProjectControls;

namespace ProjectFirma.Web.Views.Subproject
{
    public class SubprojectBasicsViewData
    {
        public ProjectFirmaModels.Models.Subproject Subproject { get; }
        //public ProjectTaxonomyViewData ProjectTaxonomyViewData { get; }
        public TenantAttribute TenantAttribute { get; set; }
        public IEnumerable<ProjectFirmaModels.Models.TaxonomyLeaf> SecondaryTaxonomyLeaves;
        //public bool IsNotTaxonomyLevelLeaf { get; }
        //public bool IsNotTaxonomyLevelLeafOrBranch { get; }

        public SubprojectBasicsViewData(ProjectFirmaModels.Models.Subproject subproject,
            bool userHasProjectBudgetManagePermissions)
        {
            Subproject = subproject;
            //IsNotTaxonomyLevelLeaf = !MultiTenantHelpers.IsTaxonomyLevelLeaf();
            //IsNotTaxonomyLevelLeafOrBranch = !MultiTenantHelpers.IsTaxonomyLevelBranch() && IsNotTaxonomyLevelLeaf;
            //ProjectTaxonomyViewData = new ProjectTaxonomyViewData(project, taxonomyLevel);
            //TenantAttribute = tenantAttribute;

            //if (tenantAttribute.EnableSecondaryProjectTaxonomyLeaf)
            //{
            //    SecondaryTaxonomyLeaves = Project.SecondaryProjectTaxonomyLeafs.Select(x => x.TaxonomyLeaf).OrderBy(x => x.GetDisplayName());
            //}
        }
        
    }
}
