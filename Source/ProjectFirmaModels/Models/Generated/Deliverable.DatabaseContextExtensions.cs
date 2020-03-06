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
        public static Deliverable GetDeliverable(this IQueryable<Deliverable> deliverables, int reclamationDeliverableID)
        {
            var deliverable = deliverables.SingleOrDefault(x => x.ReclamationDeliverableID == reclamationDeliverableID);
            Check.RequireNotNullThrowNotFound(deliverable, "Deliverable", reclamationDeliverableID);
            return deliverable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, List<int> reclamationDeliverableIDList)
        {
            if(reclamationDeliverableIDList.Any())
            {
                deliverables.Where(x => reclamationDeliverableIDList.Contains(x.ReclamationDeliverableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, ICollection<Deliverable> deliverablesToDelete)
        {
            if(deliverablesToDelete.Any())
            {
                var reclamationDeliverableIDList = deliverablesToDelete.Select(x => x.ReclamationDeliverableID).ToList();
                deliverables.Where(x => reclamationDeliverableIDList.Contains(x.ReclamationDeliverableID)).Delete();
            }
        }

        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, int reclamationDeliverableID)
        {
            DeleteDeliverable(deliverables, new List<int> { reclamationDeliverableID });
        }

        public static void DeleteDeliverable(this IQueryable<Deliverable> deliverables, Deliverable deliverableToDelete)
        {
            DeleteDeliverable(deliverables, new List<Deliverable> { deliverableToDelete });
        }
    }
}