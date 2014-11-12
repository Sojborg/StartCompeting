app.controller('WorkoutController', function($scope, $http, $modal, workoutService) {

    $scope.open = function (workoutId) {
        
        var modalInstance = $modal.open({
            templateUrl: 'app/workout/workout-modal.html',
            controller: 'ModalInstanceCtrl',
            size: '',
            resolve: {
                workoutId: function () {
                    return workoutId;
                }
            }
        });

        modalInstance.result.then(function () {
            $scope.loadWorkouts();
        }, function () {
            //$log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.loadWorkouts = function () {
        workoutService.loadWorkouts().then(function (data) {
            $scope.workouts = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });
    }

    $scope.loadWorkouts();
});