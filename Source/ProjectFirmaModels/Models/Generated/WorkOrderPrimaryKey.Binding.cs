//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.WorkOrder
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class WorkOrderPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<WorkOrder>
    {
        public WorkOrderPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WorkOrderPrimaryKey(WorkOrder workOrder) : base(workOrder){}

        public static implicit operator WorkOrderPrimaryKey(int primaryKeyValue)
        {
            return new WorkOrderPrimaryKey(primaryKeyValue);
        }

        public static implicit operator WorkOrderPrimaryKey(WorkOrder workOrder)
        {
            return new WorkOrderPrimaryKey(workOrder);
        }
    }
}