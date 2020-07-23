//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityObligationRequestPotentialObligationNumberMatch]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CostAuthorityObligationRequestPotentialObligationNumberMatch GetCostAuthorityObligationRequestPotentialObligationNumberMatch(this IQueryable<CostAuthorityObligationRequestPotentialObligationNumberMatch> costAuthorityObligationRequestPotentialObligationNumberMatches, int costAuthorityObligationRequestPotentialObligationNumberMatchID)
        {
            var costAuthorityObligationRequestPotentialObligationNumberMatch = costAuthorityObligationRequestPotentialObligationNumberMatches.SingleOrDefault(x => x.CostAuthorityObligationRequestPotentialObligationNumberMatchID == costAuthorityObligationRequestPotentialObligationNumberMatchID);
            Check.RequireNotNullThrowNotFound(costAuthorityObligationRequestPotentialObligationNumberMatch, "CostAuthorityObligationRequestPotentialObligationNumberMatch", costAuthorityObligationRequestPotentialObligationNumberMatchID);
            return costAuthorityObligationRequestPotentialObligationNumberMatch;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityObligationRequestPotentialObligationNumberMatch(this IQueryable<CostAuthorityObligationRequestPotentialObligationNumberMatch> costAuthorityObligationRequestPotentialObligationNumberMatches, List<int> costAuthorityObligationRequestPotentialObligationNumberMatchIDList)
        {
            if(costAuthorityObligationRequestPotentialObligationNumberMatchIDList.Any())
            {
                costAuthorityObligationRequestPotentialObligationNumberMatches.Where(x => costAuthorityObligationRequestPotentialObligationNumberMatchIDList.Contains(x.CostAuthorityObligationRequestPotentialObligationNumberMatchID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityObligationRequestPotentialObligationNumberMatch(this IQueryable<CostAuthorityObligationRequestPotentialObligationNumberMatch> costAuthorityObligationRequestPotentialObligationNumberMatches, ICollection<CostAuthorityObligationRequestPotentialObligationNumberMatch> costAuthorityObligationRequestPotentialObligationNumberMatchesToDelete)
        {
            if(costAuthorityObligationRequestPotentialObligationNumberMatchesToDelete.Any())
            {
                var costAuthorityObligationRequestPotentialObligationNumberMatchIDList = costAuthorityObligationRequestPotentialObligationNumberMatchesToDelete.Select(x => x.CostAuthorityObligationRequestPotentialObligationNumberMatchID).ToList();
                costAuthorityObligationRequestPotentialObligationNumberMatches.Where(x => costAuthorityObligationRequestPotentialObligationNumberMatchIDList.Contains(x.CostAuthorityObligationRequestPotentialObligationNumberMatchID)).Delete();
            }
        }

        public static void DeleteCostAuthorityObligationRequestPotentialObligationNumberMatch(this IQueryable<CostAuthorityObligationRequestPotentialObligationNumberMatch> costAuthorityObligationRequestPotentialObligationNumberMatches, int costAuthorityObligationRequestPotentialObligationNumberMatchID)
        {
            DeleteCostAuthorityObligationRequestPotentialObligationNumberMatch(costAuthorityObligationRequestPotentialObligationNumberMatches, new List<int> { costAuthorityObligationRequestPotentialObligationNumberMatchID });
        }

        public static void DeleteCostAuthorityObligationRequestPotentialObligationNumberMatch(this IQueryable<CostAuthorityObligationRequestPotentialObligationNumberMatch> costAuthorityObligationRequestPotentialObligationNumberMatches, CostAuthorityObligationRequestPotentialObligationNumberMatch costAuthorityObligationRequestPotentialObligationNumberMatchToDelete)
        {
            DeleteCostAuthorityObligationRequestPotentialObligationNumberMatch(costAuthorityObligationRequestPotentialObligationNumberMatches, new List<CostAuthorityObligationRequestPotentialObligationNumberMatch> { costAuthorityObligationRequestPotentialObligationNumberMatchToDelete });
        }
    }
}