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
        public static DeliverableType GetDeliverableType(this IQueryable<DeliverableType> deliverableTypes, int deliverableTypeID)
        {
            var deliverableType = deliverableTypes.SingleOrDefault(x => x.DeliverableTypeID == deliverableTypeID);
            Check.RequireNotNullThrowNotFound(deliverableType, "DeliverableType", deliverableTypeID);
            return deliverableType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, List<int> deliverableTypeIDList)
        {
            if(deliverableTypeIDList.Any())
            {
                deliverableTypes.Where(x => deliverableTypeIDList.Contains(x.DeliverableTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, ICollection<DeliverableType> deliverableTypesToDelete)
        {
            if(deliverableTypesToDelete.Any())
            {
                var deliverableTypeIDList = deliverableTypesToDelete.Select(x => x.DeliverableTypeID).ToList();
                deliverableTypes.Where(x => deliverableTypeIDList.Contains(x.DeliverableTypeID)).Delete();
            }
        }

        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, int deliverableTypeID)
        {
            DeleteDeliverableType(deliverableTypes, new List<int> { deliverableTypeID });
        }

        public static void DeleteDeliverableType(this IQueryable<DeliverableType> deliverableTypes, DeliverableType deliverableTypeToDelete)
        {
            DeleteDeliverableType(deliverableTypes, new List<DeliverableType> { deliverableTypeToDelete });
        }
    }
}