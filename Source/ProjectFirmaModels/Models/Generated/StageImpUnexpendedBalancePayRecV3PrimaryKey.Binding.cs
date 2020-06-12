//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StageImpUnexpendedBalancePayRecV3
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class StageImpUnexpendedBalancePayRecV3PrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<StageImpUnexpendedBalancePayRecV3>
    {
        public StageImpUnexpendedBalancePayRecV3PrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public StageImpUnexpendedBalancePayRecV3PrimaryKey(StageImpUnexpendedBalancePayRecV3 stageImpUnexpendedBalancePayRecV3) : base(stageImpUnexpendedBalancePayRecV3){}

        public static implicit operator StageImpUnexpendedBalancePayRecV3PrimaryKey(int primaryKeyValue)
        {
            return new StageImpUnexpendedBalancePayRecV3PrimaryKey(primaryKeyValue);
        }

        public static implicit operator StageImpUnexpendedBalancePayRecV3PrimaryKey(StageImpUnexpendedBalancePayRecV3 stageImpUnexpendedBalancePayRecV3)
        {
            return new StageImpUnexpendedBalancePayRecV3PrimaryKey(stageImpUnexpendedBalancePayRecV3);
        }
    }
}