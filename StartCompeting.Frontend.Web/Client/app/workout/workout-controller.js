app.controller('WorkoutController', function($scope, $http, workoutService, $location) {

    $scope.open = function (workoutId) {
        
        //var modalInstance = $modal.open({
        //    templateUrl: 'Client/app/workout/workout-modal.html',
        //    controller: 'ModalInstanceCtrl',
        //    size: '',
        //    resolve: {
        //        workoutId: function () {
        //            return workoutId;
        //        }
        //    }
        //});

        //modalInstance.result.then(function () {
        //    $scope.loadWorkouts();
        //}, function () {
        //    //$log.info('Modal dismissed at: ' + new Date());
        //});
    };

    $scope.loadWorkouts = function () {
        workoutService.loadWorkouts().then(function (data) {
            $scope.workouts = data;
        },
        function (errorMessage) {
            $scope.error = errorMessage;
        });
    }

    $scope.newWorkout = function() {
        $location.path('/newworkout');
    }

    $scope.loadWorkouts();
});