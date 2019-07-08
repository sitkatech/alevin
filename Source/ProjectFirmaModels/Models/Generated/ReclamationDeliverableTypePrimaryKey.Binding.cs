//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationDeliverableType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationDeliverableTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationDeliverableType>
    {
        public ReclamationDeliverableTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationDeliverableTypePrimaryKey(ReclamationDeliverableType reclamationDeliverableType) : base(reclamationDeliverableType){}

        public static implicit operator ReclamationDeliverableTypePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationDeliverableTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationDeliverableTypePrimaryKey(ReclamationDeliverableType reclamationDeliverableType)
        {
            return new ReclamationDeliverableTypePrimaryKey(reclamationDeliverableType);
        }
    }
}