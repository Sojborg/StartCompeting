﻿app.controller('RaceController', function($scope, $http, raceService, $location) {

    loadRaces();

    $scope.formData = {

    };

    $scope.getters = {
        Name: function (value) {
            //this will sort by the length of the first name string
            return value.Name.length;
        }
    }

    $scope.open = function (raceId) {

        //var modalInstance = $modal.open({
        //    templateUrl: 'Client/app/race/race-modal.html',
        //    controller: 'RaceModalCtrl',
        //    size: '',
        //    resolve: {
        //        raceId: function () {
        //            return raceId;
        //        }
        //    }
        //});

        //modalInstance.result.then(function () {
        //    loadRaces();
        //}, function () {
        //    //$log.info('Modal dismissed at: ' + new Date());
        //});
    };

    $scope.submit = function () {
        if (FormData.id == 0)
            createRace($scope.formData);
        else
            updateRace($scope.formData);
    };

    $scope.getRace = function (id) {
        loadRaceById(id);
    };

    $scope.newRace = function () {
        $location.path('/newrace');
    }

    function loadRaces () {
        raceService.loadRaces().then(function (data) {
            $scope.races = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });
    }
});