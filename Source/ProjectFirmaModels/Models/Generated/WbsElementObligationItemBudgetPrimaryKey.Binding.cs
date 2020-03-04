//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.WbsElementObligationItemBudget
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class WbsElementObligationItemBudgetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<WbsElementObligationItemBudget>
    {
        public WbsElementObligationItemBudgetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public WbsElementObligationItemBudgetPrimaryKey(WbsElementObligationItemBudget wbsElementObligationItemBudget) : base(wbsElementObligationItemBudget){}

        public static implicit operator WbsElementObligationItemBudgetPrimaryKey(int primaryKeyValue)
        {
            return new WbsElementObligationItemBudgetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator WbsElementObligationItemBudgetPrimaryKey(WbsElementObligationItemBudget wbsElementObligationItemBudget)
        {
            return new WbsElementObligationItemBudgetPrimaryKey(wbsElementObligationItemBudget);
        }
    }
}