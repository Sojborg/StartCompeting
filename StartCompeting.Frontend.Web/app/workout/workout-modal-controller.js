app.controller('ModalInstanceCtrl', function ($scope, $modalInstance, workoutService, workoutId) {

    $scope.formData = {
    };

    $scope.getWorkout = function (id) {
        workoutService.loadWorkoutById(id).then(function (data) {
            $scope.formData = data;
        });
    };

    $scope.submit = function () {
        if ($scope.formData.id == undefined || $scope.formData.id == 0)
            workoutService.createWorkout($scope.formData).then(function (data) {
                if (data) {
                    $scope.resetWorkout();
                }
            });
        else {

            workoutService.updateWorkout($scope.formData).then(function (data) {
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

    $scope.loadRaceTypes = function () {
        workoutService.loadRaceTypes().then(function (data) {
            $scope.raceTypes = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });

    }

    $scope.loadRaceTypes();
    if (workoutId !== undefined && workoutId != 0)
        $scope.getWorkout(workoutId);

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});