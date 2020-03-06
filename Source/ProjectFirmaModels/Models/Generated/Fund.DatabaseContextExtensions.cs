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
        public static Fund GetFund(this IQueryable<Fund> funds, int reclamationFundID)
        {
            var fund = funds.SingleOrDefault(x => x.ReclamationFundID == reclamationFundID);
            Check.RequireNotNullThrowNotFound(fund, "Fund", reclamationFundID);
            return fund;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFund(this IQueryable<Fund> funds, List<int> reclamationFundIDList)
        {
            if(reclamationFundIDList.Any())
            {
                funds.Where(x => reclamationFundIDList.Contains(x.ReclamationFundID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFund(this IQueryable<Fund> funds, ICollection<Fund> fundsToDelete)
        {
            if(fundsToDelete.Any())
            {
                var reclamationFundIDList = fundsToDelete.Select(x => x.ReclamationFundID).ToList();
                funds.Where(x => reclamationFundIDList.Contains(x.ReclamationFundID)).Delete();
            }
        }

        public static void DeleteFund(this IQueryable<Fund> funds, int reclamationFundID)
        {
            DeleteFund(funds, new List<int> { reclamationFundID });
        }

        public static void DeleteFund(this IQueryable<Fund> funds, Fund fundToDelete)
        {
            DeleteFund(funds, new List<Fund> { fundToDelete });
        }
    }
}