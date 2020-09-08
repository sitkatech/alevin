using System.Linq;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirmaModels.Models
{
    [TestFixture]
    public class ProjectTaxonomyLeafTest
    {
        [Test]
        public void EnsureAllTaxonomyLeavesDontCrash()
        {
            CallAllTaxonomyLeavesForAllProjectsToCheckForCrashes();
        }

        public static void CallAllTaxonomyLeavesForAllProjectsToCheckForCrashes()
        {
            var projects = HttpRequestStorageForTest.DatabaseEntities.Projects.ToList();
            // This can crash when data is garbled. This test is to make sure this runs for all projects.
            projects.ForEach(p =>
            {
                p.GetTaxonomyLeafWithWarning(out string warningMessage);
                Check.Ensure(warningMessage == string.Empty, $"Found warning message for GetTaxonomyLeaf(): {warningMessage}");
            });
        }
    }
}