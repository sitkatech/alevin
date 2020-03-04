//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ObligationItem
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ObligationItemPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ObligationItem>
    {
        public ObligationItemPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ObligationItemPrimaryKey(ObligationItem obligationItem) : base(obligationItem){}

        public static implicit operator ObligationItemPrimaryKey(int primaryKeyValue)
        {
            return new ObligationItemPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ObligationItemPrimaryKey(ObligationItem obligationItem)
        {
            return new ObligationItemPrimaryKey(obligationItem);
        }
    }
}