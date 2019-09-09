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
        public List<ReclamationAgreement> ReclamationAgreements { get; }
        //public ProjectFundingCalculatedCosts ProjectFundingCalculatedCosts { get; }
        //public List<IFundingSourceBudgetAmount> FundingSourceRequestAmounts { get; }

        public ProjectAgreementDetailViewData(Person currentPerson, 
                                              ProjectFirmaModels.Models.Project project,
                                              bool userHasProjectAgreementManagePermissions
                                              /*, List<IFundingSourceBudgetAmount> fundingSourceRequestAmounts*/) : base(currentPerson)
        {
            Project = project;
            UserHasProjectAgreementManagePermissions = userHasProjectAgreementManagePermissions;
            AddNewAgreementUrl = "NO_URL_YET";
            ReclamationAgreements = project.ReclamationAgreementProjects.Select(rap => rap.ReclamationAgreement).ToList();

            //FundingSourceRequestAmounts = fundingSourceRequestAmounts;
            //ProjectFundingCalculatedCosts = new ProjectFundingCalculatedCosts(project);
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
