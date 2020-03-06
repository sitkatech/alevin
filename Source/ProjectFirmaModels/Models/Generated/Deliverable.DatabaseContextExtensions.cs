//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Deliverable]
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
        public static Deliverable GetDeliverable(this IQueryable<Deliverable> deliverables, int deliverableID)
        {
            var deliverable = deliverables.SingleOrDefault(x => x.DeliverableID == deliverableID);
            Check.RequireNotNullThrowNotFound(deliverable, "Deliverable", deliverableID);
            return deliverable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, List<int> deliverableIDList)
        {
            if(deliverableIDList.Any())
            {
                deliverables.Where(x => deliverableIDList.Contains(x.DeliverableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, ICollection<Deliverable> deliverablesToDelete)
        {
            if(deliverablesToDelete.Any())
            {
                var deliverableIDList = deliverablesToDelete.Select(x => x.DeliverableID).ToList();
                deliverables.Where(x => deliverableIDList.Contains(x.DeliverableID)).Delete();
            }
        }

        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, int deliverableID)
        {
            DeleteDeliverable(deliverables, new List<int> { deliverableID });
        }

        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, Deliverable deliverableToDelete)
        {
            DeleteDeliverable(deliverables, new List<Deliverable> { deliverableToDelete });
        }
    }
}