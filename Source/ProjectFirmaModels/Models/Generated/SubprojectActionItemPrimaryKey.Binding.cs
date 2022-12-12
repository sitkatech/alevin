//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectActionItem
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectActionItemPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectActionItem>
    {
        public SubprojectActionItemPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectActionItemPrimaryKey(SubprojectActionItem subprojectActionItem) : base(subprojectActionItem){}

        public static implicit operator SubprojectActionItemPrimaryKey(int primaryKeyValue)
        {
            return new SubprojectActionItemPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectActionItemPrimaryKey(SubprojectActionItem subprojectActionItem)
        {
            return new SubprojectActionItemPrimaryKey(subprojectActionItem);
        }
    }
}