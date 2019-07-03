//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DeliverableType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DeliverableTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DeliverableType>
    {
        public DeliverableTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DeliverableTypePrimaryKey(DeliverableType deliverableType) : base(deliverableType){}

        public static implicit operator DeliverableTypePrimaryKey(int primaryKeyValue)
        {
            return new DeliverableTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator DeliverableTypePrimaryKey(DeliverableType deliverableType)
        {
            return new DeliverableTypePrimaryKey(deliverableType);
        }
    }
}