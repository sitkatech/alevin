//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Deliverable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DeliverablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Deliverable>
    {
        public DeliverablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DeliverablePrimaryKey(Deliverable deliverable) : base(deliverable){}

        public static implicit operator DeliverablePrimaryKey(int primaryKeyValue)
        {
            return new DeliverablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator DeliverablePrimaryKey(Deliverable deliverable)
        {
            return new DeliverablePrimaryKey(deliverable);
        }
    }
}