//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ImpPnBudget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ImpPnBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ImpPnBudget>
    {
        public ImpPnBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ImpPnBudgetPrimaryKey(ImpPnBudget impPnBudget) : base(impPnBudget){}

        public static implicit operator ImpPnBudgetPrimaryKey(int primaryKeyValue)
        {
            return new ImpPnBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ImpPnBudgetPrimaryKey(ImpPnBudget impPnBudget)
        {
            return new ImpPnBudgetPrimaryKey(impPnBudget);
        }
    }
}