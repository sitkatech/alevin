//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpApGenSheet]
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
        public static ImpApGenSheet GetImpApGenSheet(this IQueryable<ImpApGenSheet> impApGenSheets, int impApGenSheetID)
        {
            var impApGenSheet = impApGenSheets.SingleOrDefault(x => x.ImpApGenSheetID == impApGenSheetID);
            Check.RequireNotNullThrowNotFound(impApGenSheet, "ImpApGenSheet", impApGenSheetID);
            return impApGenSheet;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteImpApGenSheet(this IQueryable<ImpApGenSheet> impApGenSheets, List<int> impApGenSheetIDList)
        {
            if(impApGenSheetIDList.Any())
            {
                impApGenSheets.Where(x => impApGenSheetIDList.Contains(x.ImpApGenSheetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteImpApGenSheet(this IQueryable<ImpApGenSheet> impApGenSheets, ICollection<ImpApGenSheet> impApGenSheetsToDelete)
        {
            if(impApGenSheetsToDelete.Any())
            {
                var impApGenSheetIDList = impApGenSheetsToDelete.Select(x => x.ImpApGenSheetID).ToList();
                impApGenSheets.Where(x => impApGenSheetIDList.Contains(x.ImpApGenSheetID)).Delete();
            }
        }

        public static void DeleteImpApGenSheet(this IQueryable<ImpApGenSheet> impApGenSheets, int impApGenSheetID)
        {
            DeleteImpApGenSheet(impApGenSheets, new List<int> { impApGenSheetID });
        }

        public static void DeleteImpApGenSheet(this IQueryable<ImpApGenSheet> impApGenSheets, ImpApGenSheet impApGenSheetToDelete)
        {
            DeleteImpApGenSheet(impApGenSheets, new List<ImpApGenSheet> { impApGenSheetToDelete });
        }
    }
}