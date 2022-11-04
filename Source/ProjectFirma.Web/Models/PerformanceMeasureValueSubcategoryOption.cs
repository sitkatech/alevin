﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureValueSubcategoryOption.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureValueSubcategoryOption
    {
        public int PrimaryKey { get; }
        public PerformanceMeasure PerformanceMeasure { get; }
        public PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        public int PerformanceMeasureSubcategoryOptionID { get; set; }

        public PerformanceMeasureValueSubcategoryOption(int primaryKey, int performanceMeasureSubcategoryOptionID, PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            PrimaryKey = primaryKey;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasure = performanceMeasure;
            PerformanceMeasureSubcategory = performanceMeasureSubcategory;
        }

        public static IEnumerable<PerformanceMeasureValueSubcategoryOption> GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(IPerformanceMeasureValue performanceMeasureValue)
        {
            var performanceMeasure = performanceMeasureValue.PerformanceMeasure;
            var selectedPerformanceMeasureValueSubcategoryOptions = performanceMeasureValue.GetPerformanceMeasureSubcategoryOptions();
            // we need to get all possible subcategories for this performance measure and default it with empty values
            // we do this to prime the angular editor to have these performanceMeasureSubcategory dropdowns there, even if they didn't choose an option for that performanceMeasureSubcategory
            // since this part is optional when creating an expected value record
            var allPossiblePerformanceMeasureActualUpdateSubcategoryOptions =
                performanceMeasure.PerformanceMeasureSubcategories.Select(
                    x => new PerformanceMeasureValueSubcategoryOption(ModelObjectHelpers.NotYetAssignedID, ModelObjectHelpers.NotYetAssignedID, x.PerformanceMeasure, x)).ToList();

            var subcategoryOptionUpdateSimplesSelected =
                selectedPerformanceMeasureValueSubcategoryOptions.Select(
                    x =>
                        new PerformanceMeasureValueSubcategoryOption(x.PrimaryKey,
                            x.PerformanceMeasureSubcategoryOption?.PerformanceMeasureSubcategoryOptionID ?? ModelObjectHelpers.NotYetAssignedID,
                            x.PerformanceMeasure,
                            x.PerformanceMeasureSubcategory)).ToList();
            allPossiblePerformanceMeasureActualUpdateSubcategoryOptions.MergeUpdate(subcategoryOptionUpdateSimplesSelected,
                (x, y) => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID == y.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID,
                (x, y) => x.PerformanceMeasureSubcategoryOptionID = y.PerformanceMeasureSubcategoryOptionID);
            return allPossiblePerformanceMeasureActualUpdateSubcategoryOptions;
        }

        public static List<PerformanceMeasureExpectedSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureExpected performanceMeasureExpected)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureExpected);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureExpectedSubcategoryOptionSimple(x, performanceMeasureExpected)).ToList();
        }

        public static List<PerformanceMeasureExpectedSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureExpectedUpdate performanceMeasureExpected)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureExpected);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureExpectedSubcategoryOptionSimple(x, performanceMeasureExpected)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureActual performanceMeasureActual)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureActual);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionSimple(x, performanceMeasureActual)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(SubprojectPerformanceMeasureActual performanceMeasureActual)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureActual);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionSimple(x, performanceMeasureActual)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionSimple> GetAllPossibleSubcategoryOptionsToActual(PerformanceMeasureExpected performanceMeasureExpected)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureExpected);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionSimple(x, performanceMeasureExpected)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionSimple> GetAllPossibleSubcategoryOptionsToActual(SubprojectPerformanceMeasureExpected performanceMeasureExpected)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureExpected);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionSimple(x, performanceMeasureExpected)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionUpdateSimple> GetAllPossibleSubcategoryOptions(PerformanceMeasureActualUpdate performanceMeasureActualUpdate)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureActualUpdate);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionUpdateSimple(x, performanceMeasureActualUpdate)).ToList();
        }

        public static List<PerformanceMeasureActualSubcategoryOptionUpdateSimple> GetAllPossibleSubcategoryOptionsToActual(PerformanceMeasureExpectedUpdate performanceMeasureExpectedUpdate)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(performanceMeasureExpectedUpdate);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureActualSubcategoryOptionUpdateSimple(x, performanceMeasureExpectedUpdate)).ToList();
        }

        public static List<PerformanceMeasureExpectedSubcategoryOptionSimple> GetAllPossibleSubcategoryOptions(SubprojectPerformanceMeasureExpected subprojectPerformanceMeasureExpected)
        {
            var allPossibleSubcategoryOptionsForPerformanceMeasureValue = GetAllPossibleSubcategoryOptionsForPerformanceMeasureValue(subprojectPerformanceMeasureExpected);
            return allPossibleSubcategoryOptionsForPerformanceMeasureValue.Select(x => new PerformanceMeasureExpectedSubcategoryOptionSimple(x, subprojectPerformanceMeasureExpected)).ToList();
        }
    }
}
