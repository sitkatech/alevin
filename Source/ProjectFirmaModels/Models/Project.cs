/*-----------------------------------------------------------------------
<copyright file="Project.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirmaModels.Models
{
    public partial class Project : IAuditableEntity, IProject
    {
        public int GetEntityID() => ProjectID;

        public string GetAuditDescriptionString() => ProjectName;

        public string GetDisplayName() => ProjectName;

        public TaxonomyLeaf GetTaxonomyLeaf()
        {
            var primaryCostAuthorityProject = this.CostAuthorityProjects.SingleOrDefault(cap => cap.IsPrimaryProjectCawbs);
            TaxonomyLeaf taxonomyLeafViaCostAuthority = primaryCostAuthorityProject?.CostAuthority?.TaxonomyLeaf;
            TaxonomyLeaf taxonomyLeafViaOverrideOnProject = this.OverrideTaxonomyLeaf;

            // Override should only be used when there is no TaxonomyLeaf available via the CostAuthority relationship,
            // so we should never see both of these set. For the moment we'll crash if this actually happens. It seems
            // likely this will prove too brittle but we'll soon see.
            //
            // Additionally, we expect to have AT LEAST one of these work. We don't want it unset.
            //
            //-- SLG 4/20/2020
            //Check.Ensure(taxonomyLeafViaCostAuthority == null || taxonomyLeafViaOverrideOnProject == null);
            Check.Ensure(taxonomyLeafViaCostAuthority == null ^ taxonomyLeafViaOverrideOnProject == null, $"Project: {this.ProjectName} ProjectID: {this.ProjectID} taxonomyLeafViaCostAuthority = {taxonomyLeafViaCostAuthority}, taxonomyLeafViaOverrideOnProject = {taxonomyLeafViaOverrideOnProject}");

            return taxonomyLeafViaOverrideOnProject ?? taxonomyLeafViaCostAuthority;
        }

        public Organization GetPrimaryContactOrganization()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.OrganizationRelationshipType.IsPrimaryContact)?.Organization;
        }

        public FileResource GetPrimaryContactOrganizationLogo()
        {
            return GetPrimaryContactOrganization()?.LogoFileResource;
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ??
                                             GetPrimaryContactOrganization()?.PrimaryContactPerson;

        public decimal? GetProjectedFunding()
        {
            return ProjectFundingSourceBudgets.Any() ? (decimal?)ProjectFundingSourceBudgets.Sum(x => x.ProjectedAmount.GetValueOrDefault()) : 0;
        }


		// Brought over from Mainline-- should this be trashed? --- SLG 4/21/2020
        //public decimal? GetSecuredFundingForFundingSources(List<int> fundingSourceIDs)
        //{
        //    return ProjectFundingSourceBudgets.Any(x => fundingSourceIDs.Contains(x.FundingSourceID)) ? (decimal?)ProjectFundingSourceBudgets.Where(x => fundingSourceIDs.Contains(x.FundingSourceID)).Sum(x => x.SecuredAmount.GetValueOrDefault()) : 0;
        //}

        //public decimal? GetTargetedFunding()
        //{
        //    return ProjectFundingSourceBudgets.Any() ? (decimal?)ProjectFundingSourceBudgets.Sum(x => x.TargetedAmount.GetValueOrDefault()) : 0;
        //}
		// Brought over from Mainline-- should this be trashed? --- SLG 4/21/2020

        public decimal? GetTargetedFundingForFundingSources(List<int> fundingSourceIDs)
        {
            return ProjectFundingSourceBudgets.Any(x => fundingSourceIDs.Contains(x.FundingSourceID)) ? (decimal?)ProjectFundingSourceBudgets.Where(x => fundingSourceIDs.Contains(x.FundingSourceID)).Sum(x => x.ProjectedAmount.GetValueOrDefault()) : 0;
        }

        public decimal? GetNoFundingSourceIdentifiedAmount()
        {
            return ProjectNoFundingSourceIdentifieds.Sum(x => x.NoFundingSourceIdentifiedYet.GetValueOrDefault());
        }

        public decimal? GetEstimatedTotalRegardlessOfFundingType()
        {
            var targetedFunding = GetProjectedFunding();
            var noFundingSourceIdentified = GetNoFundingSourceIdentifiedAmount();
            if (targetedFunding == null && noFundingSourceIdentified == null)
            {
                return null;
            }
            return (noFundingSourceIdentified ?? 0) + (targetedFunding ?? 0);
        }

        public decimal GetNoFundingSourceIdentifiedAmountOrZero()
        {
            return GetNoFundingSourceIdentifiedAmount() ?? 0;
        }

        public decimal? TotalExpenditures
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?)null; }
        }

        public bool HasProjectLocationPoint => ProjectLocationPoint != null;
        public bool HasProjectLocationDetail => ProjectLocations.Any();

        private bool _hasCheckedProjectUpdateHistories;
        private List<ProjectUpdateHistory> _projectUpdateHistories;

        public static List<ProjectUpdateHistory> GetProjectUpdateHistories(Project project)
        {
            if (project._hasCheckedProjectUpdateHistories)
            {
                return project._projectUpdateHistories;
            }

            project.SetProjectUpdateHistories(project.ProjectUpdateBatches.SelectMany(x => x.ProjectUpdateHistories).ToList());
            return project._projectUpdateHistories;
        }

        public void SetProjectUpdateHistories(List<ProjectUpdateHistory> value)
        {
            _projectUpdateHistories = value;
            _hasCheckedProjectUpdateHistories = true;
        }

        public bool IsPersonThePrimaryContact(Person person)
        {
            if (person == null)
            {
                return false;
            }
            var primaryContactPerson = GetPrimaryContact();
            return person.PersonID == primaryContactPerson?.PersonID;
        }

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return ProjectAssessmentQuestions;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProjectLocations.ToList();
        }

        public DbGeometry GetDefaultBoundingBox()
        {
            return DefaultBoundingBox;
        }

        public IEnumerable<GeospatialArea> GetProjectGeospatialAreas()
        {
            return ProjectGeospatialAreas.Select(x => x.GeospatialArea);
        }

        public string GetDuration()
        {
            if (ImplementationStartYear == CompletionYear && ImplementationStartYear.HasValue)
            {
                return ImplementationStartYear.Value.ToString(CultureInfo.InvariantCulture);
            }

            return
                $"{ImplementationStartYear?.ToString(CultureInfo.InvariantCulture) ?? "?"} - {CompletionYear?.ToString(CultureInfo.InvariantCulture) ?? "?"}";
        }

        public ProjectImage GetKeyPhoto()
        {
            return ProjectImages.SingleOrDefault(x => x.IsKeyPhoto);
        }

        public ICollection<IEntityClassification> GetProjectClassificationsForMap() => new List<IEntityClassification>(ProjectClassifications);

        IEnumerable<IProjectCustomAttribute> IProject.GetProjectCustomAttributes() => ProjectCustomAttributes;

        public Organization GetCanStewardProjectsOrganization()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.OrganizationRelationshipType.CanStewardProjects)?.Organization;
        }

        public TaxonomyBranch GetCanStewardProjectsTaxonomyBranch()
        {
            return GetTaxonomyLeaf().TaxonomyBranch;
        }

        public List<GeospatialArea> GetCanStewardProjectsGeospatialAreas()
        {
            return ProjectGeospatialAreas.Select(x => x.GeospatialArea).ToList();
        }

        public ProjectStatus GetCurrentProjectStatus()
        {
            return ProjectProjectStatuses.OrderBy(x => x.ProjectProjectStatusUpdateDate).ThenBy(x => x.ProjectProjectStatusID).LastOrDefault()?.ProjectStatus;
        }

        public bool HasSubmittedOrApprovedUpdateBatchChangingProjectToCompleted()
        {
            return ProjectUpdateBatches
                .Where(x => x.ProjectUpdateState == ProjectUpdateState.Approved ||
                            x.ProjectUpdateState == ProjectUpdateState.Submitted)
                .Any(x => x.ProjectUpdate?.ProjectStage == ProjectStage.Completed);
        }

        public string FinalStatusReportStatusDescription
        {
            get
            {

                var shouldHaveFinalStatusReport = HasSubmittedOrApprovedUpdateBatchChangingProjectToCompleted() || ProjectStage == ProjectStage.Completed;

                var finalStatusReport = ProjectProjectStatuses.Where(x => x.IsFinalStatusUpdate);

                if (shouldHaveFinalStatusReport && finalStatusReport.Any())
                {
                    return "Submitted";
                }
                else if (shouldHaveFinalStatusReport)
                {
                    return "Not submitted";
                }

                return "n/a";
            }
        }



    }
}
