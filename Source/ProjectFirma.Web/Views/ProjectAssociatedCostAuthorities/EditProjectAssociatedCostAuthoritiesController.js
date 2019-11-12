/*-----------------------------------------------------------------------
<copyright file="ProjectContactController.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
angular.module("ProjectFirmaApp").controller("EditProjectAssociatedCostAuthoritiesController", function($scope,
    angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;


    $scope.getSelectedCostAuthorities = function () {
        if ($scope.selectedCostAuthorityIDs.length == 0) {
            return [];
        }

        var selectedCostAuthorities = _.filter($scope.AngularViewData.AllReclamationCostAuthorities,
            function (costAuthority) {
                return $scope.selectedCostAuthorityIDs.includes(costAuthority.ReclamationCostAuthorityID.toString());
            });
        return selectedCostAuthorities;
    }


    $scope.selectedCostAuthorityIDs = $scope.AngularModel.SelectedReclamationCostAuthorityIDs.map(String);
    $scope.SelectedCostAuthorities = $scope.getSelectedCostAuthorities();

    $scope.$watch(function () {
        jQuery('.selectpicker').selectpicker('refresh');
        // so that unsavedChanges.js knows to check if the form has changed.
        jQuery("form").trigger("input");
    });

    $scope.$watch('selectedCostAuthorityIDs',
        function (newValue, oldValue, scope) {
           
            if (newValue != oldValue) {
                scope.SelectedCostAuthorities = scope.getSelectedCostAuthorities();
            }
        });

    $scope.isSelected = function (id) {
        var isSelected = $scope.selectedCostAuthorityIDs.includes(id.toString());
        return isSelected;
    }

    $scope.ReclamationCostAuthorityOptions = $scope.AngularViewData.AllReclamationCostAuthorities;

    $scope.removeCostAuthority = function (id) {
        var costAuthorityID = id.toString();
        var indexOfCostAuthorityID = $scope.selectedCostAuthorityIDs.indexOf(costAuthorityID);
        if (indexOfCostAuthorityID > -1) {
            $scope.selectedCostAuthorityIDs.splice(indexOfCostAuthorityID, 1);
        }
        $scope.SelectedCostAuthorities = $scope.getSelectedCostAuthorities();
    }



   


});
