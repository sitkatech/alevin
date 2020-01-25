//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[impApGenSheet]
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
        public static impApGenSheet GetimpApGenSheet(this IQueryable<impApGenSheet> impApGenSheets, int impApGenSheetID)
        {
            var impApGenSheet = impApGenSheets.SingleOrDefault(x => x.impApGenSheetID == impApGenSheetID);
            Check.RequireNotNullThrowNotFound(impApGenSheet, "impApGenSheet", impApGenSheetID);
            return impApGenSheet;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteimpApGenSheet(this IQueryable<impApGenSheet> impApGenSheets, List<int> impApGenSheetIDList)
        {
            if(impApGenSheetIDList.Any())
            {
                impApGenSheets.Where(x => impApGenSheetIDList.Contains(x.impApGenSheetID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteimpApGenSheet(this IQueryable<impApGenSheet> impApGenSheets, ICollection<impApGenSheet> impApGenSheetsToDelete)
        {
            if(impApGenSheetsToDelete.Any())
            {
                var impApGenSheetIDList = impApGenSheetsToDelete.Select(x => x.impApGenSheetID).ToList();
                impApGenSheets.Where(x => impApGenSheetIDList.Contains(x.impApGenSheetID)).Delete();
            }
        }

        public static void DeleteimpApGenSheet(this IQueryable<impApGenSheet> impApGenSheets, int impApGenSheetID)
        {
            DeleteimpApGenSheet(impApGenSheets, new List<int> { impApGenSheetID });
        }

        public static void DeleteimpApGenSheet(this IQueryable<impApGenSheet> impApGenSheets, impApGenSheet impApGenSheetToDelete)
        {
            DeleteimpApGenSheet(impApGenSheets, new List<impApGenSheet> { impApGenSheetToDelete });
        }
    }
}