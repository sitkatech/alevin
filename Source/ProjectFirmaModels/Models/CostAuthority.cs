using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DbSpatial;

namespace ProjectFirmaModels.Models
{
    public partial class CostAuthority : IAuditableEntity
    {
        /// <summary>
        /// Length of "RX.16786820.3000100" with no dots
        /// </summary>
        private const int DotlessCostAuthorityWorkBreakdownStructureLength = 17;

        public string GetAuditDescriptionString()
        {
            return $"CostAuthority: {this.CostAuthorityID} - {this.CostAuthorityWorkBreakdownStructure}";
        }

        /// <summary>
        /// Tries to add periods to CAWBS string. Could attempt to fix other problems
        /// if needs emerge.
        /// </summary>
        public static string CorrectedCostAuthorityWorkBreakdownStructureString(string possibleCawbsString)
        {
            // Defaults to not changing the string (even if this function doesn't know what to make of it)
            string stringToReturn = possibleCawbsString;

            // This is pretty selective, but it won't surprise me if we can't take this further and do helpful
            // things like zero padding as time goes on.
            bool possibleCawbsStringStartsWithR = possibleCawbsString.ToLower().StartsWith("r");
            bool possibleCawbsStringIsDotless = possibleCawbsString.Contains(".") == false;
            bool isProperLengthToBeDotless =
                possibleCawbsString.Length == DotlessCostAuthorityWorkBreakdownStructureLength;
            if (possibleCawbsStringStartsWithR && possibleCawbsStringIsDotless && isProperLengthToBeDotless)
            {
                stringToReturn = possibleCawbsString.Substring(0, 2) + "." + possibleCawbsString.Substring(2, 8) + "." +
                                 possibleCawbsString.Substring(10);
            }

            return stringToReturn;
        }
    }
}