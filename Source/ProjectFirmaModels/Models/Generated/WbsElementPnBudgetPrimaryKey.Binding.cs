//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.WbsElementPnBudget
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class WbsElementPnBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<WbsElementPnBudget>
    {
        public WbsElementPnBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WbsElementPnBudgetPrimaryKey(WbsElementPnBudget wbsElementPnBudget) : base(wbsElementPnBudget){}

        public static implicit operator WbsElementPnBudgetPrimaryKey(int primaryKeyValue)
        {
            return new WbsElementPnBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator WbsElementPnBudgetPrimaryKey(WbsElementPnBudget wbsElementPnBudget)
        {
            return new WbsElementPnBudgetPrimaryKey(wbsElementPnBudget);
        }
    }
}