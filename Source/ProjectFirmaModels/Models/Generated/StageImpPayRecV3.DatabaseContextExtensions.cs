//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Staging].[StageImpPayRecV3]
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
        public static StageImpPayRecV3 GetStageImpPayRecV3(this IQueryable<StageImpPayRecV3> stageImpPayRecV3s, int stageImpPayRecV3ID)
        {
            var stageImpPayRecV3 = stageImpPayRecV3s.SingleOrDefault(x => x.StageImpPayRecV3ID == stageImpPayRecV3ID);
            Check.RequireNotNullThrowNotFound(stageImpPayRecV3, "StageImpPayRecV3", stageImpPayRecV3ID);
            return stageImpPayRecV3;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteStageImpPayRecV3(this IQueryable<StageImpPayRecV3> stageImpPayRecV3s, List<int> stageImpPayRecV3IDList)
        {
            if(stageImpPayRecV3IDList.Any())
            {
                stageImpPayRecV3s.Where(x => stageImpPayRecV3IDList.Contains(x.StageImpPayRecV3ID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteStageImpPayRecV3(this IQueryable<StageImpPayRecV3> stageImpPayRecV3s, ICollection<StageImpPayRecV3> stageImpPayRecV3sToDelete)
        {
            if(stageImpPayRecV3sToDelete.Any())
            {
                var stageImpPayRecV3IDList = stageImpPayRecV3sToDelete.Select(x => x.StageImpPayRecV3ID).ToList();
                stageImpPayRecV3s.Where(x => stageImpPayRecV3IDList.Contains(x.StageImpPayRecV3ID)).Delete();
            }
        }

        public static void DeleteStageImpPayRecV3(this IQueryable<StageImpPayRecV3> stageImpPayRecV3s, int stageImpPayRecV3ID)
        {
            DeleteStageImpPayRecV3(stageImpPayRecV3s, new List<int> { stageImpPayRecV3ID });
        }

        public static void DeleteStageImpPayRecV3(this IQueryable<StageImpPayRecV3> stageImpPayRecV3s, StageImpPayRecV3 stageImpPayRecV3ToDelete)
        {
            DeleteStageImpPayRecV3(stageImpPayRecV3s, new List<StageImpPayRecV3> { stageImpPayRecV3ToDelete });
        }
    }
}