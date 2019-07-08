//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationWorkOrder]
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
        public static ReclamationWorkOrder GetReclamationWorkOrder(this IQueryable<ReclamationWorkOrder> reclamationWorkOrders, int reclamationWorkOrderID)
        {
            var reclamationWorkOrder = reclamationWorkOrders.SingleOrDefault(x => x.ReclamationWorkOrderID == reclamationWorkOrderID);
            Check.RequireNotNullThrowNotFound(reclamationWorkOrder, "ReclamationWorkOrder", reclamationWorkOrderID);
            return reclamationWorkOrder;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationWorkOrder(this IQueryable<ReclamationWorkOrder> reclamationWorkOrders, List<int> reclamationWorkOrderIDList)
        {
            if(reclamationWorkOrderIDList.Any())
            {
                reclamationWorkOrders.Where(x => reclamationWorkOrderIDList.Contains(x.ReclamationWorkOrderID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationWorkOrder(this IQueryable<ReclamationWorkOrder> reclamationWorkOrders, ICollection<ReclamationWorkOrder> reclamationWorkOrdersToDelete)
        {
            if(reclamationWorkOrdersToDelete.Any())
            {
                var reclamationWorkOrderIDList = reclamationWorkOrdersToDelete.Select(x => x.ReclamationWorkOrderID).ToList();
                reclamationWorkOrders.Where(x => reclamationWorkOrderIDList.Contains(x.ReclamationWorkOrderID)).Delete();
            }
        }

        public static void DeleteReclamationWorkOrder(this IQueryable<ReclamationWorkOrder> reclamationWorkOrders, int reclamationWorkOrderID)
        {
            DeleteReclamationWorkOrder(reclamationWorkOrders, new List<int> { reclamationWorkOrderID });
        }

        public static void DeleteReclamationWorkOrder(this IQueryable<ReclamationWorkOrder> reclamationWorkOrders, ReclamationWorkOrder reclamationWorkOrderToDelete)
        {
            DeleteReclamationWorkOrder(reclamationWorkOrders, new List<ReclamationWorkOrder> { reclamationWorkOrderToDelete });
        }
    }
}