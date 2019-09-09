//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationHCategory]
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
        public static ReclamationHCategory GetReclamationHCategory(this IQueryable<ReclamationHCategory> reclamationHCategories, int reclamationHCategoryID)
        {
            var reclamationHCategory = reclamationHCategories.SingleOrDefault(x => x.ReclamationHCategoryID == reclamationHCategoryID);
            Check.RequireNotNullThrowNotFound(reclamationHCategory, "ReclamationHCategory", reclamationHCategoryID);
            return reclamationHCategory;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationHCategory(this IQueryable<ReclamationHCategory> reclamationHCategories, List<int> reclamationHCategoryIDList)
        {
            if(reclamationHCategoryIDList.Any())
            {
                reclamationHCategories.Where(x => reclamationHCategoryIDList.Contains(x.ReclamationHCategoryID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationHCategory(this IQueryable<ReclamationHCategory> reclamationHCategories, ICollection<ReclamationHCategory> reclamationHCategoriesToDelete)
        {
            if(reclamationHCategoriesToDelete.Any())
            {
                var reclamationHCategoryIDList = reclamationHCategoriesToDelete.Select(x => x.ReclamationHCategoryID).ToList();
                reclamationHCategories.Where(x => reclamationHCategoryIDList.Contains(x.ReclamationHCategoryID)).Delete();
            }
        }

        public static void DeleteReclamationHCategory(this IQueryable<ReclamationHCategory> reclamationHCategories, int reclamationHCategoryID)
        {
            DeleteReclamationHCategory(reclamationHCategories, new List<int> { reclamationHCategoryID });
        }

        public static void DeleteReclamationHCategory(this IQueryable<ReclamationHCategory> reclamationHCategories, ReclamationHCategory reclamationHCategoryToDelete)
        {
            DeleteReclamationHCategory(reclamationHCategories, new List<ReclamationHCategory> { reclamationHCategoryToDelete });
        }
    }
}