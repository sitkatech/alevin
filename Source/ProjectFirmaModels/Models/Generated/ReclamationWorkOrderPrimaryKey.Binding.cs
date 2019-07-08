//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationWorkOrder
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationWorkOrderPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationWorkOrder>
    {
        public ReclamationWorkOrderPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationWorkOrderPrimaryKey(ReclamationWorkOrder reclamationWorkOrder) : base(reclamationWorkOrder){}

        public static implicit operator ReclamationWorkOrderPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationWorkOrderPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationWorkOrderPrimaryKey(ReclamationWorkOrder reclamationWorkOrder)
        {
            return new ReclamationWorkOrderPrimaryKey(reclamationWorkOrder);
        }
    }
}