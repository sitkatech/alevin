//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.BudgetObjectCodeGroup
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class BudgetObjectCodeGroupPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<BudgetObjectCodeGroup>
    {
        public BudgetObjectCodeGroupPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public BudgetObjectCodeGroupPrimaryKey(BudgetObjectCodeGroup budgetObjectCodeGroup) : base(budgetObjectCodeGroup){}

        public static implicit operator BudgetObjectCodeGroupPrimaryKey(int primaryKeyValue)
        {
            return new BudgetObjectCodeGroupPrimaryKey(primaryKeyValue);
        }

        public static implicit operator BudgetObjectCodeGroupPrimaryKey(BudgetObjectCodeGroup budgetObjectCodeGroup)
        {
            return new BudgetObjectCodeGroupPrimaryKey(budgetObjectCodeGroup);
        }
    }
}