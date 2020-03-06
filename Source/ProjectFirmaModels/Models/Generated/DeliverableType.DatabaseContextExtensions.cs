//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[DeliverableType]
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
        public static DeliverableType GetDeliverableType(this IQueryable<DeliverableType> deliverableTypes, int reclamationDeliverableTypeID)
        {
            var deliverableType = deliverableTypes.SingleOrDefault(x => x.ReclamationDeliverableTypeID == reclamationDeliverableTypeID);
            Check.RequireNotNullThrowNotFound(deliverableType, "DeliverableType", reclamationDeliverableTypeID);
            return deliverableType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, List<int> reclamationDeliverableTypeIDList)
        {
            if(reclamationDeliverableTypeIDList.Any())
            {
                deliverableTypes.Where(x => reclamationDeliverableTypeIDList.Contains(x.ReclamationDeliverableTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, ICollection<DeliverableType> deliverableTypesToDelete)
        {
            if(deliverableTypesToDelete.Any())
            {
                var reclamationDeliverableTypeIDList = deliverableTypesToDelete.Select(x => x.ReclamationDeliverableTypeID).ToList();
                deliverableTypes.Where(x => reclamationDeliverableTypeIDList.Contains(x.ReclamationDeliverableTypeID)).Delete();
            }
        }

        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, int reclamationDeliverableTypeID)
        {
            DeleteDeliverableType(deliverableTypes, new List<int> { reclamationDeliverableTypeID });
        }

        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, DeliverableType deliverableTypeToDelete)
        {
            DeleteDeliverableType(deliverableTypes, new List<DeliverableType> { deliverableTypeToDelete });
        }
    }
}