﻿/*-----------------------------------------------------------------------
<copyright file="TestTaxonomyTrunk.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTaxonomyTrunk
        {
            public static TaxonomyTrunk Create()
            {
                var taxonomyTrunk = TaxonomyTrunk.CreateNewBlank();
                taxonomyTrunk.ThemeColor = "#FFFFFF";
                return taxonomyTrunk;
            }

            /// <summary>
            /// Create new TaxonomyTrunk and attach it to the given context
            /// </summary>
            public static TaxonomyTrunk Create(DatabaseEntities dbContext)
            {
                var taxonomyTrunk = new TaxonomyTrunk(MakeTestName("Taxonomy Tier Three", TaxonomyTrunk.FieldLengths.TaxonomyTrunkName));
                dbContext.AllTaxonomyTrunks.Add(taxonomyTrunk);
                return taxonomyTrunk;
            }
        }
    }
}
