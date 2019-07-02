//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[HabitatCategory]
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
        public static HabitatCategory GetHabitatCategory(this IQueryable<HabitatCategory> habitatCategories, int habitatCategoryID)
        {
            var habitatCategory = habitatCategories.SingleOrDefault(x => x.HabitatCategoryID == habitatCategoryID);
            Check.RequireNotNullThrowNotFound(habitatCategory, "HabitatCategory", habitatCategoryID);
            return habitatCategory;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteHabitatCategory(this IQueryable<HabitatCategory> habitatCategories, List<int> habitatCategoryIDList)
        {
            if(habitatCategoryIDList.Any())
            {
                habitatCategories.Where(x => habitatCategoryIDList.Contains(x.HabitatCategoryID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteHabitatCategory(this IQueryable<HabitatCategory> habitatCategories, ICollection<HabitatCategory> habitatCategoriesToDelete)
        {
            if(habitatCategoriesToDelete.Any())
            {
                var habitatCategoryIDList = habitatCategoriesToDelete.Select(x => x.HabitatCategoryID).ToList();
                habitatCategories.Where(x => habitatCategoryIDList.Contains(x.HabitatCategoryID)).Delete();
            }
        }

        public static void DeleteHabitatCategory(this IQueryable<HabitatCategory> habitatCategories, int habitatCategoryID)
        {
            DeleteHabitatCategory(habitatCategories, new List<int> { habitatCategoryID });
        }

        public static void DeleteHabitatCategory(this IQueryable<HabitatCategory> habitatCategories, HabitatCategory habitatCategoryToDelete)
        {
            DeleteHabitatCategory(habitatCategories, new List<HabitatCategory> { habitatCategoryToDelete });
        }
    }
}