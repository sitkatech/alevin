//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ActionItemState
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ActionItemStatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ActionItemState>
    {
        public ActionItemStatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ActionItemStatePrimaryKey(ActionItemState actionItemState) : base(actionItemState){}

        public static implicit operator ActionItemStatePrimaryKey(int primaryKeyValue)
        {
            return new ActionItemStatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ActionItemStatePrimaryKey(ActionItemState actionItemState)
        {
            return new ActionItemStatePrimaryKey(actionItemState);
        }
    }
}