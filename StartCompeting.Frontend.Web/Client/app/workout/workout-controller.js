app.controller('WorkoutController', function($scope, $http, workoutService, $location) {

    $scope.orderByField = 'start';
    $scope.reverseSort = false;

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

    $scope.onReorder = function (order) {
        getDesserts(angular.extend({}, $scope.query, { order: order }));
    };

    $scope.loadWorkouts();
});