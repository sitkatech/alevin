//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[PnBudgetFundType]
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
        public static PnBudgetFundType GetPnBudgetFundType(this IQueryable<PnBudgetFundType> pnBudgetFundTypes, int pnBudgetFundTypeID)
        {
            var pnBudgetFundType = pnBudgetFundTypes.SingleOrDefault(x => x.PnBudgetFundTypeID == pnBudgetFundTypeID);
            Check.RequireNotNullThrowNotFound(pnBudgetFundType, "PnBudgetFundType", pnBudgetFundTypeID);
            return pnBudgetFundType;
        }

        // Delete using an IDList (Firma style)
        public static void DeletePnBudgetFundType(this IQueryable<PnBudgetFundType> pnBudgetFundTypes, List<int> pnBudgetFundTypeIDList)
        {
            if(pnBudgetFundTypeIDList.Any())
            {
                pnBudgetFundTypes.Where(x => pnBudgetFundTypeIDList.Contains(x.PnBudgetFundTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeletePnBudgetFundType(this IQueryable<PnBudgetFundType> pnBudgetFundTypes, ICollection<PnBudgetFundType> pnBudgetFundTypesToDelete)
        {
            if(pnBudgetFundTypesToDelete.Any())
            {
                var pnBudgetFundTypeIDList = pnBudgetFundTypesToDelete.Select(x => x.PnBudgetFundTypeID).ToList();
                pnBudgetFundTypes.Where(x => pnBudgetFundTypeIDList.Contains(x.PnBudgetFundTypeID)).Delete();
            }
        }

        public static void DeletePnBudgetFundType(this IQueryable<PnBudgetFundType> pnBudgetFundTypes, int pnBudgetFundTypeID)
        {
            DeletePnBudgetFundType(pnBudgetFundTypes, new List<int> { pnBudgetFundTypeID });
        }

        public static void DeletePnBudgetFundType(this IQueryable<PnBudgetFundType> pnBudgetFundTypes, PnBudgetFundType pnBudgetFundTypeToDelete)
        {
            DeletePnBudgetFundType(pnBudgetFundTypes, new List<PnBudgetFundType> { pnBudgetFundTypeToDelete });
        }
    }
}