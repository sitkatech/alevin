﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class PerformanceMeasureImportanceDto
    {
        public PerformanceMeasureImportanceDto(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
            FileResources = performanceMeasure.PerformanceMeasureImages.Select(x => new FileResourceDto(x.FileResourceInfo))
                .ToList();

        }

        public PerformanceMeasureImportanceDto()
        {
        }

        public int PerformanceMeasureID { get; set; }
        public string Importance { get; set; }
        public List<FileResourceDto> FileResources { get; set; }

    }
}