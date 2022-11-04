﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectGeospatialAreasViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.Models;
using Microsoft.Ajax.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public class EditProjectGeospatialAreasViewModel : FormViewModel, IValidatableObject
    {
        [DisplayName("Project GeospatialAreas")]
        public IEnumerable<int> GeospatialAreaIDs { get; set; }

        [DisplayName("Notes")]
        [StringLength(ProjectGeospatialAreaTypeNote.FieldLengths.Notes)]
        public string ProjectGeospatialAreaNotes { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectGeospatialAreasViewModel()
        {
        }

        public EditProjectGeospatialAreasViewModel(List<int> geospatialAreaIDs, string projectGeospatialAreaNotes)
        {
            GeospatialAreaIDs = geospatialAreaIDs;
            ProjectGeospatialAreaNotes = projectGeospatialAreaNotes;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Project project, List<ProjectGeospatialArea> currentProjectGeospatialAreas, IList<ProjectGeospatialArea> allProjectGeospatialAreas)
        {
            var newProjectGeospatialAreas = GeospatialAreaIDs?.Select(x => new ProjectGeospatialArea(project.ProjectID, x)).ToList() ?? new List<ProjectGeospatialArea>();
            currentProjectGeospatialAreas.Merge(newProjectGeospatialAreas, allProjectGeospatialAreas, (x, y) => x.ProjectID == y.ProjectID && x.GeospatialAreaID == y.GeospatialAreaID, HttpRequestStorage.DatabaseEntities);
        }

        public void UpdateModel(ProjectUpdateBatch project, List<ProjectGeospatialAreaUpdate> currentProjectGeospatialAreas, IList<ProjectGeospatialAreaUpdate> allProjectGeospatialAreas)
        {
            var newProjectGeospatialAreas = GeospatialAreaIDs?.Select(x => new ProjectGeospatialAreaUpdate(project.ProjectUpdateBatchID, x)).ToList() ?? new List<ProjectGeospatialAreaUpdate>();
            currentProjectGeospatialAreas.Merge(newProjectGeospatialAreas, allProjectGeospatialAreas, (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.GeospatialAreaID == y.GeospatialAreaID, HttpRequestStorage.DatabaseEntities);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var errors = new List<ValidationResult>();
            var noGeospatialAreasSelected = GeospatialAreaIDs == null || GeospatialAreaIDs.Count().Equals(0);

            if (noGeospatialAreasSelected && ProjectGeospatialAreaNotes.IsNullOrWhiteSpace())
            {
                errors.Add(new ValidationResult("Select at least one area, or if information is unavailable/irrelevant provide explanatory information in the Notes section. "));
            }
 
            return errors;
        }
    }
}
