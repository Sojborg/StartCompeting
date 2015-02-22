app.controller('NewRaceController', function($scope, raceService, $routeParams, $location) {

    $scope.formData = {
    };

    $scope.loadRaceById = function (id) {
        raceService.loadRaceById(id).then(function (data) {
            $scope.formData = data;
        });
    }

    $scope.loadRaceTypes = function () {
        raceService.loadRaceTypes().then(function (data) {
            $scope.raceTypes = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });

    }

    $scope.submit = function () {
        if ($scope.formData.id == undefined || $scope.formData.id == 0)
            raceService.createRace($scope.formData).then(function (data) {
                if (data) {
                    $scope.resetWorkout();
                }
            });
        else {

            raceService.updateRace($scope.formData).then(function (data) {
                if (data) {
                    $scope.resetWorkout();
                }
            });
        }
    };

    $scope.resetWorkout = function () {
        $location.path('/races');
    }

    var raceId = $routeParams.raceId;
    $scope.loadRaceTypes();
    if (raceId !== undefined && raceId != 0)
        $scope.loadRaceById(raceId);

    $scope.cancel = function () {
        $location.path('/races');
    };

});