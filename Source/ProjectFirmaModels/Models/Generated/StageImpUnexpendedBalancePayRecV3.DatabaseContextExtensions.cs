//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Staging].[StageImpUnexpendedBalancePayRecV3]
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
        public static StageImpUnexpendedBalancePayRecV3 GetStageImpUnexpendedBalancePayRecV3(this IQueryable<StageImpUnexpendedBalancePayRecV3> stageImpUnexpendedBalancePayRecV3s, int stageImpUnexpendedBalancePayRecV3ID)
        {
            var stageImpUnexpendedBalancePayRecV3 = stageImpUnexpendedBalancePayRecV3s.SingleOrDefault(x => x.StageImpUnexpendedBalancePayRecV3ID == stageImpUnexpendedBalancePayRecV3ID);
            Check.RequireNotNullThrowNotFound(stageImpUnexpendedBalancePayRecV3, "StageImpUnexpendedBalancePayRecV3", stageImpUnexpendedBalancePayRecV3ID);
            return stageImpUnexpendedBalancePayRecV3;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteStageImpUnexpendedBalancePayRecV3(this IQueryable<StageImpUnexpendedBalancePayRecV3> stageImpUnexpendedBalancePayRecV3s, List<int> stageImpUnexpendedBalancePayRecV3IDList)
        {
            if(stageImpUnexpendedBalancePayRecV3IDList.Any())
            {
                stageImpUnexpendedBalancePayRecV3s.Where(x => stageImpUnexpendedBalancePayRecV3IDList.Contains(x.StageImpUnexpendedBalancePayRecV3ID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteStageImpUnexpendedBalancePayRecV3(this IQueryable<StageImpUnexpendedBalancePayRecV3> stageImpUnexpendedBalancePayRecV3s, ICollection<StageImpUnexpendedBalancePayRecV3> stageImpUnexpendedBalancePayRecV3sToDelete)
        {
            if(stageImpUnexpendedBalancePayRecV3sToDelete.Any())
            {
                var stageImpUnexpendedBalancePayRecV3IDList = stageImpUnexpendedBalancePayRecV3sToDelete.Select(x => x.StageImpUnexpendedBalancePayRecV3ID).ToList();
                stageImpUnexpendedBalancePayRecV3s.Where(x => stageImpUnexpendedBalancePayRecV3IDList.Contains(x.StageImpUnexpendedBalancePayRecV3ID)).Delete();
            }
        }

        public static void DeleteStageImpUnexpendedBalancePayRecV3(this IQueryable<StageImpUnexpendedBalancePayRecV3> stageImpUnexpendedBalancePayRecV3s, int stageImpUnexpendedBalancePayRecV3ID)
        {
            DeleteStageImpUnexpendedBalancePayRecV3(stageImpUnexpendedBalancePayRecV3s, new List<int> { stageImpUnexpendedBalancePayRecV3ID });
        }

        public static void DeleteStageImpUnexpendedBalancePayRecV3(this IQueryable<StageImpUnexpendedBalancePayRecV3> stageImpUnexpendedBalancePayRecV3s, StageImpUnexpendedBalancePayRecV3 stageImpUnexpendedBalancePayRecV3ToDelete)
        {
            DeleteStageImpUnexpendedBalancePayRecV3(stageImpUnexpendedBalancePayRecV3s, new List<StageImpUnexpendedBalancePayRecV3> { stageImpUnexpendedBalancePayRecV3ToDelete });
        }
    }
}