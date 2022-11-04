﻿/*-----------------------------------------------------------------------
<copyright file="PhotoViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System;
using System.Collections.Generic;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class PhotoViewData : ProjectCreateViewData
    {
        public string AddNewUrl { get; }
        public ImageGalleryViewData ImageGalleryViewData { get; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }

        public PhotoViewData(FirmaSession currentFirmaSession, string galleryName, IEnumerable<FileResourcePhoto> galleryImages, string addNewPhotoUrl, Func<FileResourcePhoto, object> sortFunction, ProjectFirmaModels.Models.Project project, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentFirmaSession, project, ProjectCreateSection.Photos.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            AddNewUrl = addNewPhotoUrl;
            var selectKeyImageUrl =
                SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x =>
                    x.SetKeyPhoto(UrlTemplate.Parameter1Int));
            ImageGalleryViewData = new ImageGalleryViewData(currentFirmaSession, galleryName, galleryImages, true, addNewPhotoUrl, selectKeyImageUrl, true, sortFunction, "Photo");
            ShowCommentsSection = project.IsPendingApproval() || (project.PhotosComment != null &&
                                                                  project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
        }        
    }
}
