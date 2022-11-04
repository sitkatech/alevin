﻿/*-----------------------------------------------------------------------
<copyright file="GoogleChartConfigurationViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartConfigurationViewModel : IValidatableObject
    {
        [JsonProperty(PropertyName = "options")]
        public string ChartConfigurationJson { get; set; }
        [JsonProperty(PropertyName = "chartType")]
        public string ChartType { get; set; }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, int performanceMeasureSubcategoryID, PerformanceMeasureSubcategoryChartConfiguration chartConfiguration)
        {            
            //Remove certain properties that we don't want saved to the DB
            var chartConfigurationString = CleanAndSerializeChartJsonString(ChartConfigurationJson);
            var performanceMeasureSubcategory = performanceMeasure.PerformanceMeasureSubcategories.Single(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategoryID);
            var googleChartType = ConvertChartTypeStringToGoogleChartType();

            switch (chartConfiguration)
            {
                case PerformanceMeasureSubcategoryChartConfiguration.ChartConfiguration:
                    performanceMeasureSubcategory.GoogleChartTypeID = googleChartType != null ? googleChartType.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    performanceMeasureSubcategory.ChartConfigurationJson = chartConfigurationString;
                    break;
                case PerformanceMeasureSubcategoryChartConfiguration.CumulativeConfiguration:
                    performanceMeasureSubcategory.CumulativeGoogleChartTypeID = googleChartType != null ? googleChartType.GoogleChartTypeID : GoogleChartType.ColumnChart.GoogleChartTypeID;
                    performanceMeasureSubcategory.CumulativeChartConfigurationJson = chartConfigurationString;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid PerformanceMeasureSubcategoryChartConfiguration: '{chartConfiguration}'");
            }
        }

        public string CleanAndSerializeChartJsonString(string json)
        {
            var chartConfiguration = JsonConvert.DeserializeObject<GoogleChartConfiguration>(json);
            chartConfiguration.SanitizeForSaving();
            return JsonConvert.SerializeObject(chartConfiguration);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            //Ensure our new values can be parsed without exceptions. No need to store the values.
            JsonConvert.DeserializeObject<GoogleChartConfiguration>(ChartConfigurationJson);
            var googleChartType = ConvertChartTypeStringToGoogleChartType();
            if (googleChartType == null)
            {
                validationResults.Add(new ValidationResult("Unknown chart type " + ChartType));
            }
            return validationResults;
        }

        private GoogleChartType ConvertChartTypeStringToGoogleChartType()
        {
            return GoogleChartType.All.SingleOrDefault(x => x.GoogleChartTypeDisplayName == ChartType);
        }
    }
}
