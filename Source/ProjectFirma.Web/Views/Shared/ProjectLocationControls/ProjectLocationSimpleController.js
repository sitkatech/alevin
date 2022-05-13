﻿angular.module("ProjectFirmaApp")
    .controller("ProjectLocationSimpleController",
        function ($scope, angularModelAndViewData) {
            $scope.AngularModel = angularModelAndViewData.AngularModel;
            $scope.AngularViewData = angularModelAndViewData.AngularViewData;
            $scope.hasGeospatialAreaTypeLayers = $scope.AngularViewData.GeospatialAreaMapServiceLayerNames.length > 0;
            $scope.GeospatialAreaMapServiceLayerNamesCommaSeparated =
                $scope.AngularViewData.GeospatialAreaMapServiceLayerNames.join(",");


            $scope.selectedStyle = {
                fillColor: "#FFFF00",
                fill: true,
                fillOpacity: 0.2,
                color: "#FFFF00",
                weight: 5,
                stroke: true
            };

            $scope.unselectedStyle = {
                fillColor: "#405d74",
                fill: true,
                fillOpacity: 0.2,
                color: "#405d74",
                weight: 1,
                stroke: true
            };

            $scope.toggleMap = function () {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    document.getElementById($scope.AngularViewData.MapInitJson.MapDivID).style.cursor = "crosshair";
                    $scope.projectLocationMap.unblockMap();
                    $scope.projectLocationMap.map.scrollWheelZoom.enable();

                    if ($scope.projectLocationMap.currentSelectedPoint) {
                        $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedPoint);
                    }

                    if ($scope.projectLocationMap.currentSelectedGeometry) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedGeometry);
                    }
                    break;
                case "LatLngInput":
                    document.getElementById($scope.AngularViewData.MapInitJson.MapDivID).style.cursor = "default";
                    $scope.projectLocationMap.unblockMap();
                    $scope.projectLocationMap.map.scrollWheelZoom.enable();
                    if ($scope.projectLocationMap.currentSelectedPoint) {
                        $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedPoint);
                        $scope.AngularModel.ProjectLocationPointX = L.Util.formatNum($scope.projectLocationMap.currentSelectedPoint._latlng.lng);
                        $scope.AngularModel.ProjectLocationPointY = L.Util.formatNum($scope.projectLocationMap.currentSelectedPoint._latlng.lat);
                    }

                    if ($scope.projectLocationMap.currentSelectedGeometry) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedGeometry);
                    }
                    break;
                case "None":
                    document.getElementById($scope.AngularViewData.MapInitJson.MapDivID).style.cursor = "default";
                    $scope.projectLocationMap.map.scrollWheelZoom.disable();

                    if ($scope.projectLocationMap.currentSelectedPoint) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedPoint);
                    }

                    if ($scope.projectLocationMap.currentSelectedGeometry) {
                        $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedGeometry);
                    }
                    $scope.projectLocationMap.blockMap();
                    break;
                }
            };

            $scope.changedLatLngInput = function () {
                if (isNaN($scope.AngularModel.ProjectLocationPointY) || isNaN($scope.AngularModel.ProjectLocationPointX) || $scope.AngularModel.ProjectLocationPointY.toString().slice(-1) === "." || $scope.AngularModel.ProjectLocationPointX.toString().slice(-1) === ".") {
                    return;
                }
                // if either the lat or lng are falsy we should remove the selected point from the map
                if ((!$scope.AngularModel.ProjectLocationPointY || !$scope.AngularModel.ProjectLocationPointX) && $scope.projectLocationMap.currentSelectedPoint) {
                    $scope.projectLocationMap.map.removeLayer($scope.projectLocationMap.currentSelectedPoint);
                    return;
                }

                var latlng = new L.LatLng($scope.AngularModel.ProjectLocationPointY, $scope.AngularModel.ProjectLocationPointX);

                // if we haven't returned (the lat lng numbers look good enough for the setPointOnMap function) we can set the point on the map
                setPointOnMap(latlng);
            }

            $scope.checkInputsForDegreeMinutes = function() {
                var regex = /(-*)*(\d*)[° ] *(\d*)[' ] *(\d*\.?\d*)["]? *([NnSsEeWw])?/; // https://regex101.com/r/rH0JLy/3

                if ($scope.AngularModel.ProjectLocationPointY) {
                    var latMatch = $scope.AngularModel.ProjectLocationPointY.toString().match(regex);
                    if (latMatch) {
                        var latDegrees = parseFloat(latMatch[2]);
                        var latMinutes = parseFloat(latMatch[3]);
                        var latSeconds = parseFloat(latMatch[4]);
                        var latIsNegative = (latMatch[5] && latMatch[5].toLowerCase() === "s" ) || latMatch[1] === "-";
                        var latDecimalValue = latDegrees + (latMinutes / 60) + (latSeconds / 3600);
                        $scope.AngularModel.ProjectLocationPointY = latIsNegative ? -latDecimalValue : latDecimalValue;
                        $scope.changedLatLngInput();
                    }
                }

                if ($scope.AngularModel.ProjectLocationPointX) {
                    var lonMatch = $scope.AngularModel.ProjectLocationPointX.toString().match(regex);
                    if (lonMatch) {
                        var lonDegrees = parseFloat(lonMatch[2]);
                        var lonMinutes = parseFloat(lonMatch[3]);
                        var lonSeconds = parseFloat(lonMatch[4]);
                        var lonIsNegative = (lonMatch[5] && lonMatch[5].toLowerCase() === "w") || lonMatch[1] === "-";
                        var lonDecimalValue = lonDegrees + (lonMinutes / 60) + (lonSeconds / 3600);
                        $scope.AngularModel.ProjectLocationPointX = lonIsNegative ? -lonDecimalValue : lonDecimalValue;
                        $scope.changedLatLngInput();
                    }
                }
            }

            function onMapClick(event) {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    onMapClickSetPointOnMap(event,
                        function() {
                            $scope.$apply();
                        });
                    break;
                case "LatLngInput":
                case "None": // Do nothing
                    break;
                }
            }

            function onMapClickSetPointOnMap(event, callback) {
                var latlng = event.latlng;
                var latlngWrapped = latlng.wrap();

                var propertiesForDisplay = {
                    Latitude: L.Util.formatNum(latlngWrapped.lat, 4),
                    Longitude: L.Util.formatNum(latlngWrapped.lng, 4)
                };

                setPointOnMap(latlng);
                $scope.propertiesForPointOnMap = propertiesForDisplay;
                if (callback) {
                    callback.call();
                }
            }

            function setPointOnMap(latlng) {
                if ($scope.AngularModel.ProjectLocationSimpleType === "PointOnMap") {
                    $scope.AngularModel.ProjectLocationPointX = L.Util.formatNum(latlng.lng);
                    $scope.AngularModel.ProjectLocationPointY = L.Util.formatNum(latlng.lat);
                }

                if ($scope.projectLocationMap.currentSelectedPoint) {
                    $scope.projectLocationMap.map.removeLayer(
                        $scope.projectLocationMap.currentSelectedPoint);
                }

                $scope.projectLocationMap.currentSelectedPoint = L.marker(latlng,
                    {
                        icon: L.MakiMarkers.icon({
                            icon: "marker",
                            color: $scope.selectedStyle.color,
                            size: "m"
                        })
                    });
               
                $scope.projectLocationMap.map.addLayer($scope.projectLocationMap.currentSelectedPoint);
                $scope.projectLocationMap.map.panTo(latlng);

                var latlngWrapped = latlng.wrap();
                $scope.propertiesForPointOnMap = {
                    Latitude: L.Util.formatNum(latlngWrapped.lat, 4),
                    Longitude: L.Util.formatNum(latlngWrapped.lng, 4)
                };
            }

            $scope.getProjectLocationProperties = function() {
                switch ($scope.AngularModel.ProjectLocationSimpleType) {
                case "PointOnMap":
                    return $scope.propertiesForPointOnMap;
                case "LatLngInput":
                case "None": // Do nothing
                    break;
                }
                return null;
            };

            $scope.displayLatLngInputs = function() {
                return ($scope.AngularModel.ProjectLocationSimpleType === "LatLngInput");
            }

            ProjectFirmaMaps.Map.prototype.handleWmsPopupClickEventWithCurrentLayer  = function() {
                // Override parent to do nothing
                return function () { };
            };

            var initializeMap = function () {
                $scope.projectLocationMap = new ProjectFirmaMaps.Map($scope.AngularViewData.MapInitJson);
                $scope.projectLocationMap.map.on("click", onMapClick);

                if ($scope.AngularViewData.CurrentFeature) {
                    // ReSharper disable once InconsistentNaming
                    $scope.projectLocationMap.currentSelectedGeometry = new L.geoJSON(
                        $scope.AngularViewData.CurrentFeature,
                        {
                            style: function() {
                                return $scope.selectedStyle;
                            }
                        });

                    $scope.propertiesForNamedArea = {};
                    $scope.propertiesForNamedArea[$scope.AngularViewData.GeospatialAreaFieldDefinitionLabel] = $scope.AngularViewData.InitialGeospatialAreaName;
                }

                if ($scope.AngularModel.ProjectLocationPointX && $scope.AngularModel.ProjectLocationPointY) {
                    var latlng = new L.LatLng($scope.AngularModel.ProjectLocationPointY, $scope.AngularModel.ProjectLocationPointX);
                    var latlngWrapped = latlng.wrap();
                    $scope.projectLocationMap.currentSelectedPoint = L.marker(latlng, { icon: L.MakiMarkers.icon({ icon: "marker", color: $scope.selectedStyle.color, size: "m" }) });
                    // set the point on the map if it is initialized with data
                    setPointOnMap(latlng);

                    $scope.propertiesForPointOnMap = {
                        Latitude: L.Util.formatNum(latlngWrapped.lat, 4),
                        Longitude: L.Util.formatNum(latlngWrapped.lng, 4)
                    };

                    // 7/29/2019 SMG & TK: Added setTimeout so map pans to lat lng when opening modal dialog, for some reason without setTimeout the map does not pan
                    setTimeout(function () {
                        $scope.projectLocationMap.map.panTo(latlng);
                    }, 1);
                }
            };

            initializeMap();
            $scope.toggleMap();
        });
