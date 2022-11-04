﻿/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Text.RegularExpressions;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.CustomPage
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        public int CustomPageID { get; set; }

        [Required]
        [DisplayName("Menu")]
        public int FirmaMenuItemID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.CustomPage.FieldLengths.CustomPageDisplayName)]
        [DisplayName("Page Name")]
        public string CustomPageDisplayName { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.CustomPage.FieldLengths.CustomPageVanityUrl)]
        [DisplayName("Vanity Url")]
        public string CustomPageVanityUrl { get; set; }

        [DisplayName("Anonymous (Public)")]
        public bool ViewableByAnonymous { get; set; }

        [DisplayName("Unassigned")]
        public bool ViewableByUnassigned { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.NormalUser)]
        public bool ViewableByNormal { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectSteward)]
        public bool ViewableByProjectSteward { get; set; }

        [DisplayName("Admin")]
        public bool ViewableByAdmin { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.CustomPage customPage)
        {
            CustomPageID = customPage.CustomPageID;
            FirmaMenuItemID = customPage.FirmaMenuItemID;
            CustomPageDisplayName = customPage.CustomPageDisplayName;
            CustomPageVanityUrl = customPage.CustomPageVanityUrl;

            ViewableByAnonymous = customPage.CustomPageRoles.Any(x => x.RoleID == null);
            ViewableByUnassigned = customPage.CustomPageRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Unassigned.RoleID);
            ViewableByNormal = customPage.CustomPageRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Normal.RoleID);
            ViewableByProjectSteward = customPage.CustomPageRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID);
            ViewableByAdmin = customPage.CustomPageRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Admin.RoleID);
        }

        public void UpdateModel(ProjectFirmaModels.Models.CustomPage customPage, FirmaSession currentFirmaSession, ICollection<CustomPageRole> allCustomPageRoles)
        {
            customPage.FirmaMenuItemID = FirmaMenuItemID;
            customPage.CustomPageDisplayName = CustomPageDisplayName;
            customPage.CustomPageVanityUrl = CustomPageVanityUrl;

            var newCustomPageRoles = new List<CustomPageRole>();

            if (ViewableByAnonymous)
            {
                newCustomPageRoles.Add(new CustomPageRole(customPage.CustomPageID));
            }
            if (ViewableByUnassigned)
            {
                newCustomPageRoles.Add(new CustomPageRole(customPage.CustomPageID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Unassigned.RoleID
                });
            }
            if (ViewableByNormal)
            {
                newCustomPageRoles.Add(new CustomPageRole(customPage.CustomPageID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Normal.RoleID
                });
            }
            if (ViewableByProjectSteward)
            {
                newCustomPageRoles.Add(new CustomPageRole(customPage.CustomPageID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.ProjectSteward.RoleID
                });
            }

            if (ViewableByAdmin)
            {
                newCustomPageRoles.Add(new CustomPageRole(customPage.CustomPageID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Admin.RoleID
                });
            }

            customPage.CustomPageRoles.Merge(newCustomPageRoles,
                allCustomPageRoles,
                (x, y) => x.CustomPageID == y.CustomPageID && x.RoleID == y.RoleID,
                HttpRequestStorage.DatabaseEntities);

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            var existingCustomPages = MultiTenantHelpers.GetCustomPages();
            if (!CustomPageModelExtensions.IsDisplayNameUnique(existingCustomPages, CustomPageDisplayName, CustomPageID))
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, string>("Custom Page with the provided Display Name already exists.", x => x.CustomPageDisplayName));
            }
           
            if (!string.IsNullOrWhiteSpace(CustomPageVanityUrl))
            {
                if (!new Regex("^[a-zA-Z0-9]*$").IsMatch(CustomPageVanityUrl))
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, string>("Vanity Url must not contain any special characters or spaces.", x => x.CustomPageVanityUrl));
                }
                else if (!CustomPageModelExtensions.IsVanityUrlUnique(existingCustomPages, CustomPageVanityUrl, CustomPageID))
                {
                    validationResults.Add(new SitkaValidationResult<EditViewModel, string>("An Custom Page with the provided Vanity Url already exists.", x => x.CustomPageVanityUrl));
                }
            }

            return validationResults;
        }

    }
}
