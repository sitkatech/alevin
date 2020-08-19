/*-----------------------------------------------------------------------
<copyright file="EditContactsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectAssociatedCostAuthorities
{
    public class EditProjectAssociatedCostAuthoritiesViewModel : FormViewModel, IValidatableObject
    {

        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure)]
        public List<int> SelectedCostAuthorityIDs { get; set; }

        public int? PrimaryCostAuthorityID { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditProjectAssociatedCostAuthoritiesViewModel()
        {
        }

        public EditProjectAssociatedCostAuthoritiesViewModel(ProjectFirmaModels.Models.Project project, Person currentPerson)
        {
            SelectedCostAuthorityIDs = project.CostAuthorityProjects
                .Select(x => x.CostAuthorityID).ToList();
            PrimaryCostAuthorityID = project.CostAuthorityProjects.SingleOrDefault(x => x.IsPrimaryProjectCawbs)?.CostAuthorityID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            DbSet<CostAuthorityProject> allProjectReclamationCostAuthoritiesInDatabase, Person currentPerson)
        {
            var updatedCostAuthorityIDs = new List<CostAuthorityProject>();

            if (SelectedCostAuthorityIDs != null)
            {
                updatedCostAuthorityIDs.AddRange(SelectedCostAuthorityIDs.Select(x =>
                    new CostAuthorityProject(x, project.ProjectID, (x == PrimaryCostAuthorityID))));

                //TK & SLG 8/18/20202 -- If we already have an override but are setting a new PrimaryCostAuthorityID, then we need to remove the override to prevent data issues.
                if (PrimaryCostAuthorityID != null && project.OverrideTaxonomyLeafID != null)
                {
                    project.OverrideTaxonomyLeafID = null;
                }
            }

            // Awkward hack: To get around the only-one-primary-CAWBS constraint, we need to clear any
            // existing primaries for the relevant set of existing data, and write them to disk.
            // Otherwise when we write out we'll blow up if there's already a primary and we're changing away
            // from it. We'd like to do better, but aren't sure how. -- SLG & TK 2/14/2020
            if (updatedCostAuthorityIDs.Any())
            {
                var projectReclamationCostAuthoritiesUpdatedIds = updatedCostAuthorityIDs.Select(x => x.CostAuthorityID).ToList();
                var onDiskRecordsToTemporarilyUpdate = HttpRequestStorage.DatabaseEntities.CostAuthorityProjects.Where(x => x.ProjectID == project.ProjectID && projectReclamationCostAuthoritiesUpdatedIds.Contains(x.CostAuthorityID) && x.IsPrimaryProjectCawbs).ToList();
                onDiskRecordsToTemporarilyUpdate.ForEach(odr => odr.IsPrimaryProjectCawbs = false);
                HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(MultiTenantHelpers.GetTenantAttributeFromCache().TenantID);
            }

            // Now we can do the merge again, and this time we keep the new IsPrimaryProjectCawbs.
            project.CostAuthorityProjects.Merge(
                updatedCostAuthorityIDs,
                allProjectReclamationCostAuthoritiesInDatabase.Local,  
                (x, y) => x.ProjectID == y.ProjectID && x.CostAuthorityID == y.CostAuthorityID, 
                (x, y) => x.IsPrimaryProjectCawbs = y.IsPrimaryProjectCawbs,
                HttpRequestStorage.DatabaseEntities);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();
            
            return errors;
        }
    }
}
