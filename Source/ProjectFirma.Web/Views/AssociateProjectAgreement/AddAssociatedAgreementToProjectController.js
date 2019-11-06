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
angular.module("ProjectFirmaApp").controller("AddAssociatedAgreementToProjectController", function($scope,
    angularModelAndViewData) {
    $scope.AngularModel = angularModelAndViewData.AngularModel;
    $scope.AngularViewData = angularModelAndViewData.AngularViewData;

    $scope.$watch(function () {
        jQuery('.selectpicker').selectpicker('refresh');
        // so that unsavedChanges.js knows to check if the form has changed.
        jQuery("form").trigger("input");
    });

    $scope.$watch('selectedAgreementID',
        function (newValue, oldValue, scope) {
            if (newValue != oldValue) {
                scope.ReclamationCostAuthorityOptions = scope.getOptionsForCostAuthoritiesDropdown();
                scope.selectedCostAuthorityID = 0;
            }
        });


    $scope.selectedAgreementID = 0;
    $scope.selectedCostAuthorityID = 0;

    $scope.ReclamationAgreementOptions = $scope.AngularViewData.AllReclamationAgreements;
    $scope.ReclamationCostAuthorityOptions = [];

    



    $scope.getOptionsForCostAuthoritiesDropdown = function () {

        var costAuthorities = $scope.AngularViewData.AllReclamationCostAuthorities.slice(0);
        var agreements = $scope.AngularViewData.AllReclamationAgreements.slice(0);


        var selectedAgreement = _.find(agreements,
            function(agreement) {
                return agreement.ReclamationAgreementID == $scope.selectedAgreementID;
            });

        if (!selectedAgreement) {
            return [];
        }


        var costAuthoritiesInAgreement = _.filter(costAuthorities, function (costAuthority) {

            var costAuthorityIdList = selectedAgreement.ReclamationCostAuthorityIDList;

            return costAuthorityIdList.includes(costAuthority.ReclamationCostAuthorityID);
        });

        return costAuthoritiesInAgreement;
    }


    $scope.addProjectContactSimple = function(contactID, relationshipTypeID) {
        $scope.AngularModel.ProjectContactSimples.push({
            ContactID: Number(contactID),
            ContactRelationshipTypeID: relationshipTypeID
        });
        $scope.resetSelectedContactID(relationshipTypeID);
    };

    $scope.removeProjectContactSimple = function (contactID, relationshipTypeID) {
        _.remove($scope.AngularModel.ProjectContactSimples,
            function(pos) {
                return pos.ContactID == contactID && pos.ContactRelationshipTypeID == relationshipTypeID;
            });
    };

   


});
