﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceBudgetByCostTypeController.js" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
angular.module("ProjectFirmaApp").controller("ProjectFundingSourceBudgetByCostTypeController", function ($scope, angularModelAndViewData)
{
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    if ($scope.AngularModel.ProjectFundingSourceBudgets === null) {
        $scope.AngularModel.ProjectFundingSourceBudgets = [];
    }

    $scope.$watch(function () {
        jQuery(".selectpicker").selectpicker("refresh");
    });

    $scope.resetfundingSourceIDToAdd = function() { $scope.fundingSourceIDToAdd = { Value: null } };

    $scope.setSelectedFundingTypeID = function () {
        $scope.selectedFundingTypeID = $scope.AngularModel.FundingTypeID;
    };

    $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray = function () {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        return _($scope.AngularModel.ProjectFundingSourceBudgets).filter(function (f) {
            return _.includes(relevantCostTypeIDs, f.CostTypeID);
        }).map("CalendarYearBudgets")
            .flatten();
    };

    $scope.getAllUsedFundingSourceIds = function () { return _.uniq(_.map($scope.AngularModel.ProjectFundingSourceBudgets, function (p) { return p.FundingSourceID; })); };

    $scope.filteredFundingSources = function () {
        var unknownFundingSourceNames = [
            "Unknown/Unassigned",
            "Unknown",
            "Unspecified",
            "Unidentified  **will be updated after August 2019**"
        ];
        var usedFundingSourceIDs = $scope.getAllUsedFundingSourceIds();
        var projectFundingOrganizationFundingSourceIDs = _.map($scope.AngularViewData.AllFundingSources, function (p) { return p.FundingSourceID; });
        var filteredFundingSources = _($scope.AngularViewData.AllFundingSources).filter(function (f) {
            return f.IsActive &&
                _.includes(projectFundingOrganizationFundingSourceIDs, f.FundingSourceID) &&
                !_.includes(usedFundingSourceIDs, f.FundingSourceID) &&
                !_.contains(unknownFundingSourceNames, f.FundingSourceName);
        }).sortBy(["OrganizationName", "FundingSourceName"]).value();
        return filteredFundingSources;
    };

    $scope.getFundingSourceName = function (fundingSource) { return $scope.getFundingSourceNameById(fundingSource.FundingSourceID); };

    $scope.getFundingSourceNameById = function (fundingSourceId) {
        var fundingSourceToFind = $scope.getFundingSource(fundingSourceId);
        return fundingSourceToFind.DisplayName;
    };

    $scope.getFundingSource = function (fundingSourceId) { return _.find($scope.AngularViewData.AllFundingSources, function (f) { return fundingSourceId == f.FundingSourceID; }); };

    $scope.getRelevantCostTypes = function () {
        var relevantCostTypes = _.sortBy(_.filter($scope.AngularModel.ProjectRelevantCostTypes, function (f) { return f.IsRelevant === true; }),
            function (c) {
                return c.CostTypeName;
            });
        return relevantCostTypes;
    };

    $scope.getRelevantCostTypeIDs = function () {
        return _.map($scope.getRelevantCostTypes(), function (f) { return f.CostTypeID; });
    };

    $scope.getRelevantProjectFundingSourceBudgets = function () {
        if ($scope.budgetTypeNotSelected()) {
            return [];
        }
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        return _.filter($scope.AngularModel.ProjectFundingSourceBudgets, function (f) { return _.includes(relevantCostTypeIDs, f.CostTypeID); });
    };

    $scope.getRelevantCalendarYearBudgets = function (projectFundingSourceBudget) {
        return _.filter(projectFundingSourceBudget.CalendarYearBudgets, function (f) { return f.IsRelevant; });
    };

    $scope.getCostTypeName = function (projectFundingSourceBudget) {
        var costTypeToFind = $scope.getCostType(projectFundingSourceBudget.CostTypeID);
        return costTypeToFind.CostTypeName;
    };

    $scope.getCostType = function (costTypeId) { return _.find($scope.getRelevantCostTypes(), function (f) { return costTypeId == f.CostTypeID; }); };

    $scope.getBudgetTotalForCalendarYear = function (calendarYear, isSecured) {
        var calendarYearBudgetsAsFlattenedArray = $scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().filter(function (pfse) { return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear; }).value();
        if (isSecured == null) {
            return $scope.calculateBudgetTotal(calendarYearBudgetsAsFlattenedArray) +  $scope.getNoFundingSourceIdentifiedTotalForCalendarYear(calendarYear);
        } else if (isSecured) {
            return $scope.calculateBudgetSecuredTotal(calendarYearBudgetsAsFlattenedArray);
        } else {
            return $scope.calculateBudgetTargetedTotal(calendarYearBudgetsAsFlattenedArray);
        }
    };

    $scope.getTotalVariesByYear = function () {
        return $scope.getBudgetTotalForCalendarYear();
    };

    $scope.getTotalSecuredForCalendarYear = function (calendarYear) {
        return $scope.getBudgetTotalForCalendarYear(calendarYear, true);
    }

    $scope.getTotalTargetedForCalendarYear = function (includeNoFundingIdentified, calendarYear) {
        var total = $scope.getBudgetTotalForCalendarYear(calendarYear, false);
        if (includeNoFundingIdentified) {
            // add no funding source (which is in the target column)
            total = total + $scope.getNoFundingSourceIdentifiedTotalForCalendarYear(calendarYear);
        }
        return total;
    }

    $scope.getBudgetTotalForFundingSource = function (fundingSourceId) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceBudgets)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId &&
                    _.includes(relevantCostTypeIDs, pfse.CostTypeID);
            }).map("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(_.filter(calendarYearBudgetsAsFlattenedArray, function (f) { return f.IsRelevant; }));
    };

    $scope.getBudgetTotalForRow = function (projectFundingSourceBudget) {
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceBudgets)
            .filter(function (pfse) {
                return pfse.ProjectID == projectFundingSourceBudget.ProjectID &&
                    pfse.FundingSourceID == projectFundingSourceBudget.FundingSourceID &&
                    pfse.CostTypeID == projectFundingSourceBudget.CostTypeID;
            }).map("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(_.filter(calendarYearBudgetsAsFlattenedArray, function (f) { return f.IsRelevant; }));
    };

    $scope.formatCalendarYear = function (calendarYear) { return $scope.AngularViewData.UseFiscalYears ? "FY" + calendarYear : calendarYear; };

    $scope.addCalendarYear = function (calendarYear) {
        if (Sitka.Methods.isUndefinedNullOrEmpty(calendarYear)) {
            return;
        }
        _.each($scope.getAllUsedFundingSourceIds(), function (fundingSourceId) { $scope.addCalendarYearBudgetRow(fundingSourceId, calendarYear); });
        $scope.addCalendarYearNoFundingSourceIdentifiedRow($scope.AngularViewData.ProjectID, calendarYear);
        $scope.calendarYearRange.splice(_.sortedIndex($scope.calendarYearRange, calendarYear), 0, calendarYear);
    };

    // This determines which rows to show on form but looks at the relevance of the cost type, not the ProjectFundingSourceBudget
    // Only ProjectFundingSourceBudgets that are relevant are posted
    $scope.getProjectFundingSourceBudgetRowsForFundingSource = function (fundingSourceId) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        return _.sortBy(_.filter($scope.AngularModel.ProjectFundingSourceBudgets,
            function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId && _.includes(relevantCostTypeIDs, pfse.CostTypeID);
            }), function (f) {
                return $scope.getCostTypeName(f);
            });
    };

    //Obligations
    $scope.getObligationValue = function (calendarYear, fundingSourceID, costTypeID)
    {
        var items = _.filter($scope.AngularViewData.ObligationItemBudgetRollUps, function(o) {
             return o.CalendarYear == calendarYear && o.FundingSourceID == fundingSourceID && o.CostTypeID == costTypeID;
        });

        if (items) {
            //return _.sum(items, function (item) { return item.Amount; });
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getObligationTotalForFundingSourceAndCalendarYear = function (calendarYear, fundingSourceID)
    {
        var items = _.filter($scope.AngularViewData.ObligationItemBudgetRollUps, function (o) {
            return o.CalendarYear == calendarYear && o.FundingSourceID == fundingSourceID;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getObligationTotalForCalendarYear = function (calendarYear) {
        var items = _.filter($scope.AngularViewData.ObligationItemBudgetRollUps, function (o) {
            return o.CalendarYear == calendarYear;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getObligationTotalForFundingSourceAndCostType = function (fundingSourceID, costTypeID) {
        var items = _.filter($scope.AngularViewData.ObligationItemBudgetRollUps, function (o) {
            return o.CostTypeID == costTypeID && o.FundingSourceID == fundingSourceID;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getObligationTotalForFundingSource = function (fundingSourceID) {
        var items = _.filter($scope.AngularViewData.ObligationItemBudgetRollUps, function (o) {
            return o.FundingSourceID == fundingSourceID;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getObligationTotalVariesByYear = function () {
        return _($scope.AngularViewData.ObligationItemBudgetRollUps)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
    }

    //Expenditures
    $scope.getExpenditureValue = function (calendarYear, fundingSourceID, costTypeID) {
        var items = _.filter($scope.AngularViewData.ObligationItemInvoiceRollUps, function (o) {
            return o.CalendarYear == calendarYear && o.FundingSourceID == fundingSourceID && o.CostTypeID == costTypeID;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getExpenditureTotalForFundingSourceAndCalendarYear = function (calendarYear, fundingSourceID) {
        var items = _.filter($scope.AngularViewData.ObligationItemInvoiceRollUps, function (o) {
            return o.CalendarYear == calendarYear && o.FundingSourceID == fundingSourceID;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getExpenditureTotalForCalendarYear = function (calendarYear) {
        var items = _.filter($scope.AngularViewData.ObligationItemInvoiceRollUps, function (o) {
            return o.CalendarYear == calendarYear;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getExpenditureTotalForFundingSourceAndCostType = function (fundingSourceID, costTypeID) {
        var items = _.filter($scope.AngularViewData.ObligationItemInvoiceRollUps, function (o) {
            return o.CostTypeID == costTypeID && o.FundingSourceID == fundingSourceID;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getExpenditureTotalForFundingSource = function (fundingSourceID) {
        var items = _.filter($scope.AngularViewData.ObligationItemInvoiceRollUps, function (o) {
            return o.FundingSourceID == fundingSourceID;
        });

        if (items) {
            return _(items)
                .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
                .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
        }

        return 0;
    }

    $scope.getExpenditureTotalVariesByYear = function () {
        return _($scope.AngularViewData.ObligationItemInvoiceRollUps)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
            .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
    }

    // Hide or show ProjectFundingSourceBudgets based on selected Cost Types; create a new row if needed
    $scope.addHideOrShowFundingSourceRow = function (fundingSourceId) {
        for (var i = 0; i < $scope.AngularModel.ProjectRelevantCostTypes.length; ++i) {
            var projectRelevantCostType = $scope.AngularModel.ProjectRelevantCostTypes[i];
            var existingRow = _.find($scope.AngularModel.ProjectFundingSourceBudgets, function (pfsb) {
                return pfsb.FundingSourceID == fundingSourceId && pfsb.CostTypeID == projectRelevantCostType.CostTypeID;
            });
            // if no row exists, add it
            if (existingRow == null) {
                var newProjectFundingSourceBudget = $scope.createNewRow($scope.AngularViewData.ProjectID,
                    fundingSourceId,
                    projectRelevantCostType.CostTypeID,
                    $scope.calendarYearRange,
                    projectRelevantCostType.IsRelevant);
                $scope.AngularModel.ProjectFundingSourceBudgets.push(newProjectFundingSourceBudget);
            }
            // otherwise, update IsRelevant based on new state of it's cost type
            else {
                existingRow.IsRelevant = projectRelevantCostType.IsRelevant;
            }
        }
    };

    $scope.addRow = function () {
        if ($scope.fundingSourceIDToAdd.Value == null) {
            return;
        }
        $scope.addHideOrShowFundingSourceRow(parseInt($scope.fundingSourceIDToAdd.Value));
        $scope.resetfundingSourceIDToAdd();
    };

    $scope.createNewRow = function (projectId, fundingSourceId, costTypeId, calendarYearsToAdd, isRelevant) {
        var newProjectFundingSourceBudget = {
            ProjectID: projectId,
            FundingSourceID: fundingSourceId,
            CostTypeID: costTypeId,
            IsRelevant: isRelevant,
            ProjectedAmount: 0,
            CalendarYearBudgets: _.map(calendarYearsToAdd, $scope.createNewCalendarYearBudgetRow)
        };
        return newProjectFundingSourceBudget;
    };

    $scope.addCalendarYearBudgetRow = function (fundingSourceId, calendarYear) {
        var projectFundingSourceBudgetRowsForFundingSource = $scope.getProjectFundingSourceBudgetRowsForFundingSource(fundingSourceId);
        if (projectFundingSourceBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceBudgetRowsForFundingSource.length; ++i) {
                var existingCalendarYearBudget = _.find(projectFundingSourceBudgetRowsForFundingSource[i].CalendarYearBudgets,
                    function (cye) {
                        return cye.CalendarYear == calendarYear;
                    });
                if (Sitka.Methods.isUndefinedNullOrEmpty(existingCalendarYearBudget)) {
                    projectFundingSourceBudgetRowsForFundingSource[i].CalendarYearBudgets.push(
                        $scope.createNewCalendarYearBudgetRow(calendarYear));
                } else {
                    existingCalendarYearBudget.IsRelevant = true;
                }
            }
        }
    };

    $scope.createNewCalendarYearBudgetRow = function (calendarYear) {
        return {
            CalendarYear: calendarYear,
            ProjectedAmount: 0,
            IsRelevant: true
        };
    };

    $scope.deleteFundingSourceRow = function (fundingSourceId) {
        var projectFundingSourceBudgetRowsForFundingSource = _.filter($scope.AngularModel.ProjectFundingSourceBudgets,
            function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID && pfse.FundingSourceID == fundingSourceId;
            });
        if (projectFundingSourceBudgetRowsForFundingSource.length > 0) {
            for (var i = 0; i < projectFundingSourceBudgetRowsForFundingSource.length; ++i) {
                Sitka.Methods.removeFromJsonArray($scope.AngularModel.ProjectFundingSourceBudgets, projectFundingSourceBudgetRowsForFundingSource[i]);
            }
        }
    };

    $scope.deleteCalendarYear = function (calendarYear) {
        _.each($scope.AngularModel.ProjectFundingSourceBudgets, function (pfse) {
            var calendarYearBudgets = _.filter(pfse.CalendarYearBudgets, function (cye) { return cye.CalendarYear == calendarYear });
            _.each(calendarYearBudgets, function (cye) { cye.IsRelevant = false; });
        });
        var calendarYearNoFundingSourceAmount = _.filter($scope.AngularModel.NoFundingSourceAmounts,
            function (nfsa) { return nfsa.CalendarYear == calendarYear });
        Sitka.Methods.removeFromJsonArray($scope.AngularModel.NoFundingSourceAmounts, calendarYearNoFundingSourceAmount);
        _.pull($scope.calendarYearRange, calendarYear);
    };

    $scope.addRemoveCostTypeFromBudgets = function () {
        var allUsedFundingSourceIds = $scope.getAllUsedFundingSourceIds();
        // we need to add any cost types that were not in the model in the first place
        _.each(allUsedFundingSourceIds,
            function (fundingSourceId) {
                $scope.addHideOrShowFundingSourceRow(fundingSourceId);
            });
    };

    $scope.canDeleteCalendarYear = function (calendarYear) {
        return $scope.calendarYearRange.length > 1 &&
            !_.includes($scope.AngularViewData.RequiredCalendarYearRange, calendarYear);
    };

    $scope.onTextFocus = function ($event) {
        $event.target.select();
    };


    $scope.getTotalSameEachYear = function (isSecured) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        var projectFundingSourceBudgets = _.filter($scope.AngularModel.ProjectFundingSourceBudgets, function (pfsb) {
            return _.includes(relevantCostTypeIDs, pfsb.CostTypeID);
        });

        if (isSecured == null) {
            // return secured + targeted + no funding source
            return $scope.calculateBudgetTotal(projectFundingSourceBudgets) + $scope.getTotalNoFundingIdentifiedSameEachYear();
        } else if (isSecured) {
            // return secured
            return $scope.calculateBudgetSecuredTotal(projectFundingSourceBudgets);
        } else {
            // return targeted
            return $scope.calculateBudgetTargetedTotal(projectFundingSourceBudgets);
        }
    };

    $scope.getTotalSecuredSameEachYear = function () {
        return $scope.getTotalSameEachYear(true);
    }

    $scope.getTotalTargetedSameEachYear = function (includeNoFundingIdentified) {
        var total = $scope.getTotalSameEachYear(false);
        if (includeNoFundingIdentified) {
            // add no funding source (which is in the target column)
            total = total + $scope.getTotalNoFundingIdentifiedSameEachYear();
        }
        return total;
    }

    $scope.getTotalNoFundingIdentifiedSameEachYear = function () {
        return Number($scope.noFundingSourceIdentifiedSameEachYear.Value);
    }

    $scope.getNoFundingSourceIdentifiedTotalForCalendarYear = function (calendarYear) {
        var calendarYearNoFundingSourceIdentifiedArray =
            $scope.AngularModel.NoFundingSourceAmounts.filter(
                function (pfse) {
                    return Sitka.Methods.isUndefinedNullOrEmpty(calendarYear) || pfse.CalendarYear == calendarYear;
                });
        return $scope.calculateNoFundingSourceIdentifiedTotal(calendarYearNoFundingSourceIdentifiedArray);
    };

    $scope.getBudgetTotalForFundingSourceAndCalendarYear = function (fundingSourceId, calendarYear) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceBudgets)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId &&
                    _.includes(relevantCostTypeIDs, pfse.CostTypeID);
            }).map("CalendarYearBudgets").flatten().filter(function (cye) {
                return cye.CalendarYear == calendarYear;
            }).value();

        return $scope.calculateBudgetTargetedTotal(calendarYearBudgetsAsFlattenedArray);
        
    };

    $scope.getBudgetTotalForFundingSource = function (fundingSourceId) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        var calendarYearBudgetsAsFlattenedArray = _($scope.AngularModel.ProjectFundingSourceBudgets)
            .filter(function (pfse) {
                return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                    pfse.FundingSourceID == fundingSourceId &&
                    _.includes(relevantCostTypeIDs, pfse.CostTypeID);
            }).map("CalendarYearBudgets").flatten().value();
        return $scope.calculateBudgetTotal(_.filter(calendarYearBudgetsAsFlattenedArray, function (f) { return f.IsRelevant; }));
    };

    $scope.getBudgetTotalForFundingSourceSameEachYear = function (fundingSourceId, isSecured) {
        var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        var budgetsForFundingSourceArray =
            $scope.AngularModel.ProjectFundingSourceBudgets.filter(
                function (pfse) {
                    return pfse.ProjectID == $scope.AngularViewData.ProjectID &&
                        pfse.FundingSourceID == fundingSourceId &&
                        _.includes(relevantCostTypeIDs, pfse.CostTypeID);
                });

        if (isSecured == null) {
            // get secured + targeted total
            return $scope.calculateBudgetTotal(budgetsForFundingSourceArray);
        } else if (isSecured) {
            return $scope.calculateBudgetSecuredTotal(budgetsForFundingSourceArray);
        } else {
            return $scope.calculateBudgetTargetedTotal(budgetsForFundingSourceArray);
        }
    };

    $scope.getBudgetTotalForRowSameEachYear = function (projectFundingSourceBudget) {
        return Number(projectFundingSourceBudget.ProjectedAmount); //Number(projectFundingSourceBudget.SecuredAmount) + 
    };

    $scope.calculateBudgetTotal = function (budgets) {
        return $scope.calculateBudgetTargetedTotal(budgets); //$scope.calculateBudgetSecuredTotal(budgets) + 
    };

    $scope.calculateBudgetSecuredTotal = function (budgets) {
        return _(budgets)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.SecuredAmount); })
            .reduce(function (m, x) { return Number(m) + Number(x.SecuredAmount); }, 0);
    };

    $scope.calculateBudgetTargetedTotal = function (budgets) {
        return _(budgets)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.ProjectedAmount); })
            .reduce(function (m, x) { return Number(m) + Number(x.ProjectedAmount); }, 0);
    };

    $scope.calculateNoFundingSourceIdentifiedTotal = function (noFundingSourceIdentifieds) {
        return _(noFundingSourceIdentifieds)
            .filter(function (f) { return !Sitka.Methods.isUndefinedNullOrEmpty(f.Amount); })
            .reduce(function (m, x) { return Number(m) + Number(x.Amount); }, 0);
    };

    $scope.getCalendarYearBudgets = function (projectFundingSourceBudget) {
        // when switching from "budget is the same each year" to "budget varies by year" the CalendarYearBudgets can be empty
        $scope.populateCalendarYearBudgets(projectFundingSourceBudget);
        return projectFundingSourceBudget.CalendarYearBudgets;
    };

    $scope.populateCalendarYearBudgets = function () {
        // when switching from same year to multiyear, we need to populate the CalendarYearBudgets if they don't have one
        if ($scope.budgetVariesByYear()) {
            var calendarYearsToAdd = $scope.calendarYearRange;
            if (calendarYearsToAdd.length > 0) {
                var projectFundingSourceBudgetsToUpdate = $scope.AngularModel.ProjectFundingSourceBudgets;
                _.each(projectFundingSourceBudgetsToUpdate,
                    function (pfsb) {
                        if (Sitka.Methods.isUndefinedNullOrEmpty(pfsb.CalendarYearBudgets)) {
                            pfsb.CalendarYearBudgets = [];
                        }
                        _.each(calendarYearsToAdd,
                            function (calendarYear) {
                                var existingCalendarYearBudget = _.find(pfsb.CalendarYearBudgets,
                                    function (cyb) {
                                        return cyb.CalendarYear == calendarYear;
                                    });
                                if (existingCalendarYearBudget == null) {
                                    pfsb.CalendarYearBudgets.push($scope.createNewCalendarYearBudgetRow(calendarYear));
                                }
                            });
                    });
            }
        }
        if ($scope.budgetSameEachYear()) {
            // make sure secured and targeted funding is pre-populated with zeros
            _.each($scope.AngularModel.ProjectFundingSourceBudgets,
                function (pfsb) {
                    if (pfsb.ProjectedAmount == null) {
                        pfsb.ProjectedAmount = 0;
                    }
                });
        }
    };


    $scope.getNoFundingSourceAmounts = function (costType) {
        var costTypeID = costType.CostTypeID;
        var allUsedCalendarYearsForCostType = $scope.getAllUsedCalendarYearsNoFundingSourceIdentifiedsByCostType(costType);
        var calendarYearsToAdd = _.difference($scope.calendarYearRange, allUsedCalendarYearsForCostType);
        //var relevantCostTypeIDs = $scope.getRelevantCostTypeIDs();
        _.each(calendarYearsToAdd,
            function (calendarYear) {
                $scope.addCalendarYearNoFundingSourceIdentifiedRow($scope.AngularViewData.ProjectID, calendarYear, costTypeID);
                
            });
        var noFundingForACostType = _.filter($scope.AngularModel.NoFundingSourceAmounts, function (fundingSourceAmount) { return fundingSourceAmount.CostTypeID == costTypeID });
        return noFundingForACostType;
    };

    $scope.addCalendarYearNoFundingSourceIdentifiedRow = function (projectId, calendarYear, costTypeID) {
        if ($scope.AngularModel.NoFundingSourceAmounts == null) {
            $scope.AngularModel.NoFundingSourceAmounts = [];
        }
        $scope.AngularModel.NoFundingSourceAmounts.push($scope.createNewCalendarYearNoFundingIdentifiedRow(calendarYear, costTypeID));
    };

    $scope.createNewCalendarYearNoFundingIdentifiedRow = function (calendarYear, costTypeID) {
        return {
            CalendarYear: calendarYear,
            CostTypeID: costTypeID,
            MonetaryAmount: 0
        };
    };

    $scope.getCalendarYearNoFundingSourceIdentifieds = function () {
        var projectNoFundingSourceIdentifieds = $scope.AngularModel.NoFundingSourceIdentifieds;
        return projectNoFundingSourceIdentifieds.CalendarYearNoFundingSourceIdentifieds;
    };

    $scope.setNoFundingSourceIdentifiedSameEachYear = function () {
        $scope.noFundingSourceIdentifiedSameEachYear = $scope.AngularModel.NoFundingSourceIdentifiedYet
            ? { Value: $scope.AngularModel.NoFundingSourceIdentifiedYet }
            : { Value: 0 };
    }

    $scope.fundingTypes = function () {
        return $scope.AngularViewData.FundingTypes;
    };

    $scope.budgetVariesByYear = function () {
        var selectedFundingTypeID = typeof $scope.selectedFundingTypeID === "number"
            ? $scope.selectedFundingTypeID
            : parseInt($scope.selectedFundingTypeID);
        return selectedFundingTypeID === 1;
    };

    $scope.budgetSameEachYear = function () {
        var selectedFundingTypeID = typeof $scope.selectedFundingTypeID === "number"
            ? $scope.selectedFundingTypeID
            : parseInt($scope.selectedFundingTypeID);
        return selectedFundingTypeID === 2;
    };

    $scope.budgetTypeNotSelected = function () {
        return !$scope.budgetVariesByYear() && !$scope.budgetSameEachYear();
    };

    $scope.shouldShowFundingSources = function () {
        return $scope.getAllUsedFundingSourceIds().length > 0 && $scope.getRelevantCostTypes().length > 0;
    }

    $scope.getAllUsedCalendarYearsNoFundingSourceIdentifieds = function () { return _($scope.AngularModel.NoFundingSourceAmounts).map("CalendarYear").flatten().union().sortBy().value(); };

    $scope.getAllUsedCalendarYearsNoFundingSourceIdentifiedsByCostType = function (costType) {
        var noFundingSourceAmountByCostType = _.filter($scope.AngularModel.NoFundingSourceAmounts, function (nfsa) { return nfsa.CostTypeID == costType.CostTypeID });
        return _(noFundingSourceAmountByCostType).map("CalendarYear").flatten().union().sortBy().value();
    };

    $scope.calendarYearRange = _.sortBy(_.union($scope.getAllCalendarYearBudgetsAsFlattenedLoDashArray().map("CalendarYear").flatten().union().value(), $scope.getAllUsedCalendarYearsNoFundingSourceIdentifieds(), $scope.AngularViewData.RequiredCalendarYearRange));
    $scope.resetfundingSourceIDToAdd();

    $scope.setSelectedFundingTypeID();
    $scope.setNoFundingSourceIdentifiedSameEachYear();
});

