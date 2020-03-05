//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationDeliverableType]
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
        public static ReclamationDeliverableType GetReclamationDeliverableType(this IQueryable<ReclamationDeliverableType> reclamationDeliverableTypes, int reclamationDeliverableTypeID)
        {
            var reclamationDeliverableType = reclamationDeliverableTypes.SingleOrDefault(x => x.ReclamationDeliverableTypeID == reclamationDeliverableTypeID);
            Check.RequireNotNullThrowNotFound(reclamationDeliverableType, "ReclamationDeliverableType", reclamationDeliverableTypeID);
            return reclamationDeliverableType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationDeliverableType(this IQueryable<ReclamationDeliverableType> reclamationDeliverableTypes, List<int> reclamationDeliverableTypeIDList)
        {
            if(reclamationDeliverableTypeIDList.Any())
            {
                reclamationDeliverableTypes.Where(x => reclamationDeliverableTypeIDList.Contains(x.ReclamationDeliverableTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationDeliverableType(this IQueryable<ReclamationDeliverableType> reclamationDeliverableTypes, ICollection<ReclamationDeliverableType> reclamationDeliverableTypesToDelete)
        {
            if(reclamationDeliverableTypesToDelete.Any())
            {
                var reclamationDeliverableTypeIDList = reclamationDeliverableTypesToDelete.Select(x => x.ReclamationDeliverableTypeID).ToList();
                reclamationDeliverableTypes.Where(x => reclamationDeliverableTypeIDList.Contains(x.ReclamationDeliverableTypeID)).Delete();
            }
        }

        public static void DeleteReclamationDeliverableType(this IQueryable<ReclamationDeliverableType> reclamationDeliverableTypes, int reclamationDeliverableTypeID)
        {
            DeleteReclamationDeliverableType(reclamationDeliverableTypes, new List<int> { reclamationDeliverableTypeID });
        }

        public static void DeleteReclamationDeliverableType(this IQueryable<ReclamationDeliverableType> reclamationDeliverableTypes, ReclamationDeliverableType reclamationDeliverableTypeToDelete)
        {
            DeleteReclamationDeliverableType(reclamationDeliverableTypes, new List<ReclamationDeliverableType> { reclamationDeliverableTypeToDelete });
        }
    }
}