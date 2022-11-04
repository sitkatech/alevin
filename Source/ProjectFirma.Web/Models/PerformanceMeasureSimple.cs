﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSimple.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSimple
    {
        public PerformanceMeasureSimple(PerformanceMeasure performanceMeasure)
            : this(
                performanceMeasure.PerformanceMeasureID,
                performanceMeasure.MeasurementUnitTypeID,
                performanceMeasure.PerformanceMeasureDisplayName,
                performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName,
                performanceMeasure.HasRealSubcategories(),
                performanceMeasure.GetDefinitionAndGuidanceUrl())
        {
        }

        public PerformanceMeasureSimple(int performanceMeasureID,
            int measurementUnitTypeID,
            string displayName,
            string measurementUnitTypeDisplayName,
            bool hasRealSubcategories,
            string definitionAndGuidanceUrl)
        {
            PerformanceMeasureID = performanceMeasureID;
            MeasurementUnitTypeID = measurementUnitTypeID;
            DisplayName = displayName;
            MeasurementUnitTypeDisplayName = measurementUnitTypeDisplayName;
            HasRealSubcategories = hasRealSubcategories;
            DefinitionAndGuidanceUrl = definitionAndGuidanceUrl;
        }

        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public string DisplayName { get; set; }
        public string MeasurementUnitTypeDisplayName { get; set; }
        public bool HasRealSubcategories { get; set; }
        public string DefinitionAndGuidanceUrl { get; set; }
    }
}
