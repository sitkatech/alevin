//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[StageImpApGenSheet]
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
        public static StageImpApGenSheet GetStageImpApGenSheet(this IQueryable<StageImpApGenSheet> stageImpApGenSheets, int stageImpApGenSheetID)
        {
            var stageImpApGenSheet = stageImpApGenSheets.SingleOrDefault(x => x.StageImpApGenSheetID == stageImpApGenSheetID);
            Check.RequireNotNullThrowNotFound(stageImpApGenSheet, "StageImpApGenSheet", stageImpApGenSheetID);
            return stageImpApGenSheet;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteStageImpApGenSheet(this IQueryable<StageImpApGenSheet> stageImpApGenSheets, List<int> stageImpApGenSheetIDList)
        {
            if(stageImpApGenSheetIDList.Any())
            {
                stageImpApGenSheets.Where(x => stageImpApGenSheetIDList.Contains(x.StageImpApGenSheetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteStageImpApGenSheet(this IQueryable<StageImpApGenSheet> stageImpApGenSheets, ICollection<StageImpApGenSheet> stageImpApGenSheetsToDelete)
        {
            if(stageImpApGenSheetsToDelete.Any())
            {
                var stageImpApGenSheetIDList = stageImpApGenSheetsToDelete.Select(x => x.StageImpApGenSheetID).ToList();
                stageImpApGenSheets.Where(x => stageImpApGenSheetIDList.Contains(x.StageImpApGenSheetID)).Delete();
            }
        }

        public static void DeleteStageImpApGenSheet(this IQueryable<StageImpApGenSheet> stageImpApGenSheets, int stageImpApGenSheetID)
        {
            DeleteStageImpApGenSheet(stageImpApGenSheets, new List<int> { stageImpApGenSheetID });
        }

        public static void DeleteStageImpApGenSheet(this IQueryable<StageImpApGenSheet> stageImpApGenSheets, StageImpApGenSheet stageImpApGenSheetToDelete)
        {
            DeleteStageImpApGenSheet(stageImpApGenSheets, new List<StageImpApGenSheet> { stageImpApGenSheetToDelete });
        }
    }
}