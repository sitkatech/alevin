using System;
using LtInfo.Common.HealthMonitor;
using ProjectFirma.Web.Views.TaxonomyBranch;

namespace ProjectFirma.Web.HealthMonitor
{
    internal static class BidirectionalTaxonomyLeafsHaveValidValues
    {
        public static HealthCheckResult Run()
        {
            var result = new HealthCheckResult("BidirectionalTaxonomyLeafsHaveValidValues");
            // Assume OK until we fail
            result.HealthCheckStatus = HealthCheckStatus.OK;

            try
            {
                // Run our normal tests. If they all run without issues, there are no problems.
                var taxonomyLeafTester = new TaxonomyBranchReclamationBiDirectionalTaxonomyLeafTests();
                taxonomyLeafTester.CanPullTheTaxonomyLeafForAllProjectsSuccessfully();
                taxonomyLeafTester.CanPullAllProjectsForTaxonomyHierarchySuccessfully();
                taxonomyLeafTester.EnsureOneAndOnlyOnePrimaryCawbsPerProjectCostAuthorityProjectsGroup();
                result.AddResultMessage("No problems detected with TaxonomyLeaf override correctness.");
            }
            catch (Exception e)
            {
                // Any exception here means we have a problem
                result.HealthCheckStatus = HealthCheckStatus.Critical;
                result.AddResultMessage(e.Message);
            }

            return result;
        }
    }
}