//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationDeliverable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationDeliverablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationDeliverable>
    {
        public ReclamationDeliverablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationDeliverablePrimaryKey(ReclamationDeliverable reclamationDeliverable) : base(reclamationDeliverable){}

        public static implicit operator ReclamationDeliverablePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationDeliverablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationDeliverablePrimaryKey(ReclamationDeliverable reclamationDeliverable)
        {
            return new ReclamationDeliverablePrimaryKey(reclamationDeliverable);
        }
    }
}