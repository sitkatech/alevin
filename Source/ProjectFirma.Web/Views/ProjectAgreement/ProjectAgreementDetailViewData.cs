/*-----------------------------------------------------------------------
<copyright file="ProjectAgreementDetailViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectFunding
{
    public class ProjectAgreementDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Project Project { get; }
        public bool UserHasProjectAgreementManagePermissions { get; }
        public string AddNewAgreementUrl { get; }
        public List<ProjectFirmaModels.Models.Agreement> ReclamationAgreements { get; }

        public List<ReclamationCostAuthority> SecondaryReclamationCostAuthorityWorkBreakdownStructures { get; }
        public ReclamationCostAuthority PrimaryReclamationCostAuthorityWorkBreakdownStructure { get; }

        public ProjectAgreementDetailViewData(FirmaSession currentFirmaSession, 
                                              ProjectFirmaModels.Models.Project project,
                                              bool userHasProjectAgreementManagePermissions
                                              /*, List<IFundingSourceBudgetAmount> fundingSourceRequestAmounts*/) : base(currentFirmaSession)
        {
            Project = project;
            UserHasProjectAgreementManagePermissions = userHasProjectAgreementManagePermissions;
            AddNewAgreementUrl = "NO_URL_YET";

            var costAuthorities = project.ReclamationCostAuthorityProjects.Select(x => x.ReclamationCostAuthority)
                .ToList();

            ReclamationAgreements = costAuthorities.SelectMany(ca =>
                ca.AgreementReclamationCostAuthorities.Select(rarca => rarca.ReclamationAgreement)).ToList();

            SecondaryReclamationCostAuthorityWorkBreakdownStructures = project.ReclamationCostAuthorityProjects.Where(x => !x.IsPrimaryProjectCawbs).Select(rcap => rcap.ReclamationCostAuthority).ToList();
            PrimaryReclamationCostAuthorityWorkBreakdownStructure = project.ReclamationCostAuthorityProjects.SingleOrDefault(x => x.IsPrimaryProjectCawbs)?.ReclamationCostAuthority;

        }
    }

    /*
    public class ProjectFundingCalculatedCosts
    {
        public decimal? TotalOperatingCostInYearOfExpenditure { get; }
        public int? StartYearForTotalCostCalculation { get; }

        public ProjectFundingCalculatedCosts(ProjectFirmaModels.Models.Project project)
        {
            TotalOperatingCostInYearOfExpenditure = project.CalculateTotalRemainingOperatingCost();
            StartYearForTotalCostCalculation = project.StartYearForTotalCostCalculations();
        }
    }
    */
}
