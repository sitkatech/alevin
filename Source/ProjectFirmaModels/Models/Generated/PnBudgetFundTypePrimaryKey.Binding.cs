//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PnBudgetFundType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PnBudgetFundTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PnBudgetFundType>
    {
        public PnBudgetFundTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PnBudgetFundTypePrimaryKey(PnBudgetFundType pnBudgetFundType) : base(pnBudgetFundType){}

        public static implicit operator PnBudgetFundTypePrimaryKey(int primaryKeyValue)
        {
            return new PnBudgetFundTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PnBudgetFundTypePrimaryKey(PnBudgetFundType pnBudgetFundType)
        {
            return new PnBudgetFundTypePrimaryKey(pnBudgetFundType);
        }
    }
}