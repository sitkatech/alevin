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
        public static WorkOrder GetWorkOrder(this IQueryable<WorkOrder> workOrders, int workOrderID)
        {
            var workOrder = workOrders.SingleOrDefault(x => x.WorkOrderID == workOrderID);
            Check.RequireNotNullThrowNotFound(workOrder, "WorkOrder", workOrderID);
            return workOrder;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, List<int> workOrderIDList)
        {
            if(workOrderIDList.Any())
            {
                workOrders.Where(x => workOrderIDList.Contains(x.WorkOrderID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, ICollection<WorkOrder> workOrdersToDelete)
        {
            if(workOrdersToDelete.Any())
            {
                var workOrderIDList = workOrdersToDelete.Select(x => x.WorkOrderID).ToList();
                workOrders.Where(x => workOrderIDList.Contains(x.WorkOrderID)).Delete();
            }
        }

        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, int workOrderID)
        {
            DeleteWorkOrder(workOrders, new List<int> { workOrderID });
        }

        public static void DeleteWorkOrder(this IQueryable<WorkOrder> workOrders, WorkOrder workOrderToDelete)
        {
            DeleteWorkOrder(workOrders, new List<WorkOrder> { workOrderToDelete });
        }
    }
}