//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ActionItem
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ActionItemPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ActionItem>
    {
        public ActionItemPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ActionItemPrimaryKey(ActionItem actionItem) : base(actionItem){}

        public static implicit operator ActionItemPrimaryKey(int primaryKeyValue)
        {
            return new ActionItemPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ActionItemPrimaryKey(ActionItem actionItem)
        {
            return new ActionItemPrimaryKey(actionItem);
        }
    }
}