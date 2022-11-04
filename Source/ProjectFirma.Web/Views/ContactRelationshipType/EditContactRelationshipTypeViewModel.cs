﻿/*-----------------------------------------------------------------------
<copyright file="EditContactRelationshipTypeViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Net;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ContactRelationshipType
{
    public class EditContactRelationshipTypeViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int RelationshipTypeID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.ContactRelationshipType.FieldLengths.ContactRelationshipTypeName)]
        [DisplayName("Name")]
        public string ContactRelationshipTypeName { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ContactRelationshipTypeAcceptsMultipleValues)]
        public bool ContactRelationshipTypeAcceptsMultipleValues { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.IsContactRelationshipTypeRequired)]
        public bool? IsContactRelationshipTypeRequired { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.CanContactTypeManageProject)]
        public bool? CanManageProject { get; set; }

        [DisplayName("If Required, minimum Project Stage Contact must be set by")]
        public int? IsContactRelationshipRequiredMinimumProjectStageID { get; set; }

        [Required]
        [DisplayName("Relationship Type Description")]
        public string ContactRelationshipTypeDescription { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditContactRelationshipTypeViewModel()
        {
        }

        public EditContactRelationshipTypeViewModel(ProjectFirmaModels.Models.ContactRelationshipType contactRelationshipType)
        {
            RelationshipTypeID = contactRelationshipType.ContactRelationshipTypeID;
            ContactRelationshipTypeName = contactRelationshipType.ContactRelationshipTypeName;
            ContactRelationshipTypeAcceptsMultipleValues = contactRelationshipType.ContactRelationshipTypeAcceptsMultipleValues;
            IsContactRelationshipTypeRequired = contactRelationshipType.IsContactRelationshipTypeRequired;
            IsContactRelationshipRequiredMinimumProjectStageID = contactRelationshipType.IsContactRelationshipRequiredMinimumProjectStageID;
            ContactRelationshipTypeDescription = contactRelationshipType.ContactRelationshipTypeDescription;
            CanManageProject = contactRelationshipType.CanManageProject;
        }

        public void UpdateModel(ProjectFirmaModels.Models.ContactRelationshipType contactRelationshipType)
        {
            contactRelationshipType.ContactRelationshipTypeName = ContactRelationshipTypeName;
            contactRelationshipType.ContactRelationshipTypeAcceptsMultipleValues = ContactRelationshipTypeAcceptsMultipleValues;

            contactRelationshipType.IsContactRelationshipTypeRequired = IsContactRelationshipTypeRequired ?? false;
            contactRelationshipType.IsContactRelationshipRequiredMinimumProjectStageID = IsContactRelationshipRequiredMinimumProjectStageID;
            contactRelationshipType.ContactRelationshipTypeDescription = ContactRelationshipTypeDescription;
            contactRelationshipType.CanManageProject = CanManageProject ?? false;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var contactRelationshipTypes = HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.ToList();
            if (!contactRelationshipTypes.IsContactRelationshipTypeNameUnique(ContactRelationshipTypeName, RelationshipTypeID))
            {
                yield return new SitkaValidationResult<EditContactRelationshipTypeViewModel, string>("Name already exists.",
                    x => x.ContactRelationshipTypeName);
            }

            // If we are trying to switch to single-valued, we need to make sure there are no pre-existing multiple values
            if (!ContactRelationshipTypeAcceptsMultipleValues)
            {
                var contactRelationshipType =
                    HttpRequestStorage.DatabaseEntities.ContactRelationshipTypes.SingleOrDefault(x =>
                        x.ContactRelationshipTypeID == RelationshipTypeID);
                if (contactRelationshipType != null)
                {
                    var projectUpdateContactsWithThisRelationshipType = contactRelationshipType.ProjectContactUpdates.Select(x => x.ProjectUpdateBatchID).ToList();
                    if (projectUpdateContactsWithThisRelationshipType.Count >
                        projectUpdateContactsWithThisRelationshipType.Distinct().Count())
                    {
                        yield return new SitkaValidationResult<EditContactRelationshipTypeViewModel, bool>(
                            $"There are {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Updates that have more than one contact selected with this Contact Type. Please fix those {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Updates before setting '{FieldDefinitionEnum.ContactRelationshipTypeAcceptsMultipleValues.ToType().FieldDefinitionDisplayName}' to true.", 
                            x => x.ContactRelationshipTypeAcceptsMultipleValues);
                    }

                    var projectContactsWithThisRelationshipType =
                        contactRelationshipType.ProjectContacts.Select(x => x.ProjectID).ToList();
                    if (projectContactsWithThisRelationshipType.Count >
                        projectContactsWithThisRelationshipType.Distinct().Count())
                    {
                        /*
                         * To find the Projects that have more than one of a particular ContactRelationshipType:
                         * select ProjectID, count(*) as ProjectIDCount from dbo.ProjectContact as pc 
                            where pc.ContactRelationshipTypeID = 4
                            group by ProjectID
                            order by count(*) desc
                         */
                        yield return new SitkaValidationResult<EditContactRelationshipTypeViewModel, bool>(
                            $"There are {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} that have more than one contact selected with this Contact Type. Please fix those {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} before setting '{FieldDefinitionEnum.ContactRelationshipTypeAcceptsMultipleValues.ToType().FieldDefinitionDisplayName}' to true.",
                            x => x.ContactRelationshipTypeAcceptsMultipleValues);
                    }
                }
            }

        }
    }
}
