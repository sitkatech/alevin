/*-----------------------------------------------------------------------
<copyright file="TaxonomyLeaf.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirmaModels.Models
{
    public partial class TaxonomyLeaf : IAuditableEntity, IHaveASortOrder
    {
        public void SetSortOrder(int? value) => TaxonomyLeafSortOrder = value;

        public int? GetSortOrder() => TaxonomyLeafSortOrder;
        public int GetID() => TaxonomyLeafID;

        public string GetDisplayName()
        {
            var taxonomyPrefix = string.IsNullOrWhiteSpace(TaxonomyLeafCode) ? string.Empty : $"{TaxonomyLeafCode}: ";
            return $"{taxonomyPrefix}{TaxonomyLeafName}";
        }

        public string GetAuditDescriptionString() => TaxonomyLeafName;

        public List<IGrouping<PerformanceMeasure, TaxonomyLeafPerformanceMeasure>> GetTaxonomyTierPerformanceMeasures()
        {
            return TaxonomyLeafPerformanceMeasures.GroupBy(x => x.PerformanceMeasure).ToList();
        }

        public List<Project> GetProjects()
        {
            // Notice we do NOT filter by IsPrimaryProjectCawbs when navigating in this direction.
            var costAuthorityProjects = this.CostAuthorities.SelectMany(ca => ca.CostAuthorityProjects).ToList();
            var projectsViaCostAuthorities = costAuthorityProjects.Select(cap => cap.Project).Distinct().ToList();

            // Also navigate looking for overrides
            var projectsViaOverrides = this.ProjectsWhereYouAreTheOverrideTaxonomyLeaf.Distinct().ToList();

            // We think there should be no overlap between these two sets! If there is, we something is wrong and we need 
            // to have a look.
            var costAuthorityProjectIDs = projectsViaCostAuthorities.Select(p => p.ProjectID).ToList();
            var overrideProjectIDs = projectsViaOverrides.Select(p => p.ProjectID).ToList();
            bool hasUnexpectedOverlap = costAuthorityProjectIDs.Intersect(overrideProjectIDs).Any();
            Check.Ensure(!hasUnexpectedOverlap, "Unexpected overlap between routes for Taxonomy leafs.");

            // Return the complete set
            var allRelevantProjects = projectsViaCostAuthorities.Union(projectsViaOverrides).ToList();
            return allRelevantProjects;
        }
    }
}
