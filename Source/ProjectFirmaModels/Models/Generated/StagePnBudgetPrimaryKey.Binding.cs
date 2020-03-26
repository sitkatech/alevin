//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StagePnBudget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class StagePnBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<StagePnBudget>
    {
        public StagePnBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public StagePnBudgetPrimaryKey(StagePnBudget stagePnBudget) : base(stagePnBudget){}

        public static implicit operator StagePnBudgetPrimaryKey(int primaryKeyValue)
        {
            return new StagePnBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator StagePnBudgetPrimaryKey(StagePnBudget stagePnBudget)
        {
            return new StagePnBudgetPrimaryKey(stagePnBudget);
        }
    }
}