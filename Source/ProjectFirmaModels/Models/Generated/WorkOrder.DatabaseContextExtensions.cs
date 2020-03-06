//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[WorkOrder]
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
        public static WorkOrder GetWorkOrder(this IQueryable<WorkOrder> workOrders, int reclamationWorkOrderID)
        {
            var workOrder = workOrders.SingleOrDefault(x => x.ReclamationWorkOrderID == reclamationWorkOrderID);
            Check.RequireNotNullThrowNotFound(workOrder, "WorkOrder", reclamationWorkOrderID);
            return workOrder;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, List<int> reclamationWorkOrderIDList)
        {
            if(reclamationWorkOrderIDList.Any())
            {
                workOrders.Where(x => reclamationWorkOrderIDList.Contains(x.ReclamationWorkOrderID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, ICollection<WorkOrder> workOrdersToDelete)
        {
            if(workOrdersToDelete.Any())
            {
                var reclamationWorkOrderIDList = workOrdersToDelete.Select(x => x.ReclamationWorkOrderID).ToList();
                workOrders.Where(x => reclamationWorkOrderIDList.Contains(x.ReclamationWorkOrderID)).Delete();
            }
        }

        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, int reclamationWorkOrderID)
        {
            DeleteWorkOrder(workOrders, new List<int> { reclamationWorkOrderID });
        }

        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, WorkOrder workOrderToDelete)
        {
            DeleteWorkOrder(workOrders, new List<WorkOrder> { workOrderToDelete });
        }
    }
}