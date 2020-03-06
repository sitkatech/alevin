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
        public static HCategory GetHCategory(this IQueryable<HCategory> hCategories, int reclamationHCategoryID)
        {
            var hCategory = hCategories.SingleOrDefault(x => x.ReclamationHCategoryID == reclamationHCategoryID);
            Check.RequireNotNullThrowNotFound(hCategory, "HCategory", reclamationHCategoryID);
            return hCategory;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, List<int> reclamationHCategoryIDList)
        {
            if(reclamationHCategoryIDList.Any())
            {
                hCategories.Where(x => reclamationHCategoryIDList.Contains(x.ReclamationHCategoryID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, ICollection<HCategory> hCategoriesToDelete)
        {
            if(hCategoriesToDelete.Any())
            {
                var reclamationHCategoryIDList = hCategoriesToDelete.Select(x => x.ReclamationHCategoryID).ToList();
                hCategories.Where(x => reclamationHCategoryIDList.Contains(x.ReclamationHCategoryID)).Delete();
            }
        }

        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, int reclamationHCategoryID)
        {
            DeleteHCategory(hCategories, new List<int> { reclamationHCategoryID });
        }

        public static void DeleteHCategory(this IQueryable<HCategory> hCategories, HCategory hCategoryToDelete)
        {
            DeleteHCategory(hCategories, new List<HCategory> { hCategoryToDelete });
        }
    }
}