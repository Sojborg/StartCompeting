app.controller('LeagueModalCtrl', function($scope, $modalInstance, leagueService, leagueId) {

    $scope.formData = {
    };

    $scope.loadLeagueById = function (id) {
        leagueService.loadLeagueById(id).then(function (data) {
            $scope.formData = data;
        });
    }

    $scope.loadLeagueTypes = function () {
        leagueService.loadLeagueTypes().then(function (data) {
            $scope.leagueTypes = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });

    }

    $scope.submit = function () {
        if ($scope.formData.id == undefined || $scope.formData.id == 0)
            leagueService.createLeague($scope.formData).then(function (data) {
                if (data) {
                    $scope.resetWorkout();
                }
            });
        else {

            leagueService.updateLeague($scope.formData).then(function (data) {
                if (data) {
                    $scope.resetWorkout();
                }
            });
        }
    };

    $scope.resetWorkout = function () {
        //$scope.workoutform.$setPristine();
        $modalInstance.close();
    }

    $scope.loadLeagueTypes();
    if (leagueId !== undefined && leagueId != 0)
        $scope.loadLeagueById(leagueId);

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

});