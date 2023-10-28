/*-----------------------------------------------------------------------
<copyright file="CostAuthorityEditViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.CostAuthority
{
    public class CostAuthorityEditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int CostAuthorityID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure)]
        [StringLength(ProjectFirmaModels.Models.CostAuthority.FieldLengths.CostAuthorityWorkBreakdownStructure)]
        public string CostAuthorityWorkBreakdownStructure { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.CostAuthorityNumber)]
        [StringLength(ProjectFirmaModels.Models.CostAuthority.FieldLengths.CostAuthorityNumber)]
        public string CostAuthorityNumber { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.AccountStructureDescription)]
        [StringLength(ProjectFirmaModels.Models.CostAuthority.FieldLengths.AccountStructureDescription)]
        public string AccountStructureDescription { get; set; }

        [DisplayName("Job Number")]
        [StringLength(ProjectFirmaModels.Models.CostAuthority.FieldLengths.JobNumber)]
        public string JobNumber { get; set; }

        [DisplayName("Authority")]
        [StringLength(ProjectFirmaModels.Models.CostAuthority.FieldLengths.Authority)]
        public string Authority  { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public CostAuthorityEditViewModel()
        {
        }

        public CostAuthorityEditViewModel(ProjectFirmaModels.Models.CostAuthority costAuthority)
        {
            CostAuthorityID = costAuthority.CostAuthorityID;
            CostAuthorityWorkBreakdownStructure = costAuthority.CostAuthorityWorkBreakdownStructure;
            CostAuthorityNumber = costAuthority.CostAuthorityNumber;
            AccountStructureDescription = costAuthority.AccountStructureDescription;
            JobNumber = costAuthority.JobNumber;
            Authority = costAuthority.Authority;

        }

        public void UpdateModel(ProjectFirmaModels.Models.CostAuthority costAuthority, FirmaSession currentFirmaSession)
        {
            costAuthority.CostAuthorityWorkBreakdownStructure = CostAuthorityWorkBreakdownStructure;
            costAuthority.CostAuthorityNumber = CostAuthorityNumber;
            costAuthority.AccountStructureDescription = AccountStructureDescription;
            costAuthority.JobNumber = JobNumber;
            costAuthority.Authority = Authority;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();


            return errors;
        }
    }
}
