﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualSubcategoryOptionSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.ComponentModel;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSubcategoryOptionSimple
    {
        public int PerformanceMeasureActualSubcategoryOptionID { get; set; }
        public int PerformanceMeasureActualID { get; set; }
        [DisplayName("Subcategory Option")]
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple(int performanceMeasureActualSubcategoryOptionID, int performanceMeasureActualID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOptionID;
            PerformanceMeasureActualID = performanceMeasureActualID;
            // It shouldn't ever happen that PerformanceMeasureSubcategoryOptionID is null in the database, but if it is it will come back as a -1 which will break validation on the front-end.
            PerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.IsRealPrimaryKeyValue(performanceMeasureSubcategoryOptionID) ? (int?)performanceMeasureSubcategoryOptionID : null;
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption, PerformanceMeasureActual performanceMeasureActual)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActual.PerformanceMeasureActualID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasure.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID)
        {
        }

        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption, SubprojectPerformanceMeasureActual performanceMeasureActual)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActual.SubprojectPerformanceMeasureActualID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasure.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID)
        {
        }

        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption, PerformanceMeasureExpected performanceMeasureExpected)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                -1,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasure.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID)
        {
        }

        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption, SubprojectPerformanceMeasureExpected performanceMeasureExpected)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                -1,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasure.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID)
        {
        }
    }
}
