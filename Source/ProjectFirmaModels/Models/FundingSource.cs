﻿/*-----------------------------------------------------------------------
<copyright file="FundingSource.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System;
using System.Collections.Generic;

namespace ProjectFirmaModels.Models
{
    public partial class FundingSource : IAuditableEntity, IComparable<FundingSource>
    {


        public List<ProjectFundingSourceBudget> GetProjectFundingSourceBudgetsFromDictionary(
            Dictionary<int, List<ProjectFundingSourceBudget>> dictionary)
        {
            if (dictionary.ContainsKey(FundingSourceID))
            {
                return dictionary[FundingSourceID];
            }
            return new List<ProjectFundingSourceBudget>();
        }

        public List<ProjectFundingSourceExpenditure> GetProjectFundingSourceExpendituresFromDictionary(
            Dictionary<int, List<ProjectFundingSourceExpenditure>> dictionary)
        {
            if (dictionary.ContainsKey(FundingSourceID))
            {
                return dictionary[FundingSourceID];
            }
            return new List<ProjectFundingSourceExpenditure>();
        }

        public string GetAuditDescriptionString() => FundingSourceName;
        public int CompareTo(FundingSource other)
        {
            if (this.FundingSourceID < other.FundingSourceID)
            {
                return -1;
            }
            else if (this.FundingSourceID == other.FundingSourceID)
            {
                return 0;
            }
            else if (this.FundingSourceID > other.FundingSourceID)
            {
                return 1;
            }

            throw new Exception("Coding error; should not happen.");
        }
    }
}
