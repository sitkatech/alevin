﻿/*-----------------------------------------------------------------------
<copyright file="CustomAttributesViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Views.Shared.ProjectControls;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectCustomAttributesViewModel : EditProjectCustomAttributesViewModel
    {
        [DisplayName("Reviewer Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.CustomAttributesComment)]
        public string Comments { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ProjectCustomAttributesViewModel()
        {
        }

        public ProjectCustomAttributesViewModel(ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession) : base(projectUpdateBatch, currentFirmaSession)
        {
            Project = projectUpdateBatch.ProjectUpdate;
            Comments = projectUpdateBatch.CustomAttributesComment;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession)
        {
            ProjectCustomAttributes?.UpdateModel(projectUpdateBatch.ProjectUpdate, currentFirmaSession);
        }
    }    
}
