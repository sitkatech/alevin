/*-----------------------------------------------------------------------
<copyright file="EditViewModelValidator.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using ProjectFirma.Web.Common;
using FluentValidation;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementEditViewModelValidator : AbstractValidator<AgreementEditViewModel>
    {
        // Validators are singletons, so this list must be initialized every time.
        public Func<IList<ProjectFirmaModels.Models.Agreement>> Agreements = () =>
        {
            HttpRequestStorage.DatabaseEntities.Agreements.Load();
            return HttpRequestStorage.DatabaseEntities.Agreements.Local;
        };

        public AgreementEditViewModelValidator(IList<ProjectFirmaModels.Models.Agreement> agreements) : this()
        {
            Agreements = (() => agreements);
        }

        public AgreementEditViewModelValidator()
        {
            throw new NotImplementedException("Need to implement this oddball validator pattern");
            /*
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
            */
        }
    }
}
