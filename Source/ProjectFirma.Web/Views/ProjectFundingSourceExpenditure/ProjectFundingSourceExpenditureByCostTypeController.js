﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureByCostTypeController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("ProjectFundingSourceExpenditureByCostTypeController", function ($scope, angularModelAndViewData)
{
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    if ($scope.AngularModel.ProjectFundingSourceExpenditures === null) {
        $scope.AngularModel.ProjectFundingSourceExpenditures = [];
    }

    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetfundingSourceIDToAdd = function () { $scope.fundingSourceIDToAdd = null; };

    $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray = function () { return _($scope.AngularModel.ProjectFundingSourceExpenditures).map("CalendarYearExpenditures").flatten(); }

    $scope.getAllUsedCalendarYears = function () { return $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().map("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getCalendarYearRange = function () {
        return _.sortBy(_.union($scope.getAllUsedCalendarYears(), angularModelAndViewData.AngularViewData.CalendarYearRange));
    };

    $scope.getAllUsedFundingSourceIds = function () { return _.uniq(_.map($scope.AngularModel.ProjectFundingSourceExpenditures, function (p) { return p.FundingSourceID; })); };

    $scope.filteredFundingSources = function () {
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        var projectFundingOrganizationFundingSourceIDs = _.map($scope.AngularViewData.AllFundingSources, function (p) { return p.FundingSourceID; });
        var filteredFundingSources = _($scope.AngularViewData.AllFundingSources).filter(function (f) {
            return f.IsActive &&
                _.includes(projectFundingOrganizationFundingSourceIDs, f.FundingSourceID) &&
                !_.includes(usedFundingSourceIDs, f.FundingSourceID);
        }).sortBy(["OrganizationName", "FundingSourceName"]).value();
        return filteredFundingSources;
    };

    $scope.getFundingSourceName = function (fundingSource) { return $scope.getFundingSourceNameById(fundingSource.FundingSourceID); };

    $scope.getFundingSourceNameById = function (fundingSourceId) {
        var fundingSourceToFind = $scope.getFundingSource(fundingSourceId);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceId) { return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceId == f.FundingSourceID; }); };

    $scope.getCostTypeName = function (projectFundingSourceExpenditure) {
        var costTypeToFind = $scope.getCostType(projectFundingSourceExpenditure.CostTypeID);
        return costTypeToFind.CostTypeName;
    };

    $scope.getCostType = function (costTypeId) { return _.find($scope.AngularViewData.AllCostTypes, function (f) { return costTypeId == f.CostTypeID; }); };

    $scope.getExpenditureTotalForCalendarYear = function (calendarYear) {
        var calendarYearExpendituresAsFlattenedArray = $scope.getAllCalendarYearExpendituresAsFlattenedLoDashArray().filter(function (pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForFundingSourceAndCalendarYear = function (fundingSourceId, calendarYear) {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId;
            }).map("CalendarYearExpenditures").flatten().filter(function (cye) {
                return cye.CalendarYear == calendarYear;
            }).value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForFundingSource = function (fundingSourceId) {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId;
            }).map("CalendarYearExpenditures").flatten().value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForCostTypeAndCalendarYear = function (costTypeId, calendarYear) {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.CostTypeID == costTypeId;
            }).map("CalendarYearExpenditures").flatten().filter(function (cye) {
                return cye.CalendarYear == calendarYear;
            }).value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForCostType = function (costTypeId) {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {

                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.CostTypeID == costTypeId;
            }).map("CalendarYearExpenditures").flatten().value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.getExpenditureTotalForRow = function (projectFundingSourceExpenditure) {
        var calendarYearExpendituresAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceExpenditures)
            .filter(function (pfse) {
                return pfse.ProjectID == projectFundingSourceExpenditure.ProjectID &&
                    pfse.FundingSourceID == projectFundingSourceExpenditure.FundingSourceID &&
                    pfse.CostTypeID ==
                    projectFundingSourceExpenditure.CostTypeID;
            }).map("CalendarYearExpenditures").flatten().value();
        return $scope.calculateExpenditureTotal(calendarYearExpendituresAsFlattenedArray);
    };

    $scope.calculateExpenditureTotal = function (expenditures) {
        return _(expenditures)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.MonetaryAmount); })
            .reduce(function (m, x) { return Number(m) + Number(x.MonetaryAmount); }, 0);
    };

    $scope.addCalendarYear = function (calendarYear) {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear)) {
            return;
        }
        _.each($scope.getAllUsedFundingSourceIds(), function (fundingSourceId) { $scope.addCalendarYearExpenditureRow($scope.AngularViewData.ProjectID, fundingSourceId, calendarYear); });
    };

    $scope.getProjectFundingSourceExpenditureRowsForFundingSource = function (fundingSourceId) {
        return _.filter($scope.AngularModel.ProjectFundingSourceExpenditures,
            function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId;
            });
    }

    $scope.getProjectFundingSourceExpenditureRowsForCostType = function (fundingSourceID) { return _.filter($scope.AngularModel.ProjectFundingSourceExpenditures, function (pfse) { return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceID; }); }


    $scope.addRow = function () {
        if ($scope.fundingSourceIDToAdd == null) {
            return;
        }
        for (var i = 0; i < $scope.AngularViewData.AllCostTypes.length; ++i) {
            var newProjectFundingSourceExpenditure = $scope.createNewRow($scope.AngularViewData.ProjectID, parseInt($scope.fundingSourceIDToAdd), $scope.AngularViewData.AllCostTypes[i].CostTypeID, $scope.getCalendarYearRange());
            $scope.AngularModel.ProjectFundingSourceExpenditures.push(newProjectFundingSourceExpenditure);
        }
        $scope.resetfundingSourceIDToAdd();
    };

    $scope.createNewRow = function (projectId, fundingSourceId, costTypeId, calendarYearsToAdd) {
        var newProjectFundingSourceExpenditure = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            CostTypeID: costTypeId,
            CalendarYearExpenditures: _.map(calendarYearsToAdd, $scope.createNewCalendarYearExpenditureRow)
        };
        return newProjectFundingSourceExpenditure;
    };

    $scope.addCalendarYearExpenditureRow = function (projectId, fundingSourceId, calendarYear) {
        var projectFundingSourceExpenditureRowsForFundingSource = $scope.getProjectFundingSourceExpenditureRowsForFundingSource(fundingSourceId);
        if (projectFundingSourceExpenditureRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceExpenditureRowsForFundingSource.length; ++i) {
                projectFundingSourceExpenditureRowsForFundingSource[i].CalendarYearExpenditures.push($scope.createNewCalendarYearExpenditureRow(calendarYear));
            }
        }
    };

    $scope.createNewCalendarYearExpenditureRow = function (calendarYear) {
        return {
            CalendarYear: calendarYear,
            ExpenditureAmount: null
        };
    };

    $scope.selectAllYears = function (isChecked) {
        _.each($scope.AngularModel.ProjectExemptReportingYears,
            function (f) {
                f.IsExempt = isChecked;
            });
    };

    $scope.deleteFundingSourceRow = function (fundingSourceId) {
        var projectFundingSourceExpenditureRowsForFundingSource = $scope.getProjectFundingSourceExpenditureRowsForFundingSource(fundingSourceId);
        if (projectFundingSourceExpenditureRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceExpenditureRowsForFundingSource.length; ++i) {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceExpenditures, projectFundingSourceExpenditureRowsForFundingSource[i]);
            }
        }
    };

    $scope.resetfundingSourceIDToAdd();
});
