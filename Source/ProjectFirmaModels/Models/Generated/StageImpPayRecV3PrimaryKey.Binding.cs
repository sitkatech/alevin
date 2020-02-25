//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StageImpPayRecV3
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class StageImpPayRecV3PrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<StageImpPayRecV3>
    {
        public StageImpPayRecV3PrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public StageImpPayRecV3PrimaryKey(StageImpPayRecV3 stageImpPayRecV3) : base(stageImpPayRecV3){}

        public static implicit operator StageImpPayRecV3PrimaryKey(int primaryKeyValue)
        {
            return new StageImpPayRecV3PrimaryKey(primaryKeyValue);
        }

        public static implicit operator StageImpPayRecV3PrimaryKey(StageImpPayRecV3 stageImpPayRecV3)
        {
            return new StageImpPayRecV3PrimaryKey(stageImpPayRecV3);
        }
    }
}