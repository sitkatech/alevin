//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Fund
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Fund>
    {
        public FundPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundPrimaryKey(Fund fund) : base(fund){}

        public static implicit operator FundPrimaryKey(int primaryKeyValue)
        {
            return new FundPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundPrimaryKey(Fund fund)
        {
            return new FundPrimaryKey(fund);
        }
    }
}