using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;
using ProjectFirma.Web.Common;


namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    /// <summary>
    /// We might also consider checking these sorts of things in a health check as well.
    /// </summary>
    [TestFixture]
    public class TaxonomyBranchReclamationBiDirectionalTaxonomyLeafTests
    {
        public class TaxonomyLeafFromBothDirections
        {
            public ProjectFirmaModels.Models.TaxonomyLeaf TaxonomyLeafOverrideOffProject;
            public ProjectFirmaModels.Models.TaxonomyLeaf TaxonomyLeafRoundaboutViaPrimaryCawbs;

            public TaxonomyLeafFromBothDirections(ProjectFirmaModels.Models.Project theProject)
            {
                TaxonomyLeafOverrideOffProject = theProject.OverrideTaxonomyLeaf;
                TaxonomyLeafRoundaboutViaPrimaryCawbs = theProject.GetTaxonomyLeaf();
            }

            public bool AreSameTaxonomyLeaf => TaxonomyLeafOverrideOffProject?.TaxonomyLeafID == TaxonomyLeafRoundaboutViaPrimaryCawbs?.TaxonomyLeafID;
        }

        private void WriteSpacerLine()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        [Test]
        public void CanPullAllProjectsForTaxonomyHierarchySuccessfully()
        {
            // https://bor.localhost.projectfirma.com/ProgramInfo/Taxonomy will do exactly this, but it is important enough to have a test that will fail before
            // it blows up on a user because of something unanticipated.
            var allReclamationTaxonomyLeaves = HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs
                .Where(tl => tl.TenantID == ProjectFirmaModels.Models.Tenant.BureauOfReclamation.TenantID).ToList();
            foreach (var taxonomyLeaf in allReclamationTaxonomyLeaves)
            {
                // This should not crash
                var currentProjects = taxonomyLeaf.GetProjects();
                Console.WriteLine($"Taxonomy Leaf: {taxonomyLeaf.TaxonomyLeafName}: ProjectIDs: { String.Join(", ", currentProjects.Select(p => p.ProjectID))}");
            }
        }

        [Test]
        public void CanPullTheTaxonomyLeafForAllProjectsSuccessfully()
        {
            // Unlike CanPullAllProjectsForTaxonomyHierarchySuccessfully, there's no simple way to replicate this
            // by just hitting a single page. So this test is arguably even more important.
            var allProjects = HttpRequestStorage.DatabaseEntities.AllProjects
                .Where(p => p.TenantID == ProjectFirmaModels.Models.Tenant.BureauOfReclamation.TenantID).ToList();
            foreach (var project in allProjects)
            {
                // This should not crash
                var currentTaxonomyLeaf = project.GetTaxonomyLeafWithWarning(out var warningMessage);
                Console.WriteLine($"Project Leaf: {project.ProjectName}: TaxonomyLeaf: {currentTaxonomyLeaf.TaxonomyLeafName}");
                Check.Ensure(warningMessage == string.Empty, $"Potential problem calling GetTaxonomyLeaf() for ProjectID {project.ProjectID} - {project.ProjectName} : {warningMessage}");
            }
        }

        [Test]
        public void EnsureOneAndOnlyOnePrimaryCawbsPerProjectCostAuthorityProjectsGroup()
        {
            // Other tests also exercise this requirement indirectly, but I thought it useful to spell it out directly.
            var allProjects = HttpRequestStorage.DatabaseEntities.AllProjects
                .Where(p => p.TenantID == ProjectFirmaModels.Models.Tenant.BureauOfReclamation.TenantID).ToList();
            foreach (var project in allProjects)
            {
                var costAuthorityProjects = project.CostAuthorityProjects.ToList();
                if (costAuthorityProjects.Any())
                {
                    var countOfPrimaryCawbsForProject = costAuthorityProjects.Count(cap => cap.IsPrimaryProjectCawbs);
                    Check.Assert(countOfPrimaryCawbsForProject == 1, $"Found {countOfPrimaryCawbsForProject} CostAuthorityProjects set to IsPrimaryProjectCawbs for ProjectID {project.ProjectID} - {project.ProjectName}. Should be one and only one Primary CAWBS per project.");
                }
            }
        }

        [Ignore("This test was useful for debugging, but now that the code has been restructured isn't really a valid test any more. " +
                      "Retained for context and as a starting point for further debugging, should it be needed.")]
        [Test]
        public void TaxonomyBranchIsCorrectlyLinkedInNewVersusOldStrategy()
        {
            // Go through every project. Yes it is OK that we only check our Tenant; the others will be broken and that's fine.
            var allProjects = HttpRequestStorage.DatabaseEntities.AllProjects.Where(p => p.TenantID == ProjectFirmaModels.Models.Tenant.BureauOfReclamation.TenantID).ToList();

            Dictionary<ProjectFirmaModels.Models.Project, TaxonomyLeafFromBothDirections> bothDirectionsDict = new Dictionary<ProjectFirmaModels.Models.Project, TaxonomyLeafFromBothDirections>();
            foreach (var currentProject in allProjects)
            {
                bothDirectionsDict.Add(currentProject, new TaxonomyLeafFromBothDirections(currentProject));
            }

            var matchingDictEntries = bothDirectionsDict.Where(d => d.Value.AreSameTaxonomyLeaf).ToList();
            int matchingCount = matchingDictEntries.Count();
            Console.WriteLine($"Matching TaxonomyLeafIDs (desired result): {matchingCount} matching entries");

            foreach (var dictEntry in matchingDictEntries)
            {
                Console.WriteLine($"ProjectID:{dictEntry.Key.ProjectID} Project Name:{dictEntry.Key.ProjectName} TaxonomyLeafID: {dictEntry.Value.TaxonomyLeafRoundaboutViaPrimaryCawbs?.TaxonomyLeafID} TaxonomyLeafName {dictEntry.Value.TaxonomyLeafRoundaboutViaPrimaryCawbs?.TaxonomyLeafName}");
            }

            var differingDictEntries = bothDirectionsDict.Where(d => !d.Value.AreSameTaxonomyLeaf).ToList();
            int differingCount = differingDictEntries.Count();
            Console.WriteLine($"Differing TaxonomyLeafIDs (desired result): {differingCount} differing entries");

            WriteSpacerLine();

            // Further refine to two differs. One, where we don't have a value, and one where we do.
            var diffsWithNull = differingDictEntries.Where(de => de.Value.TaxonomyLeafRoundaboutViaPrimaryCawbs == null).ToList();
            var diffsWithAlternateValue = differingDictEntries.Where(de => de.Value.TaxonomyLeafRoundaboutViaPrimaryCawbs != null).ToList();

            foreach (var nullDiffDictEntry in diffsWithNull)
            {
                Console.WriteLine($"ProjectID:{nullDiffDictEntry.Key.ProjectID} Project Name:{nullDiffDictEntry.Key.ProjectName}");
                Console.WriteLine($"   Direct TaxonomyLeafID: {nullDiffDictEntry.Value.TaxonomyLeafOverrideOffProject?.TaxonomyLeafID} Direct TaxonomyLeafName: {nullDiffDictEntry.Value.TaxonomyLeafOverrideOffProject?.TaxonomyLeafName}");
                Console.WriteLine($"   Roundabout TaxonomyLeafID: [null]");
            }
            WriteSpacerLine();

            foreach (var alternateDiffDictEntry in diffsWithAlternateValue)
            {
                Console.WriteLine($"ProjectID:{alternateDiffDictEntry.Key.ProjectID} Project Name:{alternateDiffDictEntry.Key.ProjectName}");
                Console.WriteLine($"   Direct TaxonomyLeafID: {alternateDiffDictEntry.Value.TaxonomyLeafOverrideOffProject?.TaxonomyLeafID} Direct TaxonomyLeafName: {alternateDiffDictEntry.Value.TaxonomyLeafOverrideOffProject?.TaxonomyLeafName}");
                Console.WriteLine($"   Roundabout TaxonomyLeafID: {alternateDiffDictEntry.Value.TaxonomyLeafRoundaboutViaPrimaryCawbs?.TaxonomyLeafID} Roundabout TaxonomyLeafName: {alternateDiffDictEntry.Value.TaxonomyLeafRoundaboutViaPrimaryCawbs?.TaxonomyLeafName}");
            }
            WriteSpacerLine();

            Console.WriteLine($"Matching Count: {matchingCount}");
            Console.WriteLine($"Differing Count: {differingCount}");
            Console.WriteLine($"   Null Differing Count: {diffsWithNull.Count}");
            Console.WriteLine($"   Alternate Differing Count: {diffsWithAlternateValue.Count}");
            Check.Ensure(differingCount == 0, "Found differing entries; data needs repairing or at least inspection");
        }
    }
}