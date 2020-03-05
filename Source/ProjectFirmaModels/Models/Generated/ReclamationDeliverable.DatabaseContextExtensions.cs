//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationDeliverable]
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
        public static ReclamationDeliverable GetReclamationDeliverable(this IQueryable<ReclamationDeliverable> reclamationDeliverables, int reclamationDeliverableID)
        {
            var reclamationDeliverable = reclamationDeliverables.SingleOrDefault(x => x.ReclamationDeliverableID == reclamationDeliverableID);
            Check.RequireNotNullThrowNotFound(reclamationDeliverable, "ReclamationDeliverable", reclamationDeliverableID);
            return reclamationDeliverable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationDeliverable(this IQueryable<ReclamationDeliverable> reclamationDeliverables, List<int> reclamationDeliverableIDList)
        {
            if(reclamationDeliverableIDList.Any())
            {
                reclamationDeliverables.Where(x => reclamationDeliverableIDList.Contains(x.ReclamationDeliverableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationDeliverable(this IQueryable<ReclamationDeliverable> reclamationDeliverables, ICollection<ReclamationDeliverable> reclamationDeliverablesToDelete)
        {
            if(reclamationDeliverablesToDelete.Any())
            {
                var reclamationDeliverableIDList = reclamationDeliverablesToDelete.Select(x => x.ReclamationDeliverableID).ToList();
                reclamationDeliverables.Where(x => reclamationDeliverableIDList.Contains(x.ReclamationDeliverableID)).Delete();
            }
        }

        public static void DeleteReclamationDeliverable(this IQueryable<ReclamationDeliverable> reclamationDeliverables, int reclamationDeliverableID)
        {
            DeleteReclamationDeliverable(reclamationDeliverables, new List<int> { reclamationDeliverableID });
        }

        public static void DeleteReclamationDeliverable(this IQueryable<ReclamationDeliverable> reclamationDeliverables, ReclamationDeliverable reclamationDeliverableToDelete)
        {
            DeleteReclamationDeliverable(reclamationDeliverables, new List<ReclamationDeliverable> { reclamationDeliverableToDelete });
        }
    }
}