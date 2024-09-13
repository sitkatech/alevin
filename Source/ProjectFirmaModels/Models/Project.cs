/*-----------------------------------------------------------------------
<copyright file="Project.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using LtInfo.Common.AgGridWrappers;
using log4net;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirmaModels.Models
{
    public partial class Project : IAuditableEntity, IProject
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Project));

        public int GetEntityID() => ProjectID;

        public Project GetProject() => this;
        public string GetAuditDescriptionString() => ProjectName;

        public string GetDisplayName() => ProjectName;


        public TaxonomyLeaf GetTaxonomyLeaf()
        {
            // There are two ways we can determine TaxonomyLeaf for a give Project:

            // 1) via the Primary Project CAWBS on a CostAuthorityProject record
            var primaryCostAuthorityProject = this.CostAuthorityProjects.SingleOrDefault(cap => cap.IsPrimaryProjectCawbs);
            TaxonomyLeaf taxonomyLeafViaCostAuthority = primaryCostAuthorityProject?.CostAuthority?.TaxonomyLeaf;
            // 2) via a deliberate set/override on Project itself, using OverrideTaxonomyLeaf
            TaxonomyLeaf taxonomyLeafViaOverrideOnProject = this.OverrideTaxonomyLeaf;

            // When we were first loading up the database, we only used OverrideTaxonomyLeaf when TaxonomyLeaf wasn't
            // determinable via a CostAuthorityProject record. At the time the code was very
            // rigid about only using one or the other, and the code didn't tolerate both being set.
            //
            // But now that Dorothy is up and using the system, it does seem that we can relax a bit, and
            // start to treat the override like a real override - only used if it is set.
            //
            // Now, we use the override if it is provided, and if not, the PrimaryProjectCAWBs.
            // While we warn internally if they provide the SAME answer (I think we should be able to avoid this being set this way),
            // we no longer care if both the override and the PrimaryProjectCAWBs have different answers.
            //
            // We expect to have AT LEAST one of these work. We don't want TaxonomyLeaf indeterminate.
            //
            // SLG 9/7/2020

            // First, make sure at least one of these gives us an answer. We need to be able to figure out
            // TaxonomyLeaf somehow.
            Check.Ensure(taxonomyLeafViaCostAuthority != null || taxonomyLeafViaOverrideOnProject != null, $"GetTaxonomyLeaf() - both methods return null. Cannot determine TaxonomyLeaf for  Project: {this.ProjectName} ProjectID: {this.ProjectID} ");

            // Next, check to see if they are both set, and to the same thing. Here we can return the
            // right answer, but we will gently warn developers that something may be amiss.(I keep
            // thinking this can be addressed somehow, but I may be wrong.)
            if (taxonomyLeafViaCostAuthority != null && taxonomyLeafViaOverrideOnProject != null)
            {
                if (taxonomyLeafViaCostAuthority.TaxonomyLeafID == taxonomyLeafViaOverrideOnProject.TaxonomyLeafID)
                {
                    string warningMessage = $"GetTaxonomyLeaf() - both methods return a TaxonomyLeaf, but they're the same ({taxonomyLeafViaCostAuthority.TaxonomyLeafID} - {taxonomyLeafViaCostAuthority.TaxonomyLeafName}). You should probably clear the OverrideTaxonomyLeafID on ProjectID {primaryCostAuthorityProject.ProjectID} - {primaryCostAuthorityProject.Project.ProjectName}, since it is redundant. It's also a problem that the data ended up in this state, consider investigating and fixing the bug.";
                    _logger.Warn(warningMessage);
                    return taxonomyLeafViaCostAuthority;
                }
            }

            // Favor the override if it is given
            return taxonomyLeafViaOverrideOnProject ?? taxonomyLeafViaCostAuthority;
        }

        public Organization GetPrimaryContactOrganization()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.OrganizationRelationshipType.IsPrimaryContact)?.Organization;
        }
        public String GetPrimaryContactOrganizationRelationShipType()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.OrganizationRelationshipType.IsPrimaryContact)?.OrganizationRelationshipType.OrganizationRelationshipTypeName;
        }

        public FileResourceInfo GetPrimaryContactOrganizationLogo()
        {
            return GetPrimaryContactOrganization()?.LogoFileResourceInfo;
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ??
                                             GetPrimaryContactOrganization()?.PrimaryContactPerson;

        public List<Person> GetContactsWhoCanManageProject()
        {
            return ProjectContacts.ToList().Where(x => x.ContactRelationshipType.CanManageProject).Select(x => x.Contact).ToList();
        }


        public decimal GetProjectedFunding()        {
            return ProjectFundingSourceBudgets.Any() ? ProjectFundingSourceBudgets.Sum(x => x.ProjectedAmount.GetValueOrDefault()) : 0;
        }

        

        public string GetProjectedFundingCategory(List<double> allProjectedFundingValues)
        {
            double standardDeviation = 0;
            if (!allProjectedFundingValues.Any()) return "N/A";

            var nonZeroProjectedFundingValues = allProjectedFundingValues.Where(x => x > 0).ToList();
            double avg = nonZeroProjectedFundingValues.Average();
            standardDeviation = nonZeroProjectedFundingValues.StandardDeviation();

            var projectedFunding = (double) GetProjectedFunding();
            if (projectedFunding < avg - standardDeviation)
            {
                return "Small";
            }

            if (projectedFunding > avg + standardDeviation)
            {
                return "Large";
            }

            return "Medium";

        }

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
            if (noFundingSourceIdentified == null)
            {
                return null;
            }
            return (decimal) noFundingSourceIdentified + targetedFunding;
        }

        public decimal GetNoFundingSourceIdentifiedAmountOrZero()
        {
            return GetNoFundingSourceIdentifiedAmount() ?? 0;
        }

        public int ProjectOrProjectUpdateID
        {
            get { return ProjectID; }
        }
        public bool IsProject { get { return true; } }
        public bool IsProjectUpdate { get { return false; } }

        public decimal? TotalExpenditures
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?)null; }
        }

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

        public bool IsPersonContactThatCanManageProject(Person person)
        {
            if (person == null)
            {
                return false;
            }

            var contacts = GetContactsWhoCanManageProject();
            return contacts.Any(x => x.PersonID == person.PersonID);
        }

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return ProjectAssessmentQuestions;
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

        public string FinalStatusReportStatusDescription
        {
            get
            {

                var shouldHaveFinalStatusReport = ProjectStage == ProjectStage.Completed;

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

        public bool IsActiveProject()
        {
            return !IsProposal() && ProjectApprovalStatus == ProjectApprovalStatus.Approved;
        }

        public bool IsProposal()
        {
            return ProjectStage == ProjectStage.Proposal;
        }

        public bool IsActiveProposal()
        {
            return IsProposal() && ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
        }

        public bool IsActivePendingProject()
        {
            return IsPendingProject() && ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
        }

        public bool IsPendingProject()
        {
            return IsPendingProject(this.ProjectStageID, this.ProjectApprovalStatusID);
        }

        // Centralizing the logic here so it can be shared, and changes will be consistent.
        public static bool IsPendingProject(int projectStageID, int projectApprovalStatusID)
        {
            bool isProposal = projectStageID == ProjectStage.Proposal.ProjectStageID;
            bool projectApprovalStatusIsApproved = projectApprovalStatusID == ProjectApprovalStatus.Approved.ProjectApprovalStatusID;
            return !isProposal && !projectApprovalStatusIsApproved;
        }

        public bool IsPendingApproval()
        {
            return ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
        }

        public bool IsRejected()
        {
            return ProjectApprovalStatus == ProjectApprovalStatus.Rejected;
        }

        public bool HasProjectLocationPoint(bool includePrivateLocation)
        {
            if (LocationIsPrivate && !includePrivateLocation)
            {
                return false;
            }
            return ProjectLocationPoint != null;
        }     

        // Per PF-1181, project locations that have been marked as private are only shown to users with permission to edit the project
        // pass showLocationIfPrivate = true if the point is needed regardless of privacy e.g. to select intersecting geospatial areas
        public DbGeometry GetProjectLocationPoint(bool showLocationIfPrivate)
        {
            if (LocationIsPrivate && !showLocationIfPrivate)
            {
                return null;
            }
            return ProjectLocationPoint;
        }

        public bool HasProjectLocationDetailed(bool includePrivateLocation)
        {
            if (LocationIsPrivate && !includePrivateLocation)
            {
                return false;
            }
            return ProjectLocations.Any();
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetailed(bool showLocationIfPrivate)
        {
            if (LocationIsPrivate && !showLocationIfPrivate)
            {
                return new List<IProjectLocation>();
            }
            return ProjectLocations;
        }
        
        public List<ProjectLocation> GetProjectLocationDetailedAsProjectLocations(bool showLocationIfPrivate)
        {
            if (LocationIsPrivate && !showLocationIfPrivate)
            {
                return new List<ProjectLocation>();
            }
            return ProjectLocations.ToList();
        }
    }
}
