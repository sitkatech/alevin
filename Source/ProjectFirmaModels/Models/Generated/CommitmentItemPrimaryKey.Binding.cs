//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CommitmentItem
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CommitmentItemPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CommitmentItem>
    {
        public CommitmentItemPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CommitmentItemPrimaryKey(CommitmentItem commitmentItem) : base(commitmentItem){}

        public static implicit operator CommitmentItemPrimaryKey(int primaryKeyValue)
        {
            return new CommitmentItemPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CommitmentItemPrimaryKey(CommitmentItem commitmentItem)
        {
            return new CommitmentItemPrimaryKey(commitmentItem);
        }
    }
}