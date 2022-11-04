﻿/*-----------------------------------------------------------------------
<copyright file="EditProjectLocationSimpleViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationSimpleViewModel : FormViewModel, IValidatableObject
    {
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public double? ProjectLocationPointX { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public double? ProjectLocationPointY { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectLocationSimpleTypeEnum ProjectLocationSimpleType { get; set; }

        [DisplayName("Notes")]
        [StringLength(ProjectFirmaModels.Models.Project.FieldLengths.ProjectLocationNotes)]
        public string ProjectLocationNotes { get; set; }

        public bool LocationIsPrivate { get; set; }

        public bool IsAdminProject { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public ProjectLocationSimpleViewModel()
        {
        }

        public ProjectLocationSimpleViewModel(DbGeometry projectLocationPoint, ProjectLocationSimpleTypeEnum projectLocationSimpleType, 
            string projectLocationNotes, bool locationIsPrivate, bool isAdminProject)
        {
            ProjectLocationSimpleType = projectLocationSimpleType;
            if (projectLocationPoint != null)
            {
                ProjectLocationPointX = projectLocationPoint.XCoordinate;
                ProjectLocationPointY = projectLocationPoint.YCoordinate;
            }
            else
            {
                ProjectLocationPointX = null;
                ProjectLocationPointY = null;
            }
            ProjectLocationNotes = projectLocationNotes;
            LocationIsPrivate = locationIsPrivate;
            IsAdminProject = isAdminProject;
        }

        public virtual void UpdateModel(IProject iProject)
        {
            iProject.ProjectLocationSimpleTypeID = ProjectFirmaModels.Models.ProjectLocationSimpleType.ToType(ProjectLocationSimpleType).ProjectLocationSimpleTypeID;
            switch (ProjectLocationSimpleType)
            {                
                case ProjectLocationSimpleTypeEnum.PointOnMap:
                case ProjectLocationSimpleTypeEnum.LatLngInput:
                    // Using ProjectLocationPoint here because location is being updated
                    iProject.ProjectLocationPoint = DbSpatialHelper.MakeDbGeometryFromCoordinates(ProjectLocationPointX.Value, ProjectLocationPointY.Value, LtInfoGeometryConfiguration.DefaultCoordinateSystemId);
                    break;
                case ProjectLocationSimpleTypeEnum.None:
                    // Using ProjectLocationPoint here because location is being updated
                    iProject.ProjectLocationPoint = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            iProject.ProjectLocationNotes = ProjectLocationNotes;
            iProject.LocationIsPrivate = LocationIsPrivate;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            //Simple location is not required for Admin projects
            if (IsAdminProject)
            {
                return new List<ValidationResult>();
            }

            var errors = new List<ValidationResult>();

            if (ProjectLocationSimpleType == ProjectLocationSimpleTypeEnum.PointOnMap && (!ProjectLocationPointX.HasValue || !ProjectLocationPointY.HasValue))
            {
                errors.Add(new SitkaValidationResult<ProjectLocationSimpleViewModel, double?>("Please specify a point on the map", x => x.ProjectLocationPointX));
            }

            if (ProjectLocationSimpleType == ProjectLocationSimpleTypeEnum.LatLngInput)
            {
                if (!ProjectLocationPointY.HasValue || ProjectLocationPointY < -90 || ProjectLocationPointY > 90)
                {
                    errors.Add(new SitkaValidationResult<ProjectLocationSimpleViewModel, double?>("Please enter a valid latitude", x => x.ProjectLocationPointY));
                }
                if (!ProjectLocationPointX.HasValue || ProjectLocationPointX < -180 || ProjectLocationPointX > 180)
                {
                    errors.Add(new SitkaValidationResult<ProjectLocationSimpleViewModel, double?>("Please enter a valid longitude", x => x.ProjectLocationPointX));
                }
            }

            if (ProjectLocationSimpleType == ProjectLocationSimpleTypeEnum.None && string.IsNullOrWhiteSpace(ProjectLocationNotes))
            {
                errors.Add(
                    new SitkaValidationResult<ProjectLocationSimpleViewModel, string>(
                        $"If a location point or general {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} area is not available, explanatory information in the Notes section is required.",
                        x => x.ProjectLocationNotes));
            }

            return errors;
        }
    }
}
