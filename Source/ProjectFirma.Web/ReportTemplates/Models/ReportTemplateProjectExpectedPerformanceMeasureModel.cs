﻿using System;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.ReportTemplates.Models
{
    public class ReportTemplateProjectExpectedPerformanceMeasureModel : ReportTemplateBaseModel
    {
        private PerformanceMeasureExpected PerformanceMeasureExpected { get; set; }
        private Project Project { get; }
        public double? Value { get; set; }
        public string UnitType { get; set; }
        public string PerformanceMeasureName { get; set; }
        public string PerformanceMeasureSubcategoryName { get; set; }
        public string PerformanceMeasureSubcategoryOptionName { get; set; }


        public ReportTemplateProjectExpectedPerformanceMeasureModel(PerformanceMeasureExpected performanceMeasureExpected)
        {
            PerformanceMeasureExpected = performanceMeasureExpected;
            Project = performanceMeasureExpected.Project;
            Value = performanceMeasureExpected.ExpectedValue;
            UnitType = performanceMeasureExpected.PerformanceMeasure.MeasurementUnitType.LegendDisplayName;
            PerformanceMeasureName = performanceMeasureExpected.PerformanceMeasure.PerformanceMeasureDisplayName;

            var performanceMeasureSubcategoryName = performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions?.FirstOrDefault(x => x.PerformanceMeasureExpectedID == performanceMeasureExpected.PerformanceMeasureExpectedID)?.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName ?? String.Empty;
            PerformanceMeasureSubcategoryName = performanceMeasureSubcategoryName != "Default"
                ? performanceMeasureSubcategoryName
                : String.Empty;

            var performanceMeasureSubcategoryOptionName = performanceMeasureExpected.PerformanceMeasureExpectedSubcategoryOptions?.FirstOrDefault(x => x.PerformanceMeasureExpectedID == performanceMeasureExpected.PerformanceMeasureExpectedID)?.GetPerformanceMeasureSubcategoryOptionName() ?? String.Empty;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOptionName != "Default"
                ? performanceMeasureSubcategoryOptionName
                : String.Empty;
        }
    }
}