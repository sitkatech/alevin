//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[HCategory]
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
        public static HCategory GetHCategory(this IQueryable<HCategory> hCategories, int hCategoryID)
        {
            var hCategory = hCategories.SingleOrDefault(x => x.HCategoryID == hCategoryID);
            Check.RequireNotNullThrowNotFound(hCategory, "HCategory", hCategoryID);
            return hCategory;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, List<int> hCategoryIDList)
        {
            if(hCategoryIDList.Any())
            {
                hCategories.Where(x => hCategoryIDList.Contains(x.HCategoryID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, ICollection<HCategory> hCategoriesToDelete)
        {
            if(hCategoriesToDelete.Any())
            {
                var hCategoryIDList = hCategoriesToDelete.Select(x => x.HCategoryID).ToList();
                hCategories.Where(x => hCategoryIDList.Contains(x.HCategoryID)).Delete();
            }
        }

        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, int hCategoryID)
        {
            DeleteHCategory(hCategories, new List<int> { hCategoryID });
        }

        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, HCategory hCategoryToDelete)
        {
            DeleteHCategory(hCategories, new List<HCategory> { hCategoryToDelete });
        }
    }
}