using System;

namespace ProjectFirmaModels.Models
{
    public partial class BudgetObjectCodeGroup 
    {
        /// <summary>
        ///  This is a recursive function to figure out the CostType
        /// </summary>
        /// <returns></returns>
        public CostType GetEffectiveCostType()
        {
            if (CostType != null)
            {
                return this.CostType;
            }

            if (this.ParentBudgetObjectCodeGroup != null)
            {
                return this.ParentBudgetObjectCodeGroup.GetEffectiveCostType();
            }

            throw new Exception($"No CostType for BudgetObjectCodeGroup: {this.BudgetObjectCodeGroupName}");
        }
    }
}