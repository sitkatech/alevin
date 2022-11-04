﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureControllerTest.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ApprovalUtilities.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using NUnit.Framework;
using ProjectFirma.Web.Models;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Controllers
{
    [TestFixture]
    public class ProjectFundingSourceExpenditureControllerTest
    {
        [Test]
        public void ProjectWithNoExpendituresShouldReturnEmptyDictionary()
        {
            var project = TestFramework.TestProject.Create();
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var rangeOfYears = GetRangeOfYears(projectFundingSourceExpenditures);

            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.GetDisplayName(),
                new List<string>(), x => x.FundingSource.Organization.GetDisplayName(), rangeOfYears);

            Assert.That(fullOrganizationTypeAndYearDictionary, Is.Empty);
        }

        private static List<int> GetRangeOfYears(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            if (!projectFundingSourceExpenditures.Any())
                return new List<int>();

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = FirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);
            return rangeOfYears;
        }

        [Test]
        public void SimpleProjectSumsCorrectly()
        {
            var project = TestFramework.TestProject.Create();            

            var organization = TestFramework.TestOrganization.Create("test organization 1");
            var fundingSource = TestFramework.TestFundingSource.Create(organization, "test funding source 1");

            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2010, 100.00m);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2011, 100.00m);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2012, 100.00m);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2013, 100.00m);

            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var rangeOfYears = GetRangeOfYears(projectFundingSourceExpenditures);
            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.GetDisplayName(),
                new List<string> {"test organization 1"}, x => x.FundingSource.Organization.GetDisplayName(), rangeOfYears);

            Assert.That(fullOrganizationTypeAndYearDictionary.Sum(x => x.Value.Sum(y => y.Value)), Is.EqualTo(400.00m));
        }

        [Test]
        public void MultipleProjectsSumCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}});
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}}));

            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.GetDisplayName(),
                new List<string> {"org 1", "org 2"},
                x => x.FundingSource.Organization.GetDisplayName(),
                GetRangeOfYears(projectFundingSourceExpenditures));

            Assert.That(fullOrganizationTypeAndYearDictionary.Sum(x => x.Value.Sum(y => y.Value)), Is.EqualTo(2000.0m));
        }

        [Test]
        public void DictionaryBuildsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}});

            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}}));

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = FirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);

            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.GetDisplayName(),
                new List<string> {"org 1", "org 2"}, x=> x.FundingSource.Organization.GetDisplayName(), rangeOfYears);

            Assert.That(fullOrganizationTypeAndYearDictionary["org 1"][2012], Is.EqualTo(300.00m));
        }

        [Test]
        public void YearSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}});

            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}}));

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = FirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);

            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.GetDisplayName(),
                new List<string> { "org 1", "org 2" }, x => x.FundingSource.Organization.GetDisplayName(), rangeOfYears);

            Assert.That(fullOrganizationTypeAndYearDictionary.Sum(x => x.Value[2012]), Is.EqualTo(600.0m));
        }

        [Test]
        public void GroupByOrgSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } });

            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } }));

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = FirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);

            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.GetDisplayName(),
                new List<string> { "org 1", "org 2" }, x => x.FundingSource.Organization.GetDisplayName(), rangeOfYears);

            Assert.That(fullOrganizationTypeAndYearDictionary["org 1"].Sum(x => x.Value), Is.EqualTo(1000.0m));
        }

        [Test]
        public void GroupByFundingSourceSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> { { 2010, 100.0m }, { 2011, 100.0m } });
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> { { 2010, 200.0m }, { 2011, 200.0m } }));
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 3", "funding source 2", new Dictionary<int, decimal> { { 2010, 200.0m }, { 2011, 200.0m } }));

            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.FundingSourceName,
                new List<string> { "funding source 1", "funding source 2" }, x => x.FundingSource.Organization.GetDisplayName(), GetRangeOfYears(projectFundingSourceExpenditures));

            Assert.That(fullOrganizationTypeAndYearDictionary["funding source 2"].Sum(x => x.Value), Is.EqualTo(800.0m));
        }


        [Test]
        public void ExcludedOrgSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> 
            { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } });
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> 
            { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } }));

            var fullOrganizationTypeAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.GetDisplayName(),
                new List<string> { "org 1" }, x => x.FundingSource.Organization.GetDisplayName(), GetRangeOfYears(projectFundingSourceExpenditures));

            Assert.That(fullOrganizationTypeAndYearDictionary.ContainsKey("org 2"), Is.False);
            Assert.That(fullOrganizationTypeAndYearDictionary.Sum(x => x.Value.Sum(y => y.Value)), Is.EqualTo(1000.0m));
        }


        private static List<ProjectFundingSourceExpenditure> BuildExpenditures(string organizationName, string fundingSourceName, Dictionary<int, decimal> yearAndExpenditureDictionary)
        {
            var project = TestFramework.TestProject.Create();
            var organization = TestFramework.TestOrganization.Create(organizationName);
            var fundingSource = TestFramework.TestFundingSource.CreateWithoutChangingName(organization, fundingSourceName);

            return yearAndExpenditureDictionary.Select(x => TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, x.Key, x.Value)).ToList();

        }
    }
}
