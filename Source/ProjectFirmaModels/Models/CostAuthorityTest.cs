using LtInfo.Common.DesignByContract;
using NUnit.Framework;

namespace ProjectFirmaModels.Models
{
    [TestFixture]
    public class CostAuthorityTest
    {
        [Test]
        public void TestCorrectedCostAuthorityString()
        {
            // This looks like a real CAWBS string that just needs dots, so should have them added
            Check.Ensure(CostAuthority.CorrectedCostAuthorityWorkBreakdownStructureString("RX167868203000100") == "RX.16786820.3000100");
            // This should just pass through unchanged
            Check.Ensure(CostAuthority.CorrectedCostAuthorityWorkBreakdownStructureString("bleh.blah.blah") == "bleh.blah.blah");
        }
    }
}