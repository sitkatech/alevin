﻿/*-----------------------------------------------------------------------
<copyright file="EditViewModelValidator.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Data.Entity;
using ProjectFirma.Web.Common;
using FluentValidation;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditViewModelValidator : AbstractValidator<EditViewModel>
    {
        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<ProjectFirmaModels.Models.Organization>> Organizations = () =>
        {
            HttpRequestStorage.DatabaseEntities.Organizations.Load();
            return HttpRequestStorage.DatabaseEntities.AllOrganizations.Local;
        };

        public EditViewModelValidator(IList<ProjectFirmaModels.Models.Organization> organizations) : this()
        {
            Organizations = (() => organizations);
        }

        public EditViewModelValidator()
        {
            RuleFor(x => x.OrganizationName)
                .NotEmpty()
                .WithMessage("Organization name is required")
                .Length(1, ProjectFirmaModels.Models.Organization.FieldLengths.OrganizationName)
                .Must((viewModel, organizationName) => OrganizationModelExtensions.IsOrganizationNameUnique(Organizations(), organizationName, viewModel.OrganizationID))
                .WithMessage(FirmaValidationMessages.OrganizationNameUnique);
            RuleFor(x => x.OrganizationShortName)
                .Must((viewModel, organizationShortName) => OrganizationModelExtensions.IsOrganizationShortNameUniqueIfProvided(Organizations(), organizationShortName, viewModel.OrganizationID))
                .WithMessage(FirmaValidationMessages.OrganizationShortNameUnique);
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Is Active is required");
        }
    }
}
