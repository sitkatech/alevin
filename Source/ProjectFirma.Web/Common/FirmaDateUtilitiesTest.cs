﻿/*-----------------------------------------------------------------------
<copyright file="FirmaDateUtilitiesTest.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Linq;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;

namespace ProjectFirma.Web.Common
{
    [TestFixture]
    public class FirmaDateUtilitiesTest
    {
        [Test]
        public void CalculateCalendarYearRangeAccountingForExistingYearsWithCeilingOfCurrentYearToUseTest()
        {
            // Test empty list: should return just current year
            var currentYearToUse = DateTime.Today.Year;
            var ceilingYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear), Is.EquivalentTo(Enumerable.Range(currentYearToUse, 1)));

            // No existing budget records

            // Testing if only have a start year
            // -- Start Year in the past: should go from Start Year to Current Year
            var startYear = currentYearToUse - 2;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, currentYearToUse)));
            // -- Start Year same as current year: should just be Start Year
            startYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, startYear)));
            // -- Start Year in the future: should just be the ceiling year
            startYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(ceilingYear, ceilingYear)));

            // Testing if only have a completion year
            var completionYear = currentYearToUse - 2;
            // -- Completion Year in the past or same as current year, should only show Completion Year
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            // -- Completion Year in the future: should be the ceiling year
            completionYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(ceilingYear, ceilingYear)));

            // Testing if have both Start Year and Completion Year: should always be Start Year to Completion Year
            // -- Start Year in the past
            startYear = currentYearToUse - 2;
            // -- Completion year in the past
            completionYear = currentYearToUse - 1;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future, should only go up to the ceiling year
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, ceilingYear)));

            // -- Start Year same as current year
            startYear = currentYearToUse;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, ceilingYear)));

            // -- Start Year in the future
            startYear = currentYearToUse + 2;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear), "Cannot have a start year > end year!");
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(ceilingYear, ceilingYear)));

            // If we have existing budget records, we need to factor those in
            var yearBeforeCurrentYear = currentYearToUse - 2;
            var yearAfterCurrentYear = currentYearToUse + 4;
            // no start year and no end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, currentYearToUse, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year and end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, ceilingYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), ceilingYear),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse - 1, yearAfterCurrentYear)));
        }

        [Test]
        public void CalculateCalendarYearRangeAccountingForExistingYearsWithNoCeilingYearTest()
        {
            // Test empty list: should return just current year
            var currentYearToUse = DateTime.Today.Year;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null), Is.EquivalentTo(Enumerable.Range(currentYearToUse, 1)));

            // No existing budget records

            // Testing if only have a start year
            // -- Start Year in the past: should go from Start Year to Current Year
            var startYear = currentYearToUse - 2;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, currentYearToUse)));
            // -- Start Year same as current year: should just be Start Year
            startYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, startYear)));
            // -- Start Year in the future: should just be Start Year
            startYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null), Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, startYear)));

            // Testing if only have a completion year
            var completionYear = currentYearToUse - 2;
            // -- Completion Year in the past or same as current year, should only show Completion Year
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(completionYear, completionYear)));
            // -- Completion Year in the future: should be current year to Completion Year
            completionYear = currentYearToUse + 3;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), null, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, completionYear)));

            // Testing if have both Start Year and Completion Year: should always be Start Year to Completion Year
            // -- Start Year in the past
            startYear = currentYearToUse - 2;
            // -- Completion year in the past
            completionYear = currentYearToUse - 1;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));

            // -- Start Year same as current year
            startYear = currentYearToUse;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));

            // -- Start Year in the future
            startYear = currentYearToUse + 2;
            // -- Completion year in the past; should throw since that cannot happen!
            completionYear = currentYearToUse - 1;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null), "Cannot have a start year > end year!");
            // -- Completion year same as current year
            completionYear = currentYearToUse;
            Assert.Throws<PreconditionException>(() => FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null), "Cannot have a start year > end year!");
            // -- Completion year in future
            completionYear = startYear + 5;
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(), startYear, completionYear, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(startYear, completionYear)));

            // If we have existing budget records, we need to factor those in
            var yearBeforeCurrentYear = currentYearToUse - 2;
            var yearAfterCurrentYear = currentYearToUse + 4;
            // no start year and no end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse, null, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, null, currentYearToUse, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, null, currentYearToUse, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse, yearAfterCurrentYear)));
            // start year and end year provided
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, currentYearToUse + 1)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearBeforeCurrentYear, yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(yearBeforeCurrentYear, yearAfterCurrentYear)));
            Assert.That(FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int> { yearAfterCurrentYear }, currentYearToUse - 1, currentYearToUse + 1, currentYearToUse, MultiTenantHelpers.GetMinimumYear(), null),
                Is.EquivalentTo(FirmaDateUtilities.GetRangeOfYears(currentYearToUse - 1, yearAfterCurrentYear)));
        }

        [Test]
        public void CurrentReportingYearSetCorrectlyTest()
        {
            var reportingPeriodStartMonth = 11;
            var reportingPeriodStartDay = 1;
            var currentDateTime = new DateTime(2015, 1, 1);
            var currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2014));

            currentDateTime = new DateTime(2015, 12, 1);
            currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2015));
            
            currentDateTime = new DateTime(2016, 1, 1);
            currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2015));


            currentDateTime = new DateTime(2017, 1, 1);
            currentYearToUseForReporting = FirmaDateUtilities.CalculateCurrentYearToUseForReportingImpl(currentDateTime, reportingPeriodStartMonth, reportingPeriodStartDay);

            Assert.That(currentYearToUseForReporting, Is.EqualTo(2016));
        }
    }
}
