﻿/*-----------------------------------------------------------------------
<copyright file="TestTaxonomyLeaf.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTaxonomyLeaf
        {
            public static TaxonomyLeaf Create()
            {
                var taxonomyBranch = TestTaxonomyBranch.Create();
                var taxonomyLeaf = TaxonomyLeaf.CreateNewBlank(taxonomyBranch);
                return taxonomyLeaf;
            }

            /// <summary>
            /// Create new TaxonomyLeaf and attach it to the given context
            /// </summary>
            public static TaxonomyLeaf Create(DatabaseEntities dbContext)
            {
                var taxonomyBranch = TestTaxonomyBranch.Create(dbContext);
                var taxonomyLeaf = new TaxonomyLeaf(taxonomyBranch, MakeTestName("Test Taxonomy Tier One", TaxonomyLeaf.FieldLengths.TaxonomyLeafName));
                var newTaxonomyLeaf = taxonomyLeaf;
                dbContext.AllTaxonomyLeafs.Add(newTaxonomyLeaf);
                return newTaxonomyLeaf;
            }
        }
    }
}
