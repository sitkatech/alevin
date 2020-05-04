//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StageImpPnBudget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class StageImpPnBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<StageImpPnBudget>
    {
        public StageImpPnBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public StageImpPnBudgetPrimaryKey(StageImpPnBudget stageImpPnBudget) : base(stageImpPnBudget){}

        public static implicit operator StageImpPnBudgetPrimaryKey(int primaryKeyValue)
        {
            return new StageImpPnBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator StageImpPnBudgetPrimaryKey(StageImpPnBudget stageImpPnBudget)
        {
            return new StageImpPnBudgetPrimaryKey(stageImpPnBudget);
        }
    }
}