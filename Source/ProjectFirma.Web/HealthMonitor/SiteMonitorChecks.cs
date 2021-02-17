﻿using LtInfo.Common.HealthMonitor;

namespace ProjectFirma.Web.HealthMonitor
{
    /// <summary>
    /// Hook in point for all site monitoring checks that we have
    /// </summary>
    internal static class SiteMonitorChecks
    {
        public static HealthCheckResults Run()
        {
            var results = new HealthCheckResults();
            // Here's the list of checks to run
            results.Add(Ogr2OgrIExeIsCorrectVersion.Run());
            results.Add(HeadlessGoogleChromeIsAvailable.Run());
            results.Add(SqlServerSpatialDllSeemsToWork.Run());
            results.Add(BidirectionalTaxonomyLeafsHaveValidValues.Run());
            return results;
        }
    }
}