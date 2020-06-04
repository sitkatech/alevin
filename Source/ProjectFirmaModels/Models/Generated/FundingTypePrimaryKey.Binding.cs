//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingType>
    {
        public FundingTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingTypePrimaryKey(FundingType fundingType) : base(fundingType){}

        public static implicit operator FundingTypePrimaryKey(int primaryKeyValue)
        {
            return new FundingTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingTypePrimaryKey(FundingType fundingType)
        {
            return new FundingTypePrimaryKey(fundingType);
        }
    }
}