﻿/*-----------------------------------------------------------------------
<copyright file="EditBasicsViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Views.ProjectFactSheet
{
    public class EditBasicsViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int? TenantID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ShowLeadImplementerLogoOnFactSheet)]
        public bool ShowLeadImplementerLogoOnFactSheet { get; set; }

        [DisplayName("Show Photo Credit on Fact Sheet?")]
        public bool ShowPhotoCreditOnFactSheet { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ShowExpectedPerformanceMeasuresOnFactSheet)]
        public bool ShowExpectedPerformanceMeasuresOnFactSheet { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditBasicsViewModel()
        {
        }

        public EditBasicsViewModel(ProjectFirmaModels.Models.Tenant tenant, TenantAttribute tenantAttribute)
        {
            TenantID = tenant.TenantID;
            ShowLeadImplementerLogoOnFactSheet = tenantAttribute.ShowLeadImplementerLogoOnFactSheet;
            ShowPhotoCreditOnFactSheet = tenantAttribute.ShowPhotoCreditOnFactSheet;
            ShowExpectedPerformanceMeasuresOnFactSheet = tenantAttribute.ShowExpectedPerformanceMeasuresOnFactSheet;
        }

        public void UpdateModel(TenantAttribute tenantAttribute, FirmaSession currentFirmaSession)
        {
            tenantAttribute.ShowLeadImplementerLogoOnFactSheet = ShowLeadImplementerLogoOnFactSheet;
            tenantAttribute.ShowPhotoCreditOnFactSheet = ShowPhotoCreditOnFactSheet;
            tenantAttribute.ShowExpectedPerformanceMeasuresOnFactSheet = ShowExpectedPerformanceMeasuresOnFactSheet;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}