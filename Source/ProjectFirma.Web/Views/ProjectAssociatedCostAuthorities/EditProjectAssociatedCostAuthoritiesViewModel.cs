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
        public List<int> SelectedReclamationCostAuthorityIDs { get; set; }

        public int? PrimaryReclamationCostAuthorityID { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditProjectAssociatedCostAuthoritiesViewModel()
        {
        }

        public EditProjectAssociatedCostAuthoritiesViewModel(ProjectFirmaModels.Models.Project project, Person currentPerson)
        {
            SelectedReclamationCostAuthorityIDs = project.CostAuthorityProjects
                .Select(x => x.ReclamationCostAuthorityID).ToList();
            PrimaryReclamationCostAuthorityID = project.CostAuthorityProjects.SingleOrDefault(x => x.IsPrimaryProjectCawbs)?.ReclamationCostAuthorityID;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project,
            DbSet<CostAuthorityProject> allProjectReclamationCostAuthoritiesInDatabase, Person currentPerson)
        {
            var updatedCostAuthorityIDs = new List<CostAuthorityProject>();

            if (SelectedReclamationCostAuthorityIDs != null)
            {
                updatedCostAuthorityIDs.AddRange(SelectedReclamationCostAuthorityIDs.Select(x =>
                    new CostAuthorityProject(x, project.ProjectID, (x == PrimaryReclamationCostAuthorityID))));
            }

            // Awkward hack: To get around the only-one-primary-CAWBS constraint, we need to clear any
            // existing primaries for the relevant set of existing data, and write them to disk.
            // Otherwise when we write out we'll blow up if there's already a primary and we're changing away
            // from it. We'd like to do better, but aren't sure how. -- SLG & TK 2/14/2020
            if (updatedCostAuthorityIDs.Any())
            {
                var projectReclamationCostAuthoritiesUpdatedIds = updatedCostAuthorityIDs.Select(x => x.ReclamationCostAuthorityID).ToList();
                var onDiskRecordsToTemporarilyUpdate = HttpRequestStorage.DatabaseEntities.CostAuthorityProjects.Where(x => x.ProjectID == project.ProjectID && projectReclamationCostAuthoritiesUpdatedIds.Contains(x.ReclamationCostAuthorityID) && x.IsPrimaryProjectCawbs).ToList();
                onDiskRecordsToTemporarilyUpdate.ForEach(odr => odr.IsPrimaryProjectCawbs = false);
                HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(MultiTenantHelpers.GetTenantAttribute().TenantID);
            }

            // Now we can do the merge again, and this time we keep the new IsPrimaryProjectCawbs.
            project.CostAuthorityProjects.Merge(
                updatedCostAuthorityIDs,
                allProjectReclamationCostAuthoritiesInDatabase.Local,  
                (x, y) => x.ProjectID == y.ProjectID && x.ReclamationCostAuthorityID == y.ReclamationCostAuthorityID, 
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
