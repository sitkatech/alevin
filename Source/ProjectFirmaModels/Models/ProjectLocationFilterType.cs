﻿/*-----------------------------------------------------------------------
<copyright file="ProjectLocationFilterType.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectLocationFilterType
    {
        public abstract Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues);
    }

    public partial class ProjectLocationFilterTypeTaxonomyTrunk
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunkID);
        }
    }

    public partial class ProjectLocationFilterTypeTaxonomyBranch
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyLeaf.TaxonomyBranchID);
        }
    }

    public partial class ProjectLocationFilterTypeTaxonomyLeaf
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.TaxonomyLeaf.TaxonomyLeafID);
        }
    }

    public partial class ProjectLocationFilterTypeClassification
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Intersect(project.GetProjectClassificationsForMap().Select(x => x.ClassificationID)).Any();
        }
    }

    public partial class ProjectLocationFilterTypeProjectStage
    {
        public override Expression<Func<Project, bool>> GetFilterFunction(List<int> filterValues)
        {
            return project => filterValues.Contains(project.ProjectStage.ProjectStageID);
        }
    }
  
}
