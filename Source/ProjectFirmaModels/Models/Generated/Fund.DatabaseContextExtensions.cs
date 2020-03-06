//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Fund]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Fund GetFund(this IQueryable<Fund> funds, int fundID)
        {
            var fund = funds.SingleOrDefault(x => x.FundID == fundID);
            Check.RequireNotNullThrowNotFound(fund, "Fund", fundID);
            return fund;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFund(this IQueryable<Fund> funds, List<int> fundIDList)
        {
            if(fundIDList.Any())
            {
                funds.Where(x => fundIDList.Contains(x.FundID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFund(this IQueryable<Fund> funds, ICollection<Fund> fundsToDelete)
        {
            if(fundsToDelete.Any())
            {
                var fundIDList = fundsToDelete.Select(x => x.FundID).ToList();
                funds.Where(x => fundIDList.Contains(x.FundID)).Delete();
            }
        }

        public static void DeleteFund(this IQueryable<Fund> funds, int fundID)
        {
            DeleteFund(funds, new List<int> { fundID });
        }

        public static void DeleteFund(this IQueryable<Fund> funds, Fund fundToDelete)
        {
            DeleteFund(funds, new List<Fund> { fundToDelete });
        }
    }
}