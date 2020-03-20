//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.BudgetObjectCode
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class BudgetObjectCodePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<BudgetObjectCode>
    {
        public BudgetObjectCodePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public BudgetObjectCodePrimaryKey(BudgetObjectCode budgetObjectCode) : base(budgetObjectCode){}

        public static implicit operator BudgetObjectCodePrimaryKey(int primaryKeyValue)
        {
            return new BudgetObjectCodePrimaryKey(primaryKeyValue);
        }

        public static implicit operator BudgetObjectCodePrimaryKey(BudgetObjectCode budgetObjectCode)
        {
            return new BudgetObjectCodePrimaryKey(budgetObjectCode);
        }
    }
}