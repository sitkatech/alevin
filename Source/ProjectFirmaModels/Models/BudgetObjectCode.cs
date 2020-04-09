/*-----------------------------------------------------------------------
<copyright file="BudgetObjectCode.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

namespace ProjectFirmaModels.Models
{
    public partial class BudgetObjectCode : IAuditableEntity
    {
        public int GetEntityID() => BudgetObjectCodeID;

        public string GetAuditDescriptionString() => GetDisplayName();

        public string GetDisplayName() => $"{BudgetObjectCodeName} ({FbmsYear})";

        /// <summary>
        ///  This is a recursive function to get the CostType
        /// </summary>
        /// <returns></returns>
        public CostType GetEffectiveCostType()
        {
            if (this.OverrideCostType != null)
            {
                return this.OverrideCostType;
            }

            return this.BudgetObjectCodeGroup.GetEffectiveCostType();
        }
    }
}
