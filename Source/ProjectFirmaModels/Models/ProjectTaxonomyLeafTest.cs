using System.Linq;
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
            var projects = HttpRequestStorageForTest.DatabaseEntities.Projects.ToList();
            //This can crash when data is garbled. This test is to make sure this runs for all projects.
            projects.ForEach(p => p.GetTaxonomyLeaf());
            
        }

    }
}