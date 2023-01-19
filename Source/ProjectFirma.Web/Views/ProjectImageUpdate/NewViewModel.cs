﻿/*-----------------------------------------------------------------------
<copyright file="NewViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Web;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectImageUpdate
{
    public class NewViewModel : EditViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("Image File")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase FileResourceData { get; set; }

        public NewViewModel()
        {
            IncludeInFactSheet = true;
        }

        public override void UpdateModel(ProjectFirmaModels.Models.ProjectImageUpdate projectImageUpdate, FirmaSession currentFirmaSession)
        {
            base.UpdateModel(projectImageUpdate, currentFirmaSession);
            projectImageUpdate.FileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentFirmaSession);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            FileResourceModelExtensions.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            return errors;
        }
    }
}
