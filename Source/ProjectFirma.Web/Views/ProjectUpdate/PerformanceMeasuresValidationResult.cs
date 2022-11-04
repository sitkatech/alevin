﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresValidationResult.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PerformanceMeasuresValidationResult
    {
        public static readonly string FoundIncompletePerformanceMeasureRowsMessage =
            $"has incomplete {MultiTenantHelpers.GetPerformanceMeasureName()} rows. You must either delete irrelevant rows, or provide complete information for each row.";

        public static readonly string FoundDuplicatePerformanceMeasureRowsMessage = $"has duplicate rows. The {FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabelPluralized()} must be unique for each {MultiTenantHelpers.GetPerformanceMeasureName()}. Collapse the duplicate rows into one entry row then save the page.";

        public static readonly string FoundReportedPerformanceMeasureForExemptYearRowsMessage = $"has reported value for exempt years. For years which it is indicated that there are no accomplishments to report, you cannot enter {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}. You must either correct the years for which you have no accomplishments to report, or the reported {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}.";

        private readonly int _performanceMeasureID;

        private readonly List<string> _warningMessages;

        public readonly HashSet<int> PerformanceMeasureActualUpdatesWithWarnings;

        public PerformanceMeasuresValidationResult(
            int performanceMeasureID,
            string performanceMeasureName,
            HashSet<int> missingYears,
            HashSet<int> performanceMeasureActualUpdatesWithIncompleteWarnings,
            HashSet<int> performanceMeasureActualUpdatesWithDuplicateWarnings,
            HashSet<int> performanceMeasureActualUpdatesWithExemptYear)
        {
            //string performanceMeasurePrefixString = string.Format($"{performanceMeasureName} (PM ID # {performanceMeasureID})");
            string performanceMeasurePrefixString = string.Format($"{performanceMeasureName}");

            _performanceMeasureID = performanceMeasureID;

            var ints = new HashSet<int>();
            ints.UnionWith(performanceMeasureActualUpdatesWithIncompleteWarnings);
            ints.UnionWith(performanceMeasureActualUpdatesWithDuplicateWarnings);
            ints.UnionWith(performanceMeasureActualUpdatesWithExemptYear);

            PerformanceMeasureActualUpdatesWithWarnings = ints;
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add($"<strong>{performanceMeasurePrefixString}</strong> missing {MultiTenantHelpers.GetPerformanceMeasureName()} data for {string.Join(", ", missingYears.Select(MultiTenantHelpers.FormatReportingYear))}");
            }
            if (performanceMeasureActualUpdatesWithIncompleteWarnings.Any())
            {
                _warningMessages.Add($"<strong>{performanceMeasurePrefixString}</strong> {FoundIncompletePerformanceMeasureRowsMessage}");
            }
            if (performanceMeasureActualUpdatesWithDuplicateWarnings.Any())
            {
                _warningMessages.Add($"<strong>{performanceMeasurePrefixString}</strong> {FoundDuplicatePerformanceMeasureRowsMessage}");
            }
            if (performanceMeasureActualUpdatesWithExemptYear.Any())
            {
                _warningMessages.Add($"<strong>{performanceMeasurePrefixString}</strong> {FoundReportedPerformanceMeasureForExemptYearRowsMessage}");
            }
        }


        public static bool AreAllValid(List<PerformanceMeasuresValidationResult> performanceMeasuresValidationResults)
        {
            return performanceMeasuresValidationResults.All(pmvr => pmvr.IsValid);
        }

        public PerformanceMeasuresValidationResult(string customErrorMessage)
        {
            _warningMessages = new List<string> {customErrorMessage};
        }

        public int GetPerformanceMeasureID()
        {
            return _performanceMeasureID;
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public static List<string> GetAllWarningMessages(List<PerformanceMeasuresValidationResult> performanceMeasuresValidationResults)
        {
            return performanceMeasuresValidationResults.SelectMany(pmvr => pmvr.GetWarningMessages()).ToList();
        }

        public static HashSet<int> GetAllPerformanceMeasureActualUpdatesWithWarnings(List<PerformanceMeasuresValidationResult> performanceMeasuresValidationResults)
        {
            HashSet<int> allPerformanceMeasureActualUpdatesWithWarnings = new HashSet<int>();

            foreach (var pmvr in performanceMeasuresValidationResults)
            {
                allPerformanceMeasureActualUpdatesWithWarnings.UnionWith(pmvr.PerformanceMeasureActualUpdatesWithWarnings);
            }

            return allPerformanceMeasureActualUpdatesWithWarnings;
        }

        public bool IsValid => !_warningMessages.Any();
    }
}
